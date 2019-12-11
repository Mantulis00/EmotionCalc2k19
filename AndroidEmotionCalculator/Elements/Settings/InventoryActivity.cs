using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using EmotionCalculator.EmotionCalculator.Logic;
using Newtonsoft.Json;

namespace AndroidEmotionCalculator.Fragments.Settings
{

    [Activity(Label = "InventoryActivity"), Preserve(AllMembers = true)]
    public class InventoryActivity : Activity
    {



        List<string> names;
        
        private MainManager mainManager;

        ListView ListInventory;


        protected override void OnCreate(Bundle savedInstanceState) 
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Inventory);


            // if (Intent.GetStringExtra("MainManager") != null)

            string jsone = Intent.GetStringExtra("MainManager");
            mainManager = JsonConvert.DeserializeObject<MainManager>(jsone);




            /* if foreach (var theme in mainManager.ReadOnlyUserData.OwnedItems.ThemePacks.ToArray())
             {
                 names.Add(new InventoryModel() { Name = theme.Name, Image = null, Count = theme.PrimaryTextColor.ToString() });
             }
             *//*
            names = new List<string>();
            names.Add(new string() { Name = "Breeee", Image = null, Count = "1" });
            names.Add(new string() { Name = "Defoult", Image = null, Count = "2" });
            names.Add(new string() { Name = "Helouvyn", Image = null, Count = "3" });

    */
            ListInventory = (ListView)FindViewById(Resource.Id.listInventory);

            InventoryAdaptor adaptor = new InventoryAdaptor(this, names);



            ListInventory.Adapter = adaptor;
            ListInventory.ItemClick += ListInventory_ItemClick;

        }

        private void ListInventory_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            StartNewActivity();
        }

        void StartNewActivity()
        {
            Intent intent = new Intent(this, typeof(Settings.InventoryItemActivity));
            StartActivity(intent);
        }



    }
}