Feature: Retrieve Member By ID

Scenario: Exsiting Member
Given a member exists with IdMember "84d384e4-9e9b-48cb-ae3b-2d38810e7422"
When the member is requested by IdMember
Then the member is returned with same IdMember "84d384e4-9e9b-48cb-ae3b-2d38810e7422"