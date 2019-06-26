using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.ViewModels;
using System.Data.Entity;
using DataAccess.Context;

namespace Common.Repository.Application
{
    public class StatusRepository : IStatusRepository
    {
        MyContext myContext = new MyContext();
        bool status;

        public bool Delete(int id)
        {
            var delete = Get(id);
            delete.Delete();
            myContext.Entry(delete).State = EntityState.Modified;
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

        public List<Status> Get()
        {
            var get = myContext.Statuses.Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public Status Get(int id)
        {
            var get = myContext.Statuses.Find(id);
            return get;
        }

        public List<Status> GetSearch(string values)
        {
            var get = myContext.Statuses.Where(x => x.Name_Status.Contains(values) && x.IsDelete == false).ToList();
            return get;
        }

        public bool Insert(StatusVM statusVM)
        {
            var push = new Status(statusVM);
            myContext.Statuses.Add(push);
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

        public bool Update(int id, StatusVM statusVM)
        {
            var put = Get(id);
            if (put != null)
            {
                put.Update(id, statusVM);
                myContext.Entry(put).State = EntityState.Modified;
                myContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
