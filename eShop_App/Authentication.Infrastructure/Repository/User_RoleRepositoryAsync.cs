﻿using Authentication.ApplicationCore.Contracts.Repository;
using Authentication.ApplicationCore.Entities;
using Authentication.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Infrastructure.Repository
{
    public class User_RoleRepositoryAsync : BaseRepositoryAsync<User_Role>, IUser_RoleRepositoryAsync
    {
        public User_RoleRepositoryAsync(AuthenticationMicroserviceDbContext context) : base(context)
        {
        }
    }
}