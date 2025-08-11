FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["LongestConsSequence128/LongestConsSequence128.csproj", "LongestConsSequence128/"]
RUN dotnet restore "LongestConsSequence128/LongestConsSequence128.csproj"
COPY . .
WORKDIR "/src/LongestConsSequence128"
RUN dotnet build "LongestConsSequence128.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "LongestConsSequence128.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LongestConsSequence128.dll"]
