--creer un script de sql server avec un database Vente et une table Client
--la table client doit contenir les champs suivants:
--IdClient, NomClient, PrenomClient, AdresseClient, VilleClient, CodePostalClient, TelephoneClient, EmailClient

--creation de la base de donnees
CREATE DATABASE vente
GO

--selection de la base de donnees
USE vente
GO

--creation de la table Client
CREATE TABLE client
(
    id INT PRIMARY KEY IDENTITY(1,1),
    nom NVARCHAR(20),
    prenom NVARCHAR(20),
    adresse NVARCHAR(50),
    ville NVARCHAR(20),
    codePostal NVARCHAR(10),
    telephone NVARCHAR(20),
    email NVARCHAR(20)
)
GO

-- ajoouter 2 donnees dans la table Client
INSERT INTO client(nom, prenom, adresse, ville, codePostal, telephone, email)
VALUES('Doe', 'John', '123 rue de la paix', 'Paris', '75000', '0123456789', 'rakoto@gmail.com')
GO
