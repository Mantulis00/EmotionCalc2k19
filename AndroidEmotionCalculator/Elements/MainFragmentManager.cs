using Android.Runtime;
using Android.Support.V4.App;
using AndroidEmotionCalculator.Elements.Fragments;
using AndroidEmotionCalculator.Fragments.Items;
using EmotionCalculator.EmotionCalculator.Logic;

namespace AndroidEmotionCalculator.Elements
{
    [Preserve(AllMembers = true)]
    static class MainFragmentManager
    {
        public static JavaList<Fragment> GetFragmentList(MainManager mainManager)
        {
            return new JavaList<Fragment>()
            {
                new ShopFragment(mainManager),
                new CalendarFragment(mainManager),
                new GamesFragment(mainManager),
                new InventoryFragment(mainManager)
            };
        }
    }
}