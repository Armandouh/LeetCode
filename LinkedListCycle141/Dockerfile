FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["LinkedListCycle141/LinkedListCycle141.csproj", "LinkedListCycle141/"]
RUN dotnet restore "LinkedListCycle141/LinkedListCycle141.csproj"
COPY . .
WORKDIR "/src/LinkedListCycle141"
RUN dotnet build "LinkedListCycle141.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "LinkedListCycle141.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LinkedListCycle141.dll"]
