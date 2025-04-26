using System;
using System.Collections.Generic;

namespace API.Domain.Modelos;

public   class ProfesorMateria
{
    public int Id { get; set; }

    public int? Fkidprofesor { get; set; }

    public int? Fkidmateria { get; set; }

 
}
