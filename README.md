# projects-service

[![Build Status](https://travis-ci.org/mike-trout/projects-service.svg?branch=master)](https://travis-ci.org/mike-trout/projects-service)

Microservice written in C# and using the ASP.NET Core framework that models my personal software engineering projects.

`dotnet restore` and `dotnet run` to run locally.

`docker build --tag projects-service .` and `docker run -d -p 50001:50001 --name projects-service projects-service` to build and run the Docker container locally.

`curl -i -H 'Accept: application/json' http://localhost:50001/api/projects` to get the projects collection.

`curl -i -H 'Accept: application/json' http://localhost:50001/api/projects/1` to get a project by ID.
