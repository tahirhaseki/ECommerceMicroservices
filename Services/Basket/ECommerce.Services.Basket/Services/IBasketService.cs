using ECommerce.Services.Basket.Dtos;
using ECommerce.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Services.Basket.Services
{
    public interface IBasketService
    {
        Task<Response<List<BasketDto>>> GetAllBaskets();
        Task<Response<BasketDto>> GetBasket(string userId);
        Task<Response<bool>> SaveOrUpdate(BasketDto basketDto);
        Task<Response<bool>> Delete(string userId);
    }
}
