# Set the base image to the official .NET SDK 7 image
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Install Node.js
RUN curl -sL https://deb.nodesource.com/setup_16.x | bash -
RUN apt-get install -y nodejs



# Set the working directory to /app
WORKDIR /app
COPY app/init /app/init
RUN chmod +x /app/init
# Copy the project file into the container
COPY src/project-foodie.csproj .

# Restore NuGet packages
RUN dotnet restore

# Copy the rest of the project files into the container
COPY src/ .

# Build the project
RUN dotnet publish -c Release -o  /app/bin/release/project-foodie/
RUN ls -la /app/bin/release/project-foodie/
WORKDIR /app/bin/release/project-foodie/
RUN npm install
RUN npx postcss wwwroot/css/site.css -o wwwroot/css/site.css
RUN npx postcss wwwroot/css/project-foodie.styles.css -o wwwroot/css/project-foodie.styles.css
ENV DBADDR ${DBADDR}
ENV DBNAME ${DBNAME}
ENV DBUSER ${DBUSER}
ENV DBPASS ${DBPASS}
WORKDIR /app
# Start the application

ENTRYPOINT ["/app/init"]
