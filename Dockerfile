FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy csproj files first (for better caching)
COPY *.sln .
COPY MyFirstCI.Api/*.csproj ./MyFirstCI.Api/
COPY MyFirstCI.Tests/*.csproj ./MyFirstCI.Tests/

RUN dotnet restore

# Copy everything else and build
COPY . .
RUN dotnet publish MyFirstCI.Api/MyFirstCI.Api.csproj -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/out .
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "MyFirstCI.Api.dll"]