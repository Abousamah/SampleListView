using System;
using Android.Views;
using Android.Widget;
using Android.App;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts; 
//stackoverflow.com/questions/16453379/android-list-adapter-returns-wrong-position-in-getview
namespace SampleListView
{
	public class ItemAdapterClass :BaseAdapter
	{
		Activity _context;
		List<ItemClass> _lstItem; 
		internal static List<string> lstSelectedItem; 
		ViewHolderItem viewHolder;
		CheckBox chkItem;
		public ItemAdapterClass (Activity c,List<ItemClass> lstIem)
		{
			_context = c;
			_lstItem = lstIem;
			lstSelectedItem = new List<string> ();
		}
		public override int Count {
			get { return _lstItem.Count; }
		}

		public override Java.Lang.Object GetItem (int position)
		{
			return null;
		}
		public override long GetItemId (int position)
		{
			return 0;
		}
		public override  View GetView (int position,  View convertView,  ViewGroup parent)
		{ 
			View rowView = convertView;
			//reuse view
			if (rowView == null) { 
				rowView = _context.LayoutInflater.Inflate (Resource.Layout.ItemCustomLayout, parent, false); 
				viewHolder = new ViewHolderItem ();
				viewHolder.txtTemName = rowView.FindViewById<TextView> (Resource.Id.lblItemName);
				viewHolder.imgItem = rowView.FindViewById<ImageView> (Resource.Id.imgItem);
				viewHolder.chkItem = rowView.FindViewById<CheckBox> (Resource.Id.checkitem); 
 
				chkItem = rowView.FindViewById<CheckBox> (Resource.Id.checkitem);
//				chkItem.Click += delegate(object sender, EventArgs e) {
//					Toast.MakeText(_context,string.Format( "Position:{0}, {1}",position, _lstItem [position].ItemName),ToastLength.Long).Show();
// 
//				};

				viewHolder.chkItem.Click += delegate(object sender, EventArgs e)
				{
					Console.WriteLine ("row click  " + position + " _ItemName " + _lstItem [position].ItemName); 
					var views =	(CheckBox)sender; 
					int pos = (int)views.Tag; 
						if (lstSelectedItem.Contains (_lstItem [pos].ItemName))
						{
							lstSelectedItem.Remove (_lstItem [pos].ItemName); 
						}
						else
						{
							lstSelectedItem.Add (_lstItem [pos].ItemName); 
						} 
					Console.WriteLine ("position " + pos);
				};
				rowView.Tag = viewHolder;
			} 
			else
			{
				viewHolder = (ViewHolderItem)rowView.Tag; 
			} 
//			chkItem.Click += delegate(object sender, EventArgs e) {
//				Toast.MakeText(_context,string.Format( "Position:{0}, {1}",position, _lstItem [position].ItemName),ToastLength.Long).Show();
//
//			};
			viewHolder.txtTemName.Text = _lstItem [position].ItemName;  
			viewHolder.imgItem.SetImageResource (Resource.Drawable.imgItem); 
		    viewHolder.chkItem.Checked = lstSelectedItem.Contains (_lstItem [position].ItemName) ? true :false ; 
			viewHolder.chkItem.Tag=position;
			return rowView;
		}

	  class ViewHolderItem :Java.Lang.Object
		{
			internal   TextView txtTemName;
			internal   ImageView imgItem;
			internal   CheckBox chkItem; 
		}
	}
}

