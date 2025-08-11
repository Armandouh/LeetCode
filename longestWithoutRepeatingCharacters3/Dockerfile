FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["longestWithoutRepeatingCharacters3/longestWithoutRepeatingCharacters3.csproj", "longestWithoutRepeatingCharacters3/"]
RUN dotnet restore "longestWithoutRepeatingCharacters3/longestWithoutRepeatingCharacters3.csproj"
COPY . .
WORKDIR "/src/longestWithoutRepeatingCharacters3"
RUN dotnet build "longestWithoutRepeatingCharacters3.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "longestWithoutRepeatingCharacters3.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "longestWithoutRepeatingCharacters3.dll"]
