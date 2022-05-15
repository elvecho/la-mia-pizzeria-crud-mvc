using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LaMiaPizzeria.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        [Range(0, int.MaxValue)]
        public int Prezzo { get; set; }

        [Required(ErrorMessage = "il campo nome è obbligatorio")]
        [StringLength(50)]
        public string Title { get; set; }

        [Required(ErrorMessage = "il campo descrizione è obbligatorio")]
        public string Description { get; set; }

        [Required(ErrorMessage = "il campo immagine è obbligatorio")]
        public string Image { get; set; }

        public Pizza()
        {

        }
        public Pizza(int Id, int Prezzo, string Title, string description, string image)
        {
            this.Id = Id;
            this.Prezzo = Prezzo;
            this.Title = Title;
            this.Description = description;
            this.Image = image;
        }

    }
}

 