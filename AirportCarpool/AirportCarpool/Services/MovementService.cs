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

        public List<Movement> FindMovementsByDateTime(DateTime departure)
        {
            //return (from m in _db.Movements
            //        where m.
            //        select u).SingleOrDefault<User>();

            return null;
        }
    }
}