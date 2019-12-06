using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using AndroidEmotionCalculator.Elements.Adapters;
using AndroidEmotionCalculator.Tools;
using EmotionCalculator.EmotionCalculator.Logic;
using EmotionCalculator.EmotionCalculator.Logic.User.Items;
using System.Linq;
using AppResources = EmotionCalculator.Properties.Resources;

namespace AndroidEmotionCalculator.Elements.Fragments
{
    class MusicFragment : Fragment
    {
        readonly MainManager mainManager;
        View view;
        public MusicFragment(MainManager mainManager) : base()
        {
            this.mainManager = mainManager;
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            view = inflater.Inflate(Resource.Layout.music, container, false);

            SetButtons();


            return view;
        }

        private void SetButtons()
        {
            var music = new MusicPlayer(mainManager);
            var song = mainManager.ReadOnlyUserData.OwnedItems.SongPacks.ElementAt(music.index);
            view.FindViewById<TextView>(Resource.Id.textView1).Text = song.Name;
            view.FindViewById<Button>(Resource.Id.buttonPlay).Click +=
                (o, e) =>
                {
                  
                    music.StartPlayer();
                };

            view.FindViewById<Button>(Resource.Id.buttonPause).Click +=
                (o, e) =>
                {
                    music.PausePlayer();
                };

            view.FindViewById<Button>(Resource.Id.buttonNext).Click +=
                (o, e) =>
                {
                    music.NextMusic();
                    song = mainManager.ReadOnlyUserData.OwnedItems.SongPacks.ElementAt(music.index);
                    view.FindViewById<TextView>(Resource.Id.textView1).Text = song.Name;
                };

            view.FindViewById<Button>(Resource.Id.buttonPrevious).Click +=
                (o, e) =>
                {
                    music.BackMusic();
                    song = mainManager.ReadOnlyUserData.OwnedItems.SongPacks.ElementAt(music.index);
                    view.FindViewById<TextView>(Resource.Id.textView1).Text  = song.Name;
                };
        }
    }
}