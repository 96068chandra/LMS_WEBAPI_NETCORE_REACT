using System.ComponentModel.DataAnnotations;

namespace LMS_WEBAPI_NETCORE_REACT.Models
{
    public class Content
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Title { get; set; }

        public string HTMLContent { get; set; }

        public string VideoLink { get; set; }

        public CategoryItem CategoryItem { get; set; }
    }
}
