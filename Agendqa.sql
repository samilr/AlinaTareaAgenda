create database AgendaContactos
go

use AgendaContactos

create table Contactos 
(
Id int identity (1,1) primary key,
Nombres nvarchar (100),
Apellidos nvarchar (100),
Direccion nvarchar (100),
Fecha_Cumpleanos date,
Numero nvarchar (10),
Movil nvarchar (10),
Correo nvarchar (20),
Estadocivil nvarchar (10),
Genero nvarchar (2),
)

drop table Contactos








---PROCEDIMIENTOS ALMACENADOS 
--------------------------MOSTRAR 
create proc MostrarContactos
as
select *from Contactos
go

--------------------------INSERTAR 
create proc InsetarContactos
@name nvarchar (100),
@lastName nvarchar (100),
@address nvarchar (100),
@dateBirthday date,
@phoneNumber nvarchar (10),
@Movil nvarchar (10),
@Correo nvarchar (20),
@EstadoCivil nvarchar (10),
@Genero nvarchar (2)
as
insert into Contactos values (@name,@lastName,@address,@dateBirthday,@phoneNumber, @Movil, @Correo, @EstadoCivil, @Genero)
go

DROP PROC InsetarContactos



------------------EDITAR

create proc EditarContactos 
@name nvarchar (20),
@lastName nvarchar (20),
@address nvarchar (100),
@dateBirthday date,
@phoneNumber nvarchar (10),
@idCont int,
@Movil nvarchar (10),
@Genero nvarchar (2),
@Correo nvarchar (20),
@EstadoCivil nvarchar (10)
as
update Contactos set Nombres=@name, Apellidos=@lastName, Direccion=@address, Fecha_Cumpleanos=@dateBirthday, Numero=@phoneNumber, Movil=@Movil, Correo=@Correo, EstadoCivil=@EstadoCivil,  Genero=@Genero where Id=@idCont
go

drop proc EditarContactos
go

------------------------ELIMINAR
create proc EliminarContactos
@idCont int
as
delete from Contactos where Id=@idCont
go