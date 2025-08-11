FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["encodeDecode271/encodeDecode271.csproj", "encodeDecode271/"]
RUN dotnet restore "encodeDecode271/encodeDecode271.csproj"
COPY . .
WORKDIR "/src/encodeDecode271"
RUN dotnet build "encodeDecode271.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "encodeDecode271.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "encodeDecode271.dll"]
