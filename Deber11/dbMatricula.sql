-- https://docs.microsoft.com/en-us/sql/t-sql/statements/alter-table-index-option-transact-sql?view=sql-server-2017
-- https://sqlpsykrest.wordpress.com/2009/01/22/sql-procedimiento-almacenado-para-insertar-datos-con-transaccin-y-control-de-errores/
-- https://docs.microsoft.com/en-us/sql/t-sql/language-elements/begin-transaction-transact-sql?view=sql-server-2017

GO
CREATE DATABASE DbMatriculas

GO
USE DbMatriculas

GO
PRINT N'Creating table Estudiantes'

GO
CREATE TABLE  [Estudiantes] (  
    [IdEstudiante] INT IDENTITY (1, 1) NOT NULL,  
    [Nombre] NVARCHAR (40) NOT NULL,  
    [Apellido] NVARCHAR (40) NOT NULL,  
    [Cedula] VARCHAR (10) NOT NULL UNIQUE,
    [Password] NVARCHAR (40) NOT NULL,
    [Activo] BIT NOT NULL DEFAULT 1
); 

GO 
PRINT N'Creating DbMatriculas.PK_Estudiantes_IdEstudiante...';  
GO  
ALTER TABLE  [Estudiantes]  
    ADD CONSTRAINT [PK_Estudiante_IdEstudiante] PRIMARY KEY ([IdEstudiante]); 

GO
PRINT N'Creating table Materias'
GO
CREATE TABLE  [Materias] (  
    [IdMateria] INT IDENTITY (1, 1) NOT NULL,  
    [Nombre] NVARCHAR (80) NOT NULL,  
    [Creditos] TINYINT NOT NULL,  
    [Nivel] TINYINT NOT NULL,
    [Activo] BIT NOT NULL DEFAULT 1
);

GO  
PRINT N'Creating DbMatriculas.PK_Materias_IdMateria...';  
GO  
ALTER TABLE  [Materias]  
    ADD CONSTRAINT [PK_Materias_IdMateria] PRIMARY KEY ([IdMateria]); 

GO 
PRINT N'Creating table Matriculas'
CREATE TABLE  [Matriculas] (  
    [IdMatricula] INT IDENTITY (1, 1) NOT NULL,  
    [IdEstudiante] INT NOT NULL,
    [IdMateria] INT NOT NULL,
    [Estado] NVARCHAR(10) NOT NULL,
    [NumeroMatricula] TINYINT NOT NULL DEFAULT 1,
);  
PRINT N'Creating DbMatriculas.PK_Matriculas_IdMatricula...';  
GO  
ALTER TABLE  [Matriculas]  
    ADD CONSTRAINT [PK_Matriculas_IdMatricula] PRIMARY KEY ([IdMatricula]); 

GO   
PRINT N'Creating DbMatriculas.Check_Matriculas_Estado...';  
GO  
ALTER TABLE  [Matriculas]  
    ADD CONSTRAINT [Check_Matriculas_Estado] CHECK ([Estado] IN('Cursando', 'Aprobada', 'Perdida'));
GO  
PRINT N'Creating DbMatriculas.Def_Matriculas_Estado...';  
GO  
ALTER TABLE [Matriculas]  
    ADD CONSTRAINT [Def_Matriculas_Estado] DEFAULT 'Cursando' FOR [Estado];  
GO
PRINT N'Creating DbMatriculas.FK_Matriculas_Estudiantes_IdEstudiante...';  
GO  
ALTER TABLE  [Matriculas]  
    ADD CONSTRAINT [FK_Matriculas_Estudiantes_IdEstudiante] FOREIGN KEY ([IdEstudiante]) REFERENCES  [Estudiantes] ([IdEstudiante]);  
GO  
PRINT N'Creating DbMatriculas.FK_Matriculas_Materias_IdMateria...';  
GO  
ALTER TABLE  [Matriculas]  
    ADD CONSTRAINT [FK_Matriculas_Materias_IdMateria] FOREIGN KEY ([IdMateria]) REFERENCES  [Materias] ([IdMateria]);  
GO  

PRINT N'Creating DbMatriculas.procedure.newEstudiante...';  
GO  
CREATE PROCEDURE  [uspNuevoEstudiante]  
    @Nombre NVARCHAR (40),  
    @Apellido NVARCHAR (40),  
    @Cedula NCHAR (10),
    @Password NVARCHAR (40)  
