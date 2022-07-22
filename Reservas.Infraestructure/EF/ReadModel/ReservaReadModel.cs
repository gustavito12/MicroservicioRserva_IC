using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Infraestructure.EF.ReadModel
{
    public class ReservaReadModel
    {
        //[Key]
        public Guid Id{ get; set; }
        public int IdReserva { get; set; }
        public ICollection<DetalleReservaReadModel> Detalle { get; set; }
    }
}
