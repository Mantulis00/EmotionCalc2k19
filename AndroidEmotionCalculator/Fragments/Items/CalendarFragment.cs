using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;

namespace AndroidEmotionCalculator.Fragments.Items
{
    class CalendarFragment : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.calendar, container, false);
        }
    }
}