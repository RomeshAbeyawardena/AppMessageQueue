using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMessageQueue.Domains.Data
{
    public class User
    {
        public int Id { get; set; }
        public byte[] EmailAddress { get; set; }
        public virtual ICollection<ApplicationInstance> ApplicationInstances { get; set; }
        public bool Active { get; set; }
    }
}
