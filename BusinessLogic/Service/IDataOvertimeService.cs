using DataAccess.Models;
using DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service
{
    public interface IDataOvertimeService
    {
        List<DataOvertime> GetSearch(string values);
        List<DataOvertime> Get();
        DataOvertime Get(int id);
        List<TypeOvertime> GetTypeModule(string modulQuery);
        bool Insert(DataOvertimeVM dataOvertimeVM);
        bool Update(int id, DataOvertimeVM dataOvertimeVM);
        bool Delete(int id);
    }
}
