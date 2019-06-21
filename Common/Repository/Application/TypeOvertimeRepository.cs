using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.Context;
using DataAccess.ViewModels;
using System.Data.Entity;

namespace Common.Repository.Application
{
    public class TypeOvertimeRepository : ITypeOvertimeRepository
    {
        MyContext myContext = new MyContext();
        bool status = false;

        public bool Delete(int id)
        {
            var get = Get(id);
            if (get != null)
            {
                get.Delete();
                var result = myContext.SaveChanges();
                if (result > 0)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            return status;
        }

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

        public List<TypeOvertime> GetSearch(string value)
        {
            var get = myContext.TypeOvertimes.Where
                (X => (X.OvertimeType.Contains(value) && X.IsDelete == false)).ToList();
            return get;
        }

        public bool Insert(TypeOvertimeVM typeovertimeVM)
        {
            var push = new TypeOvertime(typeovertimeVM);
            myContext.TypeOvertimes.Add(push);
            var result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            else
            {
                return status;
            }
            return status;
        }

        public bool Update(int id, TypeOvertimeVM typeovertimeVM)
        {
            var get = Get(id);
            get.Update(typeovertimeVM);
            myContext.Entry(get).State = EntityState.Modified;
            var result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            else
            {
                status = false;
            }
            return status;
        }
    }
}
