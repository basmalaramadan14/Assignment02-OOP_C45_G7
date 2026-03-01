


using System.Diagnostics.Metrics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assignment02_OOP
{
    #region Q1 Consider the following class
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
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}