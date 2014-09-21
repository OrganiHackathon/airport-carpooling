using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AirportCarpool.Models;

namespace AirportCarpool.Services
{
    public class CarpoolService: IDisposable
    {
        AirportCarpoolDbContext _db = new AirportCarpoolDbContext();

        public CarpoolService()
        {

        }

        public List<Carpool> FindCarpoolsByDateTime(DateTime arrival)
        {

            DateTime arrivalMin2hours = arrival.AddHours(-2);

            List<Carpool> carpools = (from c in _db.Carpools
                                      // greater than arrival-time minus 2 hours
                                      where c.Status != CarpoolStatus.Full && (c.Arrival > arrivalMin2hours && c.Arrival <= arrival)
                                      select c).ToList<Carpool>();


            return carpools;
        }

        public Carpool FindCarpoolById(int Id)
        {

            return (from c in _db.Carpools
                            // greater than arrival-time minus 2 hours
                            where c.CarpoolId == Id
                            select c).SingleOrDefault<Carpool>();


        }

        public Movement FindMovementById(int Id)
        {

            return (from m in _db.Movements
                    // greater than arrival-time minus 2 hours
                    where m.MovementId == Id
                    select m).SingleOrDefault<Movement>();

            
        }

        public Carpool AddMovementToCarpool(Carpool carpool, Movement movement)
        {
            if (carpool != null && movement != null)
            {
                _db.Entry(carpool).State = EntityState.Modified;
                _db.SaveChanges();
            }
          
         
            return null;
        }



        public void Dispose()
        {
            _db.Dispose();
          
        }
    }
}