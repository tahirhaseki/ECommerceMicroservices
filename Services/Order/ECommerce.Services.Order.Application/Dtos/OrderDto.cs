using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.Order.Application.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public AddressDto Address { get; set; }
        public string BuyerId { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
}
