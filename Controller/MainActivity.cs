using Android.App; 
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace SampleListView
{
	[Activity (Label = "SampleListView", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{ 
		ListView listViewItem;
		ItemAdapterClass objItemAdapter;
		List<ItemClass> lstItem;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle); 
			SetContentView (Resource.Layout.Main);
			listViewItem = FindViewById<ListView> (Resource.Id.listViewItem);
			BindListView ();
		}
		void BindListView() 
		{ 
			 lstItem = new List<ItemClass> ();
		     FillList ();
		     objItemAdapter = new ItemAdapterClass (this, lstItem);
			 listViewItem.Adapter = objItemAdapter; 
		}
		void FillList()
		{
			ItemClass objItem; 
			for (int i = 0; i <2000 ; i++)
			{ 
				
				objItem = new ItemClass ();
				objItem.ItemName =string.Format( "Item_{0} ",i);
				objItem.ItemImage = "Image name";
				lstItem.Add (objItem); 
			} 
		}
	}
}


