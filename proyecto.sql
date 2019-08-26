 create table cliente (
cl_idCliente numeric(9) primary key , 
cl_nombre varchar2(20),
cl_apellido1 varchar2(20),
cl_apellido2 varchar2(20),
cl_telefono numeric(8));

create table auditoria_cliente
(usuario varchar2(20),
fecha date,
ACCION VARCHAR2(80),
cl_idCliente numeric(9),
cl_nombre varchar2(30));

create or replace trigger auditoria1 
before insert or delete or update 
on cliente
for each row
begin
if inserting then
insert into auditoria_cliente values(
user,
sysdate,
'Se insertó un registro',
:new.cl_idCliente,
:new.cl_nombre);
end if;
if updating then
insert into auditoria_cliente values(
user,
sysdate,
'Se actualizó un registro',
:old.cl_idCliente,
:old.cl_nombre);
end if;
if deleting then
insert into auditoria_cliente values(
user,
sysdate,
'Se borró un registro',
:old.cl_idCliente,
:old.cl_nombre);
end if;
end;

--------------------------------------------------------------inserts de clientes --------------------------------------------------------------------------
insert into cliente values (1,'Alexander','Vargas','Alvarado',70333366);
insert into cliente values(2,'Maria Jose','Cespedez','Ortega',70124578);
insert into cliente values (3,'Josue','Portuguez','Lopez',71323346);
insert into cliente values (4,'Katherin','Ramirez','Cespedez',87333366);
insert into cliente values (5,'Gabriela','Leny','Araya',86333366);
insert into cliente values (6,'Daniela','Picado','Monge',71234684);
insert into cliente values (7,'Stephany','Flores','MArtinez',88737514);
insert into cliente values (8,'Andrea','Cordoba','Rojo',47123456);
insert into cliente values (9,'Clarck','Gonzales','Chavarria',76765435);
insert into cliente values (10,'Sara','Salas','Lopez',77123456);
insert into cliente values (11,'Hellen','Segura','Alvarado',79423145);
insert into cliente values (12,'Valery','Murillo','Rojas',71232453);
insert into cliente values (13,'Andrea','Porras','Espinoza',82314553);
insert into cliente values (14,'Carolina','Osorio','Flores',89994439);
insert into cliente values (15,'Carlos','Brenes','Rojas',71233145);
insert into cliente values (16,'Xinia','Rodriguez','Guzman',70111234);
insert into cliente values (17,'David','Siles','Varela',71346654);
insert into cliente values (18,'Adriana','Vargas','Alvarado',70212343);
insert into cliente values (19,'Ana','Gonzales','Arias',71123412);
insert into cliente values (20,'Alicia','Solano','Monge',88882213);
insert into cliente values (21,'Adam','Cordoba','Castro',80000123);
insert into cliente values (22,'Mariana','Alvarado','Castro',86040123);

------------------------------------------------------------------------------
grant select on cliente to rol_emple;
grant select,delete,insert,update on cliente to rol_admin;

create table reserva(
res_idReserva numeric(9) primary key,
cl_idCliente numeric(9),
pro_idProyeccion numeric(9),
res_boletos numeric(9),
res_costoTotal numeric(9),
sal_idSala numeric(9));

create table auditoria_reserva
(usuario varchar(20),
fecha date,
ACCION VARCHAR2(80),
res_idReserva numeric(9),
cl_idCliente numeric(9));

create or replace trigger auditoria2
BEFORE insert or delete or update 
on reserva
for each row
begin
if inserting then
insert into auditoria_reserva values(
user,
sysdate,
'Se insertó un registro',
:new.res_idReserva,
:new.cl_idCliente);
end if;
if updating then
insert into auditoria_RESERVA values(
user,
sysdate,
'Se actualizó un registro',
:old.res_idReserva,
:old.cl_idCliente);
end if;
if deleting then
insert into auditoria_RESERVA values(
user,
sysdate,
'Se eliminó un registro',
:old.res_idReserva,
:old.cl_idCliente);
end if;
end;



alter table reserva add
foreign key (cl_idcliente)
references cliente(cl_idcliente)
on delete cascade;

CREATE OR REPLACE TRIGGER TRGCOSTO
 BEFORE INSERT OR UPDATE ON RESERVA
 FOR EACH ROW
 BEGIN
  IF :NEW.res_boletos = 1 THEN
    :NEW.res_costoTotal := 2000;
  END IF;
  IF :NEW.res_boletos = 2 THEN
    :NEW.res_costoTotal := 4000;
  END IF;
  IF :NEW.res_boletos = 3 THEN
    :NEW.res_costoTotal := 6000;
  END IF;
  IF :NEW.res_boletos = 4 THEN
    :NEW.res_costoTotal := 8000;
  END IF;
 END;
 
---------------------------------------------------- INSERTS DE LA TABLA RESERVA ------------------------------- 
insert into reserva values(1,1,1,4,0,1);
insert into reserva values(2,2,3,2,0,3);
insert into reserva values(3,3,1,1,0,1);
insert into reserva values(4,4,2,2,0,2);
insert into reserva values(5,5,4,1,0,4);
insert into reserva values(6,6,3,3,0,3);
insert into reserva values(7,7,2,1,0,9);
insert into reserva values(8,8,1,1,0,1);
insert into reserva values(9,9,4,2,0,2);
insert into reserva values(10,10,2,1,0,6);
insert into reserva values(11,11,4,4,0,4);
insert into reserva values(12,12,1,4,0,1);
insert into reserva values(13,13,2,2,0,7);
insert into reserva values(14,14,4,1,0,4);
insert into reserva values(15,15,3,3,0,3);
insert into reserva values(16,16,1,1,0,8);
insert into reserva values(17,17,2,4,0,2);
insert into reserva values(18,18,1,1,0,5);
insert into reserva values(19,19,3,3,0,4);
insert into reserva values(20,20,10,2,0,9);
insert into reserva values(21,21,10,2,0,9);
insert into reserva values(22,22,10,4,0,9);



