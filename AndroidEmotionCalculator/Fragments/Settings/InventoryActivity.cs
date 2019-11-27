using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Support.V4.App;
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

        List<InventoryModel> names;
        ListView ListInventory;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Inventory);

            names = new List<InventoryModel>();
            names.Add(new InventoryModel() { Name = "Breeee", Image = null,Count = "1" });
            names.Add(new InventoryModel() { Name = "Defoult", Image = null, Count = "2" });
            names.Add(new InventoryModel() { Name = "Helouvyn", Image = null, Count = "3" });


            ListInventory = (ListView)FindViewById(Resource.Id.listInventory);

            InventoryAdaptor adaptor = new InventoryAdaptor (this,  names);



            ListInventory.Adapter = adaptor;
            ListInventory.ItemClick += ListInventory_ItemClick;

        }

        private void ListInventory_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            StartNewActivity();
            //Console.WriteLine(names[e.Position]);
        }

        void StartNewActivity()
        {
            Intent intent = new Intent(this, typeof(Settings.InventoryItemActivity));
            StartActivity(intent);
        }



    }
}