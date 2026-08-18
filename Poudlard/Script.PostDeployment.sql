/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
--INSERT INTO Maison(Nom, Fondateur, Couleur, Embleme) VALUES
--(N'Gryffondor', N'Godric Gryffondor', N'Rouge / Or', N'Lion'),
--(N'Pouffsoufle', N'Helga Pouffsoufle', N'Jaune / Noir', N'Blaireau'),
--(N'Serdaigle', N'Rowena Serdaigle', N'Bleu / Argent', N'Aigle'),
--(N'Serpentard', N'Salazard Serpentard', N'Vert / Argent', N'Serpent');