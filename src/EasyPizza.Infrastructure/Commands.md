# Useful Commands

## Create Postgres Docker Image

docker run -d --name postgres -p 5432:5432 -e POSTGRES_PASSWORD=pizza postgres

## Migration Commands

* dotnet ef migrations add <migration-name> --project EasyPizza.Infrastructure --startup-project EasyPizza.Api
* dotnet ef database update --project EasyPizza.Infrastructure --startup-project EasyPizza.Api
* dotnet ef migrations remove --project EasyPizza.Infrastructure --startup-project EasyPizza.Api

## Rollback
dotnet ef database update <previous-migration-name> --project EasyPizza.Infrastructure --startup-project EasyPizza.Api
