using ECommerce.Services.Basket.Services;
using ECommerce.Shared.Messages;
using ECommerce.Shared.Services;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Services.Basket.Consumer
{
    public class CourseNameChangedEventConsumer : IConsumer<CourseNameChangedEvent>
    {
        private readonly RedisService _redisService;
        private readonly IBasketService _basketService;
        private readonly ISharedIdentityService _sharedIdentityService;

        public CourseNameChangedEventConsumer(RedisService redisService,ISharedIdentityService sharedIdentityService,IBasketService basketService)
        {
            _redisService = redisService;
            _sharedIdentityService = sharedIdentityService;
            _basketService = basketService;
        }

        public async Task Consume(ConsumeContext<CourseNameChangedEvent> context)
        {
            var baskets = _basketService.GetAllBaskets().Result.Data;

            foreach (var basket in baskets)
            {
                var basketItems = basket.BasketItems.Where(x => x.CourseId == context.Message.CourseId).ToList();

                basketItems.ForEach(item =>
                {
                    item.CourseName = context.Message.UpdatedName;
                });

                await _basketService.SaveOrUpdate(basket);
            }
        }
    }
}
