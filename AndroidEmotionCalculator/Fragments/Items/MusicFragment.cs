using Android.OS;
using Android.Support.V4.App;
using Android.Views;

namespace AndroidEmotionCalculator.Fragments.Items
{
    class MusicFragment : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.music, container, false);
        }
    }
}