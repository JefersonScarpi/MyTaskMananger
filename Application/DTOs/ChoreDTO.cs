using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ChoreDTO
    {
        public int Id { get; set; }
        
        [MinLength(3)]
        [MaxLength(20)]
        [Required(ErrorMessage = "The Title is Required")]
        public string Title { get; set; }
       
        [MinLength(3)]
        [MaxLength(100)]
        [Required(ErrorMessage = "The Description is Required")]
        public string Description { get; set; }

        [DisplayName("Complete")]
        public bool Complete { get; set; }
        

        public int ListIndexId { get; set; }
        
       [DisplayName("ListIndex")]
        public ListIndex ListIndex { get; set; }
    }
}
