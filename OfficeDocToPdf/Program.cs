using OfficeDocToPdf.Converters;
using System;
using System.IO;

namespace OfficeDocToPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: OfficeDocToPdf.exe <inputFile> <outputFile>");
                return;
            }

            var inputFile = args[0];
            var outputFile = args[1];

            if (!File.Exists(inputFile))
            {
                Console.WriteLine($"File {inputFile} does not exist!");
                return;
            }

            var converter = new ConverterFactory().GetConverter(inputFile);

            var result = converter.Convert(inputFile, outputFile);

            Console.WriteLine(result.Success
                ? $"File {inputFile} successfully converted to {outputFile}."
                : $"Failed to convert {inputFile}. {result.Message}");
        }
    }
}
