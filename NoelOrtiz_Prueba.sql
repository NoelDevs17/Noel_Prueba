--1 corremos este trozo de codigo
CREATE DATABASE NoelOrtizPrueba

--2 Luego usamos la BD creada con el siguiente codigo
USE NoelOrtizPrueba

--3 Aqui creamos la tabla Persona

CREATE TABLE persona (
ID int not null Identity(1,1) primary key,
Nombre varchar(40) not null,
FechaDeNacimiento date
);


-- 4 Luego insertamos valores en ella

INSERT INTO persona VALUES ('Noel Ortiz' , '1999-02-17');
INSERT INTO persona VALUES ('Enmanuel Cabrera' , '1980-03-27');

--5 Luego hacemos un select para verificar que los datos fueron insertados
SELECT * FROM persona;
