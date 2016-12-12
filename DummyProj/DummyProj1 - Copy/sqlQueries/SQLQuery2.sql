--SELECT Student_Name.S_ID,Student_Name.STUDENT_NAME,Student_Pass.P_ID,Student_Pass.PASSWORD FROM Student_Name CROSS JOIN Student_Pass WHERE S_ID = P_ID

--Select TOP 1 (S_ID) from Student_Name ORDER BY S_ID DESC
--SELECT MAX(S_ID) FROM Student_Name GROUP BY S_ID

--DELETE FROM Student_Name WHERE S_ID = 1
--DELETE FROM Student_Pass WHERE P_ID = 1
DROP TABLE Student_Name,Student_Pass

CREATE TABLE [dbo].[Student_Name] (
    [S_ID]         INT          NOT NULL,
    [STUDENT_NAME] VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([S_ID] ASC)
);

CREATE TABLE [dbo].[Student_Pass] (
    [P_ID]     INT          IDENTITY (1, 1) NOT NULL,
    [PASSWORD] VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([P_ID] ASC)
);