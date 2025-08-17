FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["KokoEatingBananas875/KokoEatingBananas875.csproj", "KokoEatingBananas875/"]
RUN dotnet restore "KokoEatingBananas875/KokoEatingBananas875.csproj"
COPY . .
WORKDIR "/src/KokoEatingBananas875"
RUN dotnet build "KokoEatingBananas875.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "KokoEatingBananas875.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KokoEatingBananas875.dll"]
