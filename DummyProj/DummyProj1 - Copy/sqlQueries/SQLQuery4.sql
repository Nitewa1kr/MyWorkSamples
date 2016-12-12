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