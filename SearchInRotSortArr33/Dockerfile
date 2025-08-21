FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SearchInRotSortArr33/SearchInRotSortArr33.csproj", "SearchInRotSortArr33/"]
RUN dotnet restore "SearchInRotSortArr33/SearchInRotSortArr33.csproj"
COPY . .
WORKDIR "/src/SearchInRotSortArr33"
RUN dotnet build "SearchInRotSortArr33.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "SearchInRotSortArr33.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SearchInRotSortArr33.dll"]
