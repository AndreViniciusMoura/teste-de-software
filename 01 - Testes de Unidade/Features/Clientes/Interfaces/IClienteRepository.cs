﻿using Features.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Features.Clientes.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Cliente ObterPorEmail(string email);
    }
}
