using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ViewModels
{
    public class DataOvertimeVM 
    {
        public int Id { get; set; }
        public double Pay_Overtime { get; set; }
        public DateTimeOffset Date { get; set; }
        public DateTimeOffset Start_Time { get; set; }
        public DateTimeOffset End_Time { get; set; }
        public string Attachment_Overtime { get; set; }
        public string Description { get; set; }
        public string Activity { get; set; }
        public int Employee_Id { get; set; }        
        public int Type_Id { get; set; }

        public DataOvertimeVM(double pay_overtime, DateTimeOffset date, DateTimeOffset start_time, DateTimeOffset end_time, string attachment_overtime, string description, 
                                string activity, int employee_id, int type_id)
        {
            this.Employee_Id = employee_id;
            this.Date = date;
            this.Pay_Overtime = pay_overtime;
            this.Start_Time = start_time;
            this.End_Time = end_time;
            this.Type_Id = type_id;
            this.Attachment_Overtime = attachment_overtime;
            this.Description = description;
            this.Activity = activity;
        }

        public DataOvertimeVM() { }

        public  void Update(int id, double pay_overtime, DateTimeOffset date, DateTimeOffset start_time, DateTimeOffset end_time, string attachment_overtime, string description,
                              string activity, int employee_id, int type_id)
        {
            this.Id = id;
            this.Employee_Id = employee_id;
            this.Date = date;
            this.Pay_Overtime = pay_overtime;
            this.Start_Time = start_time;
            this.End_Time = end_time;
            this.Type_Id = type_id;
            this.Attachment_Overtime = attachment_overtime;
            this.Description = description;
            this.Activity = activity;
        }
    }
}

