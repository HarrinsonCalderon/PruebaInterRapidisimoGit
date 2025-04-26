
CREATE DATABASE Academico;
use Academico;
-- DROP database Academico;

--TABLAS

create table estudiante(
id int primary key identity(1,1),
nombre varchar(50),
estado int,
fkidprograma int
);

create table programa(
id int primary key identity(1,1),
nombre varchar(50)
);

create table materia(
id int primary key identity(1,1),
nombre varchar(50),
creditos int DEFAULT 3
);

create table profesor(
id int primary key identity(1,1),
nombre varchar(50)
);

create table estudiante_materia(
id int primary key identity (1,1),
fkidestudiante int,
fkidmateria int
);

create table profesor_materia(
id int primary key identity (1,1),
fkidprofesor int,
fkidmateria int
);

--LLAVES FORANEAS

alter table estudiante add constraint consfkidprograma foreign key (fkidprograma)  references programa(id);

alter table estudiante_materia  add constraint consfkidestudiante foreign key (fkidestudiante)  references estudiante(id);
alter table estudiante_materia  add constraint consfkidmateria foreign key (fkidmateria)  references materia(id);

alter table profesor_materia  add constraint consfkidprofesor foreign key (fkidprofesor)  references profesor(id);
alter table profesor_materia  add constraint consfkidmateria2 foreign key (fkidmateria)  references materia(id);


--INSERT

insert into materia values('Matematicas',3);
insert into materia values('Fisica',3);
insert into materia values('Programacion',3);
insert into materia values('Literatura',3);
insert into materia values('Historia del arte',3);
insert into materia values('Biologia',3);
insert into materia values('Quimica',3);
insert into materia values('Filosofia',3);
insert into materia values('Sociales',3);
insert into materia values('Economia',3);

insert into profesor values('Juan Lopez');
insert into profesor values('Lina Murcia');
insert into profesor values('Luis Orozco');
insert into profesor values('Daniel Melo');
insert into profesor values('Cesar Sanchez');

insert into profesor_materia values(1,1);
insert into profesor_materia values(1,2);

insert into profesor_materia values(2,3);
insert into profesor_materia values(2,4);

insert into profesor_materia values(3,5);
insert into profesor_materia values(3,6);

insert into profesor_materia values(4,7);
insert into profesor_materia values(4,8);

insert into profesor_materia values(5,9);
insert into profesor_materia values(5,10);
 

insert into programa values('Ingenieria de sistemas');
insert into programa values('Licenciatura en matematicas');

select * from profesor inner join 
profesor_materia on profesor.id=profesor_materia.fkidprofesor
inner join materia on materia.id=profesor_materia.fkidmateria

select * from materia;
select * from programa;
select * from estudiante;
 
--PROCEDIMIENTOS ALMACENADOS

--PROFESOR
go
create or alter procedure dbo.PR_ObtenerProfesor
 @id int=null
as 
begin
	select Id as Id, nombre as Nombre from profesor where @id is null or @id=id;
end

go
create or alter procedure dbo.PR_InsertarProfesor
 @nombre varchar(50)
as 
begin
	insert into profesor (nombre) values(@nombre);
end


--Programas
 Go
create or alter procedure dbo.PR_ObtenerPrograma
 @id int=null
as 
begin
	select Id as Id, nombre as Nombre from Programa where @id is null or @id=id;
end
	
--Estudiante

 Go
create or alter procedure dbo.PR_ObtenerEstudiante
 @id int=null
as 
begin
	select Id as Id, nombre as Nombre from estudiante where @id is null or @id=id and estudiante.estado=1;
end

 Go
create or alter procedure dbo.PR_ObtenerEstudiantePrograma
 @id int=null
as 
begin
	select estudiante.Id as Id, estudiante.nombre as Nombre, programa.nombre nombreprograma, fkidprograma,
	
	(SELECT STRING_AGG(ma.id, ',') AS MateriasConcatenadas
		FROM estudiante e
		INNER JOIN estudiante_materia m ON e.id = m.fkidestudiante
		INNER JOIN materia ma ON m.fkidmateria = ma.id
		WHERE ( estudiante.Id=e.id)) as materiaconcatenada,
    
	(SELECT  STRING_AGG(m.id, ',') estudiantemateria
		FROM estudiante e
		INNER JOIN estudiante_materia m ON e.id = m.fkidestudiante
		INNER JOIN materia ma ON m.fkidmateria = ma.id
		WHERE ( estudiante.Id=e.id)) as estudiantemateria
	from estudiante inner join 
	programa on estudiante.fkidprograma=programa.id where (@id is null or @id=estudiante.id)
	and estudiante.estado=1
	order by 1 desc;
end
 

 Go
create or alter procedure dbo.PR_InsertarEstudiante
 @nombre varchar(50)=null,
 @fkidprograma int
as 
begin
	insert into estudiante values(@nombre,1,@fkidprograma);
end


 Go
create or alter procedure dbo.PR_EliminarEstudiante
 @id varchar(50)=null 
  
as 
begin
	update   estudiante set estado=0 where estudiante.id =@id;
end


go
create or alter procedure dbo.PR_ActualizarEstudiante
 @id int,
 @nombre varchar(250),
 @fkidprograma int

as 
begin
	update estudiante set nombre=@nombre ,fkidprograma=@fkidprograma where id=@id;
end
 


go
create or alter procedure dbo.PR_ActualizarEstudianteMateria
 @id int,
 @materia   int,
 @estudiantemateria int
 
as 
begin
	update estudiante_materia set fkidmateria=@materia  where id=@estudiantemateria;
	
end

select * from estudiante_materia

 Go
create or alter procedure dbo.PR_InsertarEstudianteMateria

 @fkidmateria int 
as 
 
begin
   declare @fkidestudiante  int;  
    set  @fkidestudiante =(select max(Id) from estudiante);
	insert into estudiante_materia (fkidestudiante,fkidmateria)values(@fkidestudiante,@fkidmateria);
end


 Go
create or alter procedure dbo.PR_ObtenerEstudianteClase
 @id int=null
as 
begin
		WITH CTE_MateriasEstudiante AS (
		SELECT m.id materiaid, e.nombre nombreestudiante,m.nombre nombremateria
		FROM estudiante e
		INNER JOIN estudiante_materia em ON e.id = em.fkidestudiante
		INNER JOIN materia m ON em.fkidmateria = m.id
		WHERE e.id = @id and e.estado=1
	),
	CTE_Estudiantes AS (
		SELECT m.id materiaid, e.nombre nombreestudiante,m.nombre nombremateria
		FROM estudiante e
		INNER JOIN estudiante_materia em ON e.id = em.fkidestudiante
		INNER JOIN materia m ON em.fkidmateria = m.id
		where e.estado=1
	)
	SELECT CTE_Estudiantes.materiaid,CTE_Estudiantes.nombreestudiante,CTE_Estudiantes.nombremateria
	FROM CTE_MateriasEstudiante
	JOIN CTE_Estudiantes ON CTE_MateriasEstudiante.materiaid=CTE_Estudiantes.materiaid
	order by nombremateria desc; 

end


 

--Materia
 Go
create or alter procedure dbo.PR_ObtenerMateria
 @id int=null
as 
begin
	select materia.Id as Id, materia.nombre as Nombre, creditos as Creditos, profesor.nombre nombreprofesor,fkIdProfesor from materia
	inner join profesor_materia on materia.id=profesor_materia.fkidmateria
	inner join profesor on profesor_materia.fkidprofesor=profesor.id where @id is null or @id=materia.id;
end
