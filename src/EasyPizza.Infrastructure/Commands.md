# Useful Commands

## Docker Commands
### Create Postgres Docker Image

docker run -d --name postgres -p 5432:5432 -e POSTGRES_PASSWORD=pizza postgres

### Build and Run Api Command
docker build -t easypizza.api .  
docker run --rm -p 8080:80 --name easy.api easypizza.api

## Entity Framework Migration Commands

* dotnet ef migrations add <migration-name> --project EasyPizza.Infrastructure --startup-project EasyPizza.Api
* dotnet ef database update --project EasyPizza.Infrastructure --startup-project EasyPizza.Api
* dotnet ef migrations remove --project EasyPizza.Infrastructure --startup-project EasyPizza.Api

### Rollback
dotnet ef database update <previous-migration-name> --project EasyPizza.Infrastructure --startup-project EasyPizza.Api

