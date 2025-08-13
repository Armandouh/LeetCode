FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BinarySearch704/BinarySearch704.csproj", "BinarySearch704/"]
RUN dotnet restore "BinarySearch704/BinarySearch704.csproj"
COPY . .
WORKDIR "/src/BinarySearch704"
RUN dotnet build "BinarySearch704.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "BinarySearch704.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BinarySearch704.dll"]
