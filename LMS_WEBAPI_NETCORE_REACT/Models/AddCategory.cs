using System.ComponentModel.DataAnnotations;

namespace LMS_WEBAPI_NETCORE_REACT.Models
{
    public class AddCategory
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Title { get; set; }

        public string Description { get; set; }
        [Required]
        public string ThumbnailImagePath { get; set; }
    }
}
