namespace Poudlard.Api.Models.Entities
{
    public class Maison
    { 
        public Maison(Guid id, string nom, string fondateur, string couleur, string embleme)
        {
            Id = id;
            Nom = nom;
            Fondateur = fondateur;
            Couleur = couleur;
            Embleme = embleme;
        }

        public Guid Id { get; set; }
        public string Nom { get; set; }
        public string Fondateur { get; set; }
        public string Couleur { get; set; }
        public string Embleme { get; set; }


    }
}
