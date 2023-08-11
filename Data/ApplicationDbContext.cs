using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Gestion_Etudiants_App_Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Gestion_Etudiants_App_Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Gestion_Etudiants_App_Web.Models.Faculte> Faculte { get; set; } = default!;
        public DbSet<Gestion_Etudiants_App_Web.Models.Niveau> Niveau { get; set; } = default!;
        public DbSet<Gestion_Etudiants_App_Web.Models.Etudiant> Etudiant { get; set; } = default!;
        public DbSet<Gestion_Etudiants_App_Web.Models.Cours> Cours { get; set; } = default!;


    }
}