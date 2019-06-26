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
        public int Status_Id { get; set; }
        public int DataOvertime_Id { get; set; }

        public SubmitedVM(string name_submited, string status, int status_id, int dataOvertime_id)
        {
            this.Name_Submited = name_submited;
            this.Status_Id = status_id;
            this.DataOvertime_Id = dataOvertime_id;
        }

        public SubmitedVM() { }

        public void Update(int id, string name_submited, int status_id, int dataOvertime_id)
        {
            this.Id = id;
            this.Name_Submited = name_submited;
            this.Status_Id = status_id;
            this.DataOvertime_Id = dataOvertime_id;
        }
    }
}
