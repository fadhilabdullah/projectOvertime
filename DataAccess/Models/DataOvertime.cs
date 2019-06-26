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
        public DateTimeOffset Date { get; set; }
        public DateTimeOffset Start_Time { get; set; }
        public DateTimeOffset End_Time { get; set; }
        public string Attachment_Overtime { get; set; }
        public string Description { get; set; }
        public string Activity { get; set; }
        public int Employee_Id { get; set; }

        [ForeignKey("TypeOvertime")]
        public int Type_Id { get; set; }
        public TypeOvertime TypeOvertime { get; set; }

        public DataOvertime(DataOvertimeVM dataovertimeVM)
        {
            this.Pay_Overtime = dataovertimeVM.Pay_Overtime;
            this.Date = dataovertimeVM.Date;
            this.Start_Time = dataovertimeVM.Start_Time;
            this.End_Time = dataovertimeVM.End_Time;
            this.Attachment_Overtime = dataovertimeVM.Attachment_Overtime;
            this.Description = dataovertimeVM.Description;
            this.Activity = dataovertimeVM.Activity;
            this.Employee_Id = dataovertimeVM.Employee_Id;            
            this.Type_Id = dataovertimeVM.Type_Id;
            this.CreateDate = DateTime.Now.ToLocalTime();
        }

        public DataOvertime() { }

        public void Update(DataOvertimeVM dataovertimeVM)
        {
            this.Pay_Overtime = dataovertimeVM.Pay_Overtime;
            this.Date = dataovertimeVM.Date;
            this.Start_Time = dataovertimeVM.Start_Time;
            this.End_Time = dataovertimeVM.End_Time;
            this.Attachment_Overtime = dataovertimeVM.Attachment_Overtime;
            this.Description = dataovertimeVM.Description;
            this.Activity = dataovertimeVM.Activity;
            this.Employee_Id = dataovertimeVM.Employee_Id;            
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
