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
    [Table("TB_M_Submited")]
    public class Submited : BaseModel
    {
        public string Name_Submited { get; set; }
        public string Status { get; set; }

        public Submited(SubmitedVM submitedVM)
        {
            this.Name_Submited = submitedVM.Name_Submited;
            this.Status = submitedVM.Status;
            this.CreateDate = DateTime.Now.ToLocalTime();
        }

        public Submited() { }

        public void Update(int id, SubmitedVM submitedVM)
        {
            this.Id = id;
            this.Name_Submited = submitedVM.Name_Submited;
            this.Status = submitedVM.Status;
            this.UpdateDate = DateTime.Now.ToLocalTime();
        }

        public void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now.LocalDateTime;
        }
    }
}
