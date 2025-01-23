ARG DOTNET_USE_POLLING_FILE_WATCHER=1
ARG ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Jambo.csproj", "./"]
RUN dotnet restore "Jambo.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "Jambo.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Jambo.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Jambo.dll"]