FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MedianOfTwoSortArrs4/MedianOfTwoSortArrs4.csproj", "MedianOfTwoSortArrs4/"]
RUN dotnet restore "MedianOfTwoSortArrs4/MedianOfTwoSortArrs4.csproj"
COPY . .
WORKDIR "/src/MedianOfTwoSortArrs4"
RUN dotnet build "MedianOfTwoSortArrs4.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MedianOfTwoSortArrs4.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MedianOfTwoSortArrs4.dll"]
