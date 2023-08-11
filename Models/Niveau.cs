namespace Gestion_Etudiants_App_Web.Models
{
    public class Niveau
    {
        public int NiveauId { get; set; }
        public string Libelle { get; set; }
        public int FaculteId { get; set; }
        public Faculte Faculte { get; set; }
    }
}
