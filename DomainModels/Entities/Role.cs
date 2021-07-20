using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModels.Entities
{
    public class Role
    {
        public Role()
        {
            CreatedDate = DateTime.Now;
            Users = new HashSet<User>();
        }
        [Key]
        public int RoleId { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [Required]
        public string Name { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(250)]
        [Required]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
