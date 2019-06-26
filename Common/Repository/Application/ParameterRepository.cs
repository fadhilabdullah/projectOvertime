using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.ViewModels;
using DataAccess.Context;
using System.Data.Entity;

namespace Common.Repository.Application
{
    public class ParameterRepository : IParameterRepository
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

        public List<Parameter> Get()
        {
            var get = myContext.Parameters.Where(X => X.IsDelete == false).ToList();
            return get;
        }

        public Parameter Get(int id)
        {
            var get = myContext.Parameters.Find(id);
            return get;
        }

        public List<Parameter> GetSearch(string values)
        {
            var get = myContext.Parameters.Where
               (X => (X.Pay.ToString().Contains(values) && X.IsDelete == false)).ToList();
            return get;
        }

        public bool Insert(ParameterVM parameterVM)
        {
            var push = new Parameter(parameterVM);
            myContext.Parameters.Add(push);
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

        public bool Update(int id, ParameterVM parameterVM)
        {
            var get = Get(id);
            get.Update(parameterVM);
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
