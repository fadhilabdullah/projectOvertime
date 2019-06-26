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
    [Table("TB_M_TypeOvertime")]
    public class TypeOvertime : BaseModel
    {
        public string Name_Type { get; set; }
        public TypeOvertime(TypeOvertimeVM typeovertimeVM)
        {
            this.Name_Type = typeovertimeVM.Name_Type;
            this.CreateDate = DateTimeOffset.Now.LocalDateTime;
        }
        public TypeOvertime() { }
        public void Update(TypeOvertimeVM typeovertimeVM)
        {
            this.Name_Type = typeovertimeVM.Name_Type;
            this.UpdateDate = DateTimeOffset.Now.LocalDateTime;
        }
        public void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now.LocalDateTime;
        }
    }
}
