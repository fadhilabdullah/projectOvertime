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
    public class SubmitedService : ISubmitedService
    {
        bool status = false;

        public SubmitedService() { }
        public SubmitedService(ISubmitedRepository _submited)
        {
            submited = _submited;
        }
        private readonly ISubmitedRepository submited;

        public List<Submited> Get()
        {
            return submited.Get();
        }

        public Submited Get(int id)
        {
            return submited.Get(id);
        }

        public List<Submited> GetSearch(string values)
        {
            return submited.GetSearch(values);
        }

        public bool Insert(SubmitedVM submitedVM)
        {
            if (string.IsNullOrWhiteSpace(submitedVM.Name_Submited))
            {
                return status;
            }            
            else
            {
                return submited.Insert(submitedVM);
            }
        }

        public bool Update(int id, SubmitedVM submitedVM)
        {
            if (string.IsNullOrWhiteSpace(submitedVM.Name_Submited))
            {
                return status;
            }            
            else
            {
                return submited.Update(id, submitedVM);
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
                return submited.Delete(id);
            }
        }
    }
}
