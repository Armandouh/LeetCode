FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["anagramGroups49/anagramGroups49.csproj", "anagramGroups49/"]
RUN dotnet restore "anagramGroups49/anagramGroups49.csproj"
COPY . .
WORKDIR "/src/anagramGroups49"
RUN dotnet build "anagramGroups49.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "anagramGroups49.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "anagramGroups49.dll"]
