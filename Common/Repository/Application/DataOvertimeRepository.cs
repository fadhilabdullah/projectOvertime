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
    public class DataOvertimeRepository : IDataOvertimeRepository
    {
        MyContext myContext = new MyContext();
        bool status = false;

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

        public List<DataOvertime> Get()
        {
            var get = myContext.DataOvertimes.Include("TypeOvertime").Include("Submited").Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public DataOvertime Get(int id)
        {
            var get = myContext.DataOvertimes.Include("Submited").Include("TypeOvertime").SingleOrDefault(x => x.Id == id);
            return get;
        }

        public List<DataOvertime> GetSearch(string values)
        {
            var get = myContext.DataOvertimes.Include("Submited").Include("TypeOvertime").Where(x => (x.TypeOvertime.OvertimeType.Contains(values)|| (x.Submited.Name_Submited.Contains(values)) && x.IsDelete == false)).ToList();
            return get;
        }

        public bool Insert(DataOvertimeVM dataOvertimeVM)
        {
            var push = new DataOvertime(dataOvertimeVM);
            var getSubmitedId = myContext.Submiteds.Find(dataOvertimeVM.Submited_Id);
            push.Submited = getSubmitedId;
            var getTypeId = myContext.TypeOvertimes.Find(dataOvertimeVM.Type_Id);
            if (getSubmitedId != null)
            {
                push.TypeOvertime = getTypeId;
                myContext.DataOvertimes.Add(push);
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

        public bool Update(int id, DataOvertimeVM dataOvertimeVM)
        {
            var put = Get(id);
            var getSubmited = myContext.Submiteds.Find(dataOvertimeVM.Submited_Id);
            put.Submited = getSubmited;
            var getType = myContext.TypeOvertimes.Find(dataOvertimeVM.Type_Id);
            put.TypeOvertime = getType;
            put.Update(id, dataOvertimeVM);
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
        //var put = new DataOvertime(dataOvertimeVM);
        //var getSubmitedId = myContext.Submiteds.Find(dataOvertimeVM.Submited_Id);
        //put.Submited = getSubmitedId;
        //var getTypeId = myContext.TypeOvertimes.Find(dataOvertimeVM.Type_Id);
        //put.TypeOvertime = getTypeId;
        //put.Update(dataOvertimeVM);
        //myContext.Entry(put).State = EntityState.Modified;
        //var result = myContext.SaveChanges();
        //if (result > 0)
        //{
        //    status = true;
        //}
        //else
        //{
        //    status = false;
        //}
        //return status;
    }
    
}
