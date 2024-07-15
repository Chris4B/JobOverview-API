-- Insertion des données dans la table Filiere
--print 'Table Filieres'
--insert Filieres (CodeFiliere, Nom) values
--('BIOH', 'Biologie Humaine'),
--('BIOA', 'Biologie Animale')
--go

-- Insertion des données dans la table Logiciel
--print 'Table Logiciels'
--insert Logiciels (CodeLogiciel, CodeFiliere, Nom) values
--('GENOMICA', 'BIOH', 'Genomica'),
--('ANATOMIA', 'BIOH', 'Anatomia')
--go

-- Insertion des données dans la table Module
--print 'Table Modules'
--insert Modules (CodeModule, CodeLogiciel, Nom, CodeLogicielParent, CodeModuleParent) values
--('SEQUENCAGE', 'GENOMICA', 'Séquençage', null, null),
--('MARQUAGE1', 'GENOMICA', 'Marquage', 'GENOMICA', 'SEQUENCAGE'), -- unique key
--('SEPARATION', 'GENOMICA', 'Séparation', 'GENOMICA', 'SEQUENCAGE'),
--('ANALYSE1', 'GENOMICA', 'Analyse', 'GENOMICA', 'SEQUENCAGE'), -- unique key
--('POLYMORPHISME', 'GENOMICA', 'Polymorphisme génétique', null, null),
--('VAR_ALLELE', 'GENOMICA', 'Variations alléliques', null, null),
--('UTIL_DROITS', 'GENOMICA', 'Utilisateurs et droits', null, null),
--('PARAMETRES', 'GENOMICA', 'Paramétrage', null, null),
--('MICRO', 'ANATOMIA', 'Anatomie microscopique', null, null),
--('PATHO', 'ANATOMIA', 'Anatomie pathologique', null, null),
--('FONC', 'ANATOMIA', 'Anatomie fonctionnelle', null, null),
--('RADIO', 'ANATOMIA', 'Anatomie radiologique', null, null),
--('TOPO', 'ANATOMIA', 'Anatomie topographique', null, null)
--go

-- Insertion des données dans la table Version
--print 'Table Versions'
--insert Versions (NumeroVersion, CodeLogiciel, Millesime, DateOuverture, DateSortiePrevue, DateSortieReelle) values
--(1.00, 'GENOMICA', 2023, '2022-01-02', '2023-01-08', '2023-01-20'),
--(2.00, 'GENOMICA', 2024, '2022-12-28', '2024-02-28', NULL),
--(4.50, 'ANATOMIA', 2022, '2021-09-01', '2022-07-07', '2022-07-20'),
--(5.00, 'ANATOMIA', 2023, '2022-08-01', '2023-03-30', '2023-03-25'),
--(5.50, 'ANATOMIA', 2024, '2023-03-30', '2023-11-20', NULL)
--go

-- Insertion des données dans la table Release
print 'Table Releases'
SET IDENTITY_INSERT Releases ON;
insert Releases (NumeroRelease, NumeroVersion, CodeLogiciel, DatePublication) values
(1, 1.00, 'GENOMICA', '2022-01-15'),
(2, 1.00, 'GENOMICA', '2022-01-25'),
(3, 1.00, 'GENOMICA', '2022-02-05'),
(4, 1.00, 'GENOMICA', '2022-02-13'),
(5, 1.00, 'GENOMICA', '2022-02-23'),
(6, 1.00, 'GENOMICA', '2022-03-09'),
(7, 1.00, 'GENOMICA', '2022-03-18'),
(8, 1.00, 'GENOMICA', '2022-03-25'),
(9, 1.00, 'GENOMICA', '2022-04-02'),
(10, 1.00, 'GENOMICA', '2022-04-09'),
(11, 1.00, 'GENOMICA', '2022-04-16'),
(12, 1.00, 'GENOMICA', '2022-04-28'),
(13, 1.00, 'GENOMICA', '2022-05-10'),
(14, 1.00, 'GENOMICA', '2022-05-17'),
(15, 1.00, 'GENOMICA', '2022-06-10'),
(16, 1.00, 'GENOMICA', '2022-06-19'),
(17, 1.00, 'GENOMICA', '2022-06-27'),
(18, 1.00, 'GENOMICA', '2022-07-04'),
(19, 1.00, 'GENOMICA', '2022-07-13'),
(20, 1.00, 'GENOMICA', '2022-07-23'),
(21, 1.00, 'GENOMICA', '2022-08-01'),
(22, 1.00, 'GENOMICA', '2022-08-09'),
(23, 1.00, 'GENOMICA', '2022-08-21'),
(24, 1.00, 'GENOMICA', '2022-08-27'),
(25, 1.00, 'GENOMICA', '2022-09-02'),
(26, 1.00, 'GENOMICA', '2022-09-14'),
(27, 1.00, 'GENOMICA', '2022-09-22'),
(28, 1.00, 'GENOMICA', '2022-10-14'),
(29, 1.00, 'GENOMICA', '2022-10-23'),
(30, 1.00, 'GENOMICA', '2022-11-03'),
(31, 1.00, 'GENOMICA', '2022-11-15'),
(32, 1.00, 'GENOMICA', '2022-11-26'),
(33, 1.00, 'GENOMICA', '2022-12-02'),
(34, 2.00, 'GENOMICA', '2023-01-07'), -- corrected to ensure unique NumeroRelease
(35, 2.00, 'GENOMICA', '2023-02-11'), -- corrected to ensure unique NumeroRelease
(36, 2.00, 'GENOMICA', '2023-03-17'), -- corrected to ensure unique NumeroRelease
(37, 2.00, 'GENOMICA', '2023-04-12'), -- corrected to ensure unique NumeroRelease
(38, 2.00, 'GENOMICA', '2023-05-05'), -- corrected to ensure unique NumeroRelease
(39, 5.50, 'ANATOMIA', '2023-04-07'), -- corrected to ensure unique NumeroRelease
(40, 5.50, 'ANATOMIA', '2023-04-19'), -- corrected to ensure unique NumeroRelease
(41, 5.50, 'ANATOMIA', '2023-04-28'), -- corrected to ensure unique NumeroRelease
(42, 5.50, 'ANATOMIA', '2023-05-12'), -- corrected to ensure unique NumeroRelease
(43, 5.50, 'ANATOMIA', '2023-05-17'); -- corrected to ensure unique NumeroRelease

SET IDENTITY_INSERT Releases OFF;
go
