using Android.OS;
using Android.Support.V4.App;
using Android.Views;

namespace AndroidEmotionCalculator.Elements.Fragments
{
     class MoodFragment : Fragment
    {
      
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.mood, container, false);
            return view;
        }
    }
}