AS  
BEGIN  
    INSERT INTO  [Estudiantes] (Nombre,Apellido,Cedula,[Password]) VALUES (@Nombre,@Apellido,@Cedula,@Password);  
END  

GO 
CREATE PROCEDURE  [uspNuevaMateria]  
    @Nombre NVARCHAR (80),  
    @Creditos TINYINT,  
    @Nivel TINYINT
AS  
BEGIN  
    INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES (@Nombre,@Creditos,@Nivel);  
END

GO  
CREATE PROCEDURE  [uspNuevaMatricula]  
    @IdEstudiante INT,
    @IdMateria INT,
    @Estado NVARCHAR(10)
AS
BEGIN  
    INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado) VALUES (@IdEstudiante,@IdMateria,@Estado);  
END



GO  
CREATE PROCEDURE [uspActualizarMateria]  
	@IdEstudiante INT,
	@IdMateria INT,
	@Estado NVARCHAR(10)
AS  
BEGIN  
DECLARE @Id INT, @NumMatri  INT
BEGIN TRANSACTION  
    SELECT @Id = [IdMatricula], @NumMatri = [NumeroMatricula]
     FROM [Matriculas] WHERE [IdMateria] = @IdMateria and [IdEstudiante] = @IdEstudiante;  

UPDATE [Matriculas]  
   SET [NumeroMatricula] = @NumMatri+1,
		[Estado] = @Estado
WHERE [IdMatricula] = @Id;  
COMMIT TRANSACTION  
END



GO  
CREATE PROCEDURE [uspGetEstudiante]  
@Cedula VARCHAR (10)  
AS  
BEGIN  
	SELECT *  FROM [Estudiantes] 
	WHERE [Cedula] = @Cedula 
END  

GO
CREATE PROCEDURE [uspGetMateriasEstudiante]  
@IdEstudiante INT  
AS  
BEGIN 
SELECT Malla.IdMateria, Malla.Nombre, Malla.Creditos, Malla.Nivel, MatEstudiante.Estado ,MatEstudiante.NumeroMatricula   
FROM Materias AS Malla
LEFT JOIN ( SELECT Materias.IdMateria, Matriculas.NumeroMatricula , Matriculas.Estado from Materias
		JOIN Matriculas 
			ON Materias.IdMateria = Matriculas.IdMateria
			WHERE Matriculas.IdEstudiante = @IdEstudiante) AS MatEstudiante
ON Malla.IdMateria = MatEstudiante.IdMateria
END

