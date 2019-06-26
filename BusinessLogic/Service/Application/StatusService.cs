using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace BusinessLogic.Service.Application
{
    public class StatusService : IStatusService
    {
        bool information = false;

        public StatusService() { }
        public StatusService(IStatusService _status)
        {
            status = _status;
        }
        private readonly IStatusService status;
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Status> Get()
        {
            return status.Get();
        }

        public Status Get(int id)
        {
            return status.Get(id);
        }

        public List<Status> GetSearch(string values)
        {
            return status.GetSearch(values);
        }

        public bool Insert(StatusVM statusVM)
        {
            if (string.IsNullOrWhiteSpace(statusVM.Name_Status))
            {
                return information;
            }
            else
            {
                return status.Insert(statusVM);
            }
        }

        public bool Update(int id, StatusVM statusVM)
        {
            if (string.IsNullOrWhiteSpace(Convert.ToString(id)))
            {
                return information;
            }
            else
            {
                return status.Delete(id);
            }
        }
    }
}
