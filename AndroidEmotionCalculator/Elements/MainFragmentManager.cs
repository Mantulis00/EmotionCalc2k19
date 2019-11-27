using Android.Runtime;
using Android.Support.V4.App;
using AndroidEmotionCalculator.Elements.Fragments;
using EmotionCalculator.EmotionCalculator.Logic;

namespace AndroidEmotionCalculator.Elements
{
    static class MainFragmentManager
    {
        public static JavaList<Fragment> GetFragmentList(MainManager mainManager)
        {
            return new JavaList<Fragment>()
            {
                new ShopFragment(mainManager),
                new CalendarFragment(),
                new GamesFragment(),
                new MusicFragment(),
            };
        }
    }
}