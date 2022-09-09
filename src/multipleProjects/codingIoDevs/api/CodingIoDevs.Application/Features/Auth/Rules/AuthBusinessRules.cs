using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using CodingIoDevs.Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Core.Security.Hashing;

namespace CodingIoDevs.Application.Features.Auth.Rules
{

    public class AuthBusinessRules
    {
        private readonly IUserRepository _userRepository;


        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> UserControlCorrespondingToEmailAddress(string email)
        {
            User? user = await _userRepository.GetAsync(u => u.Email == email);

            if (user == null)
                throw new BusinessException("Email or password is incorrect!");

            return user;
        }

        public async Task EmailAddressCanNotBeDuplicatedWhenInserted(string email)
        {
            IPaginate<User> user = await _userRepository.GetListAsync(u => u.Email == email);

            if (user.Items.Any())
                throw new BusinessException("The email address is already registered. Please login");
        }



        public Task PasswordVerification(string password, User user)
        {
            if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                throw new BusinessException("Email or password is incorrect!");

            return Task.CompletedTask;
        }
    }
}
