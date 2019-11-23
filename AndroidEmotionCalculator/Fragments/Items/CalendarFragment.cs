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
            View view = inflater.Inflate(Resource.Layout.calendar, container, false);

            var text = view.FindViewById<TextView>(Resource.Id.calendarText);

            var button = view.FindViewById<Button>(Resource.Id.coolButton);
            button.Click +=
                (o, e) =>
                {
                    text.Text = "Cool calendar";
                };

            return view;
        }
    }
}