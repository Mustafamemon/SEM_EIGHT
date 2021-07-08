Use TestDatabase;
Go
/*
declare @temp table(
	X int ,
	Y int
)
insert into @temp values (20,20),(20,20),(21,20),(20,21),(23,20),(20,23),(29,22),(22,29)

select t1.X , t1.Y from @temp as t1 inner join @temp as t2 on t1.X = t2.Y and t1.Y = t2.X
group by t1.X , t1.Y having count(1) > 1 or t1.X  < t1.Y
*/


SELECT s.StudentId,s.StudentName
FROM Student s
LEFT JOIN StudentCourse c
ON s.StudentId = c.StudentID  where c.StudentID is null
/*
CREATE TABLE Candidate( 
  CandidateID INT NOT NULL IDENTITY(1,1) CONSTRAINT PK_Candidate PRIMARY KEY CLUSTERED,
  cname VARCHAR(100) NOT NULL,
  email VARCHAR(100) NOT NULL
);

CREATE TABLE Position(     
  PositionID INT NOT NULL IDENTITY(1,1) CONSTRAINT PK_Position PRIMARY KEY CLUSTERED,
  Title VARCHAR(100) NOT NULL,
);
  
CREATE TABLE JobPosting(     
  CompanyName VARCHAR(100) NOT NULL,
  MaxSalary INT NOT NULL,
  PositionID INT FOREIGN KEY REFERENCES Position(PositionID),
);

  
CREATE TABLE CandidateInterest(     
  PositionID INT FOREIGN KEY REFERENCES Position(PositionID),
  CandidateID INT FOREIGN KEY REFERENCES Candidate(CandidateID)

);

SET IDENTITY_INSERT Candidate ON
INSERT INTO Candidate
  (CandidateID, cname, email) VALUES
	(1, 'Arsalan', 'arsalan@noemail.com'),
	(2, 'Ahmed', 'ahmed@noemail.com'),
	(3, 'Ali', 'ali@noemail.com'),
	(4, 'Sara', 'sara@noemail.com')

SET IDENTITY_INSERT Candidate OFF

SET IDENTITY_INSERT Position ON

INSERT INTO Position
  (PositionID, Title) VALUES
	(1, 'Software Engineer'),
	(2, 'Database Developer'),
	(3, 'Data Analysist'),
	(4, 'Data Engineer'),
	(5, 'Quality Assurance Engineer')
SET IDENTITY_INSERT Position OFF


INSERT INTO JobPosting
  (CompanyName, PositionID , MaxSalary) VALUES
	('COMPANY1', 1, 50000.00),
	('COMPANY1', 2, 25000.00),
	('COMPANY2', 1, 55000.00),
	('COMPANY2', 3, 50000.00),
	('COMPANY3', 4, 70000.00),
	('COMPANY4', 5, 40000.00),
	('COMPANY5', 3, 20000.00),
	('COMPANY6', 1, 55000.00),
	('COMPANY1', 5, 40000.00),
	('COMPANY2', 5, 41000.00)


INSERT INTO CandidateInterest
  (CandidateID, PositionID) VALUES
	(1, 1),
	(1, 2),
	(1, 3),
	(2, 1),
	(2, 3),
	(3, 4),
	(4, 5)

SELECT c.CandidateID , c.cname , p.Title , jp.CompanyName , jp.MaxSalary  from Candidate as c inner join 
	CandidateInterest as ci on ci.CandidateID = c.CandidateID inner join
	Position as p on p.PositionID = ci.PositionID inner join
	JobPosting jp on jp.PositionID = p.PositionID inner join 
	(SELECT c.CandidateID , Max(jp.MaxSalary) as MaxSalary  from Candidate as c inner join 
	CandidateInterest as ci on ci.CandidateID = c.CandidateID inner join
	JobPosting jp on jp.PositionID = ci.PositionID Group by c.CandidateID) as new on new.CandidateID = c.CandidateID where jp.MaxSalary = new.MaxSalary

select * from Candidate where CandidateID%2 = 0 and cname Like 'A%'
*/

