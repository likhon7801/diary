using Digital_Diary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Digital_Diary.Repository
{
    public class DdiaryRepository : Repository<Ddiary>, IDdiaryRepository
    {
        DiaryDataContext context;
        public DdiaryRepository()
        {
            context = new DiaryDataContext();
        }

        public IEnumerable<Ddiary> GetAllDiary()
        {
            return context.Set<Ddiary>().ToList().OrderBy(x => x.Status);
        }
    }
}