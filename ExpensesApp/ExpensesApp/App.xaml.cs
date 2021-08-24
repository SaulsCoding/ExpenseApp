using System;
using Xamarin.Forms;
using ExpensesApp.Views;
using Xamarin.Forms.Xaml;

namespace ExpensesApp
{
    public partial class App : Application
    {

        public static string DatabasePath; //Define database
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public App(string databasePath) //Constructor
        {
            InitializeComponent();
            DatabasePath = databasePath;
            MainPage = new NavigationPage(new MainPage());
            
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
