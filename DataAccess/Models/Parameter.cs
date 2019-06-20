using Core.Base;
using DataAccess.Models;
using DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    [Table("TB_M_Parameter")]
    public class Parameter : BaseModel
    {
        public DateTimeOffset Long_Time { get; set; }
        public double Pay { get; set; }

        public Parameter(ParameterVM parameterVM)
        {
            this.Long_Time = parameterVM.Long_Time;
            this.Pay = parameterVM.Pay;
            this.CreateDate = DateTimeOffset.Now.LocalDateTime;
        }
        public Parameter() { }
        public void Update(ParameterVM parameterVM)
        {
            this.Id = parameterVM.Id;
            this.Long_Time = parameterVM.Long_Time;
            this.Pay = parameterVM.Pay;
            this.UpdateDate = DateTimeOffset.Now.LocalDateTime;
        }
        public void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now.LocalDateTime;
        }
    }
}
