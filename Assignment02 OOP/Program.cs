


using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assignment02_OOP
{
    #region Q01 Consider the following class
    //A) Identify at least two problems with this design from an encapsulation perspective.

    //1-Public fields(Owner and Balance)Both fields are public, which means any other class can directly modify them.
    //For example:
    //account.Balance = -50000;

    //2-No validation when modifying Balance Because Balance is public,
    //someone can change it without using Withdraw() That means:
    //No check for negative values
    //No check for overdraft
    //No protection of business rules

    //B) Describe how you would fix this class

    //Make fields private:
    /*private string owner;
    private double balance;*/
    //Use properties to control access.
    //Add validation inside methods (check if amount > 0 and sufficient balance).

    //C)

    //1-Breaks encapsulation – External code can change internal data without restriction.
    //2-No control or validation – You cannot enforce business rules.
    //3-Reduces security and data integrity – The object can enter an invalid state.
    #endregion

    #region Q02 What is the difference between a field and a property
    //property:

    //Controlled access 
    //Can validate
    //Enforces encapsulation
    //Example: public int Age { get; set; }

    //Field:
    //Direct data storage
    //No validation
    //Breaks encapsulation
    //Example: private int age;

    //Yes properties can contain logic inside the get and set accessors.


    //Validate
    //public int Age
    //{
    //    get { return age; }
    //    set
    //    {
    //        if (value > 0)
    //            age = value;
    //    }
    //}

    //Calculate values
    //public double SalaryAfterIncrease
    //{
    //    get {  return Salary + (Salary * 0.10); }
    //}
    #endregion

    #region Q03

    //A)It is called an Indexer.
    //It allows objects of a class to be accessed like an array.
    //It provides a way to access elements using an index.

    //Example:
    //register[0] = "Basmala";

    //B)What happens if someone writes `register[10] = "Ali";` ?
    //The array names has size 5 (indexes 0 to 4).
    //Index 10 is out of range.
    //This will cause an IndexOutOfRangeException (runtime error).

    //How would you make the indexer safer?

    //To make the indexer safer, we validate the index before accessing data
    //return a safe default value if the index is out of range.

    //c) Can a class have more than one indexer?
      //Yes
       //public string this[int index] { get; set; }
       //public string this[string name] { get; set; }

    //This is useful in:
      //Dictionaries
      //Data collections
   
    #endregion Q03
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}