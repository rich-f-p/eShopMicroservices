using Azure.Messaging.ServiceBus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PromotionsMicroservice.API.MessageService;
using PromotionsMicroservice.ApplicationCore.Contracts.Service;
using PromotionsMicroservice.ApplicationCore.Models.Request;

namespace PromotionsMicroservice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Promotion : ControllerBase
    {
        private readonly IPromotionServiceAsync promotionService;
        QueueService queue;
        public Promotion(IPromotionServiceAsync promotionService, IConfiguration configuration)
        {
            this.promotionService = promotionService;
            queue = new QueueService(configuration);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await promotionService.GetAllPromotions());
        }
        [HttpPost]
        public async Task<IActionResult> PostPromotion(PromotionRequestModel model)
        {
            //await queue.SendMessageAsync<PromotionRequestModel>(model, "promotionqueue");//testing:queue
            await queue.ScheduledMessage<string>(model.Name + ": starting.", "promotionqueue", model.Start_Date);
            await queue.ScheduledMessage<string>(model.Name + ": ended.", "promotionqueue", model.End_Date);
            
            return Ok(await promotionService.SavePromotion(model));
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePromotion(PromotionRequestModel model,int id)
        {
            if (model.Id == id)
            {
                return Ok(await promotionService.UpdatePromotion(model));
            }
            return BadRequest("Id doesnt match");
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetPromotionById(int id)
        {
            return Ok(await promotionService.GetPromotionById(id));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            return Ok(await promotionService.DeletePromotionById(id));
        }
        [HttpGet]
        [Route("PromotionByProductName")]
        public async Task<IActionResult> PromotionByProductName(string name)
        {
            return Ok(await promotionService.GetPromotionByProductName(name));
        }
        [HttpGet]
        [Route("activePromotions")]
        public async Task<IActionResult> activePromotions()
        {
            return Ok(await promotionService.GetActivePromotions());
        }


    }
}
