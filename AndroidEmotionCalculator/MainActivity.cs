using Android.App;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Widget;
using AndroidEmotionCalculator.Fragments;
using static AndroidEmotionCalculator.Fragments.MainFragmentManager;

namespace AndroidEmotionCalculator
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : FragmentActivity
    {
        private ViewPager viewPager;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            SetupPager();
            SetupButtons();
        }

        private void SetupPager()
        {
            viewPager = FindViewById<ViewPager>(Resource.Id.pagerMain);
            viewPager.Adapter = new ScreenAdapter(SupportFragmentManager, FragmentList);

            viewPager.SetCurrentItem(1, true);
        }

        private void SetupButtons()
        {
            Button shopButton = FindViewById<Button>(Resource.Id.buttonShopPager);
            shopButton.Click +=
                (o, e) =>
                {
                    viewPager.SetCurrentItem(0, true);
                };

            Button calendarButton = FindViewById<Button>(Resource.Id.buttonCalendarPager);
            calendarButton.Click +=
                (o, e) =>
                {
                    viewPager.SetCurrentItem(1, true);
                };

            Button gamesButton = FindViewById<Button>(Resource.Id.buttonGamesPager);
            gamesButton.Click +=
                (o, e) =>
                {
                    viewPager.SetCurrentItem(2, true);
                };

            Button musicButton = FindViewById<Button>(Resource.Id.buttonMusicPager);
            musicButton.Click +=
                (o, e) =>
                {
                    viewPager.SetCurrentItem(3, true);
                };
        }
    }
}