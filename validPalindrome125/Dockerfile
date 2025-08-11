FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["validPalindrome125/validPalindrome125.csproj", "validPalindrome125/"]
RUN dotnet restore "validPalindrome125/validPalindrome125.csproj"
COPY . .
WORKDIR "/src/validPalindrome125"
RUN dotnet build "validPalindrome125.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "validPalindrome125.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "validPalindrome125.dll"]
