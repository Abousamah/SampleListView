using Android.App; 
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using System;

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
					objItemAdapter.ActionImgSelectedToActivity -= SelectedItem;
					objItemAdapter = null;
				}
				
		     objItemAdapter = new ItemAdapterClass (this, lstItem);
			 objItemAdapter.ActionImgSelectedToActivity += SelectedItem;
			 listViewItem.Adapter = objItemAdapter; 
			}
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
		void SelectedItem( string strItemName)
		{
			Toast.MakeText ( this , string.Format("From Activity :{0}",strItemName ), ToastLength.Short ).Show ();
		}
	}
}


