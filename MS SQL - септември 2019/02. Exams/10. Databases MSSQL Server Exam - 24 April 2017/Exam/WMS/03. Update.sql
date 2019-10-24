UPDATE [dbo].[Jobs]
   SET
       [dbo].[Jobs].[Status] = 'In Progress',
	   [dbo].[Jobs].[MechanicId] = 3
 WHERE [dbo].[Jobs].[Status] = 'Pending';