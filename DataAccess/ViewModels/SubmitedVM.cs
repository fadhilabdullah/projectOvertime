using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ViewModels
{
    public class SubmitedVM
    {
        public int Id { get; set; }
        public string Name_Submited { get; set; }
        public string Status { get; set; }

        public SubmitedVM(string name_submited, string status)
        {
            this.Name_Submited = name_submited;
            this.Status = status;
        }

        public SubmitedVM() { }

        public void Update(int id, string name_submited, string status)
        {
            this.Id = id;
            this.Name_Submited = name_submited;
            this.Status = status;
        }
    }
}
