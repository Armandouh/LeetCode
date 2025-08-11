FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["HappyNumber202/HappyNumber202.csproj", "HappyNumber202/"]
RUN dotnet restore "HappyNumber202/HappyNumber202.csproj"
COPY . .
WORKDIR "/src/HappyNumber202"
RUN dotnet build "HappyNumber202.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "HappyNumber202.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HappyNumber202.dll"]
