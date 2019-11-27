using Android.Runtime;
using Android.Support.V4.App;
using AndroidEmotionCalculator.Fragments.Items;

namespace AndroidEmotionCalculator.Fragments
{
    static class MainFragmentManager
    {
        public static JavaList<Fragment> FragmentList { get; private set; } = new JavaList<Fragment>()
        {
            new ShopFragment(),
            new CalendarFragment(),
            new GamesFragment(),
            new MusicFragment(),
        };
    }
}