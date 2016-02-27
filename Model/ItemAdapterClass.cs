using System;
using Android.Views;
using Android.Widget;
using Android.App;
using System.Collections.Generic;

//stackoverflow.com/questions/16453379/android-list-adapter-returns-wrong-position-in-getview
namespace SampleListView
{
	public class ItemAdapterClass :BaseAdapter
	{
		readonly Activity _context;
		readonly List<ItemClass> _lstItem; 
		internal static List<string> lstSelectedItem; 
		ViewHolderItem viewHolder;
		//to publish ImgView click event to ActivityClass 
		internal event Action<string> ActionImgSelectedToActivity;  
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
			if (rowView == null) {
				//create new row view
				rowView = _context.LayoutInflater.Inflate (Resource.Layout.ItemCustomLayout, parent, false); 
				viewHolder = new ViewHolderItem ();
				viewHolder.txtTemName = rowView.FindViewById<TextView> (Resource.Id.lblItemName);
				viewHolder.imgItem = rowView.FindViewById<ImageView> (Resource.Id.imgItem);
				viewHolder.chkItem = rowView.FindViewById<CheckBox> (Resource.Id.checkitem); 
				viewHolder.Initialize (rowView); //to initialize listen for ImgView click   
				//tag viewHolder instance to row view.
				rowView.Tag = viewHolder;
			} 
			else
			{//re-use row view
				//fetch viewholder instance from the Tag attached to rowview
				viewHolder = (ViewHolderItem)rowView.Tag; 
			} 
			//Initialize click event
			//subscribe to event from viewholder ImgView click 
			viewHolder.eventHandlerImgViewSelected = () =>
			{
				// publish ImgView click event to ActivityClass 
				if(ActionImgSelectedToActivity!=null)
					ActionImgSelectedToActivity(_lstItem[position].ItemName);
			};
 
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
			//to publish ImgView click event to Adapter GetView()
			internal event EventHandler eventHandlerImgViewSelected;
			internal void Initialize(View view)
			{
				imgItem=view.FindViewById<ImageView> (Resource.Id.imgItem);
				//to publish ImgView click event to Adapter GetView()
				imgItem.Click += (object sender, EventArgs e) => eventHandlerImgViewSelected ();  
			} 

		}
	}
}

