namespace Gestion_Etudiants_App_Web.Models
{
    public class Faculte
    {
        public  int FaculteId { get; set; }
        public string Libelle { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public ICollection<Etudiant>? Etudiants { get; set; }
        public ICollection<Niveau>? Niveaux { get; set; }

        public string FaculteEtNiveau => $"{Libelle} - {ConcatenerNiveaux()}";

        private string ConcatenerNiveaux()
        {
            if (Niveaux != null && Niveaux.Count > 0)
            {
                return string.Join(", ", Niveaux.Select(n => n.Libelle));
            }
            return "Aucun niveau associé";
        }
    }
}
