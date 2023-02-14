# Set the base image to the official .NET SDK 7 image
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

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
RUN dotnet build

# Expose port 80 for the application
EXPOSE 80

# Start the application
ENTRYPOINT ["/app/init"]
