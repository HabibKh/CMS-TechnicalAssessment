using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.UsersMicroservice.Domain.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}