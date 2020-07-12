﻿using Microsoft.EntityFrameworkCore;
using ShoppingCart.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Data.Repositories
{
    /// <summary>
    /// Generic Repository implementation
    /// </summary>
    public class Repository<T> : IRepository<T> where T : class
    {
        private ShoppingCartDbContext context = null;
        private DbSet<T> table = null;

        public Repository()
        {
            this.context = new ShoppingCartDbContext();
            table = context.Set<T>();
        }
        public Repository(ShoppingCartDbContext context)
        {
            this.context = context;
            table = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }
        public T GetById(object id)
        {
            return table.Find(id);
        }
        public void Insert(T obj)
        {
            table.Add(obj);
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
