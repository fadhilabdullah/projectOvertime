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
        public string OvertimeType { get; set; }
        public TypeOvertime(TypeOvertimeVM typeovertimeVM)
        {
            this.OvertimeType = typeovertimeVM.OvertimeType;
            this.CreateDate = DateTimeOffset.Now.LocalDateTime;
        }
        public TypeOvertime() { }
        public void Update(TypeOvertimeVM typeovertimeVM)
        {
            this.OvertimeType = typeovertimeVM.OvertimeType;
            this.UpdateDate = DateTimeOffset.Now.LocalDateTime;
        }
        public void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now.LocalDateTime;
        }
    }
}
