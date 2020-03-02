using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMessageQueue.Domains.ViewModels
{
    public class RegisterViewModel
    {
        public int Id { get; internal set; }
        public string EmailAddress { get; internal set; }
        public Guid ApplicationInstance { get; internal set; }
    }
}
