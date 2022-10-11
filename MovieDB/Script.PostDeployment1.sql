/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

EXEC RegisterUser 'Steve', 'test@test.com', 'test1234'

INSERT INTO Movie (Title, Synopsis, ReleaseYear, PEGI) VALUES
('Star Wars : New Hope', 'Han et Chewbacca cherche la princesse pour la...', 1977, 6),
('LOTR : La communauté de l''anneau', '9 Pecnos partent en road trip', 1999, 12),
('Matrix', 'Fallait pas prendre la pillule bleue', 1999, 16)