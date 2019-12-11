namespace EmotionCalculator.EmotionCalculator.Logic.User
{
    public interface IUserLoader
    {
        UserData Load(int id);
        void Save(UserData userData, int id);
    }
}
