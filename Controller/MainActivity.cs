using Android.App; 
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
//created: 14-07-2015
//updated: 27-02-2016
//note : Good practce in listview binding 
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
			if(lstItem!=null && lstItem.Count >0)
			{
				if ( objItemAdapter != null )
				{
					//un-subscribe the event to avoid adding multiple event for click
					objItemAdapter.ActionImgSelectedToActivity -= SelectedItem;
					objItemAdapter = null;
				}
				
		     objItemAdapter = new ItemAdapterClass (this, lstItem);
				//subscribe to click event from Adapter class GetView() method 
			 objItemAdapter.ActionImgSelectedToActivity += SelectedItem;
			 listViewItem.Adapter = objItemAdapter; 
			}
		}
		//Fill some random data to list of type string lstItem
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
		void SelectedItem( string strItemName)
		{
			Toast.MakeText ( this , string.Format("From Activity :{0}",strItemName ), ToastLength.Short ).Show ();
		}
	}
}


