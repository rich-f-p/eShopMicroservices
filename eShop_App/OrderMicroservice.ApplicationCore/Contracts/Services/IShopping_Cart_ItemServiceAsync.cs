using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Contracts.Services
{
    public interface IShopping_Cart_ItemServiceAsync
    {
        Task<int> DeleteShoppingCartItemById(int id);
    }
}
