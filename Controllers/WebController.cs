using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebServices.Models;

namespace WebServices.Controllers
{
    public class WebController : ApiController
    {
        private ReservationRepository repo = ReservationRepository.Current;

        public IEnumerable<Reservation> GetAllReservations()
        {
            return repo.GetAll();
        }

        public Reservation GetReservation(int id)
        {
            return repo.Get(id);
        }

        [HttpPost]
        public Reservation CreateReservation(Reservation reservation)
        {
            return repo.Add(reservation);
        }

        [HttpPut]
        public bool UpdateReservation(Reservation reservation)
        {
            return repo.Update(reservation);
        }

        public void DeleteReservation(int id)
        {
            repo.Remove(id);
        }
    }
}
