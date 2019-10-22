namespace EmotionCalculator.EmotionCalculator.Logic.User
{
    interface IUserLoader
    {
        UserData Load();
        void Save(UserData userData);
    }
}
