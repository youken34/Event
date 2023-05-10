-- Randome data to generate
INSERT INTO Event (Title, Description, Category, Location, DateEvent, UserID)
VALUES 
  ('Summer Music Festival', 'Join us for a weekend of live music, food, and fun!', 'Festival', 'Central Park', '2023-05-12 18:00:00', 9),
  ('Charity Golf Tournament', 'Help raise money for a good cause while enjoying a day on the golf course.', 'Tournament', 'Greenwood Golf Club', '2023-05-13 08:00:00', 10),
  ('Cinco de Mayo Party', 'Celebrate the Mexican holiday with margaritas, tacos, and live music.', 'Party', 'Maria\'s Cantina', '2023-05-13 19:00:00', 9),
  ('Marketing Conference', 'Join industry experts and learn about the latest marketing trends and techniques.', 'Conference', 'New York Hilton Midtown', '2023-05-15 09:00:00', 10),
  ('Art Expo', 'Browse and buy art from local artists in a variety of mediums.', 'Expo', 'Jacob K. Javits Convention Center', '2023-05-16 11:00:00', 9),
  ('Summer Beer Festival', 'Sample craft beers from local breweries and enjoy live music and food.', 'Festival', 'Brooklyn Expo Center', '2023-05-19 15:00:00', 10),
  ('Women\'s Tennis Tournament', 'Watch top female tennis players compete for the championship title.', 'Tournament', 'Arthur Ashe Stadium', '2023-05-20 11:00:00', 9),
  ('Tech Conference', 'Learn about the latest advancements in technology and network with industry professionals.', 'Conference', 'Jacob K. Javits Convention Center', '2023-05-20 09:00:00', 10),
  ('Fashion Expo', 'Shop the latest fashion trends and see designer collections on the runway.', 'Expo', 'Pier 94', '2023-05-21 10:00:00', 9);

--Trigger

--SEE every triggers : SELECT * FROM sys.triggers

--SEE trigger description : sp_helptext 'triggername'

-- CREATE TRIGGER followerTrigger  
-- ON Followers  
-- FOR INSERT  
-- AS  
-- BEGIN  
--     UPDATE Users  
--     SET Followers = Followers + 1  
--     FROM inserted i  
--     WHERE i.FollowingID = Users.UserID;  
-- END

-- CREATE TRIGGER unfollowerTrigger  
-- ON Followers  
-- FOR DELETE  
-- AS  
-- BEGIN  
--     UPDATE Users  
--     SET Followers = Followers -1  
--     FROM deleted d  
--     WHERE d.FollowingID = Users.UserID;  
-- END

-- CREATE TRIGGER   
-- eventInsertedTrigger  
-- ON Event  
-- FOR Insert  
-- AS  
-- BEGIN  
-- UPDATE Users  SET Users.Eventposted = Users.Eventposted + 1  
-- FROM inserted i  
-- WHERE Users.UserID = i.UserID  
-- END

-- CREATE TRIGGER   
-- eventDeletedTrigger  
-- ON Event  
-- FOR DELETE  
-- AS  
-- BEGIN  
-- UPDATE Users  SET Users.Eventposted = Users.Eventposted - 1  
-- FROM deleted d  
-- WHERE Users.UserID = d.UserID  
-- END

