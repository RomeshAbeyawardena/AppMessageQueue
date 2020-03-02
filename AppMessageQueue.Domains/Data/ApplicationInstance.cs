using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMessageQueue.Domains.Data
{
    public class ApplicationInstance
    {
        public int Id { get; set; }
        public Guid InstanceId { get; set; }
        public bool Active { get; set; }
    }
}
