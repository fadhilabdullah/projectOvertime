using Core.Base;
using DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    [Table("TB_T_Submited")]
    public class Submited : BaseModel
    {
        public string Name_Submited { get; set; }

        [ForeignKey("Status")]
        public int Status_Id { get; set; }
        public Status Status { get; set; }

        [ForeignKey("DataOvertime")]
        public int DataOvertime_Id { get; set; }
        public DataOvertime DataOvertime { get; set; }

        public Submited(SubmitedVM submitedVM)
        {
            this.Name_Submited = submitedVM.Name_Submited;
            this.Status_Id = submitedVM.Status_Id;
            this.DataOvertime_Id = submitedVM.DataOvertime_Id;
            this.CreateDate = DateTime.Now.ToLocalTime();
        }

        public Submited() { }

        public void Update(int id, SubmitedVM submitedVM)
        {
            this.Name_Submited = submitedVM.Name_Submited;
            this.Status_Id = submitedVM.Status_Id;
            this.DataOvertime_Id = submitedVM.DataOvertime_Id;
            this.UpdateDate = DateTime.Now.ToLocalTime();
        }

        public void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now.LocalDateTime;
        }
    }
}
