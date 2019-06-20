using DataAccess.Models;
using DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repository
{
    public interface ITypeOvertimeRepository
    {
        List<TypeOvertime> Get();
        TypeOvertime Get(int id);
    }
}
