using Android;
using Android.Graphics;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using AndroidEmotionCalculator.Elements.Adapters;
using AndroidEmotionCalculator.Tools;
using EmotionCalculator.EmotionCalculator.Logic;
using EmotionCalculator.EmotionCalculator.Logic.User.Items;
using Plugin.Media;
using System.Linq;
using AppResources = EmotionCalculator.Properties.Resources;

namespace AndroidEmotionCalculator.Elements.Fragments
{
    class MoodFragment : Fragment
    {
        Button moodButton;
        ImageView photo;
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
            RequestPermissions(Permissons, 0);
            moodButton.Click+=
                (o, e) =>
                {
                    TakePhoto();
                };

            return view;
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
                return;
            }
            byte[] imageArray = System.IO.File.ReadAllBytes(file.Path);
            Bitmap bitmap = BitmapFactory.DecodeByteArray(imageArray, 0, imageArray.Length);
            photo.SetImageBitmap(bitmap);
        }
    }
}