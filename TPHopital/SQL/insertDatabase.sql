--INSERT INTO Medecin (Nom_Medecin, Prenom_Medecin, Tel_Medecin) VALUES 
--('Cardiak', 'Chris', 0123456789),
--('Tiremoiloss', 'Josiane', 0234567891),
--('Soulacroup','Nicole', 0345678912),
--('Bargeot','Roselyne', 0456789123);

INSERT INTO Patient (NomPatient, PrenomPatient, Date_Naissance, Sexe, Adresse, SituationFamilliale, AssuranceMedicale, CodeAssurance, Tel, NomPere, PrenomPere, NomP_a_prevenir, PrenomP_a_prevenir) VALUES
('Alatoux', 'José', GETDATE(), 'Homme', '4 rue du cancer', 'Célibataire', 'Euro-Assurance', '1926210548465', '0123456789', 'Alatoux', 'Robert', 'Alatoux', 'Robert'),
('Fer', 'Lucie', GETDATE(), 'Femme', '666 rue du diable', 'Couple', 'Le gan', '1926210548465', '0123456789', 'Fer', 'Dan', 'Fer', 'Dan');