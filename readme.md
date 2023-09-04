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

   The following frameworks and libraries have been used:

   - Angular 16
   - PrimeNG
   - ngrx

On the home page the list of contacts is shown.

![alt](./resources/home.png)

To create new contact click on the `Add Contact` button.
![alt](./resources/add-contact-btn.png)

The create contact dialog will be shown

![alt](./resources/add-contact-dialog.png)

Fill in the form
![alt](./resources/create-contact-fill-form.png)

After submit, a success message is shown and the new contact is added to the list of contacts

![alt](./resources/create-contact-success.png)

To edit the contact click on the edit button

![alt](./resources/edit-contact-btn.png)

The contact details page will show

![alt](./resources/contact-details-empty.png)

From the details page users can edit the contact or add/remove addresses

To create new address fill in the address form and click the `+` button

![alt](./resources/create-address-form.png)

The new address is added to the details page and the contacts list page

![alt](./resources/address-created.png)

From the details page the address can be deleted.
The address editing is not implemented at this point as it's pretty much the same as the contacts editing.

# E2E tests

Several test scenarios are written in cypress.
There are some simple tests to verify links and pages open.
One test for contact creation which verifies that the contact is created. The created contact is cleaned in the end.

![alt](./resources/cypress-tests.png)
