using EmotionCalculator.EmotionCalculator.FormsUI;
using System.Windows.Forms;

namespace EmotionCalculator.EmotionCalculator.Tools.API.Face
{
    class FaceAPIManager : IAPIManager
    {
        private readonly FaceAPIRequester faceAPIRequester;

        internal FaceAPIManager()
        {
            faceAPIRequester = new FaceAPIRequester(FaceAPIConfig.LoadConfig());
        }

        public IAPIRequester GetAPIRequester()
        {
            return faceAPIRequester;
        }

        public Form GetSettingsForm()
        {
            return new FaceAPISettingsForm(faceAPIRequester);
        }
    }
}
