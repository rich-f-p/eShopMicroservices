using OrderMicroservice.ApplicationCore.Contracts.Repository;
using OrderMicroservice.ApplicationCore.Entities;
using OrderMicroservice.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.Infrastructure.Repository
{
    public class User_AddressRepositoryAsync : BaseRepositoryAsync<User_Address>, IUser_AddressRepositoryAsync
    {
        private readonly OrderMicroDbContext context;

        public User_AddressRepositoryAsync(OrderMicroDbContext context) : base(context)
        {
            this.context = context;
        }

    }
}
