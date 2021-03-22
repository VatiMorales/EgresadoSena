create database EgresadoSena;
use EgresadoSena;
CREATE TABLE SE_Usuarios (
usu_id int identity NOT NULL ,
usu_documento int PRIMARY KEY NOT NULL ,
usu_tipodoc varchar(80) not null,
usu_nombre varchar (80) not null,
usu_celular int not null,
usu_email varchar(100) not null,
usu_genero varchar(80),
usu_aprendiz bit,
usu_egresado bit,
usu_areaformacion varchar(200),
usu_fechaegresado date,
usu_direccion varchar(80),
usu_barrio varchar(100),
usu_ciudad varchar(100),
usu_departamento varchar(200),
usu_fecharegistro date
);
select * from SE_Usuarios




    