namespace Gestion_Etudiants_App_Web.Models
{
    public class Cours
    {
        public int CoursId { get; set; }
        public string Code { get; set; }
        public int VolumeHoraires { get; set; }
        public int Credits { get; set; }
        public string Description { get; set; }
        public int NiveauId { get; set; }
        public Niveau Niveau { get; set; }
    }
}
