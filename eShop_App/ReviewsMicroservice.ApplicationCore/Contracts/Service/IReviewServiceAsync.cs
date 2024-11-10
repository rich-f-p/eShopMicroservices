using ReviewsMicroservice.ApplicationCore.Entities;
using ReviewsMicroservice.ApplicationCore.Models.Request;
using ReviewsMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewsMicroservice.ApplicationCore.Contracts.Service
{
    public interface IReviewServiceAsync
    {
        Task<IEnumerable<ReviewResponseModel>> GetAllReviewsAsync();
        Task<int> SaveReviewAsync(ReviewRequestModel model);
        Task<int> UpdateReviewAsync(ReviewRequestModel model);
        Task<int> DeleteReviewAsync(int id);
        Task<ReviewResponseModel> GetReviewByIdAsync(int id);
        Task<IEnumerable<ReviewResponseModel>> GetReviewByUserIdAsync(int id);
        Task<IEnumerable<ReviewResponseModel>> GetReviewByProductIdAsync(int id);
        Task<IEnumerable<ReviewResponseModel>> GetReviewsByYearAsync(int year);
        Task<int> ApproveAsync(int id);
        Task<int> RejectAsync(int id);

    }
}
