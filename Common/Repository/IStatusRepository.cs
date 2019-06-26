using DataAccess.Models;
using DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repository
{
    public interface IStatusRepository
    {
        List<Status> Get();
        Status Get(int id);
        List<Status> GetSearch(string values);
        bool Insert(StatusVM statusVM);
        bool Update(int id, StatusVM statusVM);
        bool Delete(int id);
    }
}
