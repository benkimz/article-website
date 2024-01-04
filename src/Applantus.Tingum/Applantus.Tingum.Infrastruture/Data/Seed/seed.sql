-- ~ benkimz: script for seeding the database
-- *

-- user-roles table:
INSERT INTO [tingum].[AppUserRoles] ([Id], [DateCreated], [DateModified], [IsActive], [IsDeleted], [Name], [Description])
VALUES
(NEWID(), GETDATE(), GETDATE(), 1, 0, 'Editor', 'Can edit and publish content'),
(NEWID(), GETDATE(), GETDATE(), 1, 0, 'Viewer', 'Can view content but not edit or publish');


-- article categories table:
INSERT INTO [tingum].[ArticleCategories] ([Id], [Name], [Description], [DateCreated], [DateModified], [IsActive], [IsDeleted])
VALUES
(NEWID(), 'Sports', 'Articles about sports and athletes', GETDATE(), GETDATE(), 1, 0),
(NEWID(), 'Politics', 'Articles about political events and leaders', GETDATE(), GETDATE(), 1, 0),
(NEWID(), 'Entertainment', 'Articles about movies, music, and celebrities', GETDATE(), GETDATE(), 1, 0),
(NEWID(), 'Business', 'Articles about finance, economy, and entrepreneurship', GETDATE(), GETDATE(), 1, 0),
(NEWID(), 'Technology', 'Articles about science, innovation, and gadgets', GETDATE(), GETDATE(), 1, 0),
(NEWID(), 'Health', 'Articles about wellness, fitness, and nutrition', GETDATE(), GETDATE(), 1, 0),
(NEWID(), 'Travel', 'Articles about destinations, culture, and adventure', GETDATE(), GETDATE(), 1, 0),
(NEWID(), 'Education', 'Articles about learning, teaching, and career', GETDATE(), GETDATE(), 1, 0),
(NEWID(), 'Lifestyle', 'Articles about fashion, beauty, and hobbies', GETDATE(), GETDATE(), 1, 0),
(NEWID(), 'Environment', 'Articles about nature, climate, and sustainability', GETDATE(), GETDATE(), 1, 0);


-- article tags table:
INSERT INTO [tingum].[ArticleTags] ([Id], [Name], [Description], [DateCreated], [DateModified], [IsActive], [IsDeleted])
VALUES
(NEWID(), 'Cricket', 'Articles about cricket matches and players', GETDATE(), GETDATE(), 1, 0),
(NEWID(), 'Bitcoin', 'Articles about bitcoin price and trends', GETDATE(), GETDATE(), 1, 0),
(NEWID(), 'Marvel', 'Articles about Marvel movies and comics', GETDATE(), GETDATE(), 1, 0),
(NEWID(), 'COVID-19', 'Articles about coronavirus pandemic and vaccines', GETDATE(), GETDATE(), 1, 0),
(NEWID(), 'AI', 'Articles about artificial intelligence and machine learning', GETDATE(), GETDATE(), 1, 0),
(NEWID(), 'Yoga', 'Articles about yoga poses and benefits', GETDATE(), GETDATE(), 1, 0),
(NEWID(), 'Kenya', 'Articles about Kenya''s history and culture', GETDATE(), GETDATE(), 1, 0),
(NEWID(), 'Space', 'Articles about space exploration and discoveries', GETDATE(), GETDATE(), 1, 0),
(NEWID(), 'Music', 'Articles about music genres and artists', GETDATE(), GETDATE(), 1, 0),
(NEWID(), 'Food', 'Articles about food recipes and cuisines', GETDATE(), GETDATE(), 1, 0);


