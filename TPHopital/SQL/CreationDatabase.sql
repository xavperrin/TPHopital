CREATE TABLE Rendez_vous (
	CodeRDV INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Medecin VARCHAR(50) NOT NULL,
	Date_RDV DATETIME NOT NULL,
	Service VARCHAR(50) NOT NULL,
	Patient_ID INT NOT NULL
)

CREATE TABLE Patient (
	ID_Patient INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	NomPatient VARCHAR(50) NOT NULL,
	PrenomPatient VARCHAR(50) NOT NULL,
	Date_Naissance DATETIME NOT NULL,
	Sexe VARCHAR(5) NOT NULL,
	Adresse VARCHAR(100) NOT NULL,
	SituationFamiliale VARCHAR(10) NOT NULL,
	AssuranceMedicale VARCHAR(50) NOT NULL,
	CodeAssurance VARCHAR(13) NOT NULL,
	Tel VARCHAR(10) NOT NULL,
	NomPere VARCHAR(50) NOT NULL,
	NomMere VARCHAR(50) NOT NULL,
	NomP_a_prevenir VARCHAR(50) NOT NULL,
	TelP_a_prevenir VARCHAR(10) NOT NULL
)

CREATE TABLE Type_Consultation (
	ID_Type_Consultation INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Type_Consultation VARCHAR(6) NOT NULL,
	Prix_Consultation DECIMAL NOT NULL
)

CREATE TABLE Prescription (
	ID_Prescription INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Date_Prescription DATETIME NOT NULL,
	Nom_Patient VARCHAR(50) NOT NULL,
	Prenom_Patient VARCHAR(50) NOT NULL,
	Note VARCHAR(MAX) NOT NULL
)

CREATE TABLE Medecin (
	ID_Medecin INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Nom_Medecin VARCHAR(50) NOT NULL,
	Prenom_Medecin VARCHAR(50) NOT NULL,
	Tel_Medecin VARCHAR(10) NOT NULL,
)

CREATE TABLE Consultation (
	ID_Consultation INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Date_Consultation DATETIME NOT NULL,
	Synthese VARCHAR(MAX) NOT NULL,
	Type_Consultation_ID INT NOT NULL,
	RDVCode INT NOT NULL,
	Prescription_ID INT NOT NULL,
	Medecin_ID INT NOT NULL
)

CREATE TABLE Traitement (
	ID_Traitement INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	date_traitement INT NOT NULL, -- Durée de traitement
	prix_traitement DECIMAL NOT NULL,	
	Designation VARCHAR(50) NOT NULL,
	Resultat_examen VARCHAR(50) NOT NULL,
	Image VARCHAR(50) NOT NULL,	
	Chirugien VARCHAR(50) NOT NULL,
	Anesthesiste VARCHAR(50) NOT NULL,
	Facture_ID INT NOT NULL,
)

CREATE TABLE Hospitalisation (
	ID_Admission INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Date_Admission DATETIME NOT NULL,
	Type_Admission VARCHAR(50) NOT NULL,
	Motif_Admission VARCHAR(100) NOT NULL,
	Medecin_Traitant VARCHAR(50) NOT NULL,
	Nom_Accompagnant VARCHAR(50) NOT NULL,
	Prenom_Accompagnant VARCHAR(50) NOT NULL,
	Lien_Parente VARCHAR(10) NOT NULL,
	Date_entreeAcc DATETIME NOT NULL,
	Date_sortieAcc DATETIME NOT NULL,
	Date_sortie DATETIME NOT NULL,
	Motif_sortie VARCHAR(50) NOT NULL,
	Resultat_sortie VARCHAR(50) NOT NULL,
	Date_Deces DATETIME NOT NULL,
	Motif_Deces VARCHAR(50) NOT NULL,
	Patient_ID INT NOT NULL,
	Traitement_ID INT NOT NULL,
)

CREATE TABLE Facture (
	ID_facture INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	date_facture DATETIME NOT NULL,
	total DECIMAL NOT NULL,
	Admission_ID INT NOT NULL
)