using Android.App;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Widget;
using AndroidEmotionCalculator.Elements.Adapters;
using EmotionCalculator.EmotionCalculator.Logic;
using EmotionCalculator.Tools.IO.Android;
using static AndroidEmotionCalculator.Elements.MainFragmentManager;

namespace AndroidEmotionCalculator
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : FragmentActivity
    {
        private ViewPager viewPager;
        private MainManager mainManager;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetupEmotionCalculator();

            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            SetupPager();
            SetupButtons();
        }

        private void SetupEmotionCalculator()
        {
            mainManager = new MainManager(
                new AndroidMonthLogger(),
                new AndroidUserLoader(),
                new AndroidSettingsLogger());
        }

        private void SetupPager()
        {
            viewPager = FindViewById<ViewPager>(Resource.Id.pagerMain);
            viewPager.Adapter = new ScreenAdapter(SupportFragmentManager, GetFragmentList(mainManager));

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
            Button moodButton = FindViewById<Button>(Resource.Id.buttonMoodPager);
            moodButton.Click +=
                (o, e) =>
                {
                    viewPager.SetCurrentItem(4, true);
                };


        }
    }
}