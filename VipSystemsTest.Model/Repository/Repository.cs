using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VipSystemsTest.Model.IRepository;

namespace VipSystemsTest.Model.Repository
{
    internal class Repository<TEntidade> : IRepository<TEntidade> where TEntidade : class
    {
    }
}
