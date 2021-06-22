# FluentValidation POC
 Trying out FluentValidation\
 Here's the validator implementation
 [ArticleValidator](FluentValidationPOC/Shared/Validators/ArticleValidator.cs)
 
## Test using ConsoleApp
`dotnet run --project ConsoleApp/ConsoleApp.csproj`

## Test using Blazor WebAssembly
Dependencies
- [MudBlazor](https://mudblazor.com/)
- [Blazored FluentValidation](https://github.com/Blazored/FluentValidation)

### Example using Blazor
 1. Start the site
`dotnet run --project FluentValidationPOC/Server/FluentValidationPOC.Server.csproj`

 2. Browse [http://localhost:5000/](http://localhost:5000/)
