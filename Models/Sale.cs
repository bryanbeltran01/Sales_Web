﻿namespace Sales_Web.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public string Client { get; set; }
        public string Description { get; set; }
        public string Contact { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? PaidDate { get; set; }
        public bool IsPaid { get; set; }
    }
}
