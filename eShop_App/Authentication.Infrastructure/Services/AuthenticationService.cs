﻿using Authentication.ApplicationCore.Contracts.Repository;
using Authentication.ApplicationCore.Contracts.Services;
using Authentication.ApplicationCore.Entities;
using Authentication.ApplicationCore.Models.Request;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationServiceAsync
    {
        private readonly IMapper mapper;
        private readonly IUserRepositoryAsync userRepo;
        private readonly IUser_RoleRepositoryAsync u_RoleRepo;
        private readonly IRoleRepositoryAsync roleRepo;

        public AuthenticationService(IMapper mapper,IUserRepositoryAsync userRepo,IUser_RoleRepositoryAsync u_RoleRepo,IRoleRepositoryAsync roleRepo)
        {
            this.mapper = mapper;
            this.userRepo = userRepo;
            this.u_RoleRepo = u_RoleRepo;
            this.roleRepo = roleRepo;
        }
        public async Task<int> CustomerRegisterAsync(CustomerRegisterModel model)
        {
            return await userRepo.InsertAsync(mapper.Map<User>(model));
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await userRepo.DeleteAsync(id);
        }

        public async Task<IEnumerable<CustomerRegisterModel>> GetAllAsync()
        {
            return mapper.Map<IEnumerable<CustomerRegisterModel>>( await userRepo.GetAllAsync());
        }

        public async Task<CustomerRegisterModel> GetUserByIdAsync(int id)
        {
            return mapper.Map<CustomerRegisterModel>(await userRepo.GetByIdAsync(id));
        }

        public async Task<int> LoginAsync(LoginModel model)
        {
            return await userRepo.LoginAsync(model);
        }

        public async Task<int> RegisterAdminAsync(RegisterModel model)
        {
            var userId = await userRepo.InsertAsync(mapper.Map<User>(model));

            return userId;
        }

        public async Task<int> UpdateAsync(UpdateModel model)
        {
            return await userRepo.UpdateAsync(mapper.Map<User>(model));
        }
    }
}
