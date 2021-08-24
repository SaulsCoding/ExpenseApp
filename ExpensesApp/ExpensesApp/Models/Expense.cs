using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ExpensesApp.Models
{
    
    public class Expense
    {
        [PrimaryKey, AutoIncrement] //SQLITE attribute
        public int id
        {
            get;
            set;
        }

        public string Name
        {
            get; 
            set;
        }

        public float Amount
        {
            get;
            set;
        }

        [MaxLength(25)] // max length of 25 characters
        public string Description
        {
            get;
            set;
        }

        public DateTime Date
        {
            get;
            set;
        }

        public string Category
        {
            get;
            set;
        }

        public Expense()
        {

        }

        // insert into the database
        public static int InsertExpense(Expense expense)
        {
            using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Expense>();
                return conn.Insert(expense);
            }
        }

        public static List<Expense> GetExpenses()
        {
            using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath)) //create a connection to SQLite
            {
                conn.CreateTable<Expense>();  // Expense table is created
                return conn.Table<Expense>().ToList(); // make the query converted into a list
            }
        }

        public static float TotalExpensesAmount()
        {
            using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath)) //create a connection to SQLite
            {
                conn.CreateTable<Expense>(); 
                return conn.Table<Expense>().ToList().Sum(e => e.Amount); // get all the expenses and the amount on those expenses and return that Sum
            }
        }

        public static List<Expense> GetExpenses(string category)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Expense>();
                return conn.Table<Expense>().Where(e => e.Category == category).ToList();
            }
        }

    }
}