grant select on reserva to rol_emple;
grant select,delete,insert,update on reserva to rol_admin;




create table sala(
sal_idSala numeric(9) primary key,
sal_numeroSala numeric(9),
sal_numeroAsientos numeric(3),
suc_idSucursal numeric(9));



create table auditoria_sala
(usuario varchar(20),
fecha date,
ACCION VARCHAR2(80),
sal_idSala numeric(9),
sal_numeroAsientos numeric(3));

create or replace trigger auditoria3
before insert or delete or update 
on sala
for each row
begin
if inserting then
insert into auditoria_sala values(
user,
sysdate,
'Se insertó un registro',
:new.sal_idSala,
:new.sal_numeroAsientos);
end if;
if updating then
insert into auditoria_sala values(
user,
sysdate,
'Se actualizó un registro',
:old.sal_idSala,
:old.sal_numeroAsientos);
end if;
if deleting then
insert into auditoria_sala values(
user,
sysdate,
'Se eliminó un registro',
:old.sal_idSala,
:old.sal_numeroAsientos);
end if;
end;


-------------------------------------------INSERTS DE SALAS------------------------------------------------

insert into sala values(1,1,64,1);
insert into sala values(2,2,34,1);
insert into sala values(3,3,64,1);
insert into sala values(4,1,34,2);
insert into sala values(5,2,64,2);
insert into sala values(6,3,34,2);
insert into sala values(7,1,34,3);
insert into sala values(8,2,64,3);
insert into sala values(9,3,34,3);

alter table reserva add
foreign key (sal_idSala)
references sala(sal_idSala)
ON delete cascade;


grant select on sala to rol_emple;
grant select,delete,insert,update on sala to rol_admin;

create table sucursal(
suc_idSucursal number primary key,
suc_nombre varchar(50),
suc_provincia varchar(50),
suc_telefono number,
suc_direccion varchar(50));

create table auditoria_sucursal
(usuario varchar(20),
fecha date,
ACCION VARCHAR2(80),
suc_idSucursal numeric(9),
suc_nombre varchar(20));

create or replace trigger auditoria4
before insert or delete or update 
on sucursal
for each row
begin
if inserting then
insert into auditoria_sucursal values(
user,
sysdate,
'Se insertó un registro',
:new.suc_idSucursal,
:new.suc_nombre);
end if;
if updating then
insert into auditoria_sucursal values(
user,
sysdate,
'Se actualizó un registro',
:old.suc_idSucursal,
:old.suc_nombre);
end if;
if deleting then
insert into auditoria_sucursal values(
user,
sysdate,
'Se eliminó un registro',
:old.suc_idSucursal,
:old.suc_nombre);
end if;
end;

insert into sucursal values(1,'Lincon','San José',70458766,'Moravia');
insert into sucursal values(2,'Mall San Pedro','San José',71456768,'San Pedro');
insert into sucursal values(3,'Oxigeno','Heredia',70458766,'San Francisco');

grant select on cliente to rol_emple;
grant select,delete,insert,update on cliente to rol_admin;



alter table sala add 
foreign key (suc_idSucursal)
references sucursal(suc_idSucursal)
ON DELETE CASCADE;

create table empleado(
em_idEmpleado numeric(9) primary key,
em_nombre varchar(20),
em_apellido1 varchar(20),
em_apellido2 varchar(20),
em_telefono numeric(9),
em_direccion varchar(20),
em_salario numeric(9),
suc_idSucursal numeric(9));

create table auditoria_empleado
(usuario varchar(20),
fecha date,
ACCION VARCHAR2(80),
em_idEmpleado numeric(9),
em_nombre varchar(20));

create or replace trigger auditoria5
before insert or delete or update 
on empleado
for each row
begin
if inserting then
insert into auditoria_empleado values(
user,
sysdate,
'Se insertó un registro',
:new.em_idEmpleado,
:new.em_nombre);
end if;
if updating then
insert into auditoria_empleado values(
user,
sysdate,
'Se actualizó un registro',
:old.em_idEmpleado,
:old.em_nombre);
end if;
if deleting then
insert into auditoria_empleado values(
user,
sysdate,
'Se eliminó un registro',
:old.em_idEmpleado,
:old.em_nombre);
end if;
end;

alter table empleado add
foreign key (suc_idSucursal)
references sucursal(suc_idSucursal)
ON DELETE CASCADE;



insert into empleado values(1,'Manolo', 'Picado', 'Bermudez',70124578,'Moravia',300000,1);
insert into empleado values(2,'Leticia', 'Ramos', 'Segura',77184478,'Purral',400000,2);
insert into empleado values(3,'Nicole', 'Escalante', 'Duran',8800998,'Tres Rios',650000,2);
insert into empleado values(4,'NAhin', 'Vargas', 'Corrales',78018212,'Santo Domingo',600000,3);
insert into empleado values(5,'Sebastian', 'Villalobos', 'Sibaja',7111234,'Escazu',300000,3);
insert into empleado values(6,'Michelle', 'Guardia', 'Segura',71111578,'Calle Blancos',700000,1);
insert into empleado values(7,'Melissa', 'Oviedo', 'Blanco',80876548,'Moravia',800000,1);
insert into empleado values(8,'Jimena', 'Sancho', 'Olivaz',88234562,'Guadalupe',800000,1);
insert into empleado values(9,'Jorge', 'Vega', 'Ramirez',89194978,'Tres Rios',1200000,2);
insert into empleado values(10,'Johanna', 'Bradley', 'Carmona',83224178,'Guadalupe',600000,1);
insert into empleado values(11,'Paola', 'Mendoza', 'Hernandez',80342678,'Santo Domingo',700000,3);
insert into empleado values(12,'Perla', 'Marina', 'Raudez',70111258,'Escazu',600000,3);

grant select on empleado to rol_emple;
grant select,delete,insert,update on empleado to rol_admin;



