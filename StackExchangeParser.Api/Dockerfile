FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["StackExchangeParser.Api/StackExchangeParser.Api.csproj", "StackExchangeParser.Api/"]
RUN dotnet restore "StackExchangeParser.Api/StackExchangeParser.Api.csproj"
COPY . .
WORKDIR "/src/StackExchangeParser.Api"
RUN dotnet build "StackExchangeParser.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "StackExchangeParser.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "StackExchangeParser.Api.dll"]