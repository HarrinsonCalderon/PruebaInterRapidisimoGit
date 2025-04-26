using System;
using System.Collections.Generic;

namespace API.Domain.Modelos;

public   class Materia
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public int? Creditos { get; set; }

    public string? NombreProfesor { get; set; }

    public int? FkIdProfesor { get; set; }

    public Boolean? Seleccionado { get; set; }



}
