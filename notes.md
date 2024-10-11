choices made

architecture
clean architecture

technologies used
postgres
entity framework
mediatr
fluent validation
docker

things I dont like
use exceptions for validation (using exceptions as I am using mediatr so need the thread return as I cant return to calling method)


docker commands:
docker build -t easypizza.api .
docker run -p 8080:80 --name easy.api easy.api 