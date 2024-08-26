USE [AUWalksDb]
GO
DELETE FROM [AUWalksDb].[dbo].[Regions];
GO
DELETE FROM [AUWalksDb].[dbo].[Difficulties];
GO
DELETE FROM [AUWalksDb].[dbo].[Walks];
GO
INSERT [dbo].[Difficulties] ([Id], [Name]) VALUES (N'f808ddcd-b5e5-4d80-b732-1ca523e48434', N'Hard')
GO
INSERT [dbo].[Difficulties] ([Id], [Name]) VALUES (N'54466f17-02af-48e7-8ed3-5a4a8bfacf6f', N'Easy')
GO
INSERT [dbo].[Difficulties] ([Id], [Name]) VALUES (N'ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c', N'Medium')
GO
INSERT [dbo].[Regions] ([Id], [Code], [Name], [RegionImageUrl]) VALUES (N'906cb139-415a-4bbb-a174-1a1faf9fb1f6', N'SYD', N'Sydney', N'https://www.australia.com/content/australia/en_ca/places/sydney-and-surrounds/guide-to-sydney/_jcr_content/hero/desktop.adapt.1920.high.jpg')
GO
INSERT [dbo].[Regions] ([Id], [Code], [Name], [RegionImageUrl]) VALUES (N'f7248fc3-2585-4efb-8d1d-1c555f4087f6', N'CBR', N'Canberra', N'https://www.australia.com/content/australia/en_ca/places/canberra-and-surrounds/guide-to-canberra/_jcr_content/hero/desktop.adapt.1920.high.jpg')
GO
INSERT [dbo].[Regions] ([Id], [Code], [Name], [RegionImageUrl]) VALUES (N'14ceba71-4b51-4777-9b17-46602cf66153', N'PER', N'Perth', NULL)
GO
INSERT [dbo].[Regions] ([Id], [Code], [Name], [RegionImageUrl]) VALUES (N'6884f7d7-ad1f-4101-8df3-7a6fa7387d81', N'BNE', N'Brisbane', NULL)
GO
INSERT [dbo].[Regions] ([Id], [Code], [Name], [RegionImageUrl]) VALUES (N'f077a22e-4248-4bf6-b564-c7cf4e250263', N'ADL', N'Adelaide', NULL)
GO
INSERT [dbo].[Regions] ([Id], [Code], [Name], [RegionImageUrl]) VALUES (N'cfa06ed2-bf65-4b65-93ed-c9d286ddb0de', N'MEL', N'Melbourne', N'https://www.australia.com/content/australia/en_ca/places/melbourne-and-surrounds/guide-to-melbourne/_jcr_content/hero/desktop.adapt.1920.high.jpg')
GO

INSERT INTO [AUWalksDb].[dbo].[Walks]
(Id, Name, Description, LengthInKm, WalkImageUrl, DifficultyId, RegionId)
VALUES
(N'1a2b3c4d-1234-5678-9101-112131415161', N'Coastal Pathway', N'A scenic coastal walk with stunning ocean views.', 7.5, N'https://example.com/walks/coastal-pathway.jpg', N'f808ddcd-b5e5-4d80-b732-1ca523e48434', N'906cb139-415a-4bbb-a174-1a1faf9fb1f6');

INSERT INTO [AUWalksDb].[dbo].[Walks]
(Id, Name, Description, LengthInKm, WalkImageUrl, DifficultyId, RegionId)
VALUES
(N'2b3c4d5e-2345-6789-1011-213141516171', N'City Park Loop', N'A relaxing walk through the city largest park.', 4.2, N'https://example.com/walks/city-park-loop.jpg', N'54466f17-02af-48e7-8ed3-5a4a8bfacf6f', N'f7248fc3-2585-4efb-8d1d-1c555f4087f6');

INSERT INTO [AUWalksDb].[dbo].[Walks]
(Id, Name, Description, LengthInKm, WalkImageUrl, DifficultyId, RegionId)
VALUES
(N'3c4d5e6f-3456-7890-1121-314151617181', N'Mountain Ridge Trail', N'A challenging hike up the mountain ridge with breathtaking views.', 12.3, N'https://example.com/walks/mountain-ridge-trail.jpg', N'f808ddcd-b5e5-4d80-b732-1ca523e48434', N'14ceba71-4b51-4777-9b17-46602cf66153');

INSERT INTO [AUWalksDb].[dbo].[Walks]
(Id, Name, Description, LengthInKm, WalkImageUrl, DifficultyId, RegionId)
VALUES
(N'a8fa78b5-7cca-429f-a70e-1f1ae0595adb', N'Beachside Promenade', N'A relaxing walk along the beach with soft sands and cool breezes.', 5.7, N'https://example.com/walks/beachside-promenade.jpg', N'54466f17-02af-48e7-8ed3-5a4a8bfacf6f', N'cfa06ed2-bf65-4b65-93ed-c9d286ddb0de');

INSERT INTO [AUWalksDb].[dbo].[Walks]
(Id, Name, Description, LengthInKm, WalkImageUrl, DifficultyId, RegionId)
VALUES
(N'735683ea-93b9-4a8b-9371-9d8819c7a825', N'Outback Trek', N'A challenging trek through the rugged outback, for experienced hikers.', 18.4, N'https://example.com/walks/outback-trek.jpg', N'f808ddcd-b5e5-4d80-b732-1ca523e48434', N'14ceba71-4b51-4777-9b17-46602cf66153');

INSERT INTO [AUWalksDb].[dbo].[Walks]
(Id, Name, Description, LengthInKm, WalkImageUrl, DifficultyId, RegionId)
VALUES
(N'd92961f8-ab4d-464a-a54e-9ff236ce8df1', N'Meadow Stroll', N'A gentle walk through picturesque meadows with vibrant wildflowers.', 3.2, N'https://example.com/walks/meadow-stroll.jpg', N'54466f17-02af-48e7-8ed3-5a4a8bfacf6f', N'f077a22e-4248-4bf6-b564-c7cf4e250263');

INSERT INTO [AUWalksDb].[dbo].[Walks]
(Id, Name, Description, LengthInKm, WalkImageUrl, DifficultyId, RegionId)
VALUES
(N'672d879f-d592-4014-84c4-91e63d3cfd1f', N'Heritage Trail', N'A historical walk through an area rich in cultural heritage.', 7.8, N'https://example.com/walks/heritage-trail.jpg', N'ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c', N'f7248fc3-2585-4efb-8d1d-1c555f4087f6');

INSERT INTO [AUWalksDb].[dbo].[Walks]
(Id, Name, Description, LengthInKm, WalkImageUrl, DifficultyId, RegionId)
VALUES
(N'932ba104-9da3-4c0d-937b-c69bc44671a8', N'Waterfall Trail', N'A moderate hike that leads to a stunning waterfall.', 9.3, N'https://example.com/walks/waterfall-trail.jpg', N'ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c', N'906cb139-415a-4bbb-a174-1a1faf9fb1f6');