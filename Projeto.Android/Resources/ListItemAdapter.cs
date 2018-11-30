using System;
using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using Java.Lang;
using static Projeto.MainPage;

namespace Projeto.Droid.Resources
{
    public class ListItemAdapter : BaseAdapter
    {

        private List<ListItem> listItems;

        private Activity context;

        public ListItemAdapter(Activity context, List<ListItem> listItems): base()
        {
            this.context = context;
        }



        public override int Count => listItems.Count;

        public override Java.Lang.Object GetItem(int position)
        {
            throw new NotImplementedException();
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
                view = context.LayoutInflater.Inflate(
                       Android.Resource.Layout.CustomLayout, null);
            return view;
        }
    }
}
