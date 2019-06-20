using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.Context;

namespace Common.Repository.Application
{
    public class TypeOvertimeRepository : ITypeOvertimeRepository
    {
        MyContext myContext = new MyContext();
        public List<TypeOvertime> Get()
        {
            var get = myContext.TypeOvertimes.Where(X => X.IsDelete == false).ToList();
            return get;
        }

        public TypeOvertime Get(int id)
        {
            var get = myContext.TypeOvertimes.Find(id);
            return get;
        }
    }
}
