FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["twoSum2_167/twoSum2_167.csproj", "twoSum2_167/"]
RUN dotnet restore "twoSum2_167/twoSum2_167.csproj"
COPY . .
WORKDIR "/src/twoSum2_167"
RUN dotnet build "twoSum2_167.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "twoSum2_167.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "twoSum2_167.dll"]
