using ExpensesApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpensesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoriesPage : ContentPage
    {

        CategoriesViewModel ViewModel;
        public CategoriesPage() // only fired the first time
        {
            InitializeComponent();

            ViewModel = Resources["vm"] as CategoriesViewModel; //vm is the index - each resource is type object by default - vm as a CategorieViewModel type
        }

        protected override void OnAppearing() //executed everytime this page is going to appear
        {
            base.OnAppearing();

            ViewModel.GetExpensesPerCategory();
        }
    }
}