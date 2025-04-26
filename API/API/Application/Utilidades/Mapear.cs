using API.Application.ModelosDTO;
using API.Domain.Modelos;

namespace API.Application.Utilidades
{
    public static class Mapear
    {
        
        public static ProfesorDTO MapearPersonaAPersonaDTO(this Profesor P)
        {
            return new ProfesorDTO
            {
                Id = P.Id,
                Nombre = P.Nombre
                
            };
        }
        public static ProgramaDTO MapearProgramaAProgramaDTO(this Programa P)
        {
            return new ProgramaDTO
            {
                Id = P.Id,
                Nombre = P.Nombre

            };
        }
        public static EstudianteDTO MapearEstudianteAEstudianteDTO(this Estudiante P)
        {
            return new EstudianteDTO
            {
                Id = P.Id,
                Nombre = P.Nombre,
                fkidprograma = P.Fkidprograma
                

            };
        }
        public static EstudianteProgramaDTO MapearEstudianteAEstudianteDTO(this EstudiantePrograma P)
        {
            return new EstudianteProgramaDTO
            {
                Id = P.Id,
                Nombre = P.Nombre,
                NombrePrograma = P.NombrePrograma,
                fkidprograma=P.fkidprograma,
                materiaconcatenada=P.materiaconcatenada,
                estudiantemateria=P.estudiantemateria


            };
        }
        public static MateriaDTO MapearMateriaAMateriaDTO(this Materia P)
        {
            return new MateriaDTO
            {
                Id = P.Id,
                Nombre = P.Nombre,
                Creditos = P.Creditos,
                NombreProfesor = P.NombreProfesor,
                FkIdProfesor = P.FkIdProfesor,
                Seleccionado = false


            };
        }



        public static EstudianteClaseDTO MapearEstudianteClaseDTOEstudianteClase(this EstudianteClase P)
        {
            return new EstudianteClaseDTO
            {
                materiaid=P.materiaid,
                nombremateria=P.nombremateria,
                nombreestudiante=P.nombreestudiante



            };
        }



    }
}
