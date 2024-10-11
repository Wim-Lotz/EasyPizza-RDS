FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

EXPOSE 80
#EXPOSE 443
ENV ASPNETCORE_HTTP_PORTS=80
#ENV ASPNETCORE_HTTPS_PORTS=443

COPY ["src/EasyPizza.API/EasyPizza.API.csproj", "EasyPizza.API/"]
COPY ["src/EasyPizza.Application/EasyPizza.Application.csproj", "EasyPizza.Application/"]
COPY ["src/EasyPizza.Domain/EasyPizza.Domain.csproj", "EasyPizza.Domain/"]
COPY ["src/EasyPizza.Contracts/EasyPizza.Contracts.csproj", "EasyPizza.Contracts/"]
COPY ["src/EasyPizza.Infrastructure/EasyPizza.Infrastructure.csproj", "EasyPizza.Infrastructure/"]
RUN dotnet restore "EasyPizza.API/EasyPizza.API.csproj"
COPY . ../
WORKDIR /src/EasyPizza.API
RUN dotnet build "EasyPizza.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish --no-restore -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
ENV ASPNETCORE_HTTP_PORTS=5001
EXPOSE 5001
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EasyPizza.API.dll"]