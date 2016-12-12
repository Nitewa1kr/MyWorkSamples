DROP TABLE [dbo].[Student_Name],[dbo].[Student_Pass]

CREATE TABLE [dbo].[Student_Name] (
    [S_ID]         INT          NOT NULL IDENTITY,
    [STUDENT_NAME] VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([S_ID] ASC)
);

CREATE TABLE [dbo].[Student_Pass] (
    [P_ID]     INT          NOT NULL IDENTITY,
    [PASSWORD] VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([P_ID] ASC)
);