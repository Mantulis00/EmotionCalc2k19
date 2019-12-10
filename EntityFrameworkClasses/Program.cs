using EmotionCalculator.EmotionCalculator.Logic.Currency;
using EmotionCalculator.EmotionCalculator.Logic.User;
using EmotionCalculator.Tools.IO.Android;

namespace TestField
{
    class Program
    {
        static void Main()
        {
            IUserLoader userLoader = new AndroidUserLoader();
            var receivedObject = userLoader.Load();

            System.Console.WriteLine("First load:");
            System.Console.WriteLine(receivedObject.JoyCoins);
            System.Console.WriteLine(receivedObject.JoyGems);

            receivedObject.AddCurrency(CurrencyType.JoyCoin, 20);
            userLoader.Save(receivedObject);

            receivedObject = userLoader.Load();

            System.Console.WriteLine("Second load:");
            System.Console.WriteLine(receivedObject.JoyCoins);
            System.Console.WriteLine(receivedObject.JoyGems);

            System.Console.WriteLine();

            System.Console.ReadLine();
        }
    }
}
