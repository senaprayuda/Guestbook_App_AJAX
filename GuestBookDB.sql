create database GuestBookDB;
use GuestBookDB

Create table GuestBook(
id int identity (1,1) primary key null,
nama varchar(100) null,
alamat varchar(150) null,
provinsi varchar(50) null,
jenisKelamin int null,
tanggalLahir date null,
pesan varchar(150) not null);


create procedure insertGuest
@nama varchar(100),
@alamat varchar(150), 
@provinsi varchar(50), 
@jenisKelamin int, 
@tanggalLahir date, 
@pesan varchar(150)

as 
insert into Guest values (@nama, @alamat, @provinsi, @jenisKelamin, @tanggalLahir, @pesan)
go

drop procedure selectGuest
drop procedure insertGuest


create procedure [dbo].[selectGuest]
as
select case
		when jenisKelamin=0 then 'Perempuan' else 'Laki-Laki' end as gender, 
		cast (tanggalLahir AS VARCHAR(10))  as lahir, *
from Guest



drop table GuestBook

select * from GuestBook

