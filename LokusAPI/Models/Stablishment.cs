using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LokusAPI.Models
{
    public class Stablishment
    {
        public Guid Id { get; set; } = new Guid();
        public string Name { get; set; } = string.Empty;
        public string VirtualName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Contact { get; set; } = string.Empty;
        
        //chave estrangeira FK
        public Guid CompanyId { get; set; }

        public Guid? ProfileImageId { get; set; }
        public Image? ProfileImage { get; set; }

        [JsonIgnore]
        public Company Company { get; set; }

        // Relação 1:1 - depois inserido nas configurações no front 
        public Guid? AddressId { get; set; }
        public Address? Address { get; set; } = null!;

        //relacionamento 1:N
        public ICollection<Space> Spaces { get; set; } = new List<Space>(); //relacionamento 1:N
        public List<Feedback>? Feedbacks { get; set; } // vários feedbacks para um estabelecimento
        public ICollection<StablishmentGallery> Galleries { get; set; } //galeria para até 10 fotos

        public ICollection<Category> Categories { get; set; } = new List<Category>(); //relacionamento 1:N

    }
}
