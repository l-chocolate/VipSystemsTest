﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VipSystemsTest.Model.Data;
using VipSystemsTest.Model.Entities;
using VipSystemsTest.Model.IRepository;

namespace VipSystemsTest.Model.Repository
{
    public class Repository<TEntidade>(MovControlDbContext dbContext) : IRepository<TEntidade> where TEntidade : class
    {
        public MovControlDbContext dbContext = dbContext;

        public TEntidade Add(TEntidade entidade)
        {
            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<TEntidade> AddedEntity = dbContext.Add(entidade);
            dbContext.SaveChanges();
            return AddedEntity.Entity;
        }
        public void Update(TEntidade entidade, int id)
        {
            TEntidade? currentEntidade = Get(id);
            if (currentEntidade != null)
            {
                dbContext.Entry<TEntidade>(currentEntidade).CurrentValues.SetValues(entidade);
                dbContext.SaveChanges();
            }
        }
        public TEntidade? Get(int id)
        {
            return dbContext.Find<TEntidade>(id);
        }
    }
}
