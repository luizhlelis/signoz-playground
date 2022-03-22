using System;
using System.Collections.Generic;
using Order.Api.Enums;

namespace Order.Api.Dtos
{
    public class OrderDto
    {
        public Dictionary<Guid, int> ProductIdsQuantity { get; set; }
        
        public Guid UserId { get; set; }
        
        public PaymentForm PaymentForm { get; set; }
    }
}