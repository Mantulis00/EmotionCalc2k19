using Android.OS;
using Android.Support.V4.App;
using Android.Views;

namespace AndroidEmotionCalculator.Elements.Fragments
{
    class GamesFragment : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.games, container, false);
        }
    }
}