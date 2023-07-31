FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SierraTakeHome.API/SierraTakeHome.API.csproj", "SierraTakeHome.API/"]
COPY ["SierraTakeHome.Core/SierraTakeHome.Core.csproj", "SierraTakeHome.Core/"]
RUN dotnet restore "SierraTakeHome.API/SierraTakeHome.API.csproj"
COPY . .
WORKDIR "/src/SierraTakeHome.API"
RUN dotnet build "SierraTakeHome.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SierraTakeHome.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SierraTakeHome.API.dll"]