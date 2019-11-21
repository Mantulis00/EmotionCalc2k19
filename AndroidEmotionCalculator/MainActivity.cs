using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Widget;
using AndroidEmotionCalculator.Fragments;
using Fragment = Android.Support.V4.App.Fragment;
using FragmentManager = Android.Support.V4.App.FragmentManager;

namespace AndroidEmotionCalculator
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : FragmentActivity
    {
        ViewPager viewPager;
        static JavaList<Fragment> fragments = new JavaList<Fragment>()
        {
            new ShopFragment(),
            new CalendarFragment(),
            new GamesFragment(),
            new MusicFragment(),
        };


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            SetupPager();
            SetupButtons();
        }

        private void SetupButtons()
        {
            Button shopButton = FindViewById<Button>(Resource.Id.shopButton);
            shopButton.Click +=
                (o, e) =>
                {
                    viewPager.SetCurrentItem(0, true);
                };

            Button calendarButton = FindViewById<Button>(Resource.Id.calendarButton);
            calendarButton.Click +=
                (o, e) =>
                {
                    viewPager.SetCurrentItem(1, true);
                };

            Button gamesButton = FindViewById<Button>(Resource.Id.gamesButton);
            gamesButton.Click +=
                (o, e) =>
                {
                    viewPager.SetCurrentItem(2, true);
                };

            Button musicButton = FindViewById<Button>(Resource.Id.musicButton);
            musicButton.Click +=
                (o, e) =>
                {
                    viewPager.SetCurrentItem(3, true);
                };
        }

        private void SetupPager()
        {
            FragmentManager fragmentManager = SupportFragmentManager;
            ScreenAdapter screenAdapter = new ScreenAdapter(
                fragmentManager,
                fragments);

            viewPager = FindViewById<ViewPager>(Resource.Id.pager);
            viewPager.Adapter = screenAdapter;

            viewPager.SetCurrentItem(1, true);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}