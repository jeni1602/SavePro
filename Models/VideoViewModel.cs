using System.ComponentModel.DataAnnotations;

namespace SavePro.Models
{
    public class VideoViewModel
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please select a file")]
        [Display(Name = "Video File")]
        public IFormFile VideoFile { get; set; }
    }
}