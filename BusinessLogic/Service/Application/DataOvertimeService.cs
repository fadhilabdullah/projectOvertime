using Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace BusinessLogic.Service.Application
{
    public class DataOvertimeService : IDataOvertimeService
    {
        bool status = false;

        public DataOvertimeService() { }
        public DataOvertimeService(IDataOvertimeRepository _dataOvertime)
        {
            dataOvertime = _dataOvertime;
        }
        private readonly IDataOvertimeRepository dataOvertime;

        public List<DataOvertime> GetSearch(string values)
        {
            return dataOvertime.GetSearch(values);
        }

        public List<DataOvertime> Get()
        {
            return dataOvertime.Get();
        }

        public DataOvertime Get(int id)
        {
            return dataOvertime.Get(id);
        }

        public bool Insert(DataOvertimeVM dataOvertimeVM)
        {
            if (string.IsNullOrWhiteSpace(dataOvertimeVM.Activity))
            {
                return status;
            }
            else if (string.IsNullOrWhiteSpace(Convert.ToString(dataOvertimeVM.Start_Overtime)))
            {
                return status;
            }
            else if (string.IsNullOrWhiteSpace(Convert.ToString(dataOvertimeVM.End_Overtime)))
            {
                return status;
            }
            else if (string.IsNullOrWhiteSpace(dataOvertimeVM.Attachment_Overtime))
            {
                return status;
            }
            else if (string.IsNullOrWhiteSpace(Convert.ToString(dataOvertimeVM.Pay_Overtime)))
            {
                return status;
            }
            else
            {
                return dataOvertime.Insert(dataOvertimeVM);
            }
        }

        public bool Update(int id, DataOvertimeVM dataOvertimeVM)
        {
            if (string.IsNullOrWhiteSpace(dataOvertimeVM.Activity))
            {
                return status;
            }
            else if (string.IsNullOrWhiteSpace(Convert.ToString(dataOvertimeVM.Start_Overtime)))
            {
                return status;
            }
            else if (string.IsNullOrWhiteSpace(Convert.ToString(dataOvertimeVM.End_Overtime)))
            {
                return status;
            }
            else if (string.IsNullOrWhiteSpace(dataOvertimeVM.Attachment_Overtime))
            {
                return status;
            }
            else if (string.IsNullOrWhiteSpace(Convert.ToString(dataOvertimeVM.Pay_Overtime)))
            {
                return status;
            }
            else
            {
                return dataOvertime.Update(id, dataOvertimeVM);
            }
        }

        public bool Delete(int id)
        {
            if (string.IsNullOrWhiteSpace(Convert.ToString(id)))
            {
                return status;
            }
            else
            {
                return dataOvertime.Delete(id);
            }
        }
    }
}
