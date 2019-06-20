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
    [Table("TB_T_DataOvertime")]
    public class DataOvertime : BaseModel
    {
        public double Pay_Overtime { get; set; }
        public DateTimeOffset Start_Overtime { get; set; }
        public DateTimeOffset End_Overtime { get; set; }
        public string Attachment_Overtime { get; set; }
        public string Description { get; set; }
        public string Activity { get; set; }
        public int Employee_Id { get; set; }

        [ForeignKey("Submited")]
        public int Submited_Id { get; set; }
        public Submited Submited { get; set; }

        [ForeignKey("TypeOvertime")]
        public int Type_Id { get; set; }
        public TypeOvertime TypeOvertime { get; set; }

        public DataOvertime(DataOvertimeVM dataovertimeVM)
        {
            this.Pay_Overtime = dataovertimeVM.Pay_Overtime;
            this.Start_Overtime = dataovertimeVM.Start_Overtime;
            this.End_Overtime = dataovertimeVM.End_Overtime;
            this.Attachment_Overtime = dataovertimeVM.Attachment_Overtime;
            this.Description = dataovertimeVM.Description;
            this.Activity = dataovertimeVM.Activity;
            this.Employee_Id = dataovertimeVM.Employee_Id;
            this.Submited_Id = dataovertimeVM.Submited_Id;
            this.Type_Id = dataovertimeVM.Type_Id;
            this.CreateDate = DateTime.Now.ToLocalTime();
        }

        public DataOvertime() { }

        public void Update(int id, DataOvertimeVM dataovertimeVM)
        {
            this.Id = id;
            this.Pay_Overtime = dataovertimeVM.Pay_Overtime;
            this.Start_Overtime = dataovertimeVM.Start_Overtime;
            this.End_Overtime = dataovertimeVM.End_Overtime;
            this.Attachment_Overtime = dataovertimeVM.Attachment_Overtime;
            this.Description = dataovertimeVM.Description;
            this.Activity = dataovertimeVM.Activity;
            this.Employee_Id = dataovertimeVM.Employee_Id;
            this.Submited_Id = dataovertimeVM.Submited_Id;
            this.Type_Id = dataovertimeVM.Type_Id;
            this.UpdateDate = DateTime.Now.ToLocalTime();
        }

        public void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now.LocalDateTime;
        }
    }
}