-- app-users:
INSERT INTO [tingum].[AppUsers] ([Id], [Name], [UserName], [DisplayPhoto], [Email], [Password], [Biography], [RoleId], [DateCreated], [DateModified], [IsActive], [IsDeleted], [Description])
VALUES
(NEWID(), 'Alice', 'alice123', NULL, 'alice@example.com', 'password1', 'I love writing about sports and politics', (SELECT [Id] FROM [tingum].[AppUserRoles] WHERE [Name] = 'Editor'), GETDATE(), GETDATE(), 1, 0, 'An editor at Tingum'),
(NEWID(), 'Bob', 'bob456', NULL, 'bob@example.com', 'password2', 'I enjoy reading and traveling', (SELECT [Id] FROM [tingum].[AppUserRoles] WHERE [Name] = 'Viewer'), GETDATE(), GETDATE(), 1, 0, 'A viewer at Tingum'),
(NEWID(), 'Charlie', 'charlie789', NULL, 'charlie@example.com', 'password3', 'I am a fan of Marvel and Star Wars', (SELECT [Id] FROM [tingum].[AppUserRoles] WHERE [Name] = 'Viewer'), GETDATE(), GETDATE(), 1, 0, 'A viewer at Tingum'),
(NEWID(), 'David', 'david101', NULL, 'david@example.com', 'password4', 'I am interested in business and technology', (SELECT [Id] FROM [tingum].[AppUserRoles] WHERE [Name] = 'Editor'), GETDATE(), GETDATE(), 1, 0, 'An editor at Tingum'),
(NEWID(), 'Eve', 'eve202', NULL, 'eve@example.com', 'password5', 'I like yoga and music', (SELECT [Id] FROM [tingum].[AppUserRoles] WHERE [Name] = 'Viewer'), GETDATE(), GETDATE(), 1, 0, 'A viewer at Tingum'),
(NEWID(), 'Frank', 'frank303', NULL, 'frank@example.com', 'password6', 'I am passionate about environment and health', (SELECT [Id] FROM [tingum].[AppUserRoles] WHERE [Name] = 'Editor'), GETDATE(), GETDATE(), 1, 0, 'An editor at Tingum'),
(NEWID(), 'Grace', 'grace404', NULL, 'grace@example.com', 'password7', 'I love food and culture', (SELECT [Id] FROM [tingum].[AppUserRoles] WHERE [Name] = 'Viewer'), GETDATE(), GETDATE(), 1, 0, 'A viewer at Tingum'),
(NEWID(), 'Harry', 'harry505', NULL, 'harry@example.com', 'password8', 'I am fascinated by space and science', (SELECT [Id] FROM [tingum].[AppUserRoles] WHERE [Name] = 'Editor'), GETDATE(), GETDATE(), 1, 0, 'An editor at Tingum'),
(NEWID(), 'Ivy', 'ivy606', NULL, 'ivy@example.com', 'password9', 'I am a student of education and literature', (SELECT [Id] FROM [tingum].[AppUserRoles] WHERE [Name] = 'Viewer'), GETDATE(), GETDATE(), 1, 0, 'A viewer at Tingum'),
(NEWID(), 'Jack', 'jack707', NULL, 'jack@example.com', 'password10', 'I am a fan of cricket and bitcoin', (SELECT [Id] FROM [tingum].[AppUserRoles] WHERE [Name] = 'Editor'), GETDATE(), GETDATE(), 1, 0, 'An editor at Tingum');


-- articles table:
INSERT INTO [tingum].[Articles] ([Id], [Title], [Description], [Thumbnail], [CategoryId], [MarkupData], [ViewsCount], [LikesCount], [CommentsCount], [Status], [AuthorId], [DatePublished], [DateCreated], [DateModified], [IsActive], [IsDeleted], [Name])
VALUES
(NEWID(), 'How to play cricket like a pro', 'A guide for beginners who want to learn the basics of cricket', NULL, (SELECT [Id] FROM [tingum].[ArticleCategories] WHERE [Name] = 'Sports'), '<p>Cricket is a popular sport that originated in England and is played by millions of people around the world. ...</p>', 100, 10, 5, 1, (SELECT [Id] FROM [tingum].[AppUsers] WHERE [UserName] = 'alice123'), GETDATE(), GETDATE(), GETDATE(), 1, 0, 'An article about cricket'),
(NEWID(), 'What is bitcoin and how does it work?', 'An introduction to the world of cryptocurrency and blockchain', NULL, (SELECT [Id] FROM [tingum].[ArticleCategories] WHERE [Name] = 'Business'), '<p>Bitcoin is a digital currency that was created in 2009 by an anonymous person or group using the name Satoshi Nakamoto. ...</p>', 200, 20, 10, 1, (SELECT [Id] FROM [tingum].[AppUsers] WHERE [UserName] = 'david101'), GETDATE(), GETDATE(), GETDATE(), 1, 0, 'An article about bitcoin'),
(NEWID(), 'The best Marvel movies ranked', 'A list of the top 10 Marvel movies according to critics and fans', NULL, (SELECT [Id] FROM [tingum].[ArticleCategories] WHERE [Name] = 'Entertainment'), '<p>Marvel movies are some of the most successful and popular films in the history of cinema. They are based on the comic books created by Marvel Comics, which feature a variety of superheroes and villains. ...</p>', 300, 30, 15, 1, (SELECT [Id] FROM [tingum].[AppUsers] WHERE [UserName] = 'charlie789'), GETDATE(), GETDATE(), GETDATE(), 1, 0, 'An article about Marvel movies'),
(NEWID(), 'How to protect yourself from COVID-19', 'A summary of the latest guidelines and recommendations from health authorities', NULL, (SELECT [Id] FROM [tingum].[ArticleCategories] WHERE [Name] = 'Health'), '<p>COVID-19 is a respiratory disease caused by a new strain of coronavirus that was first detected in China in late 2019. It has since spread to more than 200 countries and territories, infecting over 200 million people and killing over 4 million. ...</p>', 400, 40, 20, 1, (SELECT [Id] FROM [tingum].[AppUsers] WHERE [UserName] = 'frank303'), GETDATE(), GETDATE(), GETDATE(), 1, 0, 'An article about COVID-19'),
(NEWID(), 'How to build an AI chatbot in 10 easy steps', 'A tutorial for beginners who want to create their own conversational agent', NULL, (SELECT [Id] FROM [tingum].[ArticleCategories] WHERE [Name] = 'Technology'), '<p>AI chatbots are software applications that can interact with human users using natural language. They can be used for various purposes, such as customer service, entertainment, education, and more. ...</p>', 500, 50, 25, 1, (SELECT [Id] FROM [tingum].[AppUsers] WHERE [UserName] = 'harry505'), GETDATE(), GETDATE(), GETDATE(), 1, 0, 'An article about AI chatbots'),
(NEWID(), 'How to practice yoga at home', 'A guide for beginners who want to start their yoga journey', NULL, (SELECT [Id] FROM [tingum].[ArticleCategories] WHERE [Name] = 'Lifestyle'), '<p>Yoga is a physical, mental, and spiritual practice that originated in India and is now practiced by millions of people around the world. Yoga can help improve your health, happiness, and well-being. ...</p>', 600, 60, 30, 1, (SELECT [Id] FROM [tingum].[AppUsers] WHERE [UserName] = 'eve202'), GETDATE(), GETDATE(), GETDATE(), 1, 0, 'An article about yoga'),
(NEWID(), 'How to travel to Kenya on a budget', 'A guide for travelers who want to explore the beauty and culture of Kenya', NULL, (SELECT [Id] FROM [tingum].[ArticleCategories] WHERE [Name] = 'Travel'), '<p>Kenya is a country in East Africa that is known for its diverse wildlife, scenic landscapes, and rich history. Kenya is also a popular destination for travelers who want to experience an adventure and learn about a different culture. ...</p>', 700, 70, 35, 1, (SELECT [Id] FROM [tingum].[AppUsers] WHERE [UserName] = 'grace404'), GETDATE(), GETDATE(), GETDATE(), 1, 0, 'An article about Kenya'),
(NEWID(), 'How to become an astronaut in 10 easy steps', 'A guide for aspiring space explorers who want to reach for the stars', NULL, (SELECT [Id] FROM [tingum].[ArticleCategories] WHERE [Name] = 'Education'), '<p>Astronauts are people who travel to space and perform various missions, such as conducting scientific experiments, repairing satellites, or exploring other planets. Astronauts are also some of the most admired and respected professionals in the world. ...</p>', 800, 80, 40, 1, (SELECT [Id] FROM [tingum].[AppUsers] WHERE [UserName] = 'ivy606'), GETDATE(), GETDATE(), GETDATE(), 1, 0, 'An article about astronauts'),
(NEWID(), 'How to write a hit song in 10 easy steps', 'A guide for aspiring musicians who want to create their own masterpiece', NULL, (SELECT [Id] FROM [tingum].[ArticleCategories] WHERE [Name] = 'Music'), '<p>Songwriting is a creative process that involves expressing your thoughts, feelings, and emotions through music and lyrics. Songwriting can also be a rewarding and fun hobby, or even a lucrative career. ...</p>', 900, 90, 45, 1, (SELECT [Id] FROM [tingum].[AppUsers] WHERE [UserName] = 'jack707'), GETDATE(), GETDATE(), GETDATE(), 1, 0, 'An article about songwriting'),
(NEWID(), 'How to cook a delicious meal in 10 easy steps', 'A guide for beginners who want to impress their friends and family with their culinary skills', NULL, (SELECT [Id] FROM [tingum].[ArticleCategories] WHERE [Name] = 'Food'), '<p>Cooking is a skill that can bring joy and satisfaction to yourself and others. Cooking can also be a way of expressing your creativity, culture, and personality. ...</p>', 1000, 100, 50, 1, (SELECT [Id] FROM [tingum].[AppUsers] WHERE [UserName] = 'bob456'), GETDATE(), GETDATE(), GETDATE(), 1, 0, 'An article about cooking');


-- article comments table:
INSERT INTO [tingum].[ArticleComments] ([Id], [Message], [AuthorId], [ArticleId], [DateCreated], [DateModified], [IsActive], [IsDeleted], [Name], [Description])
VALUES
(NEWID(), 'Great article, very informative and helpful', (SELECT [Id] FROM [tingum].[AppUsers] WHERE [UserName] = 'bob456'), (SELECT [Id] FROM [tingum].[Articles] WHERE [Title] = 'How to play cricket like a pro'), GETDATE(), GETDATE(), 1, 0, 'A comment on an article about cricket', 'A positive feedback from a viewer'),
(NEWID(), 'I disagree with your ranking, Iron Man is the best Marvel movie', (SELECT [Id] FROM [tingum].[AppUsers] WHERE [UserName] = 'eve202'), (SELECT [Id] FROM [tingum].[Articles] WHERE [Title] = 'The best Marvel movies ranked'), GETDATE(), GETDATE(), 1, 0, 'A comment on an article about Marvel movies', 'A negative feedback from a viewer'),
(NEWID(), 'Thanks for the tips, I will try them out soon', (SELECT [Id] FROM [tingum].[AppUsers] WHERE [UserName] = 'grace404'), (SELECT [Id] FROM [tingum].[Articles] WHERE [Title] = 'How to practice yoga at home'), GETDATE(), GETDATE(), 1, 0, 'A comment on an article about yoga', 'A positive feedback from a viewer'),
(NEWID(), 'This is a very biased and misleading article, you should do more research before writing', (SELECT [Id] FROM [tingum].[AppUsers] WHERE [UserName] = 'charlie789'), (SELECT [Id] FROM [tingum].[Articles] WHERE [Title] = 'What is bitcoin and how does it work?'), GETDATE(), GETDATE(), 1, 0, 'A comment on an article about bitcoin', 'A negative feedback from a viewer'),
(NEWID(), 'Wow, this is amazing, I always wanted to be an astronaut', (SELECT [Id] FROM [tingum].[AppUsers] WHERE [UserName] = 'harry505'), (SELECT [Id] FROM [tingum].[Articles] WHERE [Title] = 'How to become an astronaut in 10 easy steps'), GETDATE(), GETDATE(), 1, 0, 'A comment on an article about astronauts', 'A positive feedback from an editor'),
(NEWID(), 'This is a very boring and dull article, you should add some humor and personality', (SELECT [Id] FROM [tingum].[AppUsers] WHERE [UserName] = 'ivy606'), (SELECT [Id] FROM [tingum].[Articles] WHERE [Title] = 'How to write a hit song in 10 easy steps'), GETDATE(), GETDATE(), 1, 0, 'A comment on an article about songwriting', 'A negative feedback from a viewer'),
(NEWID(), 'This is a very useful and practical article, I learned a lot from it', (SELECT [Id] FROM [tingum].[AppUsers] WHERE [UserName] = 'david101'), (SELECT [Id] FROM [tingum].[Articles] WHERE [Title] = 'How to build an AI chatbot in 10 easy steps'), GETDATE(), GETDATE(), 1, 0, 'A comment on an article about AI chatbots', 'A positive feedback from an editor'),
(NEWID(), 'This is a very inaccurate and outdated article, you should update it with the latest information', (SELECT [Id] FROM [tingum].[AppUsers] WHERE [UserName] = 'frank303'), (SELECT [Id] FROM [tingum].[Articles] WHERE [Title] = 'How to protect yourself from COVID-19'), GETDATE(), GETDATE(), 1, 0, 'A comment on an article about COVID-19', 'A negative feedback from an editor'),
(NEWID(), 'This is a very interesting and inspiring article, I enjoyed reading it', (SELECT [Id] FROM [tingum].[AppUsers] WHERE [UserName] = 'alice123'), (SELECT [Id] FROM [tingum].[Articles] WHERE [Title] = 'How to travel to Kenya on a budget'), GETDATE(), GETDATE(), 1, 0, 'A comment on an article about Kenya', 'A positive feedback from an editor'),
(NEWID(), 'This is a very bland and tasteless article, you should add some spice and flavor', (SELECT [Id] FROM [tingum].[AppUsers] WHERE [UserName] = 'jack707'), (SELECT [Id] FROM [tingum].[Articles] WHERE [Title] = 'How to cook a delicious meal in 10 easy steps'), GETDATE(), GETDATE(), 1, 0, 'A comment on an article about cooking', 'A negative feedback from an editor');


-- article-tag map table:
INSERT INTO [tingum].[ArticleTagMap] ([ArticleId], [TagsId])
VALUES
((SELECT [Id] FROM [tingum].[Articles] WHERE [Title] = 'How to play cricket like a pro'), (SELECT [Id] FROM [tingum].[ArticleTags] WHERE [Name] = 'Cricket')),
((SELECT [Id] FROM [tingum].[Articles] WHERE [Title] = 'What is bitcoin and how does it work?'), (SELECT [Id] FROM [tingum].[ArticleTags] WHERE [Name] = 'Bitcoin')),
((SELECT [Id] FROM [tingum].[Articles] WHERE [Title] = 'The best Marvel movies ranked'), (SELECT [Id] FROM [tingum].[ArticleTags] WHERE [Name] = 'Marvel')),
((SELECT [Id] FROM [tingum].[Articles] WHERE [Title] = 'How to protect yourself from COVID-19'), (SELECT [Id] FROM [tingum].[ArticleTags] WHERE [Name] = 'COVID-19')),
((SELECT [Id] FROM [tingum].[Articles] WHERE [Title] = 'How to build an AI chatbot in 10 easy steps'), (SELECT [Id] FROM [tingum].[ArticleTags] WHERE [Name] = 'AI')),
((SELECT [Id] FROM [tingum].[Articles] WHERE [Title] = 'How to practice yoga at home'), (SELECT [Id] FROM [tingum].[ArticleTags] WHERE [Name] = 'Yoga')),
((SELECT [Id] FROM [tingum].[Articles] WHERE [Title] = 'How to travel to Kenya on a budget'), (SELECT [Id] FROM [tingum].[ArticleTags] WHERE [Name] = 'Kenya')),
((SELECT [Id] FROM [tingum].[Articles] WHERE [Title] = 'How to become an astronaut in 10 easy steps'), (SELECT [Id] FROM [tingum].[ArticleTags] WHERE [Name] = 'Space')),
((SELECT [Id] FROM [tingum].[Articles] WHERE [Title] = 'How to write a hit song in 10 easy steps'), (SELECT [Id] FROM [tingum].[ArticleTags] WHERE [Name] = 'Music')),
((SELECT [Id] FROM [tingum].[Articles] WHERE [Title] = 'How to cook a delicious meal in 10 easy steps'), (SELECT [Id] FROM [tingum].[ArticleTags] WHERE [Name] = 'Food'));
