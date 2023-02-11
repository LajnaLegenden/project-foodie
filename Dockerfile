FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/project-foodie.csproj", "."]
RUN dotnet restore "project-foodie.csproj"
COPY src .
RUN dotnet build "project-foodie.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "project-foodie.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
RUN mkdir -p ./data/foodie
COPY --from=publish /app/publish .
RUN dotnet ef database update --project src/project-foodie.csproj --startup-project src/project-foodie.csproj
ENTRYPOINT ["dotnet", "project-foodie.dll"]
