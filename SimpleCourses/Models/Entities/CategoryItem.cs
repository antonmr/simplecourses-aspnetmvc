using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleCourses.Models.Entities
{
    public class CategoryItem
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Title { get; set; }

        public string Description {  get; set; }
        
        public int CategoryId { get; set; }

        [Required]
        [Display(Name = "Media Type")]
        public int MediaTypeId { get; set; }

        [NotMapped]
        public virtual ICollection<SelectListItem>? MediaTypes { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Release Date")]
        public DateTime DateTimeItemReleased { get { return (_releaseDate == DateTime.MinValue) ? DateTime.Now : _releaseDate  ; } set { _releaseDate = value; } }
        private DateTime _releaseDate = DateTime.MinValue;

        [NotMapped]
        public int ContentId { get; set; }
    }
}
