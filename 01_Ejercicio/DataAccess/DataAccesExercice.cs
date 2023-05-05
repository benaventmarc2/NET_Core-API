namespace _01_Ejercicio.DataAccess
{
    using _01_Ejercicio.Models.DataModels;
    using Microsoft.EntityFrameworkCore;
    public class DataAccesExercice : DbContext
    {
        public DataAccesExercice(DbContextOptions<DataAccesExercice> options) : base(options)
        {
        }
        // Generar las tablas de sql
        DbSet<Curso>? Curso { get; set; }
    }
}
