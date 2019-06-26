using DataAccess.Models;
using DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service
{
    public interface IStatusService
    {
        List<Status> Get();
        Status Get(int id);
        List<Status> GetSearch(string values);
        bool Insert(StatusVM statusVM);
        bool Update(int id, StatusVM statusVM);
        bool Delete(int id);
    }
}
