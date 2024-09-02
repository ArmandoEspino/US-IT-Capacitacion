/*      VIDEO 4
USE Bank;

CREATE TABLE Client(
    ID              INT             PRIMARY KEY     IDENTITY(1,1),
    Name            VARCHAR(200)    NOT NULL,
    PhoneNumber     VARCHAR(40)     NOT NULL,
    Email           VARCHAR(50),
    Balance         DECIMAL(10,2)
)   


ALTER TABLE Client
DROP COLUMN Balance;

ALTER TABLE Client
ADD RegDate DATETIME DEFAULT GETDATE();

ALTER TABLE Client
ADD RegDate DATETIME NOT NULL;



Video 7

CREATE TABLE AccountType(
    ID          INT             PRIMARY KEY         IDENTITY(1,1),
    Name        VARCHAR(100)    NOT NULL,
    RegDate     DATETIME        NOT NULL            DEFAULT     GETDATE()
);

CREATE TABLE TransactionType(
    ID          INT             PRIMARY KEY         IDENTITY(1,1),
    Name        VARCHAR(100)    NOT NULL,
    RegDate     DATETIME        NOT NULL            DEFAULT     GETDATE()
);

CREATE TABLE Account(
    ID                  INT             PRIMARY KEY         IDENTITY(1,1),
    AccountType         INT             NOT NULL,           FOREIGN KEY REFERENCES  AccountType(ID),
    ClientID            INT             NOT NULL,           FOREIGN KEY REFERENCES  Client(ID),
    Balance             DECIMAL(10,2)   NOT NULL,
    RegDate             DATETIME        NOT NULL            DEFAULT     GETDATE()
);

CREATE TABLE BankTransaction(
    ID                  INT             PRIMARY KEY         IDENTITY(1,1),
    AccountID           INT             NOT NULL,           FOREIGN KEY REFERENCES  Account(ID),
    TransactionType     INT             NOT NULL,           FOREIGN KEY REFERENCES  TransactionType(ID),
    Amount              DECIMAL(10,2)   NOT NULL,
    ExternalAccount     INT             NOT NULL,
    RegDate             DATETIME        NOT NULL            DEFAULT     GETDATE()
);


INSERT INTO AccountType (Name)
VALUES ('Personal'), ('Nomina'), ('Ahorro');

INSERT INTO TransactionType (Name)
VALUES ('Deposito en Efectivo'), ('Retiro en Efectivo'), ('Deposito via Transferencia'), ('Retiro via Transferencia');


INSERT INTO Account (AccountType, ClientID, Balance)
VALUES  (1, 1, 5000),
        (2, 1, 10000),
        (1, 2, 3000),
        (2, 1, 14000);

INSERT INTO BankTransaction (AccountID, TransactionType, Amount, ExternalAccount)
VALUES  (1, 1, 100, NULL),
        (1, 3, 200, 123456),
        (3, 1, 100, NULL),
        (3, 3, 250, 454545);


Video 8  "Joins"

SELECT a.ID, acc.Name AS AccountName, c.Name AS ClientName, a.Balance, a.RegDate FROM Account a
INNER JOIN Client c ON a.ClientID = c.ID
INNER JOIN AccountType acc ON a.AccountType = acc.ID

*/


SELECT * FROM Client
WHERE (Email IS NULL)