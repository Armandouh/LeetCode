FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["keyboardRow500/keyboardRow500.csproj", "keyboardRow500/"]
RUN dotnet restore "keyboardRow500/keyboardRow500.csproj"
COPY . .
WORKDIR "/src/keyboardRow500"
RUN dotnet build "keyboardRow500.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "keyboardRow500.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "keyboardRow500.dll"]
