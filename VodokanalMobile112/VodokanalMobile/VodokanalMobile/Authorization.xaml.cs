using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using System.Runtime.CompilerServices;

namespace VodokanalMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Authorization : ContentPage
    {
        //private SQLiteConnection database;
        // public const string DATABASE_NAME = "vodokanalmobile1.db";
        //static string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME);
        private VodokanalAsyncRepository database = new VodokanalAsyncRepository();


        //ConfiguredTaskAwaitable 
       // public static VodokanalAsyncRepository database;
        public Authorization()
        {
            InitializeComponent();

        }

        //protected override async void OnAppearing()
        //{
        //    //Login.Text = App.Database.GetItemsWorkersAsync();

        //    await App.Database.GetItemsWorkersAsync();

        //    base.OnAppearing();
        //}

        public async void Enter_Clicked(object sender, EventArgs e)
        {
            // workers workers = new workers();
            workers workers1 = this.database.GetItem(Login.Text);
            workers1 = database.GetItem(Login.Text);
            if(workers1.login == Login.Text && workers1.password == Password.Text)
            {
                await Navigation.PushModalAsync(new OrderMain(), false);
            }
            //var workers = (workers)BindingContext;
            //workers  workers = new workers();
            //workers workers1 = this.database.GetItem(Login.Text);
            //var data = database.GetItemAsync(Login.Text);
            //var d1 = data.Where(x=> x.login == workers.login && x.password == workers.password).FirstOrDefaultAsync();
            //var w = (workers)BindingContext;
            //await App.Database.GetItemsWorkersAsync(w);

            //try
            //{
                //if (workers1.password == Password.Text)
                //{
                    //OrderMain orderMain = new OrderMain();
                    //NavigationPage.PushAsync(orderMain);
                    // OrderMain = new NavigationPage(new OrderMain());
                    //await App.Database.SaveItemWorkersAsync(workers);
                    //await Navigation.PushModalAsync(new OrderMain(), false);
                //}
                //else if (workers1.password != Password.Text)
               // {
                  //  DisplayAlert("Ой..", "Логин и пароль не верные!", "OK");
                //}
            //}
            //catch
            //{
                
               //  DisplayAlert("Ой..", "Логин или пароль не верные!", "OK");
                
            //}
            
        }
    }
}