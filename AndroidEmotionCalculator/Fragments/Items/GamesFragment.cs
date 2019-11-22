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

            // pass view


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
            Intent intent = new Intent(getActivity(), SettingsActivity.class);
            //in.putExtra("more ", " some more data");
            startActivity(intent);

      //  OpenSettings();
            };

        }

        private void OpenSettings()
        {
          //  Intent intent = new Intent (getActivity(), SubActivity.class);
            //in.putExtra("more ", " some more data");
          //  startActivity(intent);
        }


    }
}