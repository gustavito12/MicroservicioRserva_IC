using Reservas.Domain.Model.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Infraestructure.MemoryRepository
{
    public class MemoryDatabase
    {
        private readonly List<Reserva> _reservas;

        public List<Reserva> Reservas
        {
            get { return _reservas; }
        }

        public MemoryDatabase()
        {
            _reservas = new List<Reserva>();
        }
    }
}
