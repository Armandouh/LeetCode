FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["stringPermutation567/stringPermutation567.csproj", "stringPermutation567/"]
RUN dotnet restore "stringPermutation567/stringPermutation567.csproj"
COPY . .
WORKDIR "/src/stringPermutation567"
RUN dotnet build "stringPermutation567.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "stringPermutation567.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "stringPermutation567.dll"]
