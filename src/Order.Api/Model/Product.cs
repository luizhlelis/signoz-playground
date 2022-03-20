using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Order.Api.Enums;

namespace Order.Api.Model
{
    [Index(nameof(Name), IsUnique = true)]
    public class Product : IdentifiableEntity
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; private set; }

        [Required]
        public double Price { get; private set; }

        public Product(Guid id, double price, string name)
        {
            Id = id;
            Price = price;
            Name = name;
        }
    }
}