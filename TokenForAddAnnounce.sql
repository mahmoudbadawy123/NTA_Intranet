exec sp_columns Announcements



{
  "id": 8,
  "labelName": "Announcement 8",
  "messageBody": "Announcement 8",
  "groupId": 4,
  "isScheduledPublish": false,
  "publishDateTime": "2022-10-04T22:28:57.931Z"
}

eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJBRE1JTiIsImp0aSI6ImYzNWVjMzlkLTk4NTctNDdmOC1iYjM4LWQ5YjI0OWI1NzI3NiIsImVtYWlsIjoiQWRtaW5ATlRBLmNvbSIsInVpZCI6ImEwN2EwNWI1LThkMDktNGI0NC1iZjBmLWUxNDAzM2Y5ZGY0NiIsInJvbGVzIjpbIlVzZXIiLCJBZG1pbiJdLCJleHAiOjE2Njc0MjYzNTAsImlzcyI6IlNlY3VyZUFwaSIsImF1ZCI6IlNlY3VyZUFwaVVzZXIifQ.nh-GkZU7iKji6uCXbJ5FphTN2RPcZjJn-FSfliYTjo4






SELECT TOP (1000) [Id]
      ,[LabelName]
      ,[MessageBody]
      ,[GroupId]
      ,[isScheduledPublish]
      ,[PublishDateTime]
      ,[InsertUserDate]
      ,[UpdateUserDate]
      ,[InsertUserId]
      ,[UpdateUserId]
  FROM [NTA_TASK].[dbo].[Announcements]