using Android.Runtime;
using Android.Support.V4.App;
using AndroidEmotionCalculator.Fragments.Items;
using EmotionCalculator.EmotionCalculator.Logic;

namespace AndroidEmotionCalculator.Fragments
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