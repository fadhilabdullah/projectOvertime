using Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace BusinessLogic.Service.Application
{
    public class TypeOvertimeService : ITypeOvertimeService
    {
        public TypeOvertimeService() { }
        
        public TypeOvertimeService(ITypeOvertimeRepository _typeOvertime)
        {
            typeOvertime = _typeOvertime;
        }
        private readonly ITypeOvertimeRepository typeOvertime;

        public List<TypeOvertime> Get()
        {
            return typeOvertime.Get();
        }

        public TypeOvertime Get(int id)
        {
            return typeOvertime.Get(id);
        }
    }
}
