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
        public DateTimeOffset Start_Overtime { get; set; }
        public DateTimeOffset End_Overtime { get; set; }
        public string Attachment_Overtime { get; set; }
        public string Description { get; set; }
        public string Activity { get; set; }
        public int Employee_Id { get; set; }
        public int Submited_Id { get; set; }
        public int Type_Id { get; set; }

        public DataOvertimeVM(double pay_overtime, DateTimeOffset start_overtime, DateTimeOffset end_overtime, string attachment_overtime, string description, 
                                string activity, int employee_id, int submited_id, int type_id)
        {
            this.Pay_Overtime = pay_overtime;
            this.Start_Overtime = start_overtime;
            this.End_Overtime = end_overtime;
            this.Attachment_Overtime = attachment_overtime;
            this.Description = description;
            this.Activity = activity;
            this.Employee_Id = employee_id;
            this.Submited_Id = submited_id;
            this.Type_Id = type_id;
        }

        public DataOvertimeVM() { }

        public  void Update(double pay_overtime, DateTimeOffset start_overtime, DateTimeOffset end_overtime, string attachment_overtime, string description,
                              string activity, int employee_id, int submited_id, int type_id)
        {
            this.Pay_Overtime = pay_overtime;
            this.Start_Overtime = start_overtime;
            this.End_Overtime = end_overtime;
            this.Attachment_Overtime = attachment_overtime;
            this.Description = description;
            this.Activity = activity;
            this.Employee_Id = employee_id;
            this.Submited_Id = submited_id;
            this.Type_Id = type_id;
        }
    }
}

