FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["palindromicSubstring647/palindromicSubstring647.csproj", "palindromicSubstring647/"]
RUN dotnet restore "palindromicSubstring647/palindromicSubstring647.csproj"
COPY . .
WORKDIR "/src/palindromicSubstring647"
RUN dotnet build "palindromicSubstring647.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "palindromicSubstring647.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "palindromicSubstring647.dll"]
