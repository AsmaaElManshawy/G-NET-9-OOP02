using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    public class Cinema
    {
        #region 3. Create a Cinema class

        /*
         * 3. Create a Cinema class that holds up to 20 tickets using a private array. 
         * Add the following: 
         *    a. Allow User To get and set tickets by index if the index is out of range, 
         *    the getter returns null and the setter does nothing. 
         *    
         *    b. Allow User To Get Movie By movieName that returns the first ticket found matching the given movie name, 
         *    or null if not found. 
         *    
         *    c. A method AddTicket(Ticket t) that adds a ticket to the first available (null) slot. 
         *    Returns true if added, false if the cinema is full.
         * 
         */

        // Private array to hold tickets
        private Ticket[] tickets = new Ticket[20];

        // Indexer
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
        // Get Movie By Name
        public Ticket GetMovieByName(string movieName)
        {
            foreach (var ticket in tickets)
            {
                if (ticket != null && ticket.MovieName.Equals(movieName, StringComparison.OrdinalIgnoreCase))
                    return ticket;
            }
            return null;
        }
        // Add Ticket
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

        #endregion

    }
}
