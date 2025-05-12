--PROCEDURE STOCKEES
--INTERLOCUTEURS

--PROCEDURE STOCKEE TEST INSERTION D'UN INTERLOCUTEUR 
CREATE PROCEDURE Test_InsertINTERLOCUTEUR
AS
BEGIN
    DECLARE @TestResult BIT;
    DECLARE @id_inter INT;

    -- Insertion un interlocuteur de test
    INSERT INTO INTERLOCUTEUR(id_titre, id_agence, loginInter, mdpInter, loginKwInter, mdpKwInter, nomInter, prenomInter, telInter, mailInter)
    VALUES (1, 2, 'LoginFinal', 'MotdePasseUltime', 'bla', 'bla', 'Jacques', 'Frere', '06.32.35.36.95', 'frereJacques@mail.com');

    -- R�cup�rer l'ID de l'interlocuteur ins�r�
    SET @id_inter = SCOPE_IDENTITY();

    -- V�rifier si l'interlocuteur a bien �t� ins�r�
    IF EXISTS (SELECT 1 FROM INTERLOCUTEUR WHERE id_inter = @id_inter AND nomInter = 'Jacques')
    BEGIN
        SET @TestResult = 1;
    END
    ELSE
    BEGIN
        SET @TestResult = 0;
    END

    -- Retourner le r�sultat du test
    SELECT @TestResult AS TestResult;

    -- Nettoyer les donn�es de test
    DELETE FROM INTERLOCUTEUR WHERE id_inter = @id_inter;
END;

--EXECUTION DE LA PROCEDURE STOCKEE
EXEC Test_InsertINTERLOCUTEUR




--CLIENTS


--PROCEDURE STOCKEE TEST INSERTION D'UN CLIENT 
CREATE PROCEDURE Test_InsertCLIENT
AS
BEGIN
    DECLARE @TestResult BIT;
    DECLARE @id_Cli INT;

    -- Insertion un interlocuteur de test
    INSERT INTO CLIENTS(id_sexe, id_ville, id_regimeSecu, nomCli, prenomCli, numIdCli, telCli, mailCli, depNaIssCli, dateNaissCli, add1Cli, add2Cli, add3Cli, numCompteCli, numSecuCli)
    VALUES (1, 1, 3, 'Deloin', 'Alain', 'qsd654aze987', '04.32.56.98.65', 'a.deloin@hotmail.com', '26', '1985-10-15', 'rue', 'de', 'la', null, null);

    -- R�cup�rer l'ID de l'interlocuteur ins�r�
    SET @id_Cli = SCOPE_IDENTITY();

    -- V�rifier si l'interlocuteur a bien �t� ins�r�
    IF EXISTS (SELECT 1 FROM CLIENTS WHERE id_Cli = @id_Cli AND numIdCli = 'qsd654aze987')
    BEGIN
        SET @TestResult = 1;
    END
    ELSE
    BEGIN
        SET @TestResult = 0;
    END

    -- Retourner le r�sultat du test
    SELECT @TestResult AS TestResult;

    -- Nettoyer les donn�es de test
    DELETE FROM CLIENTS WHERE id_Cli = @id_Cli;
END;

--EXECUTION DE LA PROCEDURE STOCKEE
EXEC Test_InsertCLIENT




--PROCEDURE STOCKEE TEST MODIFICATION D'UN CLIENT
CREATE PROCEDURE Test_UpdateCLIENT
AS
BEGIN
    DECLARE @TestResult BIT;
    DECLARE @id_Cli INT;

    -- Ins�rer un client de test
    INSERT INTO CLIENTS(id_sexe, id_ville, id_regimeSecu, nomCli, prenomCli, numIdCli, telCli, mailCli, depNaIssCli, dateNaissCli, add1Cli, add2Cli, add3Cli, numCompteCli, numSecuCli)
    VALUES (1, 1, 3, 'POLNAREFF', 'Michel', 'qsd654aze987', '04.32.56.98.65', 'm.polnareff@hotmail.com', '26', '1956-10-15', '36', 'Rue Garibaldi', 'Batiment C', null, null);

    -- R�cup�rer l'ID du contrat ins�r�
    SET @id_Cli = SCOPE_IDENTITY();

    -- Mettre � jour le contrat de test
    UPDATE CLIENTS
    SET nomCli = 'BLANC'
    WHERE numIdCli = 'qsd654aze987';

    -- V�rifier si le contrat a bien �t� mis � jour
    IF EXISTS (SELECT 1 FROM CLIENTS WHERE numIdCli = 'qsd654aze987' AND nomCli = 'BLANC')
    BEGIN
        SET @TestResult = 1;
    END
    ELSE
    BEGIN
        SET @TestResult = 0;
    END

    -- Retourner le r�sultat du test
    SELECT @TestResult AS TestResult;

    -- Nettoyer les donn�es de test
    DELETE FROM CLIENTS WHERE numIdCli = 'qsd654aze987';
END;

--EXECUTION DE LA PROCEDURE STOCKEE
EXEC Test_UpdateCLIENT