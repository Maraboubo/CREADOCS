--Test pour la modification de la fonctionnalité d'inscription au sein de l'Api afin qu'elle retourne un utilisateur.

INSERT INTO INTERLOCUTEUR(id_titre, id_agence, loginInter, mdpInter, loginKwInter, mdpKwInter, nomInter, prenomInter, telInter, mailInter)
VALUES (1, 2, 'LoginFinal', 'MotdePasseUltime', 'bla', 'bla', 'Jacques', 'Frere', '06.32.35.36.95', 'frereJacques@mail.com')
GO
SELECT * FROM INTERLOCUTEUR
WHERE mdpInter = 'MotdePasseUltime' AND mailInter = 'frereJacques@mail.com'
GO


--	Test en vue de l'amélioration de la fonctionnalité de connexion. Afin de renvoyer toutes les informations concernant l'interlocuteur.

SELECT id_Inter, prenomInter, nomInter, telInter, INTERLOCUTEUR.id_titre, INTERLOCUTEUR.id_agence, mailInter, nomAgence, nomDirAgence, prenomDirAgence, nomTitre FROM INTERLOCUTEUR
INNER JOIN AGENCE
ON INTERLOCUTEUR.id_agence = AGENCE.id_agence
INNER JOIN TITRE
ON INTERLOCUTEUR.id_titre = TITRE.id_titre
WHERE mailInter = 's.durand@agencenord.com' AND mdpInter = 'password123'


--	Test en vue de l'amélioration de la fonctionnalité de d'inscription. Afin de renvoyer toutes les informations concernant l'interlocuteur.

INSERT INTO INTERLOCUTEUR(id_titre, id_agence, loginInter, mdpInter, loginKwInter, mdpKwInter, nomInter, prenomInter, telInter, mailInter)
VALUES (1, 2, 'blabla', 'unModDePasse123', 'k', 'k', 'Michel', 'Michel', '06.32.24.58.56', 'sardou@michel.com')

SELECT id_Inter, prenomInter, nomInter, telInter, INTERLOCUTEUR.id_titre, INTERLOCUTEUR.id_agence, mailInter, nomAgence, nomDirAgence, prenomDirAgence, nomTitre FROM INTERLOCUTEUR
INNER JOIN AGENCE ON INTERLOCUTEUR.id_agence = AGENCE.id_agence
INNER JOIN TITRE ON INTERLOCUTEUR.id_titre = TITRE.id_titre
WHERE mdpInter = 'unModDePasse123' AND mailInter = 'sardou@michel.com'

--	Test en vue de l'amélioration de la fonctionnalité de d'ajout de client.
--	détermination des attributs à retourner à la partie 'front' afin de créer un constructeur dans l'api.

INSERT INTO CLIENTS (id_sexe, id_ville, id_regimeSecu, nomCli, prenomCli, numIdCli, telCli, mailCli, depNaIssCli, dateNaissCli, add1Cli, add2Cli, add3Cli, numCompteCli, numSecuCli) 
VALUES (1, 1, 3, 'Deloin', 'Alain', 'qsd654aze987', '04.32.56.98.65', 'a.deloin@hotmail.com', '26', 1985-10-15, 'rue', 'de', 'la', null, null);
SELECT * FROM CLIENTS
INNER JOIN VILLES
ON CLIENTS.id_ville = VILLES.id_ville
INNER JOIN PAYS
ON VILLES.countryCode = PAYS.countryCode
INNER JOIN SEXE
ON CLIENTS.id_sexe = SEXE.id_sexe
INNER JOIN SECURITE_SOCIALE
ON CLIENTS.id_regimeSecu = SECURITE_SOCIALE.id_regimeSecu
WHERE numIdCli = '5'


