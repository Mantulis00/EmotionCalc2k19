using System;
using System.Data.SqlClient;

namespace EntityFrameworkClasses.DB
{
    public static class DBTest
    {
        private static void TestMethod()
        {
            Console.WriteLine("\n\n\n/////////////////////");

            try
            {
                string server = "(localdb)\\MSSQLLocalDB";
                string database = "EmotionDB";

                string connectionString = $"Server={server};Database={database}";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("SELECT COUNT(*) as number FROM UserData", connection);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader["number"]);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Big error:");
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("/////////////////////\n\n\n");
        }
    }
}
