using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IComp.Core.Entities
{
    public class FeedBack : BaseEntity
    {
        public string AppUserId { get; set; }
        [Required]
        [StringLength(maximumLength:100)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [StringLength (maximumLength:1000)]
        public string Text { get; set; }
        [StringLength(maximumLength: 1000)]
        public string Answer { get; set; }
        public AppUser AppUser { get; set; }
    }
}