INSERT INTO CLIENTS (id_sexe, id_ville, id_regimeSecu, nomCli, prenomCli, numIdCli, telCli, mailCli, depNaIssCli, dateNaissCli, add1Cli, add2Cli, add3Cli, numCompteCli, numSecuCli) 
VALUES (1, 7, 3, 'Deloin', 'Alain', 'azertyuiop', '04.32.56.98.65', 'a.deloin@hotmail.com', '26', '1985-10-15', 'rue', 'de', 'la', null, null);
SELECT numIdCli, nomCli, prenomCli, nomSexe, telCli, mailCli, depNaIssCli, dateNaissCli, add1Cli, add2Cli, add3Cli, postalCode, placeName, countryName, numCompteCli, numSecuCli, nomRegimeSecu FROM CLIENTS
INNER JOIN VILLES
ON CLIENTS.id_ville = VILLES.id_ville
INNER JOIN PAYS
ON VILLES.countryCode = PAYS.countryCode
INNER JOIN SEXE
ON CLIENTS.id_sexe = SEXE.id_sexe
INNER JOIN SECURITE_SOCIALE
ON CLIENTS.id_regimeSecu = SECURITE_SOCIALE.id_regimeSecu
WHERE numIdCli = 'azertyuiop'

--renvoi des des contrats de l'utilisateur connecté
SELECT id_Contr, nomCli, prenomCli, typContr, dateContr, fichierContr  FROM CONTRAT
INNER JOIN CLIENTS
ON CLIENTS.id_Cli = CONTRAT.id_Cli
INNER JOIN TYPE_CONTRAT
ON CONTRAT.id_typContr = TYPE_CONTRAT.id_typContr
WHERE id_inter = 1009 and fichierContr is not null;

--Renvoi des données de l'interlocuteur modifié
SELECT id_inter, mailInter, nomInter, prenomInter, telInter, mailInter, nomAgence, nomDirAgence, prenomDirAgence, nomTitre FROM INTERLOCUTEUR
INNER JOIN AGENCE
ON AGENCE.id_agence = INTERLOCUTEUR.id_agence
INNER JOIN TITRE
ON TITRE.id_titre = INTERLOCUTEUR.id_titre
WHERE id_inter = 1009


--Tests sur la partie statistiques :

-- GÉNÉRAL :

-- QUELLE AGENCE A PASSÉE LE PLUS DE CONTRATS ?
SELECT TOP 1 COUNT(id_Contr) AS 'nbContrat', nomAgence FROM CONTRAT
INNER JOIN INTERLOCUTEUR
ON INTERLOCUTEUR.id_inter = CONTRAT.id_inter
INNER JOIN AGENCE
ON INTERLOCUTEUR.id_agence = AGENCE.id_agence
GROUP BY AGENCE.id_agence, nomAgence
ORDER BY nbContrat DESC

-- PAR AGENCE :

-- NOMBRE TOTAL DE CONTRATS POUR L'AGENCE
SELECT COUNT(id_Contr) AS 'nbContratAgence' FROM CONTRAT
INNER JOIN INTERLOCUTEUR
ON INTERLOCUTEUR.id_inter = CONTRAT.id_inter
INNER JOIN AGENCE
ON INTERLOCUTEUR.id_agence = AGENCE.id_agence
WHERE AGENCE.id_agence = 1
GROUP BY AGENCE.id_agence, nomAgence

-- VALEUR TOTALE DES CONTRATS D'ASSURANCE PAR AGENCE(POUR L'INSTANT SEULE INTERFACE ACTIVE)
SELECT SUM(valeurAssu*12) AS'VALEUR TOTALE DES CONTRATS D ASSURANCE POUR L ANNÉE'  FROM CONTRAT
FULL JOIN ASSURANCE
ON ASSURANCE.id_Assu = CONTRAT.id_Assu
INNER JOIN INTERLOCUTEUR
ON INTERLOCUTEUR.id_inter = CONTRAT.id_inter
INNER JOIN AGENCE
ON INTERLOCUTEUR.id_agence = AGENCE.id_agence
WHERE AGENCE.id_agence = 1
GROUP BY nomAgence

