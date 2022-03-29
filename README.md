# Credit Card Validation Api
This repository contains the code for validation of credit card data through API build using ASP .NET Core 3.1
Credit Card Validation API build on .NET CORE 3.1 with following considerations.

  * ASP.NET CORE 3.1
  * Clean Architecture
  * Mediator Design Pattern
  * FLUENT VALIDATION
  * Swagger
  * XUNIT
  * Dependecy Injection
## Clean Architecture ##
![image](https://user-images.githubusercontent.com/30867046/160513236-4cfca4c6-b37b-4cf1-981a-3a7282149af5.png)
## Design Pattern ##
![image](https://user-images.githubusercontent.com/30867046/160513328-6965e68b-9678-470c-b562-65d4ad1b0a1c.png)

## Project Structure ##
  * CreditCardValidatorApi.Api
     * Contains Main Validate Function where api controller action coded.
  * CreditCardValidatorApi.Application
     *  Common
        * Validations Behaviour
     *  Features
        * Commands
           * ModelApi Interface
        * Dto
           * Contains Data Transfer Objects
        * Handlers
           * Unit of Work Maps DTO to cascade validation.
        * MappingProfiles
           * Commands->DTO.
        * Queries
        * Validators
           * Fluent Validator where rules defined
     *  Interfaces
           * ICardReporsitory
  * CreditCardValidatorApi.Core
    * Model Entites
  * CreditCardValidatorApi.Infrastructure
    * Advanced Valdiations for Card Details in case primary validation get succeded.
  * CreditCardValidatorApi.Test
    * XUnit Test for API  
## Models ##
  * Common
    * Error
    * Response
  * Card
## Enum ##
* Card Type
* Card Brand Name
## Rules and Validations ##
  * Rules has been defined using FluentAPI and rest validations handled by Regex expression which is in Infrastructur/Helper/Utilities folder
## Request From Swagger ##
![image](https://user-images.githubusercontent.com/30867046/160510721-f1b9bc78-9a11-449e-922d-f3a93b758f9a.png)
## Response From Swagger ##
![image](https://user-images.githubusercontent.com/30867046/160510818-800c0b4e-bd03-4bba-a2e3-32827ea9f0a8.png)
## Furthur Improvement
* Clean Architecture can be more improved.
* XUNIT using MOQS/Meditor can be used.
* Code Performance

