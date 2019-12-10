using EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases;
using EmotionCalculator.EmotionCalculator.Logic.User;
using EmotionCalculator.EmotionCalculator.Tools.API.Containers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace WebService.DB
{
    public static class UserDataTableManager
    {
        private static SqlDataAdapter GetUserDataAdapter(SqlConnection connection, bool byId)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand selectCommand = new SqlCommand(
                "SELECT UserId, JoyCoins, JoyGems, DailyStreak, LastLogin, "
                + "Anger, Contempt, Disgust, Fear, Happiness, "
                + "Neutral, Sadness, Surprise "
                + "FROM UserData "
                + (byId ? "WHERE UserId = @Id" : string.Empty),
                connection);

            if (byId)
                selectCommand.Parameters.Add("@Id", SqlDbType.Int, 8, "UserId");

            SqlCommand insertCommand = new SqlCommand(
                "INSERT INTO UserData(" + (byId ? "UserId, " : string.Empty)
                + "JoyCoins, JoyGems, DailyStreak, LastLogin, Anger, Contempt, "
                + "Disgust, Fear, Happiness, Neutral, Sadness, Surprise) "
                + "VALUES(" + (byId ? "@Id, " : string.Empty)
                + "@JoyCoins, @JoyGems, @DailyStreak, @LastLogin, "
                + "@Anger, @Contempt, @Disgust, @Fear, @Happiness, "
                + "@Neutral, @Sadness, @Surprise)",
                connection);

            insertCommand.Parameters.Add("@Id", SqlDbType.Int, 8, "UserId");
            insertCommand.Parameters.Add("@JoyCoins", SqlDbType.Int, 8, "JoyCoins");
            insertCommand.Parameters.Add("@JoyGems", SqlDbType.Int, 8, "JoyGems");
            insertCommand.Parameters.Add("@DailyStreak", SqlDbType.SmallInt, 4, "DailyStreak");
            insertCommand.Parameters.Add("@LastLogin", SqlDbType.DateTime, 8, "LastLogin");
            insertCommand.Parameters.Add("@Anger", SqlDbType.Int, 8, "Anger");
            insertCommand.Parameters.Add("@Contempt", SqlDbType.Int, 8, "Contempt");
            insertCommand.Parameters.Add("@Disgust", SqlDbType.Int, 8, "Disgust");
            insertCommand.Parameters.Add("@Fear", SqlDbType.Int, 8, "Fear");
            insertCommand.Parameters.Add("@Happiness", SqlDbType.Int, 8, "Happiness");
            insertCommand.Parameters.Add("@Neutral", SqlDbType.Int, 8, "Neutral");
            insertCommand.Parameters.Add("@Sadness", SqlDbType.Int, 8, "Sadness");
            insertCommand.Parameters.Add("@Surprise", SqlDbType.Int, 8, "Surprise");

            SqlCommand updatecommand = new SqlCommand(
                "UPDATE UserData SET JoyCoins = @JoyCoins, JoyGems = @JoyGems, "
                + "DailyStreak = @DailyStreak, LastLogin = @LastLogin, "
                + "Anger = @Anger, Contempt = @Contempt, Disgust = @Disgust, "
                + "Fear = @Fear, Happiness = @Happiness, Neutral = @Neutral, "
                + "Sadness = @Sadness, Surprise = @Surprise",
                connection);

            updatecommand.Parameters.Add("@JoyCoins", SqlDbType.Int, 8, "JoyCoins");
            updatecommand.Parameters.Add("@JoyGems", SqlDbType.Int, 8, "JoyGems");
            updatecommand.Parameters.Add("@DailyStreak", SqlDbType.SmallInt, 4, "DailyStreak");
            updatecommand.Parameters.Add("@LastLogin", SqlDbType.DateTime, 8, "LastLogin");
            updatecommand.Parameters.Add("@Anger", SqlDbType.Int, 8, "Anger");
            updatecommand.Parameters.Add("@Contempt", SqlDbType.Int, 8, "Contempt");
            updatecommand.Parameters.Add("@Disgust", SqlDbType.Int, 8, "Disgust");
            updatecommand.Parameters.Add("@Fear", SqlDbType.Int, 8, "Fear");
            updatecommand.Parameters.Add("@Happiness", SqlDbType.Int, 8, "Happiness");
            updatecommand.Parameters.Add("@Neutral", SqlDbType.Int, 8, "Neutral");
            updatecommand.Parameters.Add("@Sadness", SqlDbType.Int, 8, "Sadness");
            updatecommand.Parameters.Add("@Surprise", SqlDbType.Int, 8, "Surprise");

            SqlCommand deleteCommand = new SqlCommand(
                "DELETE FROM UserData "
                + "WHERE Id = @Id",
                connection);

            deleteCommand.Parameters.Add("@Id", SqlDbType.Int, 8, "UserId");

            adapter.SelectCommand = selectCommand;
            adapter.InsertCommand = insertCommand;
            adapter.UpdateCommand = updatecommand;
            adapter.DeleteCommand = deleteCommand;

            return adapter;
        }

        public static UserData SelectUserData(int userId)
        {
            using (var connection = new SqlConnection(DBManager.GetConnectionString()))
            {
                connection.Open();

                using (var adapter = GetUserDataAdapter(connection, true))
                {
                    adapter.SelectCommand.Parameters["@Id"].Value = userId;

                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    if (dataSet.Tables[0].Rows.Count > 0)
                    {
                        var row = dataSet.Tables[0].Rows[0];

                        List<KeyValuePair<Emotion, int>> emotions = new List<KeyValuePair<Emotion, int>>();

                        foreach (var item in new Emotion[] {
                            Emotion.Anger, Emotion.Contempt, Emotion.Disgust,
                            Emotion.Fear, Emotion.Happiness, Emotion.Neutral,
                            Emotion.Sadness, Emotion.Surprise })
                        {
                            if (int.TryParse(row[item.ToString()].ToString(), out int number))
                                emotions.Add(new KeyValuePair<Emotion, int>(item, number));
                        }

                        return new UserData(
                            int.Parse(row["JoyCoins"].ToString()),
                            int.Parse(row["JoyGems"].ToString()),
                            int.Parse(row["DailyStreak"].ToString()),
                            DateTime.Parse(row["LastLogin"].ToString()),
                            emotions, new OwnedItems());
                    }
                    else
                    {
                        var userData = new UserData(0, 0, 0, DateTime.Now,
                            Enumerable.Empty<KeyValuePair<Emotion, int>>(), new OwnedItems());

                        return userData;
                    }
                }
            }
        }

        public static void InsertUserData(UserData userData)
        {
            using (var connection = new SqlConnection(DBManager.GetConnectionString()))
            {
                connection.Open();

                using (var adapter = GetUserDataAdapter(connection, false))
                {
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    DataRow newRow = dataSet.Tables[0].NewRow();
                    newRow["JoyCoins"] = userData.JoyCoins;
                    newRow["JoyGems"] = userData.JoyGems;
                    newRow["DailyStreak"] = userData.DailyStreak;
                    newRow["LastLogin"] = userData.LastLogin;

                    var emotionCount = userData.EmotionCount;
                    foreach (var count in emotionCount)
                    {
                        newRow[count.Key.ToString()] = count.Value;
                    }

                    dataSet.Tables[0].Rows.Add(newRow);

                    adapter.Update(dataSet.Tables[0]);
                }
            }
        }

        public static void UpdateUserData(int userId, UserData userData)
        {
            using (var connection = new SqlConnection(DBManager.GetConnectionString()))
            {
                connection.Open();

                using (var adapter = GetUserDataAdapter(connection, true))
                {
                    adapter.SelectCommand.Parameters["@Id"].Value = userId;

                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    DataRow updatedRow;

                    if (dataSet.Tables[0].Rows.Count != 0)
                    {
                        updatedRow = dataSet.Tables[0].Rows[0];
                    }
                    else
                    {
                        updatedRow = dataSet.Tables[0].NewRow();
                        updatedRow["UserId"] = userId;
                        dataSet.Tables[0].Rows.Add(updatedRow);
                    }

                    updatedRow["JoyCoins"] = userData.JoyCoins;
                    updatedRow["JoyGems"] = userData.JoyGems;
                    updatedRow["DailyStreak"] = userData.DailyStreak;
                    updatedRow["LastLogin"] = userData.LastLogin;

                    foreach (var item in userData.EmotionCount)
                    {
                        updatedRow[item.Key.ToString()] = item.Value;
                    }

                    adapter.Update(dataSet.Tables[0]);
                }
            }
        }

        public static void DeleteUserData(int userId)
        {
            using (var connection = new SqlConnection(DBManager.GetConnectionString()))
            {
                connection.Open();

                using (var adapter = GetUserDataAdapter(connection, false))
                {
                    adapter.SelectCommand.Parameters["@Id"].Value = userId;

                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    dataSet.Tables[0].Rows[0].Delete();

                    adapter.Update(dataSet.Tables[0]);
                }
            }
        }
    }
}
