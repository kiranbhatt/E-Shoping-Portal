using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModels.Entities
{
    public class Cart
    {
        public Cart()
        {
            Items = new HashSet<CartItem>();
            CreatedDate = DateTime.Now;
        }
        [Key]
        public int CartId { get; set; }
        public decimal MyProperty { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public virtual ICollection<CartItem> Items { get; set; }
        public virtual User User { get; set; }
    }
}