CREATE TABLE SAL_INFO
(NOMBRE_SUC VARCHAR2(80),
SAL_MAX NUMBER, 
SAL_MIN NUMBER,
SAL_AVG NUMBER,
SAL_SUM NUMBER
);

CREATE OR  REPLACE TRIGGER ACTU_EMPLE
 BEFORE UPDATE OF EM_SALARIO ON EMPLEADO
 FOR EACH ROW
 DECLARE
 SALDIF NUMBER;
 BEGIN
  DBMS_OUTPUT.PUT_LINE('EMPLEADO' || :OLD.EM_IDEMPLEADO);
  SALDIF :=  :NEW.EM_SALARIO  - :OLD.EM_SALARIO;
  DBMS_OUTPUT.PUT_LINE('SALARIO ACTUAL ' || :OLD.EM_SALARIO);
  DBMS_OUTPUT.PUT_LINE('SALARIO NUEVO ' || :NEW.EM_SALARIO);
  DBMS_OUTPUT.PUT_LINE('DIFERENCIA ' || SALDIF);
END;


create table funcion(
fun_idFuncion numeric(9) primary key,
pro_idProyeccion numeric(9),
sal_idSala numeric(9),
fun_dia date);

create table auditoria_funcion
(usuario varchar(20),
fecha date,
ACCION VARCHAR2(80),
fun_idFuncion numeric(9),
fun_horario date);

select * from funcion

create or replace trigger auditoria6
before insert or delete or update 
on funcion
for each row
begin
if inserting then
insert into auditoria_funcion values(
user,
sysdate,
'Se insertó un registro',
:new.fun_idFuncion,
:new.fun_horario);
end if;
if updating then
insert into auditoria_funcion values(
user,
sysdate,
'Se actualizó un registro',
:old.fun_idFuncion,
:old.fun_horario);
end if;
if deleting then
insert into auditoria_funcion values(
user,
sysdate,
'Se eliminó un registro',
:old.fun_idFuncion,
:old.fun_horario);
end if;
end;

insert into funcion values(1,1,1,'2019/8/1');
insert into funcion values(2,2,2,'1/8/2019');
insert into funcion values(3,3,3,'15/8/2019');
insert into funcion values(4,4,4,'15/8/2019');
insert into funcion values(5,5,5,'16/8/2019');
insert into funcion values(6,6,6,'16/8/2019');
insert into funcion values(7,7,7,'16/8/2019');
insert into funcion values(8,8,8,'17/8/2019');
insert into funcion values(9,9,9,'17/8/2019');
insert into funcion values(10,10,1,'17/8/2019');
insert into funcion values(11,11,2,'18/8/2019');
insert into funcion values(12,12,3,'18/8/2019');
insert into funcion values(13,13,4,'18/8/2019');
insert into funcion values(14,14,5,'18/8/2019');
insert into funcion values(15,15,6,'19/8/2019');
insert into funcion values(16,16,7,'19/8/2019');
insert into funcion values(17,17,8,'19/8/2019');
insert into funcion values(18,18,9,'20/8/2019');
insert into funcion values(19,19,1,'20/8/2019');

alter table funcion add
foreign key (sal_idSala)
references sala(sal_idSala)
on delete cascade;

grant select on funcion to rol_emple;
grant select,delete,insert,update on funcion to rol_admin;



create table proyeccion(
pro_idProyeccion numeric(9) primary key,
pro_horaInicio varchar(20),
pro_horaFin varchar(20),
pel_idPeli numeric(9));

create table auditoria_proyeccion
(usuario varchar(20),
fecha date,
ACCION VARCHAR2(80),
pro_idProyeccion numeric(9),
pro_horaInicio varchar(20),
pro_horaFin varchar(20));

create or replace trigger auditoria7
before insert or delete or update 
on proyeccion
for each row
begin
if inserting then
insert into auditoria_proyeccion values(
user,
sysdate,
'Se insertó un registro',
:new.pro_idProyeccion,
:new.pro_horaInicio,
:new.pro_horaFin);
end if;
if updating then
insert into auditoria_proyeccion values(
user,
sysdate,
'Se actualizó un registro',
:old.pro_idProyeccion,
:old.pro_horaInicio,
:old.pro_horaFin);
end if;
if deleting then
insert into auditoria_proyeccion values(
user,
sysdate,
'Se eliminó un registro',
:old.pro_idProyeccion,
:old.pro_horaInicio,
:old.pro_horaFin);
end if;
end;

insert into proyeccion values(1,'2pm','4pm',1);
insert into proyeccion values(2,'8pm','11:25pm',2);
insert into proyeccion values(3,'5pm','7:40pm',3);
insert into proyeccion values(4,'10pm','11:50am',4);
insert into proyeccion values(5,'8pm','10:30pm',5);
insert into proyeccion values(6,'2pm','3:40pm',3);
insert into proyeccion values(7,'6pm','8:20pm',1);
insert into proyeccion values(8,'2pm','4pm',2);
insert into proyeccion values(9,'8pm','10pm',5);
insert into proyeccion values(10,'6pm','9:PMpm',2);
insert into proyeccion values(11,'2pm','4pm',6);
insert into proyeccion values(12,'8pm','10pm',5);
insert into proyeccion values(13,'6pm','8:20pm',6);
insert into proyeccion values(14,'3pm','7:00pm',2);
insert into proyeccion values(15,'8pm','11pm',1);
insert into proyeccion values(16,'10m','1am',1);
insert into proyeccion values(17,'8pm','10:10pm',4);
insert into proyeccion values(18,'2pm','4:20pm',6);
insert into proyeccion values(19,'10pm','12am',3);

grant select on proyeccion to rol_emple;
grant select,delete,insert,update on proyeccion to rol_admin;

alter table funcion add 
foreign key (pro_idProyeccion)
references proyeccion(pro_idProyeccion)
on delete cascade;

alter table reserva add 
foreign key (pro_idProyeccion)
references proyeccion(pro_idProyeccion)
on delete cascade;



