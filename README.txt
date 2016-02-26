A principio o projeto não precisará de configuração, basta baixar do github e rodar, pois o configurei para acessar diretamente 
o banco online do Azure (banco MySql).

Caso seja de sua vontade alterar o banco, basta alterar a connectionString do arquivo Web.config com as configurações do banco local.
Se fizer isso terá que rodar os scripts abaixo para criar as tabelas no banco:

CREATE TABLE usuario (
  Id int(11) NOT NULL AUTO_INCREMENT,
  Nome varchar(45) NOT NULL,
  Senha varchar(45) NOT NULL,
  Admin bit(1) DEFAULT NULL,
  PRIMARY KEY (Id)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;


CREATE TABLE transportadora (
  Id int(11) NOT NULL AUTO_INCREMENT,
  Nome varchar(45) NOT NULL,
  PRIMARY KEY (Id)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;


CREATE TABLE nota (
  Id int(11) NOT NULL AUTO_INCREMENT,
  IdTransportadora int(11) NOT NULL,
  IdUsuario int(11) NOT NULL,
  Nota int(11) NOT NULL,
  PRIMARY KEY (Id)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

INSERT INTO usuario
(Nome, Senha, Admin)
VALUES
('admin', '123456', 1)