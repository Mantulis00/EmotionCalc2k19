namespace EmotionCalculator.EmotionCalculator.Tools.API.Face
{
    public class FaceAPIManager : IAPIManager
    {
        private readonly FaceAPIRequester faceAPIRequester;

        public FaceAPIManager()
        {
            faceAPIRequester = new FaceAPIRequester(FaceAPIConfig.LoadConfig());
        }

        public IAPIRequester GetAPIRequester()
        {
            return faceAPIRequester;
        }
    }
}
