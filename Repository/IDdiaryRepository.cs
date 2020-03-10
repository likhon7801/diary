using Digital_Diary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Diary.Repository
{
    interface IDdiaryRepository:IRepository<Ddiary>
    {
        IEnumerable<Ddiary> GetAllDiary();
    }
}
