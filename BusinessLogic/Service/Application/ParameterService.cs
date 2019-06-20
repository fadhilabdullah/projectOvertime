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
    public class ParameterService : IParameterService
    {
        public ParameterService() { }
        bool status = false;
        public ParameterService(IParameterRepository _parameter)
        {
            parameter = _parameter;
        }
        private readonly IParameterRepository parameter;

        public List<Parameter> Get()
        {
            return parameter.Get();
        }

        public Parameter Get(int id)
        {
            return parameter.Get(id);
        }

        public bool Insert(ParameterVM parameterVM)
        {
            if (string.IsNullOrWhiteSpace(Convert.ToString(parameterVM.Long_Time)) ||
                string.IsNullOrWhiteSpace(Convert.ToString(parameterVM.Pay)))
            {
                return status;
            }
            else
            {
                return parameter.Insert(parameterVM);
            }
        }

        public bool Update(int id, ParameterVM parameterVM)
        {
            if (string.IsNullOrWhiteSpace(Convert.ToString(parameterVM.Long_Time)) ||
                string.IsNullOrWhiteSpace(Convert.ToString(parameterVM.Pay)))
            {
                return status;
            }
            else
            {
                return parameter.Update(id, parameterVM);
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
                return parameter.Delete(id);
            }
        }
    }
}
