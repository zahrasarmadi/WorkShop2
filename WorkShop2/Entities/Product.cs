﻿namespace WorkShop2.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Color { get; set; }
    public int CategoryId { get; set; }
}
