using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMessageQueue.Domains.Dto
{
    public class User
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public Guid ApplicationInstance { get; set; }
    }
}
