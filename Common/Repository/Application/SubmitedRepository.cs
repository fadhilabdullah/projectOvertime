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
    public class SubmitedRepository : ISubmitedRepository
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

        public List<Submited> Get()
        {
            var get = myContext.Submiteds.Include("DataOvertime").Include("Status").Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public Submited Get(int id)
        {
            var get = myContext.Submiteds.Include("DataOvertime").Include("Status").SingleOrDefault(x => x.Id == id);
            return get;
        }

        public List<Submited> GetSearch(string values)
        {
            var get = myContext.Submiteds.Include("DataOvertime").Include("Status").Where(x => (x.Status.Name_Status.Contains(values) || (Convert.ToString(x.DataOvertime.Id).Contains(values)) && x.IsDelete == false)).ToList();
            return get;
        }

        public bool Insert(SubmitedVM submitedVM)
        {
            var push = new Submited(submitedVM);
            var getDataOvertimeId = myContext.DataOvertimes.Find(submitedVM.DataOvertime_Id);
            push.DataOvertime = getDataOvertimeId;
            var getStatusId = myContext.Statuses.Find(submitedVM.Status_Id);
            if (getStatusId != null)
            {
                push.Status = getStatusId;
                myContext.Submiteds.Add(push);
                var result = myContext.SaveChanges();
                if (result > 0)
                {
                    status = true;
                    return status;
                }
                else
                {
                    return status;
                }
            }
            else
            {
                return status;
            }
        }

        public bool Update(int id, SubmitedVM submitedVM)
        {
            var put = Get(id);
            var getDataOvertime = myContext.DataOvertimes.Find(submitedVM.DataOvertime_Id);
            put.DataOvertime = getDataOvertime;
            var getStatus = myContext.Statuses.Find(submitedVM.Status_Id);
            put.Status = getStatus;
            put.Update(id, submitedVM);
            myContext.Entry(put).State = EntityState.Modified;
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
