﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Domain.Repositories
{
    public interface IUnitOfWorks
    {
        Task Commit();
    }
}
