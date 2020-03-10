using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Diary.Repository
{
    interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
        void Insert(TEntity enity);
        void Update(TEntity enity);
        void Delete(int id);


    }
}
