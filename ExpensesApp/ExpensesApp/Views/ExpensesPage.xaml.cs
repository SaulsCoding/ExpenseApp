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
    public partial class ExpensesPage : ContentPage
    {

        ExpenseViewModel ViewModel;
        public ExpensesPage()
        {
            InitializeComponent();

            ViewModel = Resources["vm"] as ExpenseViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ViewModel.GetExpenses(); // is going to be called each when I navigate back
        }
    }
}