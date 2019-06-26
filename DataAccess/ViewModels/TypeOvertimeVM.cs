using Core.Base;
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
        public string Name_Type { get; set; }

        public TypeOvertimeVM(string nama_type)
        {
            this.Name_Type = nama_type;
        }

        public TypeOvertimeVM() { }

        public void Update(int id, string nama_type)
        {
            this.Id = id;
            this.Name_Type = nama_type;
        }
        
    }
}
