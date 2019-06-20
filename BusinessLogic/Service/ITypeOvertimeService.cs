using DataAccess.Models;
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
    }
}