create table pelicula(
pel_idPel numeric(9) primary key,
pel_nombre varchar2(30),
pel_clasificacion varchar2(20),
pel_idioma varchar2(20));

create table auditoria_pelicula
(usuario varchar(20),
fecha date,
ACCION VARCHAR2(80),
pel_idPel numeric(9),
pel_nombre varchar2(80));

create or replace trigger auditoria8
before insert or delete or update 
on pelicula
for each row
begin
if inserting then
insert into auditoria_pelicula values(
user,
sysdate,
'Se insertó un registro',
:new.pel_idPel,
:new.pel_nombre);
end if;
if updating then
insert into auditoria_pelicula values(
user,
sysdate,
'Se actualizó un registro',
:old.pel_idPel,
:old.pel_nombre);
end if;
if deleting then
insert into auditoria_pelicula values(
user,
sysdate,
'Se eliminó un registro',
:old.pel_idPel,
:old.pel_nombre);
end if;
end;

insert into pelicula values(1,'Avengers End Game','Todo Publico', 'Español');
insert into pelicula values(2,'Avengers End Game','Todo Publico', 'Ingles:Subtitulado');
insert into pelicula values(3,'La maldición de la llorona','Mayores 18 años', 'Ingles:Subtitulado');
insert into pelicula values(4,'Shazam','Todo Publico', 'Español');
insert into pelicula values(5,'Shazam','Todo Publico', 'Ingles:Subtitulado');
insert into pelicula values(6,'Dumbo','Todo Publico', 'Español');


alter table proyeccion add 
foreign key (pel_idPeli)
references pelicula(pel_idPel)
on delete cascade;

grant select on pelicula to rol_emple;
grant select,delete,insert,update on pelicula to rol_admin;


CREATE OR REPLACE PACKAGE PaqueteCine 
AS
PROCEDURE CantProyecCine;
PROCEDURE COMPROBANTE(VID IN NUMERIC);
PROCEDURE LISTAEMPLEADOS;
FUNCTION HORARIO RETURN SYS_REFCURSOR;
PROCEDURE PELIDIA(DATOS OUT SYS_REFCURSOR);
PROCEDURE PELIDIAB; 
PROCEDURE NOMBRE;
FUNCTION NUMERO RETURN SYS_REFCURSOR;
END PaqueteCine;

/*Mostrar el nombre y la cantidad de proyecciones que tiene cada película*/
--SET SERVEROUTPUT ON
CREATE OR REPLACE PACKAGE BODY PAQUETECINE 
AS               
PROCEDURE CantProyecCine
AS
CURSOR DATOS IS SELECT S.PEL_NOMBRE, count(P.PEL_IDPELI) 
               FROM PROYECCION P,PELICULA S
               where P.PEL_IDPELI=S.PEL_IDPEL
               GROUP BY S.PEL_NOMBRE;
               
VNOM VARCHAR2(50); 
VCOUNT NUMBER;
NERROR NUMBER;
VMES VARCHAR2(500);
EXP EXCEPTION;
BEGIN
OPEN DATOS;
LOOP 
FETCH DATOS INTO VNOM,VCOUNT;
EXIT WHEN DATOS%NOTFOUND;
DBMS_OUTPUT.PUT_LINE('La pelicula '||VNOM||' tiene una cantidad de '||VCOUNT||' proyecciones');
END LOOP;
CLOSE DATOS;
EXCEPTION 
  WHEN EXP THEN
      NERROR := 9999991;
      VMES := 'EXCEPCIÓN PERSONALIZADA';
      DBMS_OUTPUT.PUT_LINE('ERORR ' || NERROR ||  ' ' || VMES);
    WHEN OTHERS THEN
      NERROR := SQLCODE;
      VMES := SQLERRM;
      DBMS_OUTPUT.PUT_LINE('ERORR ' || NERROR ||  ' ' || VMES);
END CantProyecCine;

/*Simular un comprobante donde muestre el nombre del cliente, la hora de inicio
de la pelicula, la pelicula que va a ver y el numero de la sala. Como parametro el id del cliente*/

PROCEDURE COMPROBANTE(VID IN NUMERIC)
AS
CURSOR DATOS IS SELECT CL.CL_IDCLIENTE, CL.CL_NOMBRE||' '||CL.CL_APELLIDO1,PRO.PRO_HORAINICIO,PEL.PEL_NOMBRE,SAL.SAL_NUMEROSALA
                FROM CLIENTE CL,RESERVA RES,PROYECCION PRO,PELICULA PEL,SALA SAL
                WHERE PRO.PRO_IDPROYECCION=RES.PRO_IDPROYECCION
                AND RES.CL_IDCLIENTE=CL.CL_IDCLIENTE
                AND PRO.PEL_IDPELI=PEL.PEL_IDPEL
                AND SAL.SAL_IDSALA=RES.SAL_IDSALA
                AND CL.CL_IDCLIENTE=VID;
