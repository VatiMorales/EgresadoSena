create database EgresadoSena;
use EgresadoSena;
CREATE TABLE SE_Usuarios (
usu_id int identity not NULL ,
usu_documento int PRIMARY KEY NOT NULL ,
usu_tipodoc varchar(80) not null,
usu_nombre varchar (80) not null,
usu_celular int not null,
usu_email varchar(100) not null,
usu_genero varchar(80),
usu_aprendiz varchar(20),
usu_egresado varchar(20),
usu_areaformacion varchar(200),
usu_fechaegresado date,
usu_direccion varchar(80),
usu_barrio varchar(100),
usu_ciudad varchar(100),
usu_departamento varchar(200),
usu_fecharegistro date
);
select * from SE_Usuarios


insert into SE_Usuarios(usu_documento,usu_tipodoc,usu_nombre,usu_celular,usu_email,usu_genero,usu_aprendiz,usu_egresado,usu_areaformacion,usu_fechaegresado,usu_direccion,usu_barrio,usu_ciudad,usu_departamento,usu_fecharegistro)
values (1200,'CC','Luisa',32239078,'Luisa@misena.edu.co','F','Si','No','ADSI','','calle50A','Peralonso','Manizales','Caldas','2012-10-15');





    
