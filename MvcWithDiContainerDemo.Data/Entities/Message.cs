using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcWithDiContainerDemo.Data.Entities
{
    [Table("Messages")]
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MessageId { get; set; }
      
        public string Author { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Subject { get; set; }
   
        public string Description { get; set; }

        public DateTime DatePosted { get; set; }       

    }
}
