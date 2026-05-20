CREATE DATABASE IF NOT EXISTS reciclaai_db
    CHARACTER SET utf8mb4
    COLLATE utf8mb4_unicode_ci;

USE reciclaai_db;

CREATE TABLE IF NOT EXISTS Tipo_Usuario (
    id INT NOT NULL AUTO_INCREMENT,
    nome VARCHAR(100) NOT NULL,
    nivel_acesso INT NOT NULL,
    PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS usuarios (
    id BIGINT UNSIGNED NOT NULL AUTO_INCREMENT,
    nome VARCHAR(150) NOT NULL,
    email VARCHAR(150) NOT NULL,
    tipoPessoa VARCHAR(20) NOT NULL,
    perfil VARCHAR(30) NOT NULL,
    ativo TINYINT(1) NOT NULL,
    criado_em DATETIME(6) NOT NULL,
    atualizado_em DATETIME(6) NOT NULL,
    PRIMARY KEY (id),
    UNIQUE KEY IX_usuarios_email (email)
);

CREATE TABLE IF NOT EXISTS Endereco (
    id INT NOT NULL AUTO_INCREMENT,
    rua VARCHAR(150) NOT NULL,
    numero VARCHAR(10) NOT NULL,
    bairro VARCHAR(100) NOT NULL,
    cidade VARCHAR(100) NOT NULL,
    estado VARCHAR(50) NOT NULL,
    pais VARCHAR(50) NOT NULL,
    cep VARCHAR(10) NOT NULL,
    observacao TEXT NULL,
    PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS Tipo_Material (
    id INT NOT NULL AUTO_INCREMENT,
    nome VARCHAR(100) NOT NULL,
    descricao TEXT NULL,
    tipo_peso VARCHAR(50) NOT NULL,
    criadoEm DATETIME(6) NOT NULL,
    atualizadoEm DATETIME(6) NOT NULL,
    PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS Empresa (
    id INT NOT NULL AUTO_INCREMENT,
    email VARCHAR(150) NOT NULL,
    senha VARCHAR(255) NOT NULL,
    telefone VARCHAR(20) NOT NULL,
    responsavel VARCHAR(150) NOT NULL,
    cnpj VARCHAR(20) NOT NULL,
    razaoSocial VARCHAR(150) NOT NULL,
    tipo_usuario_id INT NOT NULL,
    PRIMARY KEY (id),
    UNIQUE KEY IX_Empresa_email (email),
    UNIQUE KEY IX_Empresa_cnpj (cnpj),
    CONSTRAINT FK_Empresa_Tipo_Usuario_tipo_usuario_id
        FOREIGN KEY (tipo_usuario_id) REFERENCES Tipo_Usuario(id)
        ON DELETE RESTRICT
);

CREATE TABLE IF NOT EXISTS Equipe_Coleta (
    id INT NOT NULL AUTO_INCREMENT,
    status VARCHAR(50) NOT NULL,
    nome VARCHAR(100) NOT NULL,
    empresa_id INT NOT NULL,
    PRIMARY KEY (id),
    KEY IX_Equipe_Coleta_empresa_id (empresa_id),
    CONSTRAINT FK_Equipe_Coleta_Empresa_empresa_id
        FOREIGN KEY (empresa_id) REFERENCES Empresa(id)
        ON DELETE RESTRICT
);

CREATE TABLE IF NOT EXISTS Cliente (
    id INT NOT NULL AUTO_INCREMENT,
    cpf_cnpj VARCHAR(20) NOT NULL,
    foto VARCHAR(255) NOT NULL,
    email VARCHAR(150) NOT NULL,
    senha VARCHAR(255) NOT NULL,
    responsavel VARCHAR(150) NOT NULL,
    telefone VARCHAR(20) NOT NULL,
    nome VARCHAR(150) NOT NULL,
    tipoPessoa VARCHAR(20) NOT NULL,
    tipo_usuario_id INT NOT NULL,
    PRIMARY KEY (id),
    UNIQUE KEY IX_Cliente_email (email),
    UNIQUE KEY IX_Cliente_cpf_cnpj (cpf_cnpj),
    CONSTRAINT FK_Cliente_Tipo_Usuario_tipo_usuario_id
        FOREIGN KEY (tipo_usuario_id) REFERENCES Tipo_Usuario(id)
        ON DELETE RESTRICT
);

CREATE TABLE IF NOT EXISTS Cliente_Endereco (
    id INT NOT NULL AUTO_INCREMENT,
    cliente_id INT NOT NULL,
    endereco_id INT NOT NULL,
    PRIMARY KEY (id),
    KEY IX_Cliente_Endereco_cliente_id (cliente_id),
    KEY IX_Cliente_Endereco_endereco_id (endereco_id),
    CONSTRAINT FK_Cliente_Endereco_Cliente_cliente_id
        FOREIGN KEY (cliente_id) REFERENCES Cliente(id)
        ON DELETE CASCADE,
    CONSTRAINT FK_Cliente_Endereco_Endereco_endereco_id
        FOREIGN KEY (endereco_id) REFERENCES Endereco(id)
        ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS Catador (
    id INT NOT NULL AUTO_INCREMENT,
    cpf_cnpj VARCHAR(20) NOT NULL,
    senha VARCHAR(255) NOT NULL,
    telefone VARCHAR(20) NOT NULL,
    foto VARCHAR(255) NOT NULL,
    nome VARCHAR(150) NOT NULL,
    email VARCHAR(150) NOT NULL,
    tipo_usuario_id INT NOT NULL,
    equipe_coleta_id INT NOT NULL,
    PRIMARY KEY (id),
    UNIQUE KEY IX_Catador_email (email),
    UNIQUE KEY IX_Catador_cpf_cnpj (cpf_cnpj),
    KEY IX_Catador_tipo_usuario_id (tipo_usuario_id),
    KEY IX_Catador_equipe_coleta_id (equipe_coleta_id),
    CONSTRAINT FK_Catador_Tipo_Usuario_tipo_usuario_id
        FOREIGN KEY (tipo_usuario_id) REFERENCES Tipo_Usuario(id)
        ON DELETE RESTRICT,
    CONSTRAINT FK_Catador_Equipe_Coleta_equipe_coleta_id
        FOREIGN KEY (equipe_coleta_id) REFERENCES Equipe_Coleta(id)
        ON DELETE RESTRICT
);

CREATE TABLE IF NOT EXISTS Solicitacao (
    id INT NOT NULL AUTO_INCREMENT,
    dataSolicitacao DATETIME(6) NOT NULL,
    volumeEstimado DECIMAL(10,2) NOT NULL,
    observacao TEXT NULL,
    status VARCHAR(50) NOT NULL,
    cliente_id INT NOT NULL,
    endereco_id INT NOT NULL,
    equipe_coleta_id INT NULL,
    catador_id INT NULL,
    PRIMARY KEY (id),
    KEY IX_Solicitacao_cliente_id (cliente_id),
    KEY IX_Solicitacao_endereco_id (endereco_id),
    KEY IX_Solicitacao_equipe_coleta_id (equipe_coleta_id),
    KEY IX_Solicitacao_catador_id (catador_id),
    CONSTRAINT FK_Solicitacao_Cliente_cliente_id
        FOREIGN KEY (cliente_id) REFERENCES Cliente(id)
        ON DELETE RESTRICT,
    CONSTRAINT FK_Solicitacao_Endereco_endereco_id
        FOREIGN KEY (endereco_id) REFERENCES Endereco(id)
        ON DELETE RESTRICT,
    CONSTRAINT FK_Solicitacao_Equipe_Coleta_equipe_coleta_id
        FOREIGN KEY (equipe_coleta_id) REFERENCES Equipe_Coleta(id)
        ON DELETE SET NULL,
    CONSTRAINT FK_Solicitacao_Catador_catador_id
        FOREIGN KEY (catador_id) REFERENCES Catador(id)
        ON DELETE SET NULL
);

CREATE TABLE IF NOT EXISTS Solicitacao_Tipo_Material (
    id INT NOT NULL AUTO_INCREMENT,
    quantidade DECIMAL(10,2) NOT NULL,
    solicitacao_id INT NOT NULL,
    tipo_material_id INT NOT NULL,
    PRIMARY KEY (id),
    KEY IX_Solicitacao_Tipo_Material_solicitacao_id (solicitacao_id),
    KEY IX_Solicitacao_Tipo_Material_tipo_material_id (tipo_material_id),
    CONSTRAINT FK_Solicitacao_Tipo_Material_Solicitacao_solicitacao_id
        FOREIGN KEY (solicitacao_id) REFERENCES Solicitacao(id)
        ON DELETE CASCADE,
    CONSTRAINT FK_Solicitacao_Tipo_Material_Tipo_Material_tipo_material_id
        FOREIGN KEY (tipo_material_id) REFERENCES Tipo_Material(id)
        ON DELETE RESTRICT
);

CREATE TABLE IF NOT EXISTS Foto (
    id INT NOT NULL AUTO_INCREMENT,
    url VARCHAR(255) NOT NULL,
    solicitacao_id INT NOT NULL,
    PRIMARY KEY (id),
    KEY IX_Foto_solicitacao_id (solicitacao_id),
    CONSTRAINT FK_Foto_Solicitacao_solicitacao_id
        FOREIGN KEY (solicitacao_id) REFERENCES Solicitacao(id)
        ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS Coleta (
    id INT NOT NULL AUTO_INCREMENT,
    dataColeta DATETIME(6) NOT NULL,
    status VARCHAR(50) NOT NULL,
    observacao TEXT NULL,
    pesoTotal DECIMAL(10,2) NOT NULL,
    horaColeta TIME(6) NOT NULL,
    solicitacao_id INT NOT NULL,
    PRIMARY KEY (id),
    KEY IX_Coleta_solicitacao_id (solicitacao_id),
    CONSTRAINT FK_Coleta_Solicitacao_solicitacao_id
        FOREIGN KEY (solicitacao_id) REFERENCES Solicitacao(id)
        ON DELETE RESTRICT
);

CREATE TABLE IF NOT EXISTS Avaliacao (
    id INT NOT NULL AUTO_INCREMENT,
    satisfacaoColeta INT NOT NULL,
    observacao TEXT NULL,
    coleta_id INT NOT NULL,
    cliente_id INT NOT NULL,
    PRIMARY KEY (id),
    KEY IX_Avaliacao_coleta_id (coleta_id),
    KEY IX_Avaliacao_cliente_id (cliente_id),
    CONSTRAINT FK_Avaliacao_Coleta_coleta_id
        FOREIGN KEY (coleta_id) REFERENCES Coleta(id)
        ON DELETE RESTRICT,
    CONSTRAINT FK_Avaliacao_Cliente_cliente_id
        FOREIGN KEY (cliente_id) REFERENCES Cliente(id)
        ON DELETE RESTRICT
);

CREATE TABLE IF NOT EXISTS Coleta_Tipo_Material (
    id INT NOT NULL AUTO_INCREMENT,
    quantidade DECIMAL(10,2) NOT NULL,
    coleta_id INT NOT NULL,
    tipo_material_id INT NOT NULL,
    PRIMARY KEY (id),
    KEY IX_Coleta_Tipo_Material_coleta_id (coleta_id),
    KEY IX_Coleta_Tipo_Material_tipo_material_id (tipo_material_id),
    CONSTRAINT FK_Coleta_Tipo_Material_Coleta_coleta_id
        FOREIGN KEY (coleta_id) REFERENCES Coleta(id)
        ON DELETE CASCADE,
    CONSTRAINT FK_Coleta_Tipo_Material_Tipo_Material_tipo_material_id
        FOREIGN KEY (tipo_material_id) REFERENCES Tipo_Material(id)
        ON DELETE RESTRICT
);

CREATE TABLE IF NOT EXISTS Chave_Autenticacao (
    id INT NOT NULL AUTO_INCREMENT,
    chave_hash VARCHAR(64) NOT NULL,
    usuario_tipo VARCHAR(30) NOT NULL,
    usuario_id BIGINT UNSIGNED NOT NULL,
    criado_em DATETIME(6) NOT NULL,
    expira_em DATETIME(6) NOT NULL,
    revogada_em DATETIME(6) NULL,
    PRIMARY KEY (id),
    UNIQUE KEY IX_Chave_Autenticacao_chave_hash (chave_hash),
    KEY IX_Chave_Autenticacao_usuario (usuario_tipo, usuario_id)
);

INSERT INTO Tipo_Usuario (id, nome, nivel_acesso) VALUES
    (1, 'CLIENTE', 1),
    (2, 'CATADOR', 2),
    (3, 'EMPRESA', 3)
ON DUPLICATE KEY UPDATE
    nome = VALUES(nome),
    nivel_acesso = VALUES(nivel_acesso);

INSERT INTO usuarios (id, nome, email, tipoPessoa, perfil, ativo, criado_em, atualizado_em) VALUES
    (2, 'Carlos Lima', 'carlos.lima@reciclaai.com', 'PF', 'CATADOR', 1, '2026-04-21 22:03:07', '2026-04-21 22:03:07'),
    (3, 'Coop Verde Norte', 'contato@coopverdenorte.com', 'PJ', 'EMPRESA', 1, '2026-04-21 22:03:07', '2026-04-21 22:03:07'),
    (4, 'Marina Alves', 'marina.alves@reciclaai.com', 'PF', 'CLIENTE', 1, '2026-04-21 22:03:07', '2026-04-21 22:03:07'),
    (5, 'Joao Mendes', 'joao.mendes@reciclaai.com', 'PF', 'CATADOR', 0, '2026-04-21 22:03:07', '2026-04-21 22:03:07'),
    (6, 'Augusto Freitas', 'agustinho@gmail.com', 'PF', 'CLIENTE', 1, '2026-05-05 23:24:02', '2026-05-05 23:24:02')
ON DUPLICATE KEY UPDATE
    nome = VALUES(nome),
    email = VALUES(email),
    tipoPessoa = VALUES(tipoPessoa),
    perfil = VALUES(perfil),
    ativo = VALUES(ativo),
    atualizado_em = VALUES(atualizado_em);

ALTER TABLE usuarios AUTO_INCREMENT = 7;
