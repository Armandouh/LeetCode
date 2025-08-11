FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["LargestRectHist84/LargestRectHist84.csproj", "LargestRectHist84/"]
RUN dotnet restore "LargestRectHist84/LargestRectHist84.csproj"
COPY . .
WORKDIR "/src/LargestRectHist84"
RUN dotnet build "LargestRectHist84.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "LargestRectHist84.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LargestRectHist84.dll"]
