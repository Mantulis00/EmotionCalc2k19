using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using EmotionCalculator.EmotionCalculator.Logic;
using Java.Lang;
using Newtonsoft.Json;


namespace AndroidEmotionCalculator.Fragments.Items
{

    [Preserve(AllMembers = true)]
    class GamesFragment : Fragment
    {
        MainManager mainManager;
        public GamesFragment(MainManager mainManager) : base()
        {

            this.mainManager = mainManager;
        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            View view = inflater.Inflate(Resource.Layout.games, container, false);

            SetupButtons(view);


            return view;
        }

        private void SetupButtons(View view)
        {

            view.FindViewById<Button>(Resource.Id.btnInvaders).Click += (o, e) =>
            {
                view.FindViewById<TextView>(Resource.Id.txtGamesHead).Text = "Invaders";
            };
            view.FindViewById<Button>(Resource.Id.btnSnake).Click += (o, e) =>
            {
                view.FindViewById<TextView>(Resource.Id.txtGamesHead).Text = "Snake";
            };
            view.FindViewById<Button>(Resource.Id.btnBreakout).Click += (o, e) =>
            {
                view.FindViewById<TextView>(Resource.Id.txtGamesHead).Text = "Breakout";
            };
            view.FindViewById<Button>(Resource.Id.btnSettings).Click += (o, e) =>
            {
                StartActivitySettings();
            };
            view.FindViewById<Button>(Resource.Id.buttonInventory).Click += (o, e) =>
            {
                StartActivityInventory();
            };

        }
        void StartActivitySettings()
        {
            if (mainManager != null)
            { 
            Intent intent = new Intent(this.Activity, typeof(Settings.SettingsActivity));
            intent.PutExtra("MeinManager", JsonConvert.SerializeObject(null));
            StartActivity(intent);
            }
        }

        void StartActivityInventory()
        {
            Intent intent = new Intent(this.Activity, typeof(Settings.InventoryActivity));

            intent.PutExtra("MainManager", JsonConvert.SerializeObject(mainManager));
            

            StartActivity(intent);
        }




    }

}