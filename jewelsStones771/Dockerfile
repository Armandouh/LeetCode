FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["jewelsStones771/jewelsStones771.csproj", "jewelsStones771/"]
RUN dotnet restore "jewelsStones771/jewelsStones771.csproj"
COPY . .
WORKDIR "/src/jewelsStones771"
RUN dotnet build "jewelsStones771.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "jewelsStones771.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "jewelsStones771.dll"]
