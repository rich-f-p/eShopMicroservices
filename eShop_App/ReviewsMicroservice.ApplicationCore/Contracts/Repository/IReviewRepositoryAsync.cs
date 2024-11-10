using ProductMicroservice.ApplicationCore.Contracts.Repository;
using ReviewsMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewsMicroservice.ApplicationCore.Contracts.Repository
{
    public interface IReviewRepositoryAsync :IRepositoryAsync<Customer_Review>
    {
        Task<IEnumerable<Customer_Review>> GetByUserIdAsync(int userId);
        Task<IEnumerable<Customer_Review>> GetByProductIdAsync(int productId);
        Task<IEnumerable<Customer_Review>> GetByYearAsync(int year);
        Task<int> ApproveAsync(int id);
        Task<int> RejectAsync(int id);
    }
}
