namespace EmotionCalculator.EmotionCalculator.Logic.User
{
    public interface IUserLoader
    {
        UserData Load();
        void Save(UserData userData);
    }
}
