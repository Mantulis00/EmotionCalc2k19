namespace WebService.DB
{
    public class DBManager
    {
        static readonly string server = "(localdb)\\MSSQLLocalDB";
        static readonly string database = "EmotionDB";

        public static string GetConnectionString()
        {
            return $"Server={server};Database={database}";
        }
    }
}
