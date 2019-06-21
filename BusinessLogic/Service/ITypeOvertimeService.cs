using DataAccess.Models;
using DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service
{
    public interface ITypeOvertimeService
    {
        List<TypeOvertime> Get();
        TypeOvertime Get(int id);
        bool Insert(TypeOvertimeVM typeovertimeVM);
        bool Update(int id, TypeOvertimeVM typeovertimeVM);
        bool Delete(int id);
    }
}
