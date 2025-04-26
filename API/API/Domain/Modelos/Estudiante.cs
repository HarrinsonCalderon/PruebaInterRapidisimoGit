using System;
using System.Collections.Generic;

namespace API.Domain.Modelos;

public   class Estudiante
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public int? Fkidprograma { get; set; }

 
}
