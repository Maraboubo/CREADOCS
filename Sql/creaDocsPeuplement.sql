INSERT INTO SEXE (abrSexe, nomSexe) VALUES
('M', 'Masculin'),
('F', 'Féminin'),
('N', 'Non spécifié');

INSERT INTO SECURITE_SOCIALE (nomRegimeSecu) VALUES
('Régime Général'),
('Régime Agricole'),
('Régime Social des Indépendants'),
('Régime Spécial Fonction Publique'),
('Régime Étudiant');

--avant d'insérer las données client il faut que la ville et le pays existent dans les tables correspondantes.

--INSERT INTO CLIENTS(id_sexe, id_ville, id_regimeSecu, numCompteCli, numSecuCli, nomCli, prenomCli, telCli, mailCli, depNaissCli, dateNaissCli, add1Cli, add2Cli, add3Cli) VALUES
--(1, 101, 1, 'FR7630006000011234567890189', '1234567890123456', 'Dupont', 'Jean', '0123456789', 'jean.dupont@example.com', '75', '1985-01-15', '10 Rue de la Paix', NULL, NULL),
--(2, 102, 2, 'FR7630006000019876543210123', '9876543210987654', 'Durand', 'Marie', '0987654321', 'marie.durand@example.com', '92', '1990-05-20', '20 Avenue des Champs', 'Élysées', NULL),
--(3, 103, 3, 'FR7630006000014561237890123', '4561237890456123', 'Martin', 'Claire', '0771234567', 'claire.martin@example.com', '69', '1992-03-10', '30 Boulevard Saint-Germain', 'Apt 2B', NULL),
--(1, 104, 4, NULL, '6547893210654789', 'Bernard', 'Luc', '0667891234', 'luc.bernard@example.com', '33', '1980-07-25', '40 Rue de Rivoli', NULL, NULL),
--(2, 105, NULL, 'FR7630006000013216549870789', NULL, 'Leroy', 'Anna', '0654321987', 'anna.leroy@example.com', '13', '1995-11-30', '50 Rue Lafayette', 'Étage 3', 'Porte A');

INSERT INTO TYPE_CONTRAT (typContr) VALUES
('Contrat d assurance'),
('Contrat de mutuelle'),
('Contrat de carte bancaire'),
('Contrat de carte SIM');

INSERT INTO TYPE_CARTE (nomType, RetMaxSemKwFr, RetMaxSemAbFr, RetTotalSemFr, RetMaxSemAbEtr, RetTotalSemEtr, RetMaxAuto, PaiMaxSemFr, PaiMaxSemEtr, PaiMaxSemTotal, PaiMaxMoisFr, PaiMaxMoisEtr, PaiMaxMoisTotal) VALUES
('Carte Classique', 300, 200, 500, 150, 250, 500, 1000, 500, 1500, 3000, 1500, 4500),
('Carte Gold', 600, 400, 1000, 300, 500, 1000, 2000, 1000, 3000, 6000, 3000, 9000),
('Carte Platinum', 900, 600, 1500, 450, 750, 1500, 3000, 1500, 4500, 9000, 4500, 13500),
('Carte Infinite', 1200, 800, 2000, 600, 1000, 2000, 4000, 2000, 6000, 12000, 6000, 18000);

INSERT INTO TITRE (nomTitre) VALUES
('Conseiller'),
('Directeur'),
('Gestionnaire'),
('Chargé de clientèle'),
('Agent commercial'),
('Responsable des ventes'),
('Assistant administratif'),
('Analyste financier');

INSERT INTO AGENCE (nomAgence, nomDirAgence, prenomDirAgence) VALUES
('Agence Centrale', 'Martin', 'Pierre'),
('Agence Nord', 'Durand', 'Sophie'),
('Agence Sud', 'Lefevre', 'Jean'),
('Agence Est', 'Moreau', 'Marie'),
('Agence Ouest', 'Simon', 'Louis');

INSERT INTO INTERLOCUTEUR (id_titre, id_agence, loginInter, mdpInter, loginKwInter, mdpKwInter, nomInter, prenomInter, telInter, mailInter) VALUES
(1, 1, 'pmartin', 'password123', 'pmartin_kw', 'kw_password123', 'Martin', 'Pierre', '0123456789', 'p.martin@agencecentrale.com'),
(2, 2, 'sdurand', 'password123', 'sdurand_kw', 'kw_password123', 'Durand', 'Sophie', '0123456789', 's.durand@agencenord.com'),
(3, 3, 'jlefevre', 'password123', 'jlefevre_kw', 'kw_password123', 'Lefevre', 'Jean', '0123456789', 'j.lefevre@agencesud.com'),
(4, 4, 'mmoreau', 'password123', 'mmoreau_kw', 'kw_password123', 'Moreau', 'Marie', '0123456789', 'm.moreau@agenceest.com'),
(5, 5, 'lsimon', 'password123', 'lsimon_kw', 'kw_password123', 'Simon', 'Louis', '0123456789', 'l.simon@agenceouest.com');

INSERT INTO ASSURANCE (nomAssu, valeurAssu) VALUES
('Assurance Habitation', 50.00),
('Assurance Auto', 70.00),
('Assurance Santé', 100.00),
('Assurance Vie', 150.00),
('Assurance Voyage', 20.00);

INSERT INTO MUTUELLE (nomMutu, valeurMutu) VALUES
('Mutuelle Santé Standard', 50.00),
('Mutuelle Santé Plus', 75.00),
('Mutuelle Dentaire', 30.00),
('Mutuelle Optique', 40.00),
('Mutuelle Hospitalisation', 100.00);

INSERT INTO MODE_PAIEMENT (nomModePai) VALUES
('Carte Bancaire'),
('Virement'),
('Prélèvement Automatique'),
('Chèque'),
('Espèces');

INSERT INTO TYPE_SIM (nomTypeSim, valeurTypeSim, nomRemiseTypeSim, valeurRemiseTypeSim) VALUES
('Forfait Standard', 20, 'Remise 10%', 2.00),
('Forfait Illimité', 50, 'Remise 20%', 10.00),
('Forfait Data', 30, 'Remise 15%', 4.50),
('Forfait International', 70, 'Remise 25%', 17.50),
('Forfait Jeunes', 15, 'Remise 5%', 0.75);

INSERT INTO IDENTIFICATION VALUES
(1, 'mathieusoleri');