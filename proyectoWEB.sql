/*Tabla con la informacion de las personas */

create table [dbo].[personas](
[id_persona] int IDENTITY(1,1) NOT NULL,
[identificacion] int NOT NULL,
[nombre] varchar(60) NOT NULL,
[apellido] varchar(100) NOT NULL
CONSTRAINT [pk_persona] PRIMARY KEY (id_persona),
CONSTRAINT [uk_Personas] UNIQUE (identificacion)
)
GO

/*******************************************************/
/* Tabla con los telefonos de las personas/clientes*/

create table [dbo].[telefonos](
[identificacion] int NOT NULL CONSTRAINT fk_telefonos_persona FOREIGN KEY REFERENCES personas(identificacion),
[telefono] VARCHAR(9)  NOT NULL CONSTRAINT CH_telefonos CHECK (telefono like '[0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]'),
CONSTRAINT [pk_telefono] PRIMARY KEY (identificacion,telefono)
)
GO

/*******************************************************/
/* Tabla con los correos de las personas/clientes*/
create table [dbo].[correos](
[identificacion] int NOT NULL CONSTRAINT fk_correos_persona FOREIGN KEY REFERENCES personas(identificacion),
[correo] varchar(100) NOT NULL,
CONSTRAINT [pk_correo] PRIMARY KEY (identificacion,correo)
)
GO

/*******************************************************/
/* Tabla con la informacion de mecanicos*/

create table [dbo].[mecanicos](
[persona] int NOT NULL CONSTRAINT fk_mecanico_persona FOREIGN KEY REFERENCES personas(id_persona),
[codigo] int NOT NULL,
[titulo] varchar(150) NOT NULL,
[experiencia] int NOT NULL,
CONSTRAINT [pk_mecanicos] PRIMARY KEY (persona),
CONSTRAINT [uk_mecanicos] UNIQUE (codigo)
)
GO

/********************************************/

/* Tabla con la informacion de los autos*/

create table [dbo].[autos](
[id_auto] int IDENTITY(1,1) NOT NULL,
[placa] int NOT NULL,
[marca] varchar(50) NOT NULL,
[modelo] varchar(50) NOT NULL,
[anno] int,
[numero_vin] int,
[color] varchar(50),
CONSTRAINT [pk_autos] PRIMARY KEY (id_auto),
CONSTRAINT [uk_autos] UNIQUE (placa)
)
GO

/*******************************************************/
/* Tabla con la informacion de las reparaciones*/

create table [dbo].[reparaciones](
[id_cita] int IDENTITY(1,1) NOT NULL, 
[auto] int NOT NULL CONSTRAINT fk_reparacion_auto FOREIGN KEY REFERENCES [dbo].autos(id_auto),
[fecha] datetime,
[notas] varchar(300),
[diagnostica] int CONSTRAINT fk_reparacion_diagnostica FOREIGN KEY REFERENCES mecanicos(codigo),
[diagnostico] varchar(300),
[evalua] int CONSTRAINT fk_reparacion_evalua FOREIGN KEY REFERENCES mecanicos(codigo),
[evaluacion] varchar(300),
[completado] char CONSTRAINT CK_reparacion_completado CHECK (completado <= 1),
[encargado] int CONSTRAINT fk_autos_duenno FOREIGN KEY REFERENCES personas(id_persona),
[es_duenno] char NOT NULL CONSTRAINT CK_reparacion_es_duenno CHECK (es_duenno <= 1),
[confirmar_todo] char,
CONSTRAINT [pk_reparaciones] PRIMARY KEY (id_cita)
)
GO


/*******************************************************/
/* Tabla con la informacion de los repuestos*/

create table [dbo].[repuestos](
[id_repuesto] int IDENTITY(1,1) NOT NULL, 
[reparacion] int NOT NULL CONSTRAINT fk_repuesto_reparacion FOREIGN KEY REFERENCES [dbo].reparaciones(id_cita),
[descripcion] varchar(300) NOT NULL,
[precio] int
CONSTRAINT [pk_repuestos] PRIMARY KEY (id_repuesto)
)
GO

/*******************************************************/
/* Tabla con la informacion de los roles de los mecanicos*/

create table [dbo].[roles](
[id_rol] int IDENTITY(1,1) NOT NULL, 
[nombre_rol] varchar(50) NOT NULL,
[precio] int
CONSTRAINT [pk_roles] PRIMARY KEY (id_rol)
)
GO

/*******************************************************/
/* Tabla con la informacion de los mecanicos participantes en las reparaciones*/

create table [dbo].[mecanicos_participantes](
[id_mecanicos_part] int IDENTITY(1,1) NOT NULL, 
[reparacion] int NOT NULL CONSTRAINT fk_mecanicop_reparacion FOREIGN KEY REFERENCES reparaciones(id_cita),
[mecanico] int NOT NULL CONSTRAINT fk_mecanicop_mecanico FOREIGN KEY REFERENCES mecanicos(persona),
[rol] int NOT NULL CONSTRAINT fk_mecanicop_rol FOREIGN KEY REFERENCES [dbo].roles(id_rol), 
[hora_invertidas] int NOT NULL
CONSTRAINT [pk_mecanicos_participantes] PRIMARY KEY (id_mecanicos_part)
)
GO

/****************************************************/
/* Tabla con la informacion de las labores*/

create table [dbo].[labores](
[id_labor] int IDENTITY(1,1) NOT NULL, 
[descripcion] varchar(300) NOT NULL
CONSTRAINT [pk_labores] PRIMARY KEY (id_labor)
)
GO

/*******************************************************/
/* Tabla con la informacion de las labores requeridas*/

create table [dbo].[labores_requeridas](
[id_labor_requerida] int IDENTITY(1,1) NOT NULL, 
[reparacion] int NOT NULL CONSTRAINT fk_labor_req_reparacion FOREIGN KEY REFERENCES reparaciones(id_cita),
[labor] int NOT NULL CONSTRAINT fk_labor_req_labor FOREIGN KEY REFERENCES labores(id_labor),
[mecanico] int NOT NULL CONSTRAINT fk_labor_req_mecanico FOREIGN KEY REFERENCES mecanicos(codigo),
[aprobada] char NOT NULL CONSTRAINT CK_labores_req_aprob CHECK (aprobada <= 1)
CONSTRAINT [pk_labores_requeridas] PRIMARY KEY (id_labor_requerida)
)
GO

/****************************************************/
/* Tabla con la informacion de las alertas*/

create table [dbo].[alertas](
[id_alerta] int IDENTITY(1,1) NOT NULL, 
[placa] int NOT NULL CONSTRAINT fk_alerta FOREIGN KEY REFERENCES autos(placa),
[fecha] datetime NOT NULL,
[recordatorio] varchar(200) NOT NULL
CONSTRAINT [pk_alerta] PRIMARY KEY (id_alerta)
)
GO

/*********************************************************************************************************/

/* PROCEDIMIENTOS PARA INSERTAR EN LAS TABLAS*/

/*********************************************************************************************************/
/*Procedimiento para insertar a las personas*/
CREATE PROCEDURE [dbo].[insertar_personas]
	@INTidentificacion INT = NULL, 	
	@STRnombre VARCHAR(60) = NULL,
	@STRapellido VARCHAR(100) = NULL,		
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT,
    @INTid int output

AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
INSERT INTO [dbo].[personas]
		( [identificacion],
          [nombre],
          [apellido])
           
     VALUES(
			@INTidentificacion,	
			@STRnombre,
			@STRapellido
			)
			set @INTid = SCOPE_IDENTITY()
		
SALIDA:
	SELECT @nStatus, @strMessage, @INTid
	RETURN 
END
GO



/*Procedimiento para insertar telefonos a las personas*/
CREATE PROCEDURE [dbo].[insertar_telefonos]
	@INTidentificacion INT = NULL, 	
	@STRtelefono VARCHAR(9) = NULL,
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT

AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
INSERT INTO [dbo].[telefonos]
          ([identificacion],
          [telefono])
           
     VALUES(
			@INTidentificacion,	
			@STRtelefono)
		
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN 
END
GO


/*Procedimiento para insertar los correos de las personas*/
CREATE PROCEDURE [dbo].[insertar_correos]
	@INTidentificacion INT = NULL, 	
	@STRcorreo VARCHAR(100)= NULL,
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT

AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
INSERT INTO [dbo].[correos]
          ([identificacion],
          [correo])
           
     VALUES(
			@INTidentificacion,	
			@STRcorreo)
		
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN 
END
GO

/*Procedimiento para insertar mecanicos*/

CREATE PROCEDURE [dbo].[insertar_mecanicos]
	@INTpersona INT = NULL,
	@INTcodigo INT = NULL, 	
	@STRtitulo VARCHAR(150) = NULL,
	@INTexperiencia INT=NULL, 		
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT

AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
INSERT INTO [dbo].[mecanicos]
          ([persona],
          [codigo],
          [titulo],
          [experiencia])
           
     VALUES(
			@INTpersona,
			@INTcodigo,	
			@STRtitulo,
			@INTexperiencia
			)
		
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN 
END
GO


/*Procedimiento para insertar autos*/

CREATE PROCEDURE [dbo].[insertar_autos]
	@INTplaca INT = NULL, 	
	@STRmarca VARCHAR(50) = NULL,
	@STRmodelo VARCHAR(50) = NULL,
	@INTanno INT=NULL,
	@INTnumero_vin INT=NULL,
	@STRcolor VARCHAR(50) = NULL,
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT,
    @INTid_Auto INT OUTPUT

AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
INSERT INTO [dbo].[autos]
          ([placa],
          [marca],
          [modelo],
          [anno],
          [numero_vin],
          [color])
           
     VALUES(
			@INTplaca,	
			@STRmarca,
			@STRmodelo,
			@INTanno,
			@INTnumero_vin,
			@STRcolor)
			set @INTid_Auto = SCOPE_IDENTITY()
		
SALIDA:
	SELECT @nStatus, @strMessage, @INTid_Auto
	RETURN 
END
GO



