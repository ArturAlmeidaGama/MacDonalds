create database dbMacDonalds;
use dbMacDonalds;
create table tbProduto
(
idProduto int auto_increment,
nmProduto varchar(100) not null,
vlProduto decimal(5,2) not null,
primary key(idProduto)
);
create table tbPedido
(
idPedido int auto_increment,
vlTotal decimal(8,2) not null,
vlTotalPago decimal(8,2) not null,
formaPag varchar(50) not null,
primary key(idPedido)
);
create table tbPedidoItem
(
idProdutoItem int not null,
idPedidoItem int not null,
vlProdutoItem decimal(5,2) not null,
qtde int not null,
primary key(idProdutoItem,idPedidoItem),
foreign key(idProdutoItem)references tbProduto(idProduto),
foreign key(idPedidoItem)references tbPedido(idPedido)
);
select * from tbProduto