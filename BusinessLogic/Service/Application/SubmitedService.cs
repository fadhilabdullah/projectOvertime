using Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace BusinessLogic.Service.Application
{
    public class SubmitedService : ISubmitedService
    {
        public SubmitedService() { }
        public SubmitedService(ISubmitedRepository _submitedRepository)
        {
            submitedRepository = _submitedRepository;
        }
        private readonly ISubmitedRepository submitedRepository;

        public List<Submited> Get()
        {
            return submitedRepository.Get();
        }

        public Submited Get(int id)
        {
            return submitedRepository.Get(id);
        }
    }
}