/*Procedimiento para insertar reparaciones*/
IF EXISTS (
	SELECT 'h' FROM DBO.SYSOBJECTS 
		WHERE id = OBJECT_ID(N'[dbo].[insertar_reparaciones]')AND 
		OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[insertar_reparaciones]
GO


CREATE PROCEDURE [dbo].[insertar_reparaciones]
	@INTauto INT = NULL, 	
	@DTfecha DATETIME = NULL,
	@STRnotas VARCHAR(300) = NULL,
	@INTdiagnostica INT = NULL,
	@strdiagnostico VARCHAR(300) = NULL,
	@INTevalua INT = NULL,
	@STRevaluacion VARCHAR(300) = NULL,
	@CHARcompletado CHAR = NULL,
	@INTencargado INT = NULL,
	@CHARes_duenno CHAR = NULL,
	@CHARconfirmar_todo CHAR = NULL,
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT

AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
INSERT INTO [dbo].[reparaciones]
          ([auto],
          [fecha],
          [notas],
          [diagnostica],
          [diagnostico],
          [evalua],
          [evaluacion],
          [completado],
          [encargado],
          [es_duenno],
          [confirmar_todo]
          )
           
     VALUES(
			@INTauto,
			@DTfecha,	
			@STRnotas,
			@INTdiagnostica,
			@strdiagnostico,
			@INTevalua,
			@STRevaluacion,
			@CHARcompletado,
			@INTencargado,
			@CHARes_duenno,
			@CHARconfirmar_todo
			)
		
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN 
END
GO


/*Procedimiento para insertar repuestos*/

CREATE PROCEDURE [dbo].[insertar_repuestos]
	@INTreparacion INT = NULL, 	
	@STRdescripcion VARCHAR(300) = NULL,
	@INTprecio INT = NULL,
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT

AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
INSERT INTO [dbo].[repuestos]
          ([reparacion],
          [descripcion],
          [precio])
           
     VALUES(
			@INTreparacion,
			@STRdescripcion,
			@INTprecio
			)
		
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN 
END
GO


/*Procedimiento para insertar roles*/

CREATE PROCEDURE [dbo].[insertar_roles]
	@STRnombre VARCHAR(50) = NULL,
	@INTprecio INT = NULL,
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT

AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
INSERT INTO [dbo].[roles]
          ([nombre_rol],
          [precio])
           
     VALUES(
			@STRnombre,
			@INTprecio
			)
		
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN 
END
GO

/*Procedimiento para insertar los mecanicos participantes*/
IF EXISTS (
	SELECT 'h' FROM DBO.SYSOBJECTS 
		WHERE id = OBJECT_ID(N'[dbo].[insertar_mecanicos_participantes]')AND 
		OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[insertar_mecanicos_participantes]
GO

CREATE PROCEDURE [dbo].[insertar_mecanicos_participantes]
	@INTreparacion INT = NULL,
	@INTmecanico INT = NULL,
	@INTrol INT = NULL,
	@INThoras_invertida INT = NULL,
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT

AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			


INSERT INTO [dbo].[mecanicos_participantes]
          ([reparacion],
          [mecanico],
          [rol],
          [hora_invertidas])
           
     VALUES(
			@INTreparacion,
			(select mecanicos.persona from 
			mecanicos where mecanicos.codigo = @INTmecanico),
			@INTrol,
			@INThoras_invertida
			)
		
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN 
END
GO


/*Procedimiento para insertar las labores*/

CREATE PROCEDURE [dbo].[insertar_labores]
	@STRdescripcion VARCHAR(300) = NULL,
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT

AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
INSERT INTO [dbo].[labores]
          ([descripcion])
           
     VALUES(
			@STRdescripcion
			)
		
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN 
END
GO


/*Procedimiento para insertar las labores requeridas*/

CREATE PROCEDURE [dbo].[insertar_labores_requeridas]
	@INTreparacion INT = NULL,
	@INTlabor INT = NULL,
	@INTmecanico INT = NULL,
	@CHARaprobada CHAR = NULL,
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT

AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
INSERT INTO [dbo].[labores_requeridas]
          ([reparacion],
          [labor],
          [mecanico],
          [aprobada])
           
     VALUES(
			@INTreparacion,
			@INTlabor,
			@INTmecanico,
			@CHARaprobada
			)
		
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN 
END
GO

/*Procedimiento para insertar las alertas*/

CREATE PROCEDURE [dbo].[insertar_alertas]
	@INTplaca INT = NULL,
	@DTfecha DATETIME = NULL,
	@STRrecordatorio VARCHAR(200) = NULL,
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT

AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
INSERT INTO [dbo].[alertas]
          ([placa],
          [fecha],
          [recordatorio])
           
     VALUES(
			@INTplaca,
			@DTfecha,
			@STRrecordatorio
			)
		
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN 
END
GO




/*********************************************************************************************************/

/* PROCEDIMIENTOS PARA MODIFICAR LOS DATOS ALMACENADOS */

/*********************************************************************************************************/


/* Procedimiento para modificar la informacion de las reparaciones */

IF EXISTS (
	SELECT 'h' FROM DBO.SYSOBJECTS 
		WHERE id = OBJECT_ID(N'[dbo].[modificar_reparacion]')AND 
		OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[modificar_reparacion]
GO

CREATE PROCEDURE [dbo].[modificar_reparacion]
	@INTid_cita INT = NULL,	
	@DTfecha DATETIME = NULL,
	@STRnotas VARCHAR(300) = NULL,
	@STRdiagnostico VARCHAR(300) = NULL,
	@STRevaluacion VARCHAR(300) = NULL,
	@CHARcompletado CHAR = NULL,
	@INTdiagnostica INT = NULL,
	@INTevalua INT = NULL,
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT 
AS	
BEGIN
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
			
	UPDATE [dbo].[reparaciones]

	SET		
		   [fecha] = ISNULL(@DTfecha, [fecha]),
           [notas] = ISNULL(@STRnotas,[notas]),
           [diagnostico] = ISNULL(@strdiagnostico,[diagnostico]),
           [evaluacion] = ISNULL(@STRevaluacion, [evaluacion]),
           [completado] = ISNULL(@CHARcompletado, [completado]),
           [diagnostica] = ISNULL(@INTdiagnostica, [diagnostica]),
           [evalua] = ISNULL(@INTevalua, [evalua])
           
	FROM reparaciones
    WHERE [id_cita] = @INTid_cita 
		
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN
END
GO

/* Procedimiento para modificar una labor requerida */

IF EXISTS (
	SELECT 'h' FROM DBO.SYSOBJECTS 
		WHERE id = OBJECT_ID(N'[dbo].[modificar_labor_requerida]')AND 
		OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[modificar_labor_requerida]
GO

CREATE PROCEDURE [dbo].[modificar_labor_requerida]
	@CHARaprobada CHAR,
	@INTlabor_requerida INT,
	@nStatus INT OUTPUT,
    @strMessage VARCHAR(250) OUTPUT
AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
	update
		labores_requeridas
	set
		aprobada = @CHARaprobada
	where
		labores_requeridas.id_labor_requerida = @INTlabor_requerida
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN
END
GO


/*********************************************************************************************************/

/* PROCEDIMIENTOS PARA CONSULTAR LOS DATOS ALMACENADOS */

/*********************************************************************************************************/


/* Procedimiento para consultar personas */


IF EXISTS (
	SELECT 'h' FROM DBO.SYSOBJECTS 
		WHERE id = OBJECT_ID(N'[dbo].[consultar_personas]')AND 
		OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[consultar_personas]
GO

CREATE PROCEDURE [dbo].[consultar_personas]
	@INTidentificacion INT = NULL,
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT 
AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
	SELECT
		id_persona, identificacion,	nombre,	apellido
	FROM 
		personas p		
	WHERE 
		p.identificacion = ISNULL(@INTidentificacion, p.identificacion)
		
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN
END
GO


/* Procedimiento para consultar telefonos */

IF EXISTS (
	SELECT 'h' FROM DBO.SYSOBJECTS 
		WHERE id = OBJECT_ID(N'[dbo].[consultar_telefonos]')AND 
		OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[consultar_telefonos]
GO


CREATE PROCEDURE [dbo].[consultar_telefonos]
	@INTidentificacion INT = NULL,
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT 
AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
	SELECT
		telefono
	FROM 
		telefonos		
	WHERE 
		identificacion=@INTidentificacion
		
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN
END
GO

/* Procedimiento para consultar correos */

IF EXISTS (
	SELECT 'h' FROM DBO.SYSOBJECTS 
		WHERE id = OBJECT_ID(N'[dbo].[consultar_correos]')AND 
		OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[consultar_correos]
GO


CREATE PROCEDURE [dbo].[consultar_correos]
	@INTidentificacion INT = NULL,
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT 
AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
	SELECT
		correo
	FROM 
		correos		
	WHERE 
		identificacion=@INTidentificacion
		
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN
END
GO



/* Procedimiento para consultar autos */

IF EXISTS (
	SELECT 'h' FROM DBO.SYSOBJECTS 
		WHERE id = OBJECT_ID(N'[dbo].[consultar_autos]')AND 
		OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[consultar_autos]
GO


CREATE PROCEDURE [dbo].[consultar_autos]
	@INTplaca INT = NULL,
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT 
AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
		SELECT
			id_auto, marca, modelo, anno, numero_vin, color, id_persona,id_cita
		FROM 
			autos,reparaciones,Personas
		WHERE 
			placa=@INTplaca and id_auto=auto and encargado = id_persona
		GROUP BY id_auto, marca, modelo, anno, numero_vin, color, id_persona, id_cita
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN
END
GO


/* Procedimiento para consultar autos de una persona */

IF EXISTS (
	SELECT 'h' FROM DBO.SYSOBJECTS 
		WHERE id = OBJECT_ID(N'[dbo].[consultar_aut_pers]')AND 
		OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[consultar_aut_pers]
GO


CREATE PROCEDURE [dbo].[consultar_aut_pers]
	@INTidentificacion INT = NULL,
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT 
AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
		SELECT
			placa
		FROM 
			autos,reparaciones,Personas
		WHERE 
			identificacion=@INTidentificacion and id_persona=encargado and id_auto = auto
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN
END
GO



/* Procedimiento para consultar reparaciones */
IF EXISTS (
	SELECT 'h' FROM DBO.SYSOBJECTS 
		WHERE id = OBJECT_ID(N'[dbo].[consultar_reparaciones]')AND 
		OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[consultar_reparaciones]
GO
CREATE PROCEDURE [dbo].[consultar_reparaciones]
	@INTid_cita INT = NULL,
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT 
AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'
	
	select  id_cita, autos.placa, fecha, notas,
		encargado.id_persona as encargado_id, encargado.nombre as encargado,
		diagnostica.id_persona as id_diagnostica, diagnostica.nombre as diagnostica, diagnostico,
		evalua.id_persona as id_evalua, evalua.nombre as evalua, evaluacion,
		completado, confirmar_todo
	from reparaciones
		inner join autos on reparaciones.auto = autos.id_auto
		inner join personas as encargado on reparaciones.encargado = encargado.id_persona
		left join personas as evalua on reparaciones.evalua = evalua.id_persona
		left join personas as diagnostica on reparaciones.diagnostica = diagnostica.id_persona
	where id_cita = @INTid_cita
	
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN
END
GO


/* Procedimiento para consultar los mecanicos */


IF EXISTS (
	SELECT 'h' FROM DBO.SYSOBJECTS 
		WHERE id = OBJECT_ID(N'[dbo].[consultar_mecanicos]')AND 
		OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[consultar_mecanicos]
GO

CREATE PROCEDURE [dbo].[consultar_mecanicos]
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT 
AS	
BEGIN
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
	SELECT
		nombre, apellido, codigo, experiencia, titulo
	FROM 
		personas inner join mecanicos
		on personas.id_persona = mecanicos.persona
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN
END
GO


/* Procedimiento para consultar las reparaciones que esten por diagnosticar */


IF EXISTS (
	SELECT 'h' FROM DBO.SYSOBJECTS 
		WHERE id = OBJECT_ID(N'[dbo].[consultar_por_diagnosticar]')AND 
		OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[consultar_por_diagnosticar]
GO

CREATE PROCEDURE [dbo].[consultar_por_diagnosticar]
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT 
AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
	SELECT
		id_cita, placa, fecha, notas
	FROM 
		reparaciones, autos								
	WHERE 
		completado = 0 and evaluacion IS NULL and  diagnostico IS NULL and id_auto=auto
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN
END
GO

/* Procedimiento para consultar las reparaciones que esten por evaluar */


IF EXISTS (
	SELECT 'h' FROM DBO.SYSOBJECTS 
		WHERE id = OBJECT_ID(N'[dbo].[consultar_por_evaluar]')AND 
		OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[consultar_por_evaluar]
GO

CREATE PROCEDURE [dbo].[consultar_por_evaluar]
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT 
AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
	SELECT
		id_cita, placa, fecha, notas
	FROM 
		reparaciones, autos								
	WHERE 
		diagnostico IS NOT NULL and evaluacion IS NULL and completado = 0 and id_auto=auto
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN
END
GO



/* Procedimiento para consultar las reparaciones que esten por completar */


IF EXISTS (
	SELECT 'h' FROM DBO.SYSOBJECTS 
		WHERE id = OBJECT_ID(N'[dbo].[consultar_por_completar]')AND 
		OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[consultar_por_completar]
GO

CREATE PROCEDURE [dbo].[consultar_por_completar]
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT 
AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
	SELECT
		id_cita, placa,fecha, notas
	FROM 
		reparaciones, autos								
	WHERE
		diagnostico IS NOT NULL and evaluacion IS NOT NULL and completado = 0
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN
END
GO


/* Procedimiento para consultar el historial de las reparaciones */


IF EXISTS (
	SELECT 'h' FROM DBO.SYSOBJECTS 
		WHERE id = OBJECT_ID(N'[dbo].[consultar_historial]')AND 
		OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[consultar_historial]
GO

CREATE PROCEDURE [dbo].[consultar_historial]
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT 
AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
	SELECT
		id_cita, diagnostica, diagnostico, evalua, evaluacion, fecha, confirmar_todo,completado
	FROM 
		reparaciones 
	WHERE 
		completado = 1
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN
END
GO


/*Metodo para consultar el costo de mano de obra de una reparacion */

CREATE PROCEDURE [dbo].[consultar_costo_reparacion]
	@INTid_cita INT = NULL,
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT 
AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
	SELECT
		'mecanico ' + nombre_rol as descripcion,precio,hora_invertidas as horas, (precio * hora_invertidas) as total
	FROM 
		reparaciones, mecanicos_participantes, roles
	WHERE 
		id_cita=@INTid_cita and id_cita=reparacion and rol = id_rol
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN
END
GO

/*Metodo para consultar el costo de mano de obra de una reparacion */

CREATE PROCEDURE [dbo].[consultar_costo_repuestos]
	@INTid_cita INT = NULL,
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT 
AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
	SELECT
		descripcion,precio, precio as total
	FROM 
		reparaciones, repuestos
	WHERE 
		id_cita=@INTid_cita and id_cita=reparacion
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN
END
GO


/* Obtener los mecánicos asignados de una reparación */

IF EXISTS (
	SELECT 'h' FROM DBO.SYSOBJECTS 
		WHERE id = OBJECT_ID(N'[dbo].[consultar_mecánicos_asignados]')AND 
		OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].consultar_mecánicos_asignados
GO

CREATE PROCEDURE [dbo].[consultar_mecánicos_asignados]
	@INTid_cita INT = NULL,
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT 
AS	
BEGIN

	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
	SELECT
		mecanicos_participantes.mecanico, p.nombre, mecanicos_participantes.rol,
		r.nombre_rol, mecanicos_participantes.hora_invertidas
	FROM 
			mecanicos_participantes
		inner join
			(select personas.nombre, id_mecanicos_part
			from personas inner join mecanicos_participantes
			on personas.id_persona = mecanicos_participantes.mecanico
			where mecanicos_participantes.reparacion = @INTid_cita) as p
				on mecanicos_participantes.id_mecanicos_part = p.id_mecanicos_part
		inner join
			(select roles.nombre_rol, id_mecanicos_part
			from roles inner join mecanicos_participantes
			on roles.id_rol = mecanicos_participantes.rol
			where mecanicos_participantes.reparacion = @INTid_cita) as r
		on p.id_mecanicos_part = r.id_mecanicos_part
	WHERE 
		mecanicos_participantes.reparacion = @INTid_cita
		
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN
END
GO


/* Obtener las labores asignadas a una reparación */

IF EXISTS (
	SELECT 'h' FROM DBO.SYSOBJECTS 
		WHERE id = OBJECT_ID(N'[dbo].[consultar_labores_asignadas]')AND 
		OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].consultar_labores_asignadas
GO

CREATE PROCEDURE [dbo].[consultar_labores_asignadas]
	@INTid_cita INT = NULL,
	@nStatus INT OUTPUT,
    @strMessage VARCHAR(250) OUTPUT
AS	
BEGIN

	SET @nStatus = 0
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'

	select l.id_labor_requerida, l.aprobada, l.descripcion, nombre
	from
		(select * from
		labores_requeridas
		inner join
		labores
		on id_labor = labor) as l
		inner join
		personas
		on mecanico = id_persona
	where
		reparacion = @INTid_cita
		
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN
END
GO


/* Obtener los repuestos asignados a una reparación */

IF EXISTS (
	SELECT 'h' FROM DBO.SYSOBJECTS 
		WHERE id = OBJECT_ID(N'[dbo].[consultar_repuestos_asignados]')AND 
		OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].consultar_repuestos_asignados
GO

CREATE PROCEDURE [dbo].[consultar_repuestos_asignados]
	@INTid_cita INT = NULL,
	@nStatus INT OUTPUT,
    @strMessage VARCHAR(250) OUTPUT
AS	
BEGIN

	SET @nStatus = 0
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'

	SELECT
		repuestos.id_repuesto, repuestos.descripcion, repuestos.precio
	FROM 
		repuestos
	WHERE 
		repuestos.reparacion = @INTid_cita
		
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN
END
GO


/*Procedimiento para consultar la lista de roles*/
IF EXISTS (
	SELECT 'h' FROM DBO.SYSOBJECTS 
		WHERE id = OBJECT_ID(N'[dbo].[consultar_roles]')AND 
		OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[consultar_roles]
GO

CREATE PROCEDURE [dbo].[consultar_roles]
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT

AS	
BEGIN
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'
	
	select roles.id_rol, roles.nombre_rol, roles.precio
	from roles
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN 
END
GO

/*Procedimiento para consultar la lista de labores*/
IF EXISTS (
	SELECT 'h' FROM DBO.SYSOBJECTS 
		WHERE id = OBJECT_ID(N'[dbo].[consultar_labores]')AND 
		OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[consultar_labores]
GO

CREATE PROCEDURE [dbo].[consultar_labores]
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT

AS	
BEGIN
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'
	
	select labores.id_labor, labores.descripcion
	from labores
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN 
END
GO

/* Procedimiento para consultar un mecanico particular */


IF EXISTS (
	SELECT 'h' FROM DBO.SYSOBJECTS 
		WHERE id = OBJECT_ID(N'[dbo].[consultar_mecanico]')AND 
		OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[consultar_mecanico]
GO

CREATE PROCEDURE [dbo].[consultar_mecanico]
	@INTcedula INT = NULL,
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT 
AS	
BEGIN
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
	SELECT
		nombre, apellido, codigo, experiencia, titulo
	FROM 
		personas p, mecanicos m
	WHERE p.id_persona = m.persona and p.identificacion=@INTcedula
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN
END
GO


/* Procedimiento para consultar las alertas */


IF EXISTS (
	SELECT 'h' FROM DBO.SYSOBJECTS 
		WHERE id = OBJECT_ID(N'[dbo].[consultar_alertas]')AND 
		OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[consultar_alertas]
GO

CREATE PROCEDURE [dbo].[consultar_alertas]
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT 
AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
	SELECT
		a.placa, recordatorio
	FROM 
		alertas a, autos au
	WHERE 
		a.placa=au.placa and fecha = GETDATE()
		
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN
END
GO

/* INSERCIONES EN LA TABLA LABORES, INSERTADOS POR DEFECTO */
exec insertar_labores 'Cambio de bateria',null,null
Go
exec insertar_labores 'Balanceo',null,null
Go
exec insertar_labores 'Ajuste de frenos',null,null
Go
exec insertar_labores 'Cambio de aceite',null,null
Go
exec insertar_labores 'Revision general',null,null
Go

/* INSERCIONES EN LA TABLA LABORES, INSERTADOS POR DEFECTO */
exec insertar_roles 'Asistente',5000,null,null
Go
exec insertar_roles 'Tecnico',7000,null,null
Go
exec insertar_roles 'Analisis de seguridad',10000,null,null
Go
exec insertar_roles 'Especialista',12000,null,null
Go

