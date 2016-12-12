--SELECT Student_Name.S_ID,Student_Name.STUDENT_NAME,Student_Pass.P_ID,Student_Pass.PASSWORD FROM Student_Name CROSS JOIN Student_Pass WHERE S_ID = P_ID

--Select TOP 1 (S_ID) from Student_Name ORDER BY S_ID DESC
--SELECT MAX(S_ID) FROM Student_Name GROUP BY S_ID


DROP TABLE Student_Name,Student_Pass,Student_DOB

CREATE TABLE [dbo].[Student_Name] (
    [S_ID]         INT          IDENTITY (1, 1) NOT NULL,
    [STUDENT_NUM]  INT          NULL,
    [STUDENT_NAME] VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([S_ID] ASC)
);

CREATE TABLE [dbo].[Student_Pass] (
    [P_ID]		   INT			IDENTITY (1, 1) NOT NULL,
    [PASSWORD] VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([P_ID] ASC)
);

CREATE TABLE [dbo].[Student_DOB]
(
	[D_ID]		   INT			IDENTITY (1, 1) NOT NULL, 
    [DOB] DATE NULL,
	PRIMARY KEY CLUSTERED ([D_ID] ASC)
);