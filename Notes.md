# Decisions Made

## Architecture
* Clean Architecture

## Technologies Used
* Postgres
* Entity Framework
* Mediatr
* Fluent Validation
* Docker

## Features
* Caching
* Filtering
* Pagination
* Sorting
* Validation
* Api Versioning
* Swagger
* Authentication (simple token creation) and Authorization
* Health Checks
* Docker Compose Orchestration
* Http Files
* Insomnia Api Tester Json Import

#### Things I dont like
using exceptions for validation (using exceptions as I am using mediatr, so I need the thread return as I cant return to calling method)


