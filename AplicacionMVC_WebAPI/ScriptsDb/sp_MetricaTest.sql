use db_MetricaTest
go
--Currency List
if object_id('usp_currencyList') is null
execute('create procedure usp_currencyList as return 0')
go
alter procedure usp_currencyList
as
begin
	select c.id, c.iso, c.symbol, c.name
	from currency c
	order by c.id
end
go

--Payment State List
if object_id('usp_paymentStateList') is null
execute('create procedure usp_paymentStateList as return 0')
go
alter procedure usp_paymentStateList
as
begin
	select ps.id, ps.name
	from payment_state ps
	order by ps.id
end
go

------------------------
--Bank Procedures
------------------------
--Bank List
if object_id('usp_bankList') is null
execute('create procedure usp_bankList as return 0')
go
alter procedure usp_bankList
@id int = 0
as
begin
	select b.id, b.name, b.address, b.registration_date
	from bank b
	where (@id = 0 or b.id = @id)
	order by b.id
end
go

--Add Bank
if object_id('usp_addBank') is null
execute('create procedure usp_addBank as return 0')
go
alter procedure usp_addBank
@name varchar(50),
@address varchar(128),
@registration_date datetime
as
	insert into bank (name, address, registration_date) values (@name, @address, @registration_date)
go

--Update Bank
if object_id('usp_updateBank') is null
execute('create procedure usp_updateBank as return 0')
go
alter procedure usp_updateBank
@id int,
@name varchar(50),
@address varchar(128)
as
	update bank set name = @name, address = @address where id = @id
go

--Delete Bank
if object_id('usp_deleteBank') is null
execute('create procedure usp_deleteBank as return 0')
go
alter procedure usp_deleteBank
@id int
as
	delete bank where id = @id
go


------------------------
--Branch Procedures
------------------------
--Branch List
if object_id('usp_branchList') is null
execute('create procedure usp_branchList as return 0')
go
alter procedure usp_branchList
@bank_id int = 0
as
begin
	select br.id, br.name, br.address, br.registration_date, br.bank_id, b.name as bank_name
	from branch br
	inner join bank b on b.id = br.bank_id
	where (@bank_id = 0 or br.bank_id = @bank_id)
	order by br.id
end
go

--Add Branch
if object_id('usp_addBranch') is null
execute('create procedure usp_addBranch as return 0')
go
alter procedure usp_addBranch
@bank_id int,
@name varchar(50),
@address varchar(128),
@registration_date datetime
as
	insert into branch (bank_id, name, address, registration_date) values (@bank_id, @name, @address, @registration_date)
go

--Update Branch
if object_id('usp_updateBranch') is null
execute('create procedure usp_updateBranch as return 0')
go
alter procedure usp_updateBranch
@id int,
@bank_id int,
@name varchar(50),
@address varchar(128)
as
	update branch set bank_id = @bank_id, name = @name, address = @address where id = @id
go

--Delete Branch
if object_id('usp_deleteBranch') is null
execute('create procedure usp_deleteBranch as return 0')
go
alter procedure usp_deleteBranch
@id int
as
	delete branch where id = @id
go


----------------------------
--Payment Order Procedures
----------------------------
--Payment Order List
if object_id('usp_paymentOrderList') is null
execute('create procedure usp_paymentOrderList as return 0')
go
alter procedure usp_paymentOrderList
@currency_id int = 0
as
begin
	select po.id, po.amount, po.payment_date, po.branch_id, br.name as branch_name, po.currency_id, c.name as currency_name,
		c.symbol as currency_symbol, c.iso as currency_iso, po.payment_state_id, ps.name as payment_state_name
	from payment_order po
	inner join branch br on br.id = po.branch_id
	inner join currency c on c.id = po.currency_id
	inner join payment_state ps on ps.id = po.payment_state_id
	where (@currency_id = 0 or po.currency_id = @currency_id)
	order by po.id
end
go

--Add Payment Order
if object_id('usp_addPaymentOrder') is null
execute('create procedure usp_addPaymentOrder as return 0')
go
alter procedure usp_addPaymentOrder
@branch_id int,
@currency_id int,
@payment_state_id int,
@amount decimal (17, 2)
as
	insert into payment_order (branch_id, currency_id, payment_state_id, amount, payment_date) values (@branch_id, @currency_id, @payment_state_id, @amount, GETDATE())
go

--Update Payment Order
if object_id('usp_updatePaymentOrder') is null
execute('create procedure usp_updatePaymentOrder as return 0')
go
alter procedure usp_updatePaymentOrder
@id int,
@branch_id int,
@currency_id int,
@payment_state_id int,
@amount decimal (17, 2)
as
	update payment_order set branch_id = @branch_id, currency_id = @currency_id, payment_state_id = @payment_state_id, amount = @amount where id = @id
go

--Delete Payment Order
if object_id('usp_deletePaymentOrder') is null
execute('create procedure usp_deletePaymentOrder as return 0')
go
alter procedure usp_deletePaymentOrder
@id int
as
	delete payment_order where id = @id
go