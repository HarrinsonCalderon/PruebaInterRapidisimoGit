using System;
using System.Collections.Generic;

namespace API.Domain.Modelos;

public   class EstudianteMateria
{
    public int Id { get; set; }

    public int? Fkidestudiante { get; set; }

    public int? Fkidmateria { get; set; }

 
}
