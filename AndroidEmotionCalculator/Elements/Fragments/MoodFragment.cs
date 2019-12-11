using Android;
using Android.Graphics;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Plugin.Media;
using EmotionCalculator.EmotionCalculator.Tools.API;
using EmotionCalculator.EmotionCalculator.Tools.Web;
using System;
using System.Net.Http;
using EmotionCalculator.EmotionCalculator.Tools.API.Face;
using System.IO;
using EmotionCalculator.EmotionCalculator.Logic;
using System.Linq;

namespace AndroidEmotionCalculator.Elements.Fragments
{
    class MoodFragment : Fragment
    {
        internal IAPIManager APIManager { get; private set; }
        internal MainManager MainManager { get; private set; }
        Button moodButton;
        ImageView photo;
        string path;
        string endpoint;
        TextView moodText;
        private readonly EmotionCalculator.EmotionCalculator.Tools.API.Face.FaceAPIRequester faceAPIRequester;
        string key;
        readonly string[] Permissons =
        {
            Manifest.Permission.ReadExternalStorage,
            Manifest.Permission.WriteExternalStorage,
            Manifest.Permission.Camera
        };
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.mood, container, false);
            moodButton = (Button)view.FindViewById(Resource.Id.moodButton);
            photo = (ImageView)view.FindViewById(Resource.Id.imageView1);
            moodText = (TextView)view.FindViewById(Resource.Id.moodText);
            key = "";//key azure 
            endpoint = "";// endpoint azure 
            RequestPermissions(Permissons, 0);
            moodButton.Click+=
                (o, e) =>
                {
                    TakePhoto();

                };

            return view;
        }
        async void apirequest()
        {
            IAPIManager apiManager = new FaceAPIManager();
            APIManager = apiManager;
            FaceAPIKey updatedKey = new
            FaceAPIKey(key, endpoint);

            faceAPIRequester.APIKey = updatedKey;
            FaceAPIConfig.SaveConfig(updatedKey);

            System.Drawing.Image image = System.Drawing.Image.FromFile(path);
            ImageToByteArray(image);
            try
            {
                APIParseResult parseResult = await APIManager
                        .GetAPIRequester().RequestParseResultAsync(ImageToByteArray(image));
                
            }
            catch (Exception)
            {

            }

            image.Dispose();

        }

        async void TakePhoto()
        {
            await CrossMedia.Current.Initialize();

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                CompressionQuality = 100,
                Name = "image.jpg",
                Directory = "imager"
            }) ;
            if (file == null)
            {
                return ;
            }
            byte[] imageArray = System.IO.File.ReadAllBytes(file.Path);
            Bitmap bitmap = BitmapFactory.DecodeByteArray(imageArray, 0, imageArray.Length);
            photo.SetImageBitmap(bitmap);
            path = file.Path;
            //apirequest();
        }
        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }
        internal void UpdateParsedData(APIParseResult parseResult)
        {
            if (parseResult.Faces.Count > 0)
            {
               MainManager.MonthManager.SetEmotion(parseResult.Faces.First().EmotionData.GetEmotion());
            }
        }
    }
}