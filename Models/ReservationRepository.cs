using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServices.Models
{
    public class ReservationRepository
    {
        private static ReservationRepository repo = new ReservationRepository();

        //To ensure there is some persistence b/w requests,
        //create a static instance of this class, accessible through the Current property:
        public static ReservationRepository Current
        {
            get
            {
                return repo;
            }
        }

        private List<Reservation> data = new List<Reservation>
        {
            new Reservation {ReservationID=1, ClientName="Andrew", Location="Board Room"},
            new Reservation {ReservationID=2, ClientName="Jackie", Location="Lecture Hall"},
            new Reservation {ReservationID=3, ClientName="Russell", Location="Meeting Room"},
        };

        public IEnumerable<Reservation> GetAll()
        {
            return data;
        }

        public Reservation Get(int id)
        {
            return data.Where(r => r.ReservationID == id).FirstOrDefault();
        }

        public Reservation Add(Reservation reservation)
        {
            reservation.ReservationID = data.Count + 1;
            data.Add(reservation);
            return reservation;
        }

        public void Remove(int id)
        {
            Reservation reservation = Get(id);
            if (reservation != null)
            {
                data.Remove(reservation);
            }
        }

        public bool Update(Reservation reservation)
        {
            Reservation storedReservation = Get(reservation.ReservationID);
            if(storedReservation != null)
            {
                storedReservation.ClientName = reservation.ClientName;
                storedReservation.Location = reservation.Location;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}