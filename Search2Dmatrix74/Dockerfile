FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Search2Dmatrix74/Search2Dmatrix74.csproj", "Search2Dmatrix74/"]
RUN dotnet restore "Search2Dmatrix74/Search2Dmatrix74.csproj"
COPY . .
WORKDIR "/src/Search2Dmatrix74"
RUN dotnet build "Search2Dmatrix74.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Search2Dmatrix74.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Search2Dmatrix74.dll"]
