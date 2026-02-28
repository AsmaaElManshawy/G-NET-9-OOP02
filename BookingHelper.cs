using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    public static class BookingHelper
    {
        #region 4. Create a static utility class
        /*
         * 
         * 4. Create a static utility class called BookingHelper with the following static methods: 
         *     a. double CalcGroupDiscount(int numberOfTickets, double pricePerTicket) 
         *     That returns total price with a 10% discount if the group has 5 or more tickets, 
         *     otherwise returns the full total. 
         *     
         *     b. string GenerateBookingReference() That returns a unique string each time it is called 
         *     (e.g., "BK-1", "BK-2", "BK-3", ...). Use a private static counter internally.
         * 
         */
        // Private static counter for generating unique booking references
        private static int bookingCounter = 0;
        // a. Calculate group discount
        public static double CalcGroupDiscount(int numberOfTickets, double pricePerTicket)
        {
            double total = numberOfTickets * pricePerTicket;

            if (numberOfTickets >= 5)
                return total * 0.9; // 10% discount

            return total;
        }
        // b. Generate unique booking reference
        public static string GenerateBookingReference()
        {
            bookingCounter++;
            return $"BK-{bookingCounter}";
        }

        #endregion

    }
}
