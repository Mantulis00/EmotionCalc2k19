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
    class InventoryAdaptor : BaseAdapter<InventoryModel>
    {

        private List<InventoryModel> itemInfo;
        private Context context;


        public InventoryAdaptor(Context context, List<InventoryModel> itemInfo)
        {
            this.context = context;
            this.itemInfo = itemInfo;
        }

        public override InventoryModel this[int position]
        {
            get { return itemInfo[position]; }
        }
        //=> throw new NotImplementedException();

        public override int Count
        {
            get { return itemInfo.Count; }
        }
        //=> throw new NotImplementedException();

        public override long GetItemId(int position)
        {
            return position; 
        }
        //throw new NotImplementedException();

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(context).Inflate(Resource.Layout.inventoryItem, null, false);
            }

            TextView txtItem = row.FindViewById<TextView>(Resource.Id.txtInventoryItem);
            txtItem.Text = itemInfo[position].Name;

            return row;

        }
        //throw new NotImplementedException();





    }
}