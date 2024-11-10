using Microsoft.EntityFrameworkCore;
using ReviewsMicroservice.ApplicationCore.Contracts.Repository;
using ReviewsMicroservice.ApplicationCore.Entities;
using ReviewsMicroservice.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewsMicroservice.Infrastructure.Repository
{
    public class ReviewRepositoryAsync : BaseRepositoryAsync<Customer_Review>, IReviewRepositoryAsync
    {
        private readonly ReviewMicroserviceDbContext context;

        public ReviewRepositoryAsync(ReviewMicroserviceDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<int> ApproveAsync(int id)
        {
            var result = await context.Customer_Reviews.FirstOrDefaultAsync(x=>x.Id==id);
            if(result != null)
            {
                result.AdminApproval = "Approved";
                return context.SaveChanges();
            }
            throw new Exception("Approval Denied");
        }

        public async Task<IEnumerable<Customer_Review>> GetByProductIdAsync(int productId)
        {
            return await context.Customer_Reviews.Where(x=>x.Product_Id==productId).ToListAsync();
        }

        public async Task<IEnumerable<Customer_Review>> GetByUserIdAsync(int userId)
        {
            return await context.Customer_Reviews.Where(x => x.Customer_Id == userId).ToListAsync();
        }

        public async Task<IEnumerable<Customer_Review>> GetByYearAsync(int year)
        {
            return await context.Customer_Reviews.Where(x=>x.Order_Date.Year == year).ToListAsync();
        }

        public async Task<int> RejectAsync(int id)
        {
            var result = await context.Customer_Reviews.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                result.AdminApproval = "Rejected";
                return context.SaveChanges();
            }
            throw new Exception("Invalid Operation: Try again");
        }
    }
}
