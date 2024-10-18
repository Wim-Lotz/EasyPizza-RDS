FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/EasyPizza.Api/EasyPizza.Api.csproj", "src/EasyPizza.Api/"]
COPY ["src/EasyPizza.Application/EasyPizza.Application.csproj", "src/EasyPizza.Application/"]
COPY ["src/EasyPizza.Domain/EasyPizza.Domain.csproj", "src/EasyPizza.Domain/"]
COPY ["src/EasyPizza.Contracts/EasyPizza.Contracts.csproj", "src/EasyPizza.Contracts/"]
COPY ["src/EasyPizza.Infrastructure/EasyPizza.Infrastructure.csproj", "src/EasyPizza.Infrastructure/"]
RUN dotnet restore "src/EasyPizza.Api/EasyPizza.Api.csproj"
COPY . .
WORKDIR "/src/src/EasyPizza.Api"
RUN dotnet build "EasyPizza.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "EasyPizza.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EasyPizza.Api.dll"]
