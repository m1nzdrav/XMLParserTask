FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["XMLParser/XMLParser.csproj", "XMLParser/"]
RUN dotnet restore "XMLParser/XMLParser.csproj"
COPY . .
WORKDIR "/src/XMLParser"
RUN dotnet build "XMLParser.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "XMLParser.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "XMLParser.dll"]
