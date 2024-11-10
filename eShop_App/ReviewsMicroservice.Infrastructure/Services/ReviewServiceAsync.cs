using AutoMapper;
using ReviewsMicroservice.ApplicationCore.Contracts.Repository;
using ReviewsMicroservice.ApplicationCore.Contracts.Service;
using ReviewsMicroservice.ApplicationCore.Entities;
using ReviewsMicroservice.ApplicationCore.Models.Request;
using ReviewsMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewsMicroservice.Infrastructure.Services
{
    public class ReviewServiceAsync : IReviewServiceAsync
    {
        private readonly IMapper mapper;
        private readonly IReviewRepositoryAsync reviewsRepo;

        public ReviewServiceAsync(IMapper mapper, IReviewRepositoryAsync reviewsRepo)
        {
            this.mapper = mapper;
            this.reviewsRepo = reviewsRepo;
        }

        public async Task<int> ApproveAsync(int id)
        {
            return await reviewsRepo.ApproveAsync(id);
        }

        public async Task<int> DeleteReviewAsync(int id)
        {
            return await reviewsRepo.DeleteAsync(id);
        }

        public async Task<IEnumerable<ReviewResponseModel>> GetAllReviewsAsync()
        {
            return mapper.Map<IEnumerable<ReviewResponseModel>>( await reviewsRepo.GetAllAsync());
        }

        public async Task<ReviewResponseModel> GetReviewByIdAsync(int id)
        {
            return mapper.Map<ReviewResponseModel>( await reviewsRepo.GetByIdAsync(id));
        }

        public async Task<IEnumerable<ReviewResponseModel>> GetReviewByProductIdAsync(int id)
        {
            return mapper.Map< IEnumerable<ReviewResponseModel>>( await reviewsRepo.GetByProductIdAsync(id));
        }

        public async Task<IEnumerable<ReviewResponseModel>> GetReviewByUserIdAsync(int id)
        {
            return mapper.Map<IEnumerable<ReviewResponseModel>>(await reviewsRepo.GetByUserIdAsync(id)); 
        }

        public async Task<IEnumerable<ReviewResponseModel>> GetReviewsByYearAsync(int year)
        {
            return mapper.Map<IEnumerable<ReviewResponseModel>>(await reviewsRepo.GetByYearAsync(year));
        }

        public async Task<int> RejectAsync(int id)
        { 
            return await reviewsRepo.RejectAsync(id);
        }

        public async Task<int> SaveReviewAsync(ReviewRequestModel model)
        {
            return await reviewsRepo.InsertAsync(mapper.Map<Customer_Review>(model));
        }

        public async Task<int> UpdateReviewAsync(ReviewRequestModel model)
        {
            return await reviewsRepo.UpdateAsync(mapper.Map<Customer_Review>(model));
        }
    }
}
