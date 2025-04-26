namespace API.Domain.Modelos
{
    public class EstudiantePrograma
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? NombrePrograma { get; set; }

        public string? fkidprograma { get; set; }

        public string? materiaconcatenada { get; set; }

        public string? estudiantemateria { get; set; }
    }
}
