FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TimeBasedKeyVal981/TimeBasedKeyVal981.csproj", "TimeBasedKeyVal981/"]
RUN dotnet restore "TimeBasedKeyVal981/TimeBasedKeyVal981.csproj"
COPY . .
WORKDIR "/src/TimeBasedKeyVal981"
RUN dotnet build "TimeBasedKeyVal981.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "TimeBasedKeyVal981.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TimeBasedKeyVal981.dll"]
