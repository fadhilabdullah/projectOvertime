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
    [Table("TB_M_Status")]
    public class Status : BaseModel
    {
            public string Name_Status { get; set; }

            public Status(StatusVM StatusVM)
            {
                this.Name_Status = StatusVM.Name_Status;
                this.CreateDate = DateTimeOffset.Now.LocalDateTime;
            }
            public Status() { }
            public void Update(int id, StatusVM statusVM)
            {
                this.Name_Status = statusVM.Name_Status;
                this.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            }
            public void Delete()
            {
                this.IsDelete = true;
                this.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            }
        }    
}
