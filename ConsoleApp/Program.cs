using ConsoleTableExt;
using FluentValidationPOC.Shared;
using FluentValidationPOC.Shared.Validators;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConsoleApp
{
    class Program
    {

        private static readonly ArticleValidator _articleValidator = new ArticleValidator();

        static void Main(string[] args)
        {
            Console.WriteLine("*-* Fluent Validation DEMO *-*");
            //CultureInfo.CurrentUICulture = new CultureInfo("sv-SE");


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


            ValidateAndPrintResult(article1);
            ValidateAndPrintResult(article2);
            ValidateAndPrintResult(article3);
            ValidateAndPrintResult(article4);


            Console.Write("\n\n\n\n\n\n\n\n\n\n");
        }





        private static void ValidateAndPrintResult(Article article)
        {
            Info($"\n\n\n{JsonSerializer.Serialize(article, jsonSerializerOptions)}");


            // Validate article
            var validationResult = _articleValidator.Validate(article);

            if (validationResult.IsValid)
            {
                Success("Article is valid!");
            }
            else
            {
                Failure($"Validator returned {validationResult.Errors.Count} {(validationResult.Errors.Count > 1 ? "errors" : "error")}");

                ConsoleTableBuilder
                    .From(validationResult.Errors)
                    .ExportAndWriteLine();
            }
        }



        #region utils

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
