create database bancarota
go
use bancarota

CREATE TABLE cliente(
id_cliente int Identity primary key, 
nombre varchar(30),
Domicilio varchar(30))

CREATE TABLE cuentatipo(
id_cuentatipo int Identity primary key,
nombre varchar(30))

CREATE TABLE cuentacliente(
id_cuenta int primary key , 
id_cliente int foreign key references cliente(id_cliente), 
id_cuentatipo int foreign key references cuentatipo(id_cuentatipo),
saldo money)

CREATE TABLE movimiento(
id_movimiento int Identity,
fecha Datetime, 
id_cuenta int foreign key references cuentacliente(id_cuenta), 
debito_credito bit, 
monto numeric(12,2), 
tasadiaria numeric(12,2),
vencimiento datetime)

insert into cuentatipo(nombre) values ('plazo fijo')
insert into cuentatipo(nombre) values ('cuenta corriente')
insert into cuentatipo(nombre) values ('caja de ahorro')
go

/* 0=false=debito(saca $$$)
1=true=credito(pone $$$)*/
