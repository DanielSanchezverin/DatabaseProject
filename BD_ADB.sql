CREATE TABLE Calificacion (
  noControl VARCHAR(15) NOT NULL,
  idMateria NUMERIC(2) NOT NULL,
  idCarrera NUMERIC(2) NOT NULL,
  calificacion NUMERIC(4,2) NULL,
  PRIMARY KEY(noControl, idMateria, idCarrera),
  CONSTRAINT fK_noControlMateriaCarrera FOREIGN KEY (noControl, idMateria, idCarrera)
  REFERENCES CargaMateria(noControl, idMateria, idCarrera)
);

CREATE TABLE CargaMateria (
  noControl VARCHAR(15) NOT NULL,
  idMateria NUMERIC(2) NOT NULL,
  idCarrera NUMERIC(2) NOT NULL,
  PRIMARY KEY(noControl, idMateria, idCarrera),
  CONSTRAINT fK_noControl FOREIGN KEY (noControl)
  REFERENCES Alumno(noControl),
  CONSTRAINT fk_idMateria_idCarrera FOREIGN KEY (idMateria, idCarrera)
  REFERENCES MateriaPorCarrera (idMateria, idCarrera)
);

CREATE TABLE MateriaPorCarrera (
  idMateria NUMERIC(2) NOT NULL,
  idCarrera NUMERIC(2) NOT NULL,
  descripcion VARCHAR(70) NOT NULL,
  PRIMARY KEY(idMateria, idCarrera),
  CONSTRAINT fk_idCarrera2 FOREIGN KEY (idCarrera)
  REFERENCES Carrera(idCarrera)
);

CREATE TABLE Alumno (
  noControl VARCHAR(15) NOT NULL,
  idCarrera NUMERIC(2) NOT NULL,
  idCivil NUMERIC(1) NOT NULL,
  idGenero NUMERIC(1) NOT NULL,
  idColonia NUMERIC(3) NOT NULL,
  nombre VARCHAR(30) NULL,
  paterno VARCHAR(30) NULL,
  materno VARCHAR(30) NULL,
  PRIMARY KEY(noControl),
  CONSTRAINT fk_idCarrera FOREIGN KEY (idCarrera)
  REFERENCES Carrera(idCarrera),
  CONSTRAINT fk_idCivil FOREIGN KEY (idCivil)
  REFERENCES EdoCivil(idCivil),
  CONSTRAINT fk_idGenero FOREIGN KEY (idGenero)
  REFERENCES Genero(idGenero),
  CONSTRAINT fk_idColonia FOREIGN KEY (idColonia)
  REFERENCES Colonia(idColonia)
);

CREATE TABLE Colonia (
  idColonia NUMERIC(3) NOT NULL,
  idCiudad NUMERIC(3) NOT NULL,
  nombre VARCHAR(80) NULL,
  PRIMARY KEY(idColonia),
  CONSTRAINT fk_idCiudad FOREIGN KEY (idCiudad)
  REFERENCES Ciudad(idCiudad)
);

CREATE TABLE Ciudad (
  idCiudad NUMERIC(3) NOT NULL,
  idEstado NUMERIC(3) NOT NULL,
  nombre VARCHAR(50) NULL,
  PRIMARY KEY(idCiudad),
  CONSTRAINT fk_idEstado FOREIGN KEY (idEstado)
  REFERENCES Estado(idEstado)
);

CREATE TABLE Estado (
  idEstado NUMERIC(3) NOT NULL,
  idPais NUMERIC(3) NOT NULL,
  nombre VARCHAR(50) NULL,
  PRIMARY KEY(idEstado),
  CONSTRAINT fk_idPais FOREIGN KEY (idPais)
  REFERENCES Pais(idPais)
);

CREATE TABLE Pais (
  idPais NUMERIC(3) NOT NULL,
  nombre VARCHAR(100) NULL,
  PRIMARY KEY(idPais)
);

CREATE TABLE EdoCivil (
  idCivil NUMERIC(1) NOT NULL,
  nombre VARCHAR(20) NULL,
  PRIMARY KEY(idCivil)
);

CREATE TABLE Genero (
  idGenero NUMERIC(1) NOT NULL,
  nombre VARCHAR(15) NULL,
  PRIMARY KEY(idGenero)
);

CREATE TABLE Carrera (
  idCarrera NUMERIC(2) NOT NULL,
  nombre VARCHAR(100) NULL,
  PRIMARY KEY(idCarrera)
);