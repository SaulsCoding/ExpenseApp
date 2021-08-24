using ExpensesApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;

namespace ExpensesApp.ViewModels
{
    public class CategoriesViewModel
    {

        public ObservableCollection<string> Categories
        {
            get;
            set;
        }

        public ObservableCollection<CategoryExpenses> CategoryExpensesCollection { get; set; }
        public CategoriesViewModel()
        {
            Categories = new ObservableCollection<string>();// initilize
            CategoryExpensesCollection = new ObservableCollection<CategoryExpenses>();

            GetCategories();
            GetExpensesPerCategory();
        }

        private void GetCategories()
        {
            Categories.Clear();
            Categories.Add("Housing"); //values
            Categories.Add("Debt");
            Categories.Add("Health");
            Categories.Add("Food");
            Categories.Add("Personal");
            Categories.Add("Travel");
            Categories.Add("Other");
        }

        public void GetExpensesPerCategory()
        {
            CategoryExpensesCollection.Clear();

            float totalExpressAmount = Expense.TotalExpensesAmount();//
            foreach(string c in Categories)
            {
                var expenses = Expense.GetExpenses(c); //get the amount for each expense and add it together
                float expensesAmountInCategory = expenses.Sum(e => e.Amount);

                CategoryExpenses ce = new CategoryExpenses()
                {
                    Category = c,
                    ExpensesPercentage = expensesAmountInCategory / totalExpressAmount
                };

                CategoryExpensesCollection.Add(ce);
            }
            
        }

        public class CategoryExpenses
        {
            public string Category
            {
                get;
                set;
            }

            public float ExpensesPercentage
            {
                get;
                set;
            }
        }
    }
}
