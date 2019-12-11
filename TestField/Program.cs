using EmotionCalculator.EmotionCalculator.Logic.Currency;
using EmotionCalculator.Tools.IO.Android;

namespace TestField
{
    class Program
    {
        static void Main()
        {
            var key = AndroidAPILoader.Load(1);
            System.Console.WriteLine(key);
            int id = AndroidAPILoader.Load(key);
            System.Console.WriteLine(id);

            AndroidUserLoader userLoader = new AndroidUserLoader();
            var receivedObject = userLoader.Load(id);

            System.Console.WriteLine("First load:");
            System.Console.WriteLine(receivedObject.JoyCoins);
            System.Console.WriteLine(receivedObject.JoyGems);

            receivedObject.AddCurrency(CurrencyType.JoyCoin, 20);
            userLoader.Save(receivedObject, id);

            receivedObject = userLoader.Load(id);

            System.Console.WriteLine("Second load:");
            System.Console.WriteLine(receivedObject.JoyCoins);
            System.Console.WriteLine(receivedObject.JoyGems);

            System.Console.WriteLine();

            AndroidAPILoader.ClearAsync(id);

            System.Console.ReadLine();
        }
    }
}
