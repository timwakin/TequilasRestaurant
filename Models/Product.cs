﻿namespace TequilasRestaurant.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; } //A product belongs to a category 
        public ICollection<OrderItem> OrderItems { get; set; } //A product can be ina many order items 
        public ICollection<ProductIngredient>? ProductIngredients { get; set; }
    }
}