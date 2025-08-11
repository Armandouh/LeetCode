FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["productOfArrayExceptSelf238/productOfArrayExceptSelf238.csproj", "productOfArrayExceptSelf238/"]
RUN dotnet restore "productOfArrayExceptSelf238/productOfArrayExceptSelf238.csproj"
COPY . .
WORKDIR "/src/productOfArrayExceptSelf238"
RUN dotnet build "productOfArrayExceptSelf238.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "productOfArrayExceptSelf238.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "productOfArrayExceptSelf238.dll"]
