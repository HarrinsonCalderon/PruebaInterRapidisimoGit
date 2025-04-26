namespace API.Application.ModelosDTO
{
    public class EstudianteDTO
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public int? fkidprograma { get; set; }
    }
}
