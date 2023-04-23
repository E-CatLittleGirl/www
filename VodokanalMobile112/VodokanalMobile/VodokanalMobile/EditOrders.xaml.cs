using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VodokanalMobile
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	[QueryProperty(nameof(ItemId), nameof(ItemId))]
	public partial class EditOrders : ContentPage
	{
        VodokanalAsyncRepository database = new VodokanalAsyncRepository();

        public string ItemId {
			set
			{
				LoadZayavky(value);
			}
		}

        

        public EditOrders ()
		{
			InitializeComponent ();

            //var z = (zayavky)BindingContext;
            BindingContext = new zayavky();
            //zayavky z = 
        }

        private void LoadZayavky(string value)
        {
            try 
            { 
                int id = Convert.ToInt32(value);
                zayavky z = database.GetIdZayavky(id);
                BindingContext = z;
            }
            catch { }
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            zayavky z = (zayavky)BindingContext;
            if (!string.IsNullOrWhiteSpace(z.Info_message))
            {
                database.SaveItemZayavky(z);
            }
            await Shell.Current.GoToAsync("..");
        }
    }
}