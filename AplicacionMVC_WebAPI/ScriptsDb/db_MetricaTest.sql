use master
go
if exists(select name from sys.databases where name = 'db_MetricaTest')
	drop database db_MetricaTest
create database db_MetricaTest
go
use db_MetricaTest
go
--Bank
if not exists
      (select name from sysobjects where id = OBJECT_ID(N'[dbo].[bank]') 
               AND objectproperty(id, N'IsUserTable') = 1)
create table bank
(
	id int identity(1,1) constraint bank_pk primary key,
	name varchar(50),
	address varchar(128),
	registration_date datetime
)
go
insert into bank (name, address, registration_date) values ('BBVA Continental', 'Av. Lima 1086', GETDATE())
insert into bank (name, address, registration_date) values ('Interbank', 'Jr. Las Flores 445', GETDATE())
insert into bank (name, address, registration_date) values ('Scotiabank', 'Psje. Los Alamos 256', GETDATE())
go

--Branch
if not exists
      (select name from sysobjects where id = OBJECT_ID(N'[dbo].[branch]') 
               AND objectproperty(id, N'IsUserTable') = 1)
create table branch
(
	id int identity(1,1) constraint branch_pk primary key,
	bank_id int constraint branch_bank_id_fk foreign key references Bank(id),
	name varchar(50),
	address varchar(128),
	registration_date datetime
)
go
insert into branch (bank_id, name, address, registration_date) values (1, 'Agencia Surco', 'Jr. Las Lomas 333', GETDATE())
insert into branch (bank_id, name, address, registration_date) values (1, 'Agencia La Molina', 'Av. Republica de Colombia 556', GETDATE())
insert into branch (bank_id, name, address, registration_date) values (2, 'Agencia Surquillo', 'Jr. Los Incas 445', GETDATE())
insert into branch (bank_id, name, address, registration_date) values (2, 'Agencia Centro', 'Jr. Los Nogales 666', GETDATE())
insert into branch (bank_id, name, address, registration_date) values (3, 'Agencia Comas', 'Calle Las Perlas 568', GETDATE())
insert into branch (bank_id, name, address, registration_date) values (3, 'Agencia Miraflores', 'Av. Larco 1278', GETDATE())
go

--Currency
if not exists
      (select name from sysobjects where id = OBJECT_ID(N'[dbo].[currency]') 
               AND objectproperty(id, N'IsUserTable') = 1)
create table currency
(
	id int identity(1,1) constraint currency_pk primary key,
	iso varchar(3),
	symbol varchar(5),
	name varchar(50),
)
go
insert into currency (iso, symbol, name) values ('PEN', 'S/', 'Nuevos Soles')
insert into currency (iso, symbol, name) values ('USD', '$', 'Dolares Americanos')
go

--Payment State
if not exists
      (select name from sysobjects where id = OBJECT_ID(N'[dbo].[payment_state]') 
               AND objectproperty(id, N'IsUserTable') = 1)
create table payment_state
(
	id int identity(1,1) constraint payment_state_pk primary key,
	name varchar(50)
)
go
insert into payment_state (name) values ('Pagada')
insert into payment_state (name) values ('Declinada')
insert into payment_state (name) values ('Fallida')
insert into payment_state (name) values ('Anulada')
go

--Payment Order
if not exists
      (select name from sysobjects where id = OBJECT_ID(N'[dbo].[payment_order]') 
               AND objectproperty(id, N'IsUserTable') = 1)
create table payment_order
(
	id int identity(1,1) constraint sucursal_pk primary key,
	branch_id int constraint payment_order_branch_id_fk foreign key references branch(id),
	currency_id int constraint payment_order_currency_id_fk foreign key references currency(id),
	payment_state_id int constraint payment_order_payment_state_id_fk foreign key references payment_state(id),
	amount decimal(17, 2),
	payment_date datetime
)
go
insert into payment_order (branch_id, currency_id, payment_state_id, amount, payment_date) values (1, 1, 1, 500, GETDATE())
insert into payment_order (branch_id, currency_id, payment_state_id, amount, payment_date) values (2, 2, 2, 400, GETDATE())
insert into payment_order (branch_id, currency_id, payment_state_id, amount, payment_date) values (3, 1, 3, 300, GETDATE())
insert into payment_order (branch_id, currency_id, payment_state_id, amount, payment_date) values (4, 2, 4, 700, GETDATE())
insert into payment_order (branch_id, currency_id, payment_state_id, amount, payment_date) values (5, 1, 1, 100, GETDATE())
insert into payment_order (branch_id, currency_id, payment_state_id, amount, payment_date) values (6, 2, 2, 200, GETDATE())
go