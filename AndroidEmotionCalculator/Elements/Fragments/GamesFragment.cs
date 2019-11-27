using Android.Content;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;

namespace AndroidEmotionCalculator.Fragments.Items
{

    class GamesFragment : Fragment
    {
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
            Intent intent = new Intent(this.Activity, typeof(Settings.SettingsActivity));
            StartActivity(intent);
        }

        void StartActivityInventory()
        {
            Intent intent = new Intent(this.Activity, typeof(Settings.InventoryActivity));
            StartActivity(intent);
        }




    }

}