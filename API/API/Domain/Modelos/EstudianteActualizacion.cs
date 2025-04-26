using System;
using System.Collections.Generic;

namespace API.Domain.Modelos;

public   class EstudianteActualizacion
{
    public int? Id { get; set; }

    public string? Nombre { get; set; }

    public string? fkidprograma { get; set; }

    public string? materia { get; set; }

    public string? estudiantemateria { get; set; }


}
