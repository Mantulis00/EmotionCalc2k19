using EmotionCalculator.EmotionCalculator.Tools.API.Face;
using System;
using System.Diagnostics;
using static EmotionCalculator.EmotionCalculator.Tools.Web.ImageDownloader;

namespace EmotionCalculator.EmotionCalculator.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Microsoft service:
            //https://azure.microsoft.com/en-us/services/cognitive-services/face/

            string endpoint = GetInput("Enter the API endpoint:");
            string subKey = GetInput("Enter your subscription key:");
            string imageURL = GetInput("Enter an image URL:");

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            //TO DO: exceptions
            var image = GetByteArrayFromUrl(imageURL);
            FaceAPIRequester faceAPIRequester = new FaceAPIRequester(new FaceAPIKey(subKey, endpoint));
            string JSONresponse = faceAPIRequester.RequestImageDataAsync(image).Result;

            stopwatch.Stop();
            float ellapsedSeconds = stopwatch.ElapsedMilliseconds / 1000f;

            Console.WriteLine($"Request duration: {ellapsedSeconds} seconds.");

            Console.WriteLine("\n" +
                "Response received:\n" + JSONresponse);

            //TO DO:
            //JSONParser.TryParse(JSONResponse, ...) ...
            //API reference + Error codes:
            //https://westus.dev.cognitive.microsoft.com/docs/services/563879b61984550e40cbbe8d/operations/563879b61984550f30395236

            Console.ReadLine();
        }

        static string GetInput(string query)
        {
            Console.WriteLine(query);
            return Console.ReadLine();
        }
    }
}