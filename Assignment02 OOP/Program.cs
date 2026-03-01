
 
    using System;

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

    #region Q04
    //A)What does the `static` keyword mean on `TotalOrders`? 
    //Belongs to class
    // Shared among all objects
    //Single value

    // How is it different from the `Item` field?
    // Belongs to object
    //Unique for each object
    // Each object has its own value

    //B) Can a static method inside `Order` access the `Item` field directly?
    //No

    //Why or why not?
    //Item is a non-static field(belongs to objects).
    //A static method belongs to the class, not to a specific object.
    //Static methods cannot directly access non-static members.


    #endregion

    #region  Part 02 : Practical

    public enum TicketType
        {
            Standard,
            VIP,
            IMAX
        }
        public struct SeatLocation
        {
            public char Row;
            public int Number;
        }
        public class Ticket
        {
            private static int ticketCounter = 0;

            public int TicketId { get; private set; }
            public string MovieName { get; set; }
            public TicketType Type { get; set; }
            public SeatLocation Seat { get; set; }

            private double price;
            public double Price
            {
                get { return price; }
                set
                {
                    if (value > 0)
                        price = value;
                }
            }
            public double PriceAfterTax
            {
                get { return Price + (Price * 0.14); }
            }
            public Ticket(string movieName, TicketType type, SeatLocation seat, double price)
            {
                MovieName = movieName;
                Type = type;
                Seat = seat;
                Price = price;

                ticketCounter++;
                TicketId = ticketCounter;
            }
            public static int GetTotalTicketsSold()
            {
                return ticketCounter;
            }
        }
        public class Cinema
        {
            private Ticket[] tickets = new Ticket[20];

            public Ticket this[int index]
            {
                get
                {
                    if (index >= 0 && index < tickets.Length)
                        return tickets[index];
                    return null;
                }
                set
                {
                    if (index >= 0 && index < tickets.Length)
                        tickets[index] = value;
                }
            }
            public Ticket GetMovie(string movieName)
            {
                foreach (var ticket in tickets)
                {
                    if (ticket != null && ticket.MovieName.Equals(movieName, StringComparison.OrdinalIgnoreCase))
                        return ticket;
                }
                return null;
            }
            public bool AddTicket(Ticket t)
            {
                for (int i = 0; i < tickets.Length; i++)
                {
                    if (tickets[i] == null)
                    {
                        tickets[i] = t;
                        return true;
                    }
                }
                return false;
            }
        }
        public static class BookingHelper
        {
            private static int counter = 0;

            public static double CalcGroupDiscount(int numberOfTickets, double pricePerTicket)
            {
                double total = numberOfTickets * pricePerTicket;

                if (numberOfTickets >= 5)
                    return total * 0.9; // 10% discount
                return total;
            }
            public static string GenerateBookingReference()
            {
                counter++;
                return "BK-" + counter;
            }
        }
        internal class Program
        {
            static void Main()
            {
                Cinema cinema = new Cinema();

                Console.WriteLine("==========Ticket Booking==========\n");

                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine($"\nEnter data for Ticket {i + 1}:");
                    Console.Write("Movie Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Ticket Type (0-Standard, 1-VIP, 2-IMAX): ");
                    TicketType type = (TicketType)int.Parse(Console.ReadLine());
                    Console.Write("Seat Row (A-Z): ");
                    char row = char.Parse(Console.ReadLine());
                    Console.Write("Seat Number: ");
                    int number = int.Parse(Console.ReadLine());
                    Console.Write("Price: ");
                    double price = double.Parse(Console.ReadLine());
                    SeatLocation seat = new SeatLocation { Row = row, Number = number };
                    Ticket ticket = new Ticket(name, type, seat, price);
                    cinema.AddTicket(ticket);
                }
                Console.WriteLine("\n=========All Tickets=========\n");

                for (int i = 0; i < 3; i++)
                {
                    Ticket t = cinema[i];
                    if (t != null)
                    {
                        Console.WriteLine($"Ticket #{t.TicketId}");
                        Console.WriteLine($"{t.MovieName} | {t.Type} |");
                        Console.WriteLine($"Seat: {t.Seat.Row}-{t.Seat.Number} |");
                        Console.WriteLine($"Price: {t.Price} EGP |");
                        Console.WriteLine($"After Tax: {t.PriceAfterTax:F1} EGP\n");
                    }
                }

                Console.WriteLine("==========Search by Movie==========");

                Console.Write("Enter movie name to search: ");
                string search = Console.ReadLine();
                Ticket found = cinema.GetMovie(search);

                if (found != null)
                {
                    Console.WriteLine($"Found: Ticket #{found.TicketId} | {found.MovieName} | {found.Type} |");
                    Console.WriteLine($"Seat: {found.Seat.Row}-{found.Seat.Number} |");
                    Console.WriteLine($"Price: {found.Price} EGP");
                }
                else
                {
                    Console.WriteLine("Not found");
                }

                Console.WriteLine("\n==========Statistics==========");

                Console.WriteLine($"Total Tickets Sold: {Ticket.GetTotalTicketsSold()}");
                Console.WriteLine($"Booking Reference 1: {BookingHelper.GenerateBookingReference()}");
                Console.WriteLine($"Booking Reference 2: {BookingHelper.GenerateBookingReference()}");
                double groupDiscount = BookingHelper.CalcGroupDiscount(5, 80);
                Console.WriteLine($"Group Discount (5 tickets x 80 EGP): {groupDiscount} EGP (10% off applied)");
            }
        }
            #endregion
}