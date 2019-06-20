using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.Context;

namespace Common.Repository.Application
{
    public class SubmitedRepository : ISubmitedRepository
    {
        MyContext myContext = new MyContext();

        public List<Submited> Get()
        {
            var get = myContext.Submiteds.Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public Submited Get(int id)
        {
            var get = myContext.Submiteds.Find(id);
            return get; 
        }
    }
}
