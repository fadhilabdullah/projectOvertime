using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ViewModels
{
    public class StatusVM
    {
        public int Id { get; set; }
        public string Name_Status { get; set; }

        public StatusVM(string name_status)
        {
            this.Name_Status = name_status;
        }

        public StatusVM() { }

        public void Update(int id, string name_status)
        {
            this.Id = id;
            this.Name_Status = name_status;
        }
    }
}
