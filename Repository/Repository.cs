using Digital_Diary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Digital_Diary.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        DiaryDataContext context;
        public Repository()
        {
            context = new DiaryDataContext();

        }
        public void Delete(int id)
        {
            context.Set<TEntity>().Remove(Get(id));
            context.SaveChanges();
        }

        public TEntity Get(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public void Insert(TEntity enity)
        {

            context.Set<TEntity>().Add(enity);
            context.SaveChanges();




        }

        public void Update(TEntity enity)
        {
            context.Entry(enity).State = EntityState.Modified;
            context.SaveChanges();
        }

    }
}