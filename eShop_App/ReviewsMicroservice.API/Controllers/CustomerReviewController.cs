using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReviewsMicroservice.ApplicationCore.Contracts.Service;
using ReviewsMicroservice.ApplicationCore.Models.Request;

namespace ReviewsMicroservice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerReviewController : ControllerBase
    {
        private readonly IReviewServiceAsync reviewService;

        public CustomerReviewController(IReviewServiceAsync reviewService)
        {
            this.reviewService = reviewService;
        }
        [HttpGet]
        public async Task<IActionResult> GetReviews()
        {
            return Ok(await reviewService.GetAllReviewsAsync());
        }
        [HttpPost]
        public async Task<IActionResult> SaveCustomerReview(ReviewRequestModel model)
        {
            return Ok(await reviewService.SaveReviewAsync(model));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCustomerReview(ReviewRequestModel model)
        {
            return Ok(await reviewService.UpdateReviewAsync(model));
        }
        [HttpDelete]
        [Route("delete-{id}")]
        public async Task<IActionResult> DeleteCustomerReview(int id)
        {
            return Ok(await reviewService.DeleteReviewAsync(id));
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCustomerReviewById(int id)
        {
            return Ok(await reviewService.GetReviewByIdAsync(id));
        }
        [HttpGet]
        [Route("user/{userId}")]
        public async Task<IActionResult> GetCustomerReviewByUserId(int userId)
        {
            return Ok(await reviewService.GetReviewByUserIdAsync(userId));
        }
        [HttpGet]
        [Route("product/{productId}")]

        public async Task<IActionResult> GetCustomerReviewByProductId(int productId)
        {
            return Ok(await reviewService.GetReviewByProductIdAsync(productId));
        }
        [HttpGet]
        [Route("year/{year}")]
        public async Task<IActionResult> GetCustomerReviewByYear(int year)
        {
            return Ok(await reviewService.GetReviewsByYearAsync(year));
        }
        [HttpPut]
        [Route("approve/{id}")]
        public async Task<IActionResult> Approve(int id)
        {
            return Ok(await reviewService.ApproveAsync(id));
        }
        [HttpPut]
        [Route("reject/{id}")]
        public async Task<IActionResult> Reject(int id)
        {
            return Ok(await reviewService.RejectAsync(id));
        }
    }
}