GO  
 INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Calculo en una variable',6,1);
 GO
  INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Algebra Lineal 1',4,1);    
 GO
  INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Quimica General 1',4,1);
 GO
  INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Fisica General 1',4,1);
 GO
  INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Laboratorio Fisica General',1,1);
 GO
  INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Expresion Oral y Escrita',2,1);
 GO
   INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Realidad Socio EconXmica y PolXtica del Ecuador',2,1);
 GO
   INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Optativa Social',2,1);
 GO
  INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Calculo Vectorial',4,2);
 GO
  INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Ecuaciones Diferenciales Ordinarias',4,2);
 GO
  INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Probabilidad y EstadXstica BXsica',4,2);
 GO
  INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Laboratorio FXsica General 2',5,2);
 GO
  INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('FXsica General 2',5,2);
 GO
  INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('TecnologXa ElXctrica',3,2);      
 GO
  INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Laboratorio TecnologXa ElXctrica',2,2);  
 GO
  INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('DesafXos del mundo actual',2,2);
 GO
  INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('ProgramaciXn',3,2);


 GO                     
   INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('MatemXtica Avanzada',4,3);
 GO                   
   INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('FXsica General 3',4,3);
 GO     
  INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Sistemas Operativos',5,3);
 GO              
  INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('TeorXa ElectromagnXtica',4,3);
 GO
  INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('AnXlisis de Circuitos ElXctricos 1',4,3);
 GO
  INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Laboratorio AnXlisis de Circuitos 1',2,3);
 GO
  INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Optativa Social',2,3);
 GO
  INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('AdministraciXn General',5,3);
 GO
 INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('AnXlisis de SeXales y Sistemas',4,4);
 GO
 INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Seminario',1,4);
 GO
 INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Dispositivos ElectrXnicos',5,4);
 GO
 INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Lab Dispositivos ElectrXnicos',2,4);
 GO
 INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('AnXlisis de Circuitos ElXctricos 2',4,4);
 GO
 INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Laboratorio AnXlisis de Circuitos',2,4);
 GO
 INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('TeorXa de InformaciXn y CodificaciXn',3,4);
 GO
 INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('ProgramaciXn Orientada a Objetos',4,4);
 GO
 INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Medios de TransmisiXn y Antenas',5,4);
 GO


 INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Sistemas Digitales',4,5);
 GO
  INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Laboratorio Sistemas Digitales',4,5);
 GO
  INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Circuitos ElectrXnicos',4,5);
 GO
  INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Laboratorio Circuitos ElectrXnicos',2,5);
 GO
  INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Instalaciones ElXctricas y de Comunicaciones',3,5);
 GO
  INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Base de Datos',4,5);
 GO
  INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('TeorXa de Comunicaciones',5,5);
 GO
  INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Laboratorio de TeorXa de Comunicaciones',2,5);
 GO
  INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('ComercializaciXn',3,5);
 GO


  INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Sistemas Microprocesados',3,6);
 GO
 INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Laboratorio Sistemas Microprocesados',2,6);
 GO
  INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Sistemas Cableado Estructurado',3,6);
 GO
 -- INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Optativa',1,6);
 --GO
  --INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Libre ElecciXn',3,6);
 --GO
  INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('ProgramaciXn con Herramientas Visuales',3,6);
 GO
  INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Laboratorio de Redes TCP/IP',1,6);
 GO
  INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Redes TCP/IP',3,6);
 GO
  INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Redes de Area Local',4,6);
 GO
  INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Laboratorio de Redes de Area Local',1,6);
 GO
  INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('IngenierXa Financiera',3,6);
 GO
 



  INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Aplicaciones Distribuidas',5,7);
 GO
 INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Seguridad en Redes',4,7);
 GO
 INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Redes de Area Extendida',4,7);
 GO
 INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Laboratorio de Redes de Area Extendida',5,7);
 GO
 INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Optativa',1,7);
 GO
 INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Comunicaciones InalXmbricas',4,7);
 GO
 INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Redes e Intranets',3,7);
 GO
 INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('EcologXa y Medio Ambiente',3,7);
 GO



 INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Marco Regulatorio de las Telecomunicaciones',3,8);
 GO
 INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('AdministraciXn de Redes',4,8);
 GO
  INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('DiseXo y EvaluaciXn de redes',3,8);
 GO
  INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Optativa',1,8);
 GO
  INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Optativa',1,8);
 GO
  INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Optativa',1,8);
 GO
  INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Redes de Area Local InalXmbrica',4,8);
 GO
  INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('FormulaXciXn y EvaluaciXn de Proyectos',3,8);
 GO
  INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Proyecto de TitulaciXn',20,9);
 GO
  INSERT INTO  [Materias] (Nombre,Creditos,Nivel) VALUES ('Optativa',1,9);
GO
INSERT INTO  [Estudiantes] (Nombre,Apellido,Cedula,[Password]) VALUES ('Andrea','Jurado','1722772527','est1');
GO
INSERT INTO  [Estudiantes] (Nombre,Apellido,Cedula,[Password]) VALUES ('Henry','Villavicencio','1718928207','est2');
GO
INSERT INTO  [Estudiantes] (Nombre,Apellido,Cedula,[Password]) VALUES ('Cristian','Ronda','1018363912','est3');
GO
INSERT INTO  [Estudiantes] (Nombre,Apellido,Cedula,[Password]) VALUES ('Camila','Andrade','171829162','est4');
GO
INSERT INTO  [Estudiantes] (Nombre,Apellido,Cedula,[Password]) VALUES ('Jorge','Sanchez','1718272635','est5');
GO
INSERT INTO  [Estudiantes] (Nombre,Apellido,Cedula,[Password]) VALUES ('Andres','Sanchez','1234567890','est6');
GO


INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado) VALUES (1,1,'Aprobada');
GO
INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado) VALUES (1,2,'Aprobada');
GO
INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado) VALUES (1,3,'Perdida');
GO
INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado) VALUES (1,4,'Aprobada');
GO
INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado) VALUES (1,5,'Aprobada');
GO

INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado) VALUES (2,9,'Perdida');
GO
INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado) VALUES (2,10,'Perdida');
GO
INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado) VALUES (2,11,'Perdida');
GO
INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado) VALUES (2,12,'Aprobada');
GO
INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado) VALUES (2,13,'Aprobada');
GO

INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado) VALUES (3,19,'Aprobada');
GO
INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado) VALUES (3,20,'Perdida');
GO
INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado) VALUES (3,21,'Aprobada');
GO
INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado) VALUES (3,22,'Perdida');
GO
INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado) VALUES (3,23,'Aprobada');
GO

INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado) VALUES (4,27,'Aprobada');
GO
INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado) VALUES (4,28,'Aprobada');
GO
INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado) VALUES (4,29,'Aprobada');
GO
INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado) VALUES (4,30,'Aprobada');
GO
INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado) VALUES (4,31,'Perdida');
GO

INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado) VALUES (5,23,'Aprobada');
GO
INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado) VALUES (5,28,'Aprobada');
GO
INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado) VALUES (5,29,'Aprobada');
GO
INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado) VALUES (5,39,'Perdida');
GO
INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado) VALUES (5,40,'Perdida');
GO



INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado,NumeroMatricula) VALUES (6,1,'Aprobada',1);
GO
INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado,NumeroMatricula) VALUES (6,2,'Aprobada',2);
GO
INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado,NumeroMatricula) VALUES (6,3,'Aprobada',1);
GO
INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado,NumeroMatricula) VALUES (6,4,'Aprobada',2);
GO
INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado,NumeroMatricula) VALUES (6,5,'Aprobada',2);
GO
INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado,NumeroMatricula) VALUES (6,6,'Aprobada',1);
GO
INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado,NumeroMatricula) VALUES (6,7,'Aprobada',1);
GO
INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado,NumeroMatricula) VALUES (6,8,'Aprobada',1);
GO

INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado,NumeroMatricula) VALUES (6,9,'Aprobada',1);
GO
INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado,NumeroMatricula) VALUES (6,10,'Aprobada',1);
GO
INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado,NumeroMatricula) VALUES (6,11,'Aprobada',1);
GO
INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado,NumeroMatricula) VALUES (6,12,'Aprobada',1);
GO
INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado,NumeroMatricula) VALUES (6,13,'Aprobada',1 );
GO
INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado,NumeroMatricula) VALUES (6,14,'Aprobada',1);
GO
INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado,NumeroMatricula) VALUES (6,15,'Aprobada',1);
GO
INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado,NumeroMatricula) VALUES (6,16,'Aprobada',1);
GO
INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado,NumeroMatricula) VALUES (6,17,'Aprobada',1);
GO
INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado,NumeroMatricula) VALUES (6,18,'Aprobada',1);
GO
INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado,NumeroMatricula) VALUES (6,19,'Aprobada',1);
GO
INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado,NumeroMatricula) VALUES (6,20,'Aprobada',2);
GO
INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado,NumeroMatricula) VALUES (6,21,'Aprobada',3);
GO
INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado,NumeroMatricula) VALUES (6,22,'Aprobada',2);
GO
INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado,NumeroMatricula) VALUES (6,23,'Aprobada',2);
GO
INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado,NumeroMatricula) VALUES (6,24,'Aprobada',1);
GO
INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado,NumeroMatricula) VALUES (6,25,'Aprobada',1);
GO

INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado,NumeroMatricula) VALUES (6,27,'Perdida',1);
GO
INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado,NumeroMatricula) VALUES (6,28,'Perdida',2);
GO
INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado,NumeroMatricula) VALUES (6,36,'Aprobada',2);
GO
INSERT INTO  [Matriculas] (IdEstudiante,IdMateria,Estado,NumeroMatricula) VALUES (6,37,'Perdida',1);
GO




 select * from Materias
GO
 select * from Estudiantes
GO
 select * from Matriculas
