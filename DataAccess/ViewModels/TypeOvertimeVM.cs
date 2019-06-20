using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ViewModels
{
    public class TypeOvertimeVM
    {
        public int Id { get; set; }
        public string OvertimeType { get; set; }

        public TypeOvertimeVM(string overtimetype)
        {
            this.OvertimeType = overtimetype;
        }

        public TypeOvertimeVM() { }

        public void Update(int id, string overtimetype)
        {
            this.Id = id;
            this.OvertimeType = overtimetype;
        }
    }
}
