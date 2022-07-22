using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Application.Services
{
   public class ReservaService : IReservaService
    {
        private static Random global = new Random();
        int ranNum = global.Next(100, 150);
     
        
        public Task<int> GenerarIdReservaAsync() => Task.FromResult(ranNum);
    }
}
