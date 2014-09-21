using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirportCarpool.Models
{

    public enum CarpoolStatus
    {
        Full,
        New
    }

    public class Carpool
    {
        public int CarpoolId { get; set; }
        public int MaxSeats { get; set; }
        public int MaxLuggage { get; set; }
        public int MaxKm { get; set; }
        public DateTime Arrival { get; set; }
        public CarpoolStatus Status { get; set; }
        public virtual IList<Movement> Movements { get; set; }


        public int SeatsLeft()
        {
            int viTotalSeatsTaken = 0;

            foreach (Movement movement in Movements)
            {
                viTotalSeatsTaken += movement.Seats;
            }


            return (MaxSeats - viTotalSeatsTaken);
        }

        public string SeatsLeftString()
        {
            int count = SeatsLeft();
            if (count > 0)
                return "Only " + SeatsLeft().ToString() + " left, hurry up!";
            else
                return "No seats left";
        }


        public string getColor()
        {
            int viTotalSeatsLeft = SeatsLeft();

            if (viTotalSeatsLeft <= 0)
            {
                return "#ef1010";
            }
            else if (viTotalSeatsLeft == 1)
            {
                return "#ff9730";
            }
            else
            {
                return "#33912d";
            }
            
        }
    }
}