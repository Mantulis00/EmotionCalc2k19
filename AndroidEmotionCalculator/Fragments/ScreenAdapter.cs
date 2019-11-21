using Android.Runtime;
using Android.Support.V4.App;

namespace AndroidEmotionCalculator.Fragments
{
    class ScreenAdapter : FragmentPagerAdapter
    {
        readonly JavaList<Fragment> fragments;

        public ScreenAdapter(FragmentManager fm, JavaList<Fragment> fragments) : base(fm)
        {
            this.fragments = fragments;
        }

        public override int Count => fragments.Count;

        public override Fragment GetItem(int position)
        {
            return fragments[position];
        }
    }
}