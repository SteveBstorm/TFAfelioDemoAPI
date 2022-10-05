using System.ComponentModel.DataAnnotations;

namespace DemoAPI.Models
{
    public class MovieForm
    {
        [Required(ErrorMessage = "Mets un titre abruti")]
        public string Title { get; set; }
        public string Synopsis { get; set; }

        [Range(1950, 2050, ErrorMessage = "Doit etre compris entre ...")]
        public int ReleaseYear { get; set; }

        public int PEGI { get; set; }
    }
}
