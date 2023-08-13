CREATE TABLE Patients (
    PatientId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100),
    Age NVARCHAR(10),
    Gender NVARCHAR(10),
    Date DATE,
    Investigate NVARCHAR(MAX)
)
