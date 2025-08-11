FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["FirstOccurance28/FirstOccurance28.csproj", "FirstOccurance28/"]
RUN dotnet restore "FirstOccurance28/FirstOccurance28.csproj"
COPY . .
WORKDIR "/src/FirstOccurance28"
RUN dotnet build "FirstOccurance28.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "FirstOccurance28.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FirstOccurance28.dll"]
