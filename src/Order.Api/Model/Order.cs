using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Order.Api.Enums;
using Order.Api.Infrastructure;

namespace Order.Api.Model
{
    public class Order : IdentifiableEntity
    {
        [Required]
        public Guid UserId { get; private set; }
        
        [Required]
        public DateTime DateTime { get; private set; }

        [Required]
        public PaymentForm PaymentForm { get; private set; }
        
        [Required]
        public double FullPrice { get; private set; }

        [JsonIgnore]
        public virtual ICollection<Product> Products { get; set; }
        
        [NotMapped]
        [JsonIgnore]
        public OrderContext DbContext { get; set; }

        public Order()
        {
        }

        public Order(Guid userId, PaymentForm paymentForm)
        {
            UserId = userId;
            PaymentForm = paymentForm;
        }

        public async Task Create(List<Guid> productIds)
        {
            DateTime = new DateTime();
            
            if (productIds == null)
                return;
            
            Products = await DbContext.Products.Where(product => productIds.Contains(product.Id)).ToListAsync();

            if (!Products.Any())
                return;

            foreach (var productId in productIds)
                FullPrice += Products.First(product => productId == product.Id).Price;

            DbContext.Orders.Add(this);
            await DbContext.SaveChangesAsync();
        }
    }
}