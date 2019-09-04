CREATE DATABASE M_AutoPecas
GO

USE M_AutoPecas
GO

CREATE TABLE Usuarios
(
	UsuarioId		INT PRIMARY KEY IDENTITY
	, Email			VARCHAR(255) NOT NULL UNIQUE
	, Senha			VARCHAR(255) NOT NULL
);

CREATE TABLE Fornecedores 
(
	FornecedorId	INT PRIMARY KEY IDENTITY
	, CNPJ			CHAR(14)		NOT NULL UNIQUE
	, RazaoSocial	VARCHAR(255)	NOT NULL UNIQUE
	, NomeFantasia	VARCHAR(255)	NOT NULL
	, Endereco		VARCHAR(255)	NOT NULL
	, UsuarioId		INT FOREIGN KEY REFERENCES Usuarios(UsuarioId) NOT NULL UNIQUE
);

CREATE TABLE Pecas (
	PecaId			INT PRIMARY KEY IDENTITY
	, Codigo		VARCHAR(255) NOT NULL UNIQUE
	, Descricao		TEXT
	, Peso			FLOAT(2) NOT NULL
	, PrecoCusto	FLOAT(2) NOT NULL
	, PrecoVenda	FLOAT(2) NOT NULL
	, FornecedorId	INT FOREIGN KEY REFERENCES Fornecedores(FornecedorId) NOT NULL
);

INSERT INTO Usuarios (Email, Senha) 
	VALUES	('mano@brown.com', 'manob')
			,('charlie@brown.com', 'choris');



INSERT INTO Fornecedores (CNPJ, RazaoSocial, NomeFantasia, Endereco, UsuarioId) 
	VALUES	('11111111111111', 'Que ota produções ', 'V$M Inc.', 'Avendia jhonny', 1)
			,('22222222222222', 'Fon', 'Yoda', 'Rua lego legal', 2);

INSERT INTO Pecas (Codigo, Descricao, Peso, PrecoCusto, PrecoVenda, FornecedorId) 
			VALUES	('01', 'Desert Eagle', 1, 1000, 2000, 1)
					,('02', 'Main Mid', 1, 10, 50, 2);

SELECT * FROM Fornecedores

