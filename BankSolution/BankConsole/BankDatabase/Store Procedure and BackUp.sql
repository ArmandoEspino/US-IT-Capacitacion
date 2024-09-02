--  Crea un nuevo procedimiento almacenado, llamado SelectClient...
/*
CREATE PROCEDURE SelectClient
    @ClientID   INT  =  NULL
AS
    IF (@ClientID IS NULL)
    BEGIN
        SELECT * FROM Client
    END
    ELSE
    BEGIN
        SELECT * FROM Client WHERE (ID = @ClientID)
    END
GO
*/

-- EXEC SelectClient @ClientID = 1


--  Modifica el procedimiento almacenado InsertClient...
/*
ALTER PROCEDURE InsertClient
    @Name           VARCHAR(200),
    @PhoneNumber    VARCHAR(40),
    @Email          VARCHAR(50) = NULL
AS
    IF EXISTS ( SELECT 1 FROM Client WHERE (Email = @Email))
    BEGIN
        PRINT 'EL Email ya existe'
        RETURN;
    END
    ELSE
    BEGIN
        INSERT INTO Client (Name, PhoneNumber, Email)
        VALUES (@Name, @PhoneNumber, @Email);
    END
GO
*/

-- EXEC InsertClient @Name = 'Ale', @PhoneNumber = '12345678', @Email = 'pedro@gmail.com';

-- SELECT * FROM Client


--  Modifica el procedimiento almacenado InsertBankTransaction...

-- CREATE PROCEDURE InsertBankTransaction
--     @AccountID          INT,
--     @TransactionType    INT,
--     @Amount             DECIMAL(10,2),
--     @ExternalAccount    INT = NULL
-- AS

--     DECLARE @CurrentBalance DECIMAL(10,2), @NewBalance  DECIMAL(10,2);

--     SET @CurrentBalance = (SELECT Balance FROM Account WHERE ID = @AccountID);

--     -- Obtener nuevo saldo
--     IF @TransactionType = 2 OR @TransactionType = 4
--     BEGIN
--         -- Retiros
--         SET @NewBalance = @CurrentBalance - @Amount;
--         IF @NewBalance < 0
--         BEGIN
--             PRINT 'EL saldo es menor a 0'
--             RETURN;
--         END
--     END
--     ELSE
--     BEGIN
--         -- Depositos
--         SET @NewBalance = @CurrentBalance + @Amount;
--     END

--     UPDATE Account SET Balance = @NewBalance WHERE ID = @AccountID;

--     -- Insertar registro de la operacion
--     INSERT INTO BankTransaction (AccountID, TransactionType, Amount, ExternalAccount)
--     VALUES (@AccountID, @TransactionType, @Amount, @ExternalAccount);

-- GO

EXEC InsertBankTransaction @AccountID = 1, @TransactionType = 2, @Amount = 7000;


SELECT * FROM Account
SELECT * FROM TransactionType
SELECT * FROM BankTransaction

--  Genera un full backup de la base de datos Bank...

-- BACKUP DATABASE Bank
-- TO DISK = 'C:\Users\Darkm\Desktop\ProyectosS2024\US-IT-Capacitacion\BankSolution\BankConsole\BankDatabase\BankBackup.bak'
-- WITH FORMAT,
--      MEDIANAME = 'BankBackup',
--      NAME = 'BackupCompleteBank';

