using AppMessageQueue.Domains.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppMessageQueue.Contracts
{
    public interface IUserService
    {
        Task<User> Get(int id, CancellationToken cancellationToken);
        Task<User> GetByEmailAddress(Guid applicationInstance, byte[] emailAddress, CancellationToken cancellationToken);
        Task<User> Save(User encryptedUser, CancellationToken cancellationToken);
    }
}
