using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    public class Ticket
    {
        #region 1. Refactor the Ticket class
        /*
         * 
         * 1. Refactor the Ticket class to use proper encapsulation: 
         * 
         *    a. Create public properties for each field with the following validation rules: 
         *    
         *       • MovieName : cannot be null or empty. If an invalid value is set, keep the previous value.
         *       
         *       • Type : use the TicketType enum from Assignment 01 (no special validation needed).
         *       
         *       • Seat : use the SeatLocation struct from Assignment 01 (no special validation needed). 
         *       
         *       • Price : must be greater than 0. If an invalid value is set, keep the previous value.
         *       
         *    b. Add property PriceAfterTax that returns the price with 14% tax included (calculated, not stored).
         */

        // Fields
        private string movieName;
        public TicketType Type { get; set; }
        public SeatLocation Seat { get; set; }

        private double price;

        // Properties with validation

        public string MovieName
        {
            get { return movieName; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    movieName = value;
            }
        }

        public double Price
        {
            get { return price; }
            set
            {
                if (value > 0)
                    price = value;
            }
        }

        // Calculated property PriceAfterTax
        public double PriceAfterTax
        {
            get { return Price * 1.14; } // calculated, not stored
        }

        #endregion


        #region 2. Add a static field and a static method to the Ticket class
        /*
         *2. Add a static field and a static method to the Ticket class: 
         *  a. Add a ’ticketCounter’ field that starts at 0. 
         *  
         *  b. Add a ‘TicketId’ property. Each ticket gets a unique ID automatically when created 
         *  (increment ticketCounter in the constructor and assign it to the ID). 
         *  
         *  c. Add a ‘GetTotalTicketsSold()’ method that returns the current value of ticketCounter.
         *
         */

        // Static counter
        private static int ticketCounter = 0;


        // Ticket ID
        public int TicketId { get; }

        // Constructor
        public Ticket(string movieName, TicketType type, SeatLocation seat, double price)
        {
            ticketCounter++;
            TicketId = ticketCounter;

            MovieName = movieName;
            Type = type;
            Seat = seat;
            Price = price;
        }
        // Static method to get total tickets sold
        public static int GetTotalTicketsSold()
        {
            return ticketCounter;
        }

        #endregion

        // 5 - b) Print Ticket showing: TicketId, MovieName, Type, Seat, Price, and PriceAfterTax.
        public override string ToString()
        {
            return $"Ticket #{TicketId} | {MovieName} | {Type} | Seat: {Seat} | Price: {Price} EGP | After Tax: {PriceAfterTax:F2} EGP";
        }

    }
}
