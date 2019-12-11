using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using AndroidEmotionCalculator.Fragments.Settings;
using DocumentFormat.OpenXml.Drawing;
using EmotionCalculator.EmotionCalculator.Logic;
using System.Collections.Generic;
using System.Linq;

namespace AndroidEmotionCalculator.Elements.Fragments
{
    [Preserve(AllMembers = true)]
    class MusicFragment : Fragment
    {
        MainManager mainManager;

        ListView ListInventory;
        List<string> names;

        Android.Views.View view;

        public MusicFragment(MainManager mainManager) : base()
        {

            this.mainManager = mainManager;
        }

        public override Android.Views.View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
             view = inflater.Inflate(Resource.Layout.Inventory, container, false);

            ListInventory = (Android.Widget.ListView)view.FindViewById(Resource.Id.listInventory);

            names = new List<string>();

            foreach (var item in mainManager.ReadOnlyUserData.OwnedItems.ThemePacks.ToArray())
            {
                names.Add(item.Name.ToString());
            }
            


            InventoryAdaptor adaptor = new InventoryAdaptor(Activity, names);


            ListInventory.Adapter = adaptor;
            ListInventory.ItemSelected += ( sender,  e) =>
            {

            };

            return view;
        }

        private void ListInventory_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Intent intent = new Intent(view.Context, typeof(InventoryItemActivity));



            StartActivity(intent);
        }

    }
}