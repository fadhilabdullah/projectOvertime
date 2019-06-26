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
    public class TypeOvertimeService : ITypeOvertimeService
    {
        public bool status = false;

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

        public bool Insert(TypeOvertimeVM typeovertimeVM)
        {
            if (string.IsNullOrWhiteSpace(typeovertimeVM.Name_Type))
            {
                return status;
            }
            else
            {
                return typeOvertime.Insert(typeovertimeVM);
            }
        }

        public bool Update(int id, TypeOvertimeVM typeovertimeVM)
        {

            if (string.IsNullOrWhiteSpace(typeovertimeVM.Name_Type))
            {
                return status;
            }
            else
            {
                return typeOvertime.Update(id, typeovertimeVM);
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
                return typeOvertime.Delete(id);
            }
        }
    }
}