VID2 NUMERIC(9);
VNOM VARCHAR2(100);
VHORA VARCHAR2(100); 
VPEL VARCHAR2(100);
NERROR NUMBER;
VMES VARCHAR2(500);
EXP EXCEPTION;
VSAL NUMERIC(9);
BEGIN
OPEN DATOS;
LOOP 
FETCH DATOS INTO VID2,VNOM,VHORA,VPEL,VSAL;
EXIT WHEN DATOS%NOTFOUND;
IF VID=VID2 THEN 
DBMS_OUTPUT.PUT_LINE(' El cliente '||VNOM||' con el ID '||VID2||' tiene la 
función a las '||VHORA||' de la pelicula '||VPEL||' en la sala '||VSAL);
ELSE 
DBMS_OUTPUT.PUT_LINE(' El cliente solicitado no se encontró');
END IF;
END LOOP;
CLOSE DATOS;
EXCEPTION 
  WHEN EXP THEN
      NERROR := 9999991;
      VMES := 'EXCEPCIÓN PERSONALIZADA';
      DBMS_OUTPUT.PUT_LINE('ERORR ' || NERROR ||  ' ' || VMES);
    WHEN OTHERS THEN
      NERROR := SQLCODE;
      VMES := SQLERRM;
      DBMS_OUTPUT.PUT_LINE('ERORR ' || NERROR ||  ' ' || VMES);
END COMPROBANTE; 

/*Mostrar los nombres de los empleados de cada sucursal*/

PROCEDURE LISTAEMPLEADOS
AS
CURSOR DATOS IS SELECT DISTINCT SUC_IDSUCURSAL,SUC_NOMBRE
                FROM SUCURSAL;
VNOM VARCHAR2(100);
VID NUMERIC;
VEMPL VARCHAR2(100);
NERROR NUMBER;
VMES VARCHAR2(500);
EXP EXCEPTION;
BEGIN 
OPEN DATOS;
LOOP
FETCH DATOS INTO VID,VNOM;
EXIT WHEN DATOS%NOTFOUND;
DBMS_OUTPUT.PUT_LINE(' Surcursal : '||VNOM);
DBMS_OUTPUT.PUT_LINE(' EMPLEADOS : ');
FOR CUR IN (SELECT EM_NOMBRE,EM_APELLIDO1
            FROM EMPLEADO
            WHERE SUC_IDSUCURSAL=VID)
LOOP
DBMS_OUTPUT.PUT_LINE(' - '||CUR.EM_NOMBRE||' '||CUR.EM_APELLIDO1);
END LOOP;
END LOOP;
CLOSE DATOS;
EXCEPTION 
  WHEN EXP THEN
      NERROR := 9999991;
      VMES := 'EXCEPCIÓN PERSONALIZADA';
      DBMS_OUTPUT.PUT_LINE('ERORR ' || NERROR ||  ' ' || VMES);
    WHEN OTHERS THEN
      NERROR := SQLCODE;
      VMES := SQLERRM;
      DBMS_OUTPUT.PUT_LINE('ERORR ' || NERROR ||  ' ' || VMES);
END LISTAEMPLEADOS;

/*Una función que muestre los horarios de las pelicula*/
                
  FUNCTION HORARIO
  RETURN SYS_REFCURSOR
  AS
    DATOS SYS_REFCURSOR;
    VSQL VARCHAR2(500);
  BEGIN
    VSQL := 'SELECT SUC.SUC_NOMBRE,PEL.PEL_NOMBRE,FUN_HORARIO,PRO.PRO_HORAINICIO,PRO.PRO_HORAFIN
                FROM SUCURSAL SUC,PROYECCION PRO,PELICULA PEL,FUNCION FUN,SALA SAL
                WHERE PRO.PRO_IDPROYECCION=FUN.PRO_IDPROYECCION
                AND SAL.SAL_IDSALA=FUN.SAL_IDSALA
                AND SAL.SUC_IDSUCURSAL=SUC.SUC_IDSUCURSAL
                AND PRO.PEL_IDPELI=PEL.PEL_IDPEL';
 open datos for VSQL;
     RETURN DATOS;
   END;

/*Un procedimiento que utilice un cursor de sistema y muestre el 
nombre y fecha de la pelicula que se proyecta los dias 14 y 15*/
PROCEDURE PELIDIA(DATOS OUT SYS_REFCURSOR)
AS 
BEGIN
OPEN DATOS FOR SELECT P.PEL_NOMBRE,F.FUN_HORARIO
                 FROM PELICULA P,FUNCION F,PROYECCION J
                 WHERE TO_CHAR(F.FUN_HORARIO,'DD') BETWEEN 14 AND 15
                 AND F.PRO_IDPROYECCION=J.PRO_IDPROYECCION
                 AND P.PEL_IDPEL=J.PEL_IDPELI;
END PELIDIA;

PROCEDURE PELIDIAB
AS
  VNAME VARCHAR2(100);
  VDATE DATE;
  NERROR NUMBER;
  VMES VARCHAR2(500);
  EXP EXCEPTION;
  DATOSB SYS_REFCURSOR;
BEGIN
     PAQUETECINE.PELIDIA(DATOSB);
      LOOP
      FETCH DATOSB INTO VNAME, VDATE;
        EXIT WHEN DATOSB%NOTFOUND;
          DBMS_OUTPUT.PUT_LINE(VNAME ||' - '||VDATE);
      END LOOP;
      CLOSE DATOSB;
      EXCEPTION 
  WHEN EXP THEN
      NERROR := 9999991;
      VMES := 'EXCEPCIÓN PERSONALIZADA';
      DBMS_OUTPUT.PUT_LINE('ERORR ' || NERROR ||  ' ' || VMES);
    WHEN OTHERS THEN
      NERROR := SQLCODE;
      VMES := SQLERRM;
      DBMS_OUTPUT.PUT_LINE('ERORR ' || NERROR ||  ' ' || VMES);
END PELIDIAB;

/*Extraiga todos los empleados nombres que tengan como segunda posición una vocal y como ultima una vocal, tambien que pertenezca en la sucursal del Lincon*/  
PROCEDURE NOMBRE
AS 
  VSQL VARCHAR2(600);
  VNOM VARCHAR2(100);
  TYPE DATOS IS REF CURSOR;
  CDATOS DATOS;
    VCOD NUMBER;
    VMES VARCHAR2(180);
    VEXP EXCEPTION;
BEGIN
  VSQL :='SELECT EM_NOMBRE
          FROM EMPLEADO
          WHERE REGEXP_LIKE(EM_NOMBRE,''^.[aeiou].+[aeiou]$'')
          AND SUC_IDSUCURSAL =(SELECT SUC_IDSUCURSAL
                              FROM SUCURSAL
                              WHERE SUC_IDSUCURSAL=1)';
OPEN CDATOS FOR VSQL;
LOOP 
FETCH CDATOS INTO VNOM;
EXIT WHEN CDATOS%NOTFOUND;
DBMS_OUTPUT.PUT_LINE(VNOM );
END LOOP;
CLOSE CDATOS;
 EXCEPTION 
 WHEN VEXP  THEN
     VCOD := 100001;
     VMES :=  'USUARIO FUERA DE RANGO DE EMPLEADOS';
     DBMS_OUTPUT.PUT_LINE(' - ' ||  VCOD || ' ERROR ' || VMES);
 WHEN NO_DATA_FOUND THEN
     VCOD := SQLCODE;
     VMES :=  SQLERRM;
   DBMS_OUTPUT.PUT_LINE(' - ' ||  VCOD || ' ERROR ' || VMES); 
 WHEN OTHERS THEN
     VCOD := SQLCODE;
     VMES := SQLERRM;
     DBMS_OUTPUT.PUT_LINE(' - ' ||  VCOD || ' ERROR ' || VMES);
END NOMBRE;

FUNCTION NUMERO
  RETURN SYS_REFCURSOR
  AS
    DATOS SYS_REFCURSOR;
    VSQL VARCHAR2(500);
  BEGIN
    VSQL := 'SELECT EM_NOMBRE,EM_TELEFONO
             FROM EMPLEADO
             WHERE REGEXP_LIKE(EM_TELEFONO,''^7.[01].+9'')';
 open datos for VSQL;
     RETURN DATOS;
   END NUMERO;
END PAQUETECINE;
-------------------------Respuuestas--------------------------------------------
EXECUTE PAQUETECINE.CantProyecCine;
EXECUTE PAQUETECINE.COMPROBANTE(2);
EXECUTE PAQUETECINE.LISTAEMPLEADOS;
EXECUTE PAQUETECINE.PELIDIAB;
EXECUTE PAQUETECINE.NOMBRE;

--------------------Respuesta función horario----------------------------------
DECLARE 
VSUC VARCHAR2(100);
VNOM VARCHAR2(100);
VHOR DATE;
VINI VARCHAR2(50);
VFIN VARCHAR2(50);
NERROR NUMBER;
VMES VARCHAR2(500);
EXP EXCEPTION;
CDATOS SYS_REFCURSOR;
BEGIN
CDATOS:=HORARIO;
LOOP
FETCH CDATOS INTO VSUC,VNOM,VHOR,VINI,VFIN;
EXIT WHEN CDATOS%NOTFOUND;
DBMS_OUTPUT.PUT_LINE(' - '||VSUC||' '||VNOM||' '||VHOR||' '||VINI||' '||VFIN);
END LOOP;
CLOSE CDATOS;
EXCEPTION 
  WHEN EXP THEN
      NERROR := 9999991;
      VMES := 'EXCEPCIÓN PERSONALIZADA';
      DBMS_OUTPUT.PUT_LINE('ERROR ' || NERROR ||  ' ' || VMES);
    WHEN OTHERS THEN
      NERROR := SQLCODE;
      VMES := SQLERRM;
      DBMS_OUTPUT.PUT_LINE('ERROR ' || NERROR ||  ' ' || VMES);
END;
------------------------Respuesta función número-------------------------------
UPDATE EMPLEADO SET EM_TELEFONO=70124579 WHERE EM_IDEMPLEADO=1;
DECLARE 
VNOM VARCHAR2(100);
VNUM NUMERIC;
NERROR NUMBER;
VMES VARCHAR2(500);
EXP EXCEPTION;
CDATOS SYS_REFCURSOR;
BEGIN
CDATOS:=NUMERO;
LOOP
FETCH CDATOS INTO VNOM,VNUM;
EXIT WHEN CDATOS%NOTFOUND;
DBMS_OUTPUT.PUT_LINE('El empleado '||VNOM||' con el número '||VNUM);
END LOOP;
CLOSE CDATOS;
EXCEPTION 
  WHEN EXP THEN
      NERROR := 9999991;
      VMES := 'EXCEPCIÓN PERSONALIZADA';
      DBMS_OUTPUT.PUT_LINE('ERROR ' || NERROR ||  ' ' || VMES);
    WHEN OTHERS THEN
      NERROR := SQLCODE;
      VMES := SQLERRM;
      DBMS_OUTPUT.PUT_LINE('ERROR ' || NERROR ||  ' ' || VMES);
END;
----------------------------------------------------------------------------------
CREATE OR REPLACE PROCEDURE TABLA_EMPLE
AS
  CURSOR DATOS IS SELECT SUC_NOMBRE, MAX(E.EM_SALARIO), MIN(E.EM_SALARIO),
                         ROUND(AVG(E.EM_SALARIO)),SUM(E.EM_SALARIO)
                         FROM SUCURSAL S,EMPLEADO E
                         WHERE S.SUC_IDSUCURSAL=E.SUC_IDSUCURSAL
                         GROUP BY SUC_NOMBRE
                         ORDER BY SUC_NOMBRE;
  VNOM VARCHAR2(80);
  VMAX NUMBER;
  VMIN NUMBER;
  VAVG NUMBER;
  VSUM NUMBER;
  NERROR NUMBER;
  VMES VARCHAR2(500);
  EXP EXCEPTION;
BEGIN
  DELETE FROM SAL_INFO;
  OPEN DATOS;
  LOOP
  FETCH DATOS INTO VNOM,VMAX,VMIN,VAVG,VSUM;
  EXIT WHEN DATOS%NOTFOUND;
    INSERT INTO SAL_INFO VALUES(VNOM,VMAX,VMIN,VAVG,VSUM);
  END LOOP;
  CLOSE DATOS;
  EXCEPTION 
  WHEN EXP THEN
      NERROR := 9999991;
      VMES := 'EXCEPCIÓN PERSONALIZADA';
      DBMS_OUTPUT.PUT_LINE('ERORR ' || NERROR ||  ' ' || VMES);
    WHEN OTHERS THEN
      NERROR := SQLCODE;
      VMES := SQLERRM;
      DBMS_OUTPUT.PUT_LINE('ERORR ' || NERROR ||  ' ' || VMES);
END TABLA_EMPLE;


CREATE OR REPLACE TRIGGER UPDATE_SALINFO
AFTER DELETE OR INSERT OR UPDATE OF EM_SALARIO
ON EMPLEADO
BEGIN
 TABLA_EMPLE;
END;
UPDATE EMPLEADO SET EM_SALARIO= 1400000 WHERE EM_IDEMPLEADO =1
SELECT * FROM SAL_INFO;
SELECT * FROM AUDITORIA_EMPLEADO




----------------------------RANDALL-------------------------------------------------

----------------------------------CLIENTES-----------------------------------------


CREATE OR REPLACE PROCEDURE OBT_PERSONAS(REGISTROS OUT SYS_REFCURSOR)
AS

BEGIN
   OPEN REGISTROS  FOR SELECT * FROM CLIENTE C   ORDER BY C.CL_NOMBRE;
END OBT_PERSONAS;


CREATE or replace PROCEDURE borrar_cliente(idCliente INT)
AS
begin
  DELETE FROM reserva
   WHERE cl_idcliente = idCliente;
   DELETE FROM cliente
   WHERE cl_idcliente = idCliente;
   commit;
end;


CREATE or replace PROCEDURE agregar_cliente(idCliente in number,
                                            nombre in varchar2,
                                            ap1 in varchar2,
                                            ap2 in varchar2,
                                            tel in number)
AS
begin
 insert into cliente values(idCliente,nombre,ap1,ap2,tel);
end;

CREATE OR REPLACE PROCEDURE actualizar_cliente(idCliente in number,
                                            nombre in varchar2,
                                            ap1 in varchar2,
                                            ap2 in varchar2,
                                            tel in number)
as
  vidCliente number :=idCliente;
  vnombre  varchar2(50) :=nombre ;
  vap1 varchar2(50) :=ap1;
  vap2  varchar2(50) :=ap2;
  vtel  number :=tel;
  
begin
  update cliente set cl_nombre = vnombre,
                     cl_apellido1 = vap1,
                     cl_apellido2 = vap2,
                     cl_telefono = vtel
                  where cl_idcliente = vidCliente ;
  Exception 
  when NO_DATA_FOUND then
    null;
  when others then
  raise;

end actualizar_cliente;

----------------------------------EMPLEADOS-----------------------------------------


CREATE OR REPLACE PROCEDURE OBT_EMPLEADOS(REGISTROS OUT SYS_REFCURSOR)
AS

BEGIN
   OPEN REGISTROS  FOR SELECT e.em_idempleado idE ,e.em_nombre NOMBRE ,e.em_apellido1 APELLIDO1,e.em_apellido2 APELLIDO2,e.em_telefono TELEFONO,e.em_direccion DIRECCION,e.em_salario SALARIO,s.suc_nombre SUCURSAL
                        FROM EMPLEADO E ,SUCURSAL s
                        where e.suc_idsucursal = s.suc_idsucursal;
  END;



CREATE or replace PROCEDURE borrar_empleado(idEmpleado INT)
AS
begin
   DELETE FROM empleado
   WHERE em_idempleado = idEmpleado;
   commit;
end;

CREATE or replace PROCEDURE agregar_empleado(idEmp in number,
                                            nombre in varchar2,
                                            ap1 in varchar2,
                                            ap2 in varchar2,
                                            tel in number,
                                            dir varchar2,
                                            sal number,
                                            suc number)
AS
begin
 insert into empleado values(idEmp,nombre,ap1,ap2,tel,dir,sal,suc);
end;

CREATE OR REPLACE PROCEDURE actualizar_empleado(idEmp in number,
                                            nombre in varchar2,
                                            ap1 in varchar2,
                                            ap2 in varchar2,
                                            tel in number,
                                            dir varchar2,
                                            sal number)
as
  vidEmp number :=idEmp;
  vnombre  varchar2(50) :=nombre ;
  vap1 varchar2(50) :=ap1;
  vap2  varchar2(50) :=ap2;
  vtel  number :=tel;
  vdir varchar2(100) :=dir;
  vsal number := sal;
  
begin
  update empleado set em_nombre = vnombre,
                     em_apellido1 = vap1,
                     em_apellido2 = vap2,
                     em_telefono = vtel,
                     em_direccion = vdir,
                     em_salario = vsal                     
                  where em_idempleado = vidEmp ;
  Exception 
  when NO_DATA_FOUND then
    null;
  when others then
  raise;

end actualizar_empleado;

  
----------------------------------PELICULAS-----------------------------------------


CREATE OR REPLACE PROCEDURE OBT_PELICULAS(REGISTROS OUT SYS_REFCURSOR)
AS

BEGIN
   OPEN REGISTROS  FOR SELECT p.pel_idpel "ID",p.pel_nombre TITULO,p.pel_clasificacion CLASIFICACION ,p.pel_idioma IDIOMA
                       FROM PELICULA P;
  END;

CREATE or replace PROCEDURE borrar_pelicula(idPelicula INT)
AS
begin   
   DELETE FROM pelicula
   WHERE pel_idpel = idPelicula;
   commit;
end;

CREATE or replace PROCEDURE agregar_pelicula(idPeli in number,
                                            nom in varchar2,
                                            cla in varchar2,
                                            idi in varchar2)
                                           
AS
begin
 insert into pelicula values(idPeli,nom,cla,idi);
end;

CREATE OR REPLACE PROCEDURE actualizar_peli(idPeli in number,
                                            nom in varchar2,
                                            cla in varchar2,
                                            idi in varchar2)
as
  vidPeli number :=idPeli;
  vnombre  varchar2(50) :=nom ;
  vcla varchar2(50) :=cla;
  vidi  varchar2(50) :=idi;

begin
  update pelicula set pel_nombre = vnombre,
                     pel_clasificacion = vcla,
                     pel_idioma = vidi                                    
                  where pel_idpel = vidPeli ;
  Exception 
  when NO_DATA_FOUND then
    null;
  when others then
  raise;

end actualizar_peli;  

----------------------------------PAQUETE DE Sucursales-----------------------------------------

CREATE OR REPLACE PACKAGE PKGSUCURSAL
AS
PROCEDURE OBT_SUCURSALES(REGISTROS OUT SYS_REFCURSOR);
PROCEDURE agregar_sucursal(idSuc in number,
                                            nom in varchar2,
                                            pro in varchar2,
                                            tel in number,
                                            dir in varchar2);
PROCEDURE borrar_sucursal(idSucursal INT);
PROCEDURE actualizar_sucursal(idSuc in number,
                                            nom in varchar2,
                                            pro in varchar2,
                                            tel in number,
                                            dir in varchar2);

end PKGSUCURSAL;

CREATE OR REPLACE PACKAGE BODY PKGSUCURSAL
AS

PROCEDURE OBT_SUCURSALES(REGISTROS OUT SYS_REFCURSOR)
AS

BEGIN
   OPEN REGISTROS  FOR SELECT s.suc_idsucursal "ID",s.suc_nombre SUCURSAL,
                              s.suc_telefono TELEFONO,s.suc_provincia PROVINCIA,
                              s.suc_direccion DIRECCION
                       FROM sucursal S;
  END;



PROCEDURE agregar_sucursal(idSuc in number,
                                            nom in varchar2,
                                            pro in varchar2,
                                            tel in number,
                                            dir in varchar2)
                                           
AS
begin
 insert into sucursal values(idSuc,nom,pro,tel,dir);
end;


PROCEDURE borrar_sucursal(idSucursal INT)
AS
begin
   
   DELETE FROM Sucursal
   WHERE suc_idsucursal = idSucursal;
   commit;
end;


PROCEDURE actualizar_sucursal(idSuc in number,
                                            nom in varchar2,
                                            pro in varchar2,
                                            tel in number,
                                            dir in varchar2)
as
  vidSuc number :=idSuc;
  vnom  varchar2(50) :=nom ;
  vpro varchar2(50) :=pro;
  vtel number :=tel;
  vdir varchar2(50) :=dir;

begin
  update sucursal set SUC_NOMBRE = vnom,
                     SUC_PROVINCIA = vpro,
                     SUC_TELEFONO = vtel , 
                     SUC_DIRECCION = vdir 
                  where SUC_IDSUCURSAL = vidSuc ;
  Exception 
  when NO_DATA_FOUND then
    null;
  when others then
  raise;

end actualizar_sucursal;


END PKGSUCURSAL;


----------------------------------------------PAQUETE PROYECCIONES--------------------------------------

CREATE OR REPLACE PACKAGE PKGPROYECCION
AS
PROCEDURE OBT_PROYECCION(REGISTROS OUT SYS_REFCURSOR);
end PKGPROYECCION;

CREATE OR REPLACE PACKAGE BODY PKGPROYECCION
AS

PROCEDURE OBT_PROYECCION(REGISTROS OUT SYS_REFCURSOR)
AS

BEGIN
   OPEN REGISTROS  FOR 
                      SELECT P.PRO_IDPROYECCION "ID",X.PEL_NOMBRE PELICULA,P.PRO_HORAINICIO INICIO,P.PRO_HORAFIN FIN
                      FROM PROYECCION P,PELICULA X
                      WHERE P.PEL_IDPELI = X.PEL_IDPEL;
  END;
END PKGPROYECCION;
---------------------------------------------PAQUETE SALAS---------------------------





CREATE OR REPLACE PACKAGE PKGSALA
AS
PROCEDURE OBT_SALA(REGISTROS OUT SYS_REFCURSOR);
end PKGSALA;

CREATE OR REPLACE PACKAGE BODY PKGSALA
AS

PROCEDURE OBT_SALA(REGISTROS OUT SYS_REFCURSOR)
AS

BEGIN
   OPEN REGISTROS  FOR 
                        SELECT S.SAL_IDSALA "ID",S.SAL_NUMEROSALA "# SALA",
                                S.SAL_NUMEROASIENTOS ASIENTOS,L.SUC_NOMBRE SUCURSAL
                        FROM SALA S,SUCURSAL L
                        WHERE L.SUC_IDSUCURSAL = S.SUC_IDSUCURSAL;
  END;
END PKGSALA;


--------------------------------------------------------PAQUETE DE RESERVA -------------------------------------------------------------------
CREATE OR REPLACE PACKAGE PKGRESERVA 
AS
PROCEDURE OBT_RESERVA(REGISTROS OUT SYS_REFCURSOR);
end PKGRESERVA;

CREATE OR REPLACE PACKAGE BODY PKGRESERVA 
AS 

PROCEDURE OBT_RESERVA(REGISTROS OUT SYS_REFCURSOR)
AS

BEGIN
   OPEN REGISTROS  FOR 
                        SELECT R.RES_IDRESERVA "ID",L.CL_NOMBRE||' '||L.CL_APELLIDO1 "CLIENTE",E.PEL_NOMBRE PELICULA,R.RES_BOLETOS "# BOLETOS",R.RES_COSTOTOTAL TOTAL,U.SUC_NOMBRE SUCURSAL,S.SAL_IDSALA          
                        FROM RESERVA R,CLIENTE L,PROYECCION P,SALA S,PELICULA E,SUCURSAL U
                        WHERE R.CL_IDCLIENTE = L.CL_IDCLIENTE
                        AND R.PRO_IDPROYECCION = P.PRO_IDPROYECCION
                        AND P.PEL_IDPELI = E.PEL_IDPEL
                        AND R.SAL_IDSALA = S.SAL_IDSALA
                        AND S.SUC_IDSUCURSAL = U.SUC_IDSUCURSAL;
  END;
END PKGRESERVA;

