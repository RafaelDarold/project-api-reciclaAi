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
