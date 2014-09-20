using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AirportCarpool.Models;

namespace AirportCarpool.Services
{
    public class MovementService
    {
        AirportCarpoolDbContext _db = new AirportCarpoolDbContext();

        public MovementService()
        {

        }

        public List<Movement> FindMovementsByDateTime(DateTime arrival)
        {
            List<Movement> movements = null;
            IEnumerable<Carpool> carpools = from c in _db.Carpools
                        // greater than arrival-time minus 2 hours
                        where c.Status != CarpoolStatus.Full && (c.Arrival > arrival.Subtract(new TimeSpan(2, 0, 0)) && c.Arrival <= arrival)
                        select c;
            foreach (Carpool carpool in carpools)
            {
                foreach(Movement movement in carpool.Movements)
                {
                    movements.Add(movement);
                }
            }

            return movements;
        }
    }
}