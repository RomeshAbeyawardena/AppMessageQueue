using AppMessageQueue.Contracts;
using AppMessageQueue.Domains.Data;
using DNI.Shared.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppMessageQueue.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private IQueryable<User> DefaultQuery => _userRepository.Query(user => user.Active, false);
        public async Task<User> Get(int id, CancellationToken cancellationToken)
        {
            return await _userRepository.Find(false, cancellationToken, id);
        }

        public async Task<User> GetByEmailAddress(Guid applicationInstanceGuid, byte[] emailAddress, CancellationToken cancellationToken)
        {
            var emailAddressArray = emailAddress.ToArray();
            var query = from user in DefaultQuery
                        where user.EmailAddress == emailAddressArray
                            && user.ApplicationInstances.Any(applicationInstance => 
                            applicationInstance.InstanceId == applicationInstanceGuid)
                        select user;

            return await query.SingleOrDefaultAsync();
        }

        public async Task<User> Save(User user, CancellationToken cancellationToken)
        {
            return await _userRepository.SaveChanges(user, cancellationToken: cancellationToken);
        }

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
    }
}
