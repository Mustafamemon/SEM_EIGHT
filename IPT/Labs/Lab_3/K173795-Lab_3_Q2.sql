USE [TestDatabase]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 5/19/2021 11:21:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON

GO

CREATE TABLE [dbo].[StudentAudit](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[StudentName] [varchar](255) NOT NULL,
	[Gender] [varchar](10) NULL,
	[AdmissionYear] [date] NULL,
)
GO


CREATE CLUSTERED INDEX StudentAuditCI ON StudentAudit (StudentId ASC)

CREATE NONCLUSTERED INDEX StudentAuditNCI ON StudentAudit (StudentName ASC)

GO
CREATE OR ALTER TRIGGER BackupStudent ON Student
AFTER INSERT
AS
	BEGIN 
		SET IDENTITY_INSERT Student OFF

		SET IDENTITY_INSERT StudentAudit ON

		INSERT INTO StudentAudit(StudentId , StudentName , Gender, AdmissionYear) Select StudentId , StudentName , Gender, AdmissionYear from inserted

		SET IDENTITY_INSERT StudentAudit OFF

		Select * from StudentAudit
	END

GO

CREATE OR ALTER TRIGGER UpdateBackupStudent ON Student
AFTER UPDATE
AS
	BEGIN
		UPDATE StudentAudit
		SET StudentName = inserted.StudentName , Gender = inserted.Gender , AdmissionYear = inserted.AdmissionYear
		from StudentAudit 
		inner join inserted
		on inserted.StudentId = StudentAudit.StudentId
		Select * from StudentAudit
	END
GO


SET IDENTITY_INSERT Student ON
INSERT INTO Student(StudentId , StudentName , Gender, AdmissionYear) values(18,'ABCD','Male','2020-09-10')

UPDATE Student
SET StudentName = 'FGB' , Gender = 'FEMALE'
Where StudentId = 18