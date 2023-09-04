# Contacts Book

## Description

Simple application for managing person contacts. Users can create contacts with some details, then add addresses to them. One contact can have 0 or multiple addresses.

Note: The purpose of this project is only to demonstrate the used technologies and patterns. Some of the functionalities are not completed, but as a whole the main features are implemented.

## Backend

1. Frameworks and libraries used:

- .NET 7
- ASP Web API
- FluentValidation
- AutoMapper
- MediatR
- EntityFramework
- Swagger Open API

1. Architecture

   Considering the requirements to use FluentValidation, CQRS Pattern and rich domain models, I've used clean architecture with DDD approach.

   ![alt](https://miro.medium.com/v2/resize:fit:719/1*ZNT5apOxDzGrTKUJQAIcvg.png)

   In this project the above diagram is a bit simplified.
   ![alt](./resources/server-solution.PNG)

   In the center we have the domain layer `ContactsBook.Domain`. It is independent from the other projects and encapsulates the domain logic.

   The Application layer has access to the domain layer and is responsible for processing the CQRS operations.

   The actual database operations are managed in the infrastructure layer. This layer communicates with the database.

   Here is a high level diagram
   ![alt](./resources/architecture.png)

   ## Frontend
