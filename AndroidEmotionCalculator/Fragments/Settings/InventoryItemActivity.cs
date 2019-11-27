using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AndroidEmotionCalculator.Fragments.Settings
{
    [Activity(Label = "InventoryItemActivity")]
    public class InventoryItemActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.inventoryItemSelect);


            Button buttonReturn = (Button)FindViewById<Button>(Resource.Id.buttonInventoryReturn);
            buttonReturn.Click += ButtonReturn_Click;
            
        }

        private void ButtonReturn_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Settings.InventoryActivity));
            StartActivity(intent);
        }
    }
}