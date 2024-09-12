FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
#EXPOSE 443
ENV ASPNETCORE_HTTP_PORTS=80
#ENV ASPNETCORE_HTTPS_PORTS=443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["EasyPizza.API/EasyPizza.API.csproj", "EasyPizza.API/"]
RUN dotnet restore "EasyPizza.API/EasyPizza.API.csproj"
COPY . .
WORKDIR "/src/EasyPizza.API"
RUN dotnet build "EasyPizza.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EasyPizza.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EasyPizza.API.dll"]
