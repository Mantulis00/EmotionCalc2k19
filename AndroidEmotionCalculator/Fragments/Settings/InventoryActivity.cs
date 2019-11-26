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
    [Activity(Label = "InventoryActivity")]
    public class InventoryActivity : Activity
    {

        List<String> names;
        ListView ListInventory;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Inventory);

            names = new List<String>()
            {
                "Mantas", "Tomas", "Julius"
            };

            ListInventory = (ListView)FindViewById(Resource.Id.listInventory);

            InventoryAdaptor adaptor = new InventoryAdaptor (this,  names);



            ListInventory.Adapter = adaptor;


            ListInventory.ItemClick += ListInventory_ItemClick;

        }

        private void ListInventory_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Console.WriteLine(names[e.Position]);
        }
    }
}