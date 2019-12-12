using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using EmotionCalculator.EmotionCalculator.Logic;
using EmotionCalculator.EmotionCalculator.Logic.Currency;

namespace AndroidEmotionCalculator.Elements.Fragments
{
    class CalendarFragment : Fragment
    {
        private readonly MainManager _mainManager;

        public CalendarFragment(MainManager mainManager) : base()
        {
            _mainManager = mainManager;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.calendar, container, false);

            var text = view.FindViewById<TextView>(Resource.Id.calendarText);

            var button = view.FindViewById<Button>(Resource.Id.coolButton);
            button.Click +=
                (o, e) =>
                {
                    text.Text = "Cool calendar";
                    _mainManager.CurrencyManager.TemporaryCurrencyEntryPoint(
                        CurrencyType.JoyCoin,
                        10);

                    _mainManager.Save();
                };

            return view;
        }
    }
}