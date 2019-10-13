  SELECT i.Id,
         CONCAT(a.Username, ' : ', i.Title) AS [IssueAssignee]
    FROM Issues AS i
    JOIN Users AS a
      ON a.Id = i.AssigneeId
ORDER BY i.Id DESC, [IssueAssignee]