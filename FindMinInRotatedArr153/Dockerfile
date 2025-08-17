FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["FindMinInRotatedArr153/FindMinInRotatedArr153.csproj", "FindMinInRotatedArr153/"]
RUN dotnet restore "FindMinInRotatedArr153/FindMinInRotatedArr153.csproj"
COPY . .
WORKDIR "/src/FindMinInRotatedArr153"
RUN dotnet build "FindMinInRotatedArr153.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "FindMinInRotatedArr153.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FindMinInRotatedArr153.dll"]
