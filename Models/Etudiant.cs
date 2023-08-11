using System.ComponentModel.DataAnnotations;

namespace Gestion_Etudiants_App_Web.Models
{
    public class Etudiant
    {
        public enum Genre
        {
            [Display(Name = "Masculin")]
            Masculin = 0,
            [Display(Name = "Féminin")]
            Feminin = 1,
        }

        public enum Boursier
        {
            [Display(Name = "Boursier")]
            Masculin = 0,
            [Display(Name = "Non-Boursier")]
            Feminin = 1,
        }

        public int EtudiantID { get; set; }
        public string Matricule { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public Genre Sexe { get; set; }
        public int age { get; set; }
        public string Adresse { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public Boursier typeEtudiant { get; set; }
        public int FaculteId { get; set; }
        public Faculte? Faculte { get; set; }
    }
}
