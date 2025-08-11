FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["bestTimeToBuy121/bestTimeToBuy121.csproj", "bestTimeToBuy121/"]
RUN dotnet restore "bestTimeToBuy121/bestTimeToBuy121.csproj"
COPY . .
WORKDIR "/src/bestTimeToBuy121"
RUN dotnet build "bestTimeToBuy121.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "bestTimeToBuy121.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "bestTimeToBuy121.dll"]
