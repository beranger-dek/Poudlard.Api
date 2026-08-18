using System.ComponentModel.DataAnnotations;

namespace Poudlard.Api.Models.Entities
{
    public class Sorcier
    {
        public Sorcier() { }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public Guid MaisonId { get; set; }
    }
}
