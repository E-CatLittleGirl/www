using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//using VodokanalMobile.Droid;
using SQLite;
using System.IO;


namespace VodokanalMobile
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Orders : ContentPage
	{
        VodokanalAsyncRepository database = new VodokanalAsyncRepository();
        public Orders ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            collectionView.ItemsSource = database.GetZayavky();

            base.OnAppearing();
        }

        private void Source_Clicked(object sender, EventArgs e)
        {
			DisplayAlert("oh","Coming soon", "Ок");
        }

        private async void collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection !=null)
            {
                zayavky z = (zayavky)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(EditOrders)}?{nameof(EditOrders.ItemId)}={z.id_zayavky.ToString()}");
                DisplayAlert("oh", "Coming soon", "Ок");
            }
        }
    }
}