using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace WouldYouRather
{
    class Program
    {
        static void Main(string[] args)
        {
            var @continue = true;

            while (@continue)
            {
                Console.Write("\nGenerating");

                Enumerable.Range(1, 25).ToList().ForEach(x =>
                {
                    Console.Write(".");
                    Thread.Sleep(50);
                });

                Console.WriteLine("\n");

                Console.WriteLine(GetQuestion());
                Console.WriteLine("");

                Console.Write("Again? (Y/N): ");
                @continue = Console.ReadLine().ToLower().StartsWith("y");
            }
        }

        private static string GetQuestion()
        {
            var lines = new string[] { string.Empty };
            var name = "WouldYouRather.WouldYouRather.txt";

            var stream = Assembly.GetCallingAssembly().GetManifestResourceStream(name);

            if (stream != null)
            {
                using (var sr = new StreamReader(stream))
                {
                    lines = sr.ReadToEnd().Split('\n');
                }
            }

            var rand = new Random();
            var num = rand.Next(0, lines.Length);

            return lines[num];
        }
    }
}
