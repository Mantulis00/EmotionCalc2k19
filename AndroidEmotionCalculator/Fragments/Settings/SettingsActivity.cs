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
    [Activity(Label = "SettingsActivity")]
    public class SettingsActivity : Activity
    {

        List<String> names;
        ListView ListInventory;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Inventory);

            // Create your application here



            names = new List<String>()
            {
                "Mantas", "Tomas", "Julius"
            };

            ListInventory = (ListView) FindViewById(Resource.Id.listInventory) ;

            ArrayAdapter<string> adaptor = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, names);

            ListInventory.Adapter = adaptor;

        }
    }
}