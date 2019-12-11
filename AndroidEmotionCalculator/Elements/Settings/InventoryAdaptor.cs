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
    [Preserve(AllMembers = true)]
    class InventoryAdaptor : BaseAdapter<string>
    {

        private List<string> itemInfo;
        private Context context;



        public InventoryAdaptor(Context context, List<string> itemInfo)
        {
            this.context = context;
            this.itemInfo = itemInfo;
        }

        public override string this[int position]
        {
            get { return itemInfo[position]; }
        }

        public override int Count
        {
            get { return itemInfo.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(context).Inflate(Resource.Layout.inventoryItem, null, false);
            }

            TextView txtItem = row.FindViewById<TextView>(Resource.Id.txtInventoryItem);
            txtItem.Text = itemInfo[position];

            return row;

        }
        //throw new NotImplementedException();





    }
}