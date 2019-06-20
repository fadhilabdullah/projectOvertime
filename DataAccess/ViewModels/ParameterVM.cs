using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ViewModels
{
    public class ParameterVM
    {
        public int Id { get; set; }
        public DateTimeOffset Long_Time { get; set; }
        public double Pay { get; set; }

        public ParameterVM(DateTimeOffset time, double pay)
        {
            this.Long_Time = time;
            this.Pay = pay;
        }
        public ParameterVM() { }
        public void Update(int id, DateTimeOffset time, double pay)
        {
            this.Id = id;
            this.Long_Time = time;
            this.Pay = pay;
        }
    }
}
