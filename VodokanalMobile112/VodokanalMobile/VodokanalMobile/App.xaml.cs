using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Reflection;
using System.IO;

namespace VodokanalMobile
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "vodokanalmobile.db";
       

        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();

            MainPage = new Authorization();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
