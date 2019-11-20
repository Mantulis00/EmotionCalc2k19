
using Android.App;
using Android.OS;

namespace AndroidEmotionCalculator
{
    [Activity(Label = "ShopActivity")]
    public class ShopActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.shop);
        }
    }
}