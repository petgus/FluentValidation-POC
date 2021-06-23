using ConsoleTableExt;
using FluentValidation;
using FluentValidation.Results;
using FluentValidationPOC.Shared.Models;
using FluentValidationPOC.Shared.Validators.ArticleValidators;
using FluentValidationPOC.Shared.Validators.UserValidators;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*-* Fluent Validation DEMO *-*");

            //CultureInfo.CurrentUICulture = new CultureInfo("sv-SE");

            ValidateArticles();
            ValidateUsers();

            Console.Write("\n\n\n\n\n\n\n\n\n\n");
        }



        private static void ValidateArticles()
        {
            // Switch Validator implementation by commenting out validators here...
            //var articleValidator = new SimpleArticleValidator();
            var articleValidator = new ArticleValidator();



            Article article1 = new();


            Article article2 = new()
            {
                ArticleNumber = "123",
                Status = ArticleStatus.ReadyForWeb
            };


            Article article3 = new()
            {
                ArticleNumber = "1234-123-1234",
                Name = "Artikel 3",
                Status = ArticleStatus.ReadyForWeb
            };


            Article article4 = new()
            {
                Status = ArticleStatus.ReadyForWeb
            };


            ValidateAndPrintResult( articleValidator.Validate(article1), article1 );
            ValidateAndPrintResult( articleValidator.Validate(article2), article2 );
            ValidateAndPrintResult( articleValidator.Validate(article3), article3 );
            ValidateAndPrintResult( articleValidator.Validate(article4), article4 );
        }



        private static void ValidateUsers()
        {
            var userValidator = new UserValidator();
            User user = new()
            {
                Username = "username",
                Password = null,
                Address = new Address
                {
                    Street = "Storgatan 1",
                    Postcode = "1234",
                    Town = "Storstan",
                    Country = Country.Sweden
                }
            };

            ValidateAndPrintResult(userValidator.Validate(user), user);

            // Fix username
            user.Username = "rick@WubbaLubbaDubDub.com";

            Console.WriteLine("| Swedish address validation |");
            ValidateAndPrintResult(userValidator.Validate(user), user);

            user.Address.Country = Country.Norway;
            Console.WriteLine("| Norweigan address validation |");
            ValidateAndPrintResult(userValidator.Validate(user), user);
        }


        #region utils

        private static void ValidateAndPrintResult<T>(ValidationResult validationResult, T objectToValidate)
        {
            Info($"\n{JsonSerializer.Serialize(objectToValidate, jsonSerializerOptions)}");

            if (validationResult.IsValid)
            {
                Success("Object is valid!");
            }
            else
            {
                Failure($"Validator returned {validationResult.Errors.Count} {(validationResult.Errors.Count > 1 ? "errors" : "error")}");

                ConsoleTableBuilder
                    .From(validationResult.Errors)
                    .ExportAndWriteLine();
            }

            Console.WriteLine("\n\n\n");
        }


        static JsonSerializerOptions jsonSerializerOptions =
            new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new JsonStringEnumConverter() }
            };

        private static void Success(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void Failure(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void Info(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        #endregion utils
    }
}