-- QUEL EST LE CLIENT LE PLUS IMPORTANT DE CETTE AGENCE ? (DONT LA SOMME DE VALEUR ANNUELLE EST LA PLUS IMPORTANTE)
SELECT TOP 1 prenomCli, nomCli, COUNT(CONTRAT.id_Contr) AS 'NOMBRE DE CONTRATS', SUM(valeurAssu*12) AS 'VALEUR TOTALE DES CONTRATS', nomAgence FROM CLIENTS
INNER JOIN CONTRAT
ON CONTRAT.id_Cli = CLIENTS.id_Cli
INNER JOIN ASSURANCE
ON ASSURANCE.id_Assu = CONTRAT.id_Assu
INNER JOIN INTERLOCUTEUR
ON INTERLOCUTEUR.id_inter = CONTRAT.id_inter
INNER JOIN AGENCE
ON AGENCE.id_agence = INTERLOCUTEUR.id_agence
WHERE AGENCE.id_agence = 3
GROUP BY prenomCli, nomCli, nomAgence
ORDER BY 'VALEUR TOTALE DES CONTRATS' DESC

-- QUEL EST LE TYPE DE CONTRAT D'ASSURANCE LE PLUS PASSÉ POUR CETTE AGENCE ?
SELECT TOP 1 nomAssu, COUNT(CONTRAT.id_Contr) AS 'nbContrMax', nomAgence FROM ASSURANCE
INNER JOIN CONTRAT
ON CONTRAT.id_Assu = ASSURANCE.id_Assu
INNER JOIN INTERLOCUTEUR
ON INTERLOCUTEUR.id_inter = CONTRAT.id_inter
INNER JOIN AGENCE
ON AGENCE.id_agence = INTERLOCUTEUR.id_agence
WHERE AGENCE.id_agence = 3
GROUP BY nomAssu, nomAgence
ORDER BY nbContrMax DESC

--PAR INTERLOCUTEUR

--COMBIEN DE CONTRATS AVEZ VOUS PASSÉS ?
SELECT COUNT(id_Contr) AS 'NOMBRE DE CONTRATS PASSÉS' FROM CONTRAT
INNER JOIN INTERLOCUTEUR
ON INTERLOCUTEUR.id_inter = CONTRAT.id_inter
WHERE CONTRAT.id_inter = 1009

--VALEUR TOTALE DES CONTRATS PASSÉS
SELECT SUM(valeurAssu*12), nomInter AS 'valTotalContrInter' FROM ASSURANCE
INNER JOIN CONTRAT
ON ASSURANCE.id_Assu = CONTRAT.id_Assu
INNER JOIN INTERLOCUTEUR
ON INTERLOCUTEUR.id_inter = CONTRAT.id_inter
WHERE CONTRAT.id_inter = 1009
GROUP BY nomInter

--QUEL CLIENT A PASSÉ LE PLUS DE CONTRATS AVEC VOUS
SELECT TOP 1 prenomCli, nomCli, COUNT(CONTRAT.id_Contr) AS 'nbContrCliMax'FROM CLIENTS
INNER JOIN CONTRAT
ON CLIENTS.id_Cli = CONTRAT.id_Cli
INNER JOIN INTERLOCUTEUR
ON INTERLOCUTEUR.id_inter = CONTRAT.id_inter
WHERE CONTRAT.id_inter = 1009
GROUP BY prenomCli, nomCli
ORDER BY nbContrCliMax DESC

----QUELS TYPES DE CONTRATS
--SELECT id_Contr, typContr, nomAgence, valeurAssu, valeurMutu FROM CONTRAT
--FULL JOIN TYPE_CONTRAT
--ON CONTRAT.id_typContr = TYPE_CONTRAT.id_typContr
--FULL JOIN ASSURANCE
--ON ASSURANCE.id_Assu = CONTRAT.id_Assu
--FULL JOIN MUTUELLE
--ON MUTUELLE.id_mutu = CONTRAT.id_Mutu
--INNER JOIN INTERLOCUTEUR
--ON INTERLOCUTEUR.id_inter = CONTRAT.id_inter
--INNER JOIN AGENCE
--ON INTERLOCUTEUR.id_agence = AGENCE.id_agence