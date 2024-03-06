using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VipSystemsTest.Model.Entities;

namespace VipSystemsTest.Model.IRepository
{
    public interface IRepository<TEntidade> where TEntidade : class
    {
        void Add(TEntidade entidade);
        TEntidade? Get(int id);
        void Update(TEntidade entidade, int id);
    }
}
