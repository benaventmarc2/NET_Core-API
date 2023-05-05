using System.ComponentModel.DataAnnotations;

namespace _01_Ejercicio.Models.DataModels
{
    public class Curso
    {
        [Key,StringLength(50)]
        public string? Nombre { get; set; }
        [StringLength(280)]
        public string? DescripcionCorta { get; set; }
        public string? DescripcionLarga { get; set; }
        public string? PublicoObjetivo { get; set; }
        public string? Objetivos { get; set; }
        public string? Requisitos { get; set;}
        public enum Nivel
        {
            Basico,
            Intermedio,
            Avanzado,
        }
    }
}
