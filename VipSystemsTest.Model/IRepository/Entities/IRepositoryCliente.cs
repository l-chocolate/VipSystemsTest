﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VipSystemsTest.Model.Entities;

namespace VipSystemsTest.Model.IRepository.Entities
{
    public interface IRepositoryCliente : IRepository<Cliente>
    {
        Cliente? GetByCPF(string CPF);
    }
}
