namespace API.Application.ModelosDTO
{
    public class MateriaDTO
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public int? Creditos { get; set; }

        public string? NombreProfesor { get; set; }

        public int? FkIdProfesor { get; set; }

        public Boolean? Seleccionado { get; set; }
    }
}
