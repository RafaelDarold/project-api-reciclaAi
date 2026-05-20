USE reciclaai_db;

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

INSERT INTO Tipo_Material (id, nome, descricao, tipo_peso, criadoEm, atualizadoEm) VALUES
    (1, 'Plastico', 'Garrafas PET, embalagens e outros residuos plasticos reciclaveis.', 'kg', NOW(6), NOW(6)),
    (2, 'Papel', 'Papeis, jornais, revistas, caixas e papelao limpo.', 'kg', NOW(6), NOW(6)),
    (3, 'Vidro', 'Garrafas, potes e recipientes de vidro separados para coleta.', 'kg', NOW(6), NOW(6)),
    (4, 'Metal', 'Latas de aluminio, aco e pequenos metais reciclaveis.', 'kg', NOW(6), NOW(6)),
    (5, 'Eletronico', 'Pequenos eletronicos, cabos e componentes separados por unidade.', 'unidade', NOW(6), NOW(6))
ON DUPLICATE KEY UPDATE
    nome = VALUES(nome),
    descricao = VALUES(descricao),
    tipo_peso = VALUES(tipo_peso),
    atualizadoEm = NOW(6);

INSERT INTO Empresa (id, email, senha, telefone, responsavel, cnpj, razaoSocial, tipo_usuario_id) VALUES
    (1, 'contato@coopverdenorte.com', '$2a$11$wJ2T5cJ5J5wqO2wqv7nG2OZqHoV5L7fyS2mRZ0RGx2hJeJQ9XxGgG', '92999990001', 'Ana Souza', '12345678000190', 'Coop Verde Norte', 3),
    (2, 'operacao@ecociclo.com', '$2a$11$wJ2T5cJ5J5wqO2wqv7nG2OZqHoV5L7fyS2mRZ0RGx2hJeJQ9XxGgG', '92999990002', 'Bruno Castro', '98765432000110', 'EcoCiclo Servicos Ambientais', 3)
ON DUPLICATE KEY UPDATE
    telefone = VALUES(telefone),
    responsavel = VALUES(responsavel),
    razaoSocial = VALUES(razaoSocial),
    tipo_usuario_id = VALUES(tipo_usuario_id);

INSERT INTO Equipe_Coleta (id, status, nome, empresa_id) VALUES
    (1, 'ativa', 'Equipe Norte 01', 1),
    (2, 'ativa', 'Equipe Centro 02', 1),
    (3, 'em pausa', 'Equipe Reserva', 2)
ON DUPLICATE KEY UPDATE
    status = VALUES(status),
    nome = VALUES(nome),
    empresa_id = VALUES(empresa_id);

INSERT INTO Endereco (id, rua, numero, bairro, cidade, estado, pais, cep, observacao) VALUES
    (1, 'Rua das Samaumas', '120', 'Centro', 'Manaus', 'AM', 'Brasil', '69010010', 'Proximo a praca central.'),
    (2, 'Avenida Brasil', '850', 'Compensa', 'Manaus', 'AM', 'Brasil', '69036000', 'Portaria comercial.'),
    (3, 'Rua Rio Negro', '45', 'Adrianopolis', 'Manaus', 'AM', 'Brasil', '69057040', 'Casa com portao verde.'),
    (4, 'Travessa das Flores', '12', 'Cidade Nova', 'Manaus', 'AM', 'Brasil', '69095000', NULL)
ON DUPLICATE KEY UPDATE
    rua = VALUES(rua),
    numero = VALUES(numero),
    bairro = VALUES(bairro),
    cidade = VALUES(cidade),
    estado = VALUES(estado),
    pais = VALUES(pais),
    cep = VALUES(cep),
    observacao = VALUES(observacao);

INSERT INTO Cliente (id, cpf_cnpj, foto, email, senha, responsavel, telefone, nome, tipoPessoa, tipo_usuario_id) VALUES
    (1, '12345678901', 'https://example.com/fotos/marina.jpg', 'marina.alves@reciclaai.com', '$2a$11$wJ2T5cJ5J5wqO2wqv7nG2OZqHoV5L7fyS2mRZ0RGx2hJeJQ9XxGgG', 'Marina Alves', '92988880001', 'Marina Alves', 'PF', 1),
    (2, '11222333000144', 'https://example.com/fotos/mercado.jpg', 'mercado@exemplo.com', '$2a$11$wJ2T5cJ5J5wqO2wqv7nG2OZqHoV5L7fyS2mRZ0RGx2hJeJQ9XxGgG', 'Roberta Lima', '92988880002', 'Mercado Bom Preco', 'PJ', 1),
    (3, '98765432100', 'https://example.com/fotos/augusto.jpg', 'agustinho@gmail.com', '$2a$11$wJ2T5cJ5J5wqO2wqv7nG2OZqHoV5L7fyS2mRZ0RGx2hJeJQ9XxGgG', 'Augusto Freitas', '92988880003', 'Augusto Freitas', 'PF', 1)
ON DUPLICATE KEY UPDATE
    foto = VALUES(foto),
    responsavel = VALUES(responsavel),
    telefone = VALUES(telefone),
    nome = VALUES(nome),
    tipoPessoa = VALUES(tipoPessoa),
    tipo_usuario_id = VALUES(tipo_usuario_id);

INSERT INTO Cliente_Endereco (id, cliente_id, endereco_id) VALUES
    (1, 1, 1),
    (2, 2, 2),
    (3, 3, 3),
    (4, 1, 4)
ON DUPLICATE KEY UPDATE
    cliente_id = VALUES(cliente_id),
    endereco_id = VALUES(endereco_id);

INSERT INTO Catador (id, cpf_cnpj, senha, telefone, foto, nome, email, tipo_usuario_id, equipe_coleta_id) VALUES
    (1, '45678912300', '$2a$11$wJ2T5cJ5J5wqO2wqv7nG2OZqHoV5L7fyS2mRZ0RGx2hJeJQ9XxGgG', '92977770001', 'https://example.com/fotos/carlos.jpg', 'Carlos Lima', 'carlos.lima@reciclaai.com', 2, 1),
    (2, '78912345600', '$2a$11$wJ2T5cJ5J5wqO2wqv7nG2OZqHoV5L7fyS2mRZ0RGx2hJeJQ9XxGgG', '92977770002', 'https://example.com/fotos/joao.jpg', 'Joao Mendes', 'joao.mendes@reciclaai.com', 2, 2)
ON DUPLICATE KEY UPDATE
    telefone = VALUES(telefone),
    foto = VALUES(foto),
    nome = VALUES(nome),
    tipo_usuario_id = VALUES(tipo_usuario_id),
    equipe_coleta_id = VALUES(equipe_coleta_id);

INSERT INTO Solicitacao (id, dataSolicitacao, volumeEstimado, observacao, status, cliente_id, endereco_id, equipe_coleta_id, catador_id) VALUES
    (1, '2026-05-01 09:30:00', 18.50, 'Materiais separados em sacos por categoria.', 'pendente', 1, 1, NULL, NULL),
    (2, '2026-05-03 14:10:00', 42.00, 'Coleta comercial com papelao e plastico.', 'em andamento', 2, 2, 1, 1),
    (3, '2026-05-06 08:45:00', 12.25, 'Retirar no fim da tarde.', 'concluida', 3, 3, 2, 2),
    (4, '2026-05-08 11:00:00', 5.00, 'Cliente cancelou por falta de material.', 'cancelada', 1, 4, NULL, NULL)
ON DUPLICATE KEY UPDATE
    dataSolicitacao = VALUES(dataSolicitacao),
    volumeEstimado = VALUES(volumeEstimado),
    observacao = VALUES(observacao),
    status = VALUES(status),
    cliente_id = VALUES(cliente_id),
    endereco_id = VALUES(endereco_id),
    equipe_coleta_id = VALUES(equipe_coleta_id),
    catador_id = VALUES(catador_id);

INSERT INTO Solicitacao_Tipo_Material (id, quantidade, solicitacao_id, tipo_material_id) VALUES
    (1, 10.00, 1, 1),
    (2, 8.50, 1, 2),
    (3, 30.00, 2, 2),
    (4, 12.00, 2, 1),
    (5, 6.25, 3, 3),
    (6, 6.00, 3, 4),
    (7, 5.00, 4, 5)
ON DUPLICATE KEY UPDATE
    quantidade = VALUES(quantidade),
    solicitacao_id = VALUES(solicitacao_id),
    tipo_material_id = VALUES(tipo_material_id);

INSERT INTO Foto (id, url, solicitacao_id) VALUES
    (1, 'https://example.com/solicitacoes/1-material.jpg', 1),
    (2, 'https://example.com/solicitacoes/2-papelao.jpg', 2),
    (3, 'https://example.com/solicitacoes/3-vidro-metal.jpg', 3)
ON DUPLICATE KEY UPDATE
    url = VALUES(url),
    solicitacao_id = VALUES(solicitacao_id);

INSERT INTO Coleta (id, dataColeta, status, observacao, pesoTotal, horaColeta, solicitacao_id) VALUES
    (1, '2026-05-04 00:00:00', 'em andamento', 'Equipe a caminho do endereco.', 0.00, '15:30:00', 2),
    (2, '2026-05-07 00:00:00', 'finalizada', 'Coleta concluida sem divergencias.', 12.25, '10:15:00', 3)
ON DUPLICATE KEY UPDATE
    dataColeta = VALUES(dataColeta),
    status = VALUES(status),
    observacao = VALUES(observacao),
    pesoTotal = VALUES(pesoTotal),
    horaColeta = VALUES(horaColeta),
    solicitacao_id = VALUES(solicitacao_id);

INSERT INTO Coleta_Tipo_Material (id, quantidade, coleta_id, tipo_material_id) VALUES
    (1, 30.00, 1, 2),
    (2, 12.00, 1, 1),
    (3, 6.25, 2, 3),
    (4, 6.00, 2, 4)
ON DUPLICATE KEY UPDATE
    quantidade = VALUES(quantidade),
    coleta_id = VALUES(coleta_id),
    tipo_material_id = VALUES(tipo_material_id);

INSERT INTO Avaliacao (id, satisfacaoColeta, observacao, coleta_id, cliente_id) VALUES
    (1, 5, 'Atendimento rapido e materiais retirados corretamente.', 2, 3)
ON DUPLICATE KEY UPDATE
    satisfacaoColeta = VALUES(satisfacaoColeta),
    observacao = VALUES(observacao),
    coleta_id = VALUES(coleta_id),
    cliente_id = VALUES(cliente_id);

ALTER TABLE Tipo_Material AUTO_INCREMENT = 6;
ALTER TABLE usuarios AUTO_INCREMENT = 7;
ALTER TABLE Empresa AUTO_INCREMENT = 3;
ALTER TABLE Equipe_Coleta AUTO_INCREMENT = 4;
ALTER TABLE Endereco AUTO_INCREMENT = 5;
ALTER TABLE Cliente AUTO_INCREMENT = 4;
ALTER TABLE Cliente_Endereco AUTO_INCREMENT = 5;
ALTER TABLE Catador AUTO_INCREMENT = 3;
ALTER TABLE Solicitacao AUTO_INCREMENT = 5;
ALTER TABLE Solicitacao_Tipo_Material AUTO_INCREMENT = 8;
ALTER TABLE Foto AUTO_INCREMENT = 4;
ALTER TABLE Coleta AUTO_INCREMENT = 3;
ALTER TABLE Coleta_Tipo_Material AUTO_INCREMENT = 5;
ALTER TABLE Avaliacao AUTO_INCREMENT = 2;


