using System.ComponentModel.DataAnnotations;

namespace LMS_WEBAPI_NETCORE_REACT.Models
{
    public class CategoryItem
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Title { get; set; }

        public int CategoryId { get; set; }

        public int MediaTypeId { get; set; }
        //public virtual MediaType MediaType { get; set; }
        public DateTime DateTimeReleased { get; set; }
    }
}
