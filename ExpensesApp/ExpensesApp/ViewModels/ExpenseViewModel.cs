using ExpensesApp.Models;
using ExpensesApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace ExpensesApp.ViewModels
{
    public class ExpenseViewModel
    {
        public ObservableCollection<Expense> Expenses
        {
            get;
            set;
        }

        public Command AddExpenseCommand
        {
            get;
            set;
        }

        public ExpenseViewModel()
        {
            Expenses = new ObservableCollection<Expense>();
            GetExpenses();
        }

        public void GetExpenses()
        {
            AddExpenseCommand = new Command(AddExpense);  //Initilize AddExpense Command - executed when the command fires
            var expenses = Expense.GetExpenses();

            Expenses.Clear();

            foreach(var expense in expenses)
            {
                Expenses.Add(expense);
            }
        }

        public void AddExpense() // Navigating to NewExpensePage
        {
            Application.Current.MainPage.Navigation.PushAsync(new NewExpensePage());
        }
    }
}
