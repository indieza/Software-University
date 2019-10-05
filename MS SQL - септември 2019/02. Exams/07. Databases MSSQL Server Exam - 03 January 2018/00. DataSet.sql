USE RentACar
GO

-- Disable referential integrity
EXEC sp_MSForEachTable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'
GO

EXEC sp_MSForEachTable 'DELETE FROM ?'
GO

EXEC sp_MSForEachTable 'DBCC CHECKIDENT(''?'', RESEED, 0)'
GO

-- Enable referential integrity 
EXEC sp_MSForEachTable 'ALTER TABLE ? WITH CHECK CHECK CONSTRAINT ALL'
GO

--INSERT Clients
SET IDENTITY_INSERT Clients ON;

insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (1, 'Reidar', 'Dowsey', 'M', '1988-12-31', '3564511817471012', '2016-06-10', 'rdowsey0@businessweek.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (2, 'Amitie', 'Faraday', 'F', '1971-07-28', '3536317652610440', '2015-07-12', 'afaraday1@spiegel.de');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (3, 'Laurena', 'Alston', 'F', '1998-08-16', '3551324790335781', '2017-03-03', 'lalston2@nba.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (4, 'Hobie', 'Hartegan', 'M', '1967-07-20', '3560704585034781', '2018-09-29', 'hhartegan3@merriam-webster.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (5, 'Kyle', 'Trousdell', 'M', '1966-11-13', '5313201102292591', '2017-10-14', 'ktrousdell4@bigcartel.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (6, 'Aluin', 'Druett', 'M', '1965-11-06', '3544966238825896', '2017-02-06', 'adruett5@angelfire.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (7, 'Dar', 'Demageard', 'M', '1998-07-09', '4041597055680', '2016-10-26', 'ddemageard6@godaddy.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (8, 'Aldon', 'Spikeings', 'M', '1959-10-03', '5610338298481941', '2017-10-07', 'aspikeings7@sphinn.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (9, 'Cyndi', 'Clowney', 'F', '1973-07-27', '3543577822606427', '2015-10-02', 'cclowney8@apple.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (10, 'Elfie', 'Carnaman', 'F', '1974-05-26', '5602226084086463', '2019-12-22', 'ecarnaman9@feedburner.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (11, 'Hadrian', 'Raffin', 'M', '1998-05-13', '5893988251883029983', '2015-08-12', 'hraffina@about.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (12, 'Alysia', 'Ivatt', 'F', '1985-11-10', '5100144256376652', '2019-04-25', 'aivattb@weibo.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (13, 'Dorolisa', 'Openshaw', 'F', '1995-07-24', '5002356400858174', '2018-09-23', 'dopenshawc@theatlantic.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (14, 'Debee', 'Hacker', 'F', '1994-08-21', '5150951235906907', '2018-06-08', 'dhackerd@addtoany.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (15, 'Sergent', 'Rushby', 'M', '1974-01-26', '5100131176495373', '2019-06-10', 'srushbye@cnet.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (16, 'Freeland', 'Bleddon', 'M', '1983-06-07', '670929906244080228', '2019-10-05', 'fbleddonf@unc.edu');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (17, 'Anabal', 'Mistry', 'F', '1979-03-08', '3564442340433149', '2016-10-03', 'amistryg@buzzfeed.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (18, 'Maximilien', 'McGenis', 'M', '1983-03-13', '30350616253525', '2018-04-16', 'mmcgenish@wordpress.org');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (19, 'Cynthie', 'Duberry', 'F', '1959-04-24', '3585739794661603', '2018-01-02', 'cduberryi@geocities.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (20, 'Agretha', 'Bumphries', 'F', '1990-06-12', '3567475299173487', '2016-03-03', 'abumphriesj@abc.net.au');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (21, 'Jaimie', 'Trewman', 'F', '1996-05-20', '4041596897058', '2018-10-01', 'jtrewmank@about.me');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (22, 'Moira', 'Extil', 'F', '1961-08-10', '3529761291528845', '2018-07-19', 'mextill@sbwire.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (23, 'Land', 'Durban', 'M', '1978-08-07', '0604701490843243', '2017-08-05', 'ldurbanm@sina.com.cn');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (24, 'Mikael', 'MacIlhargy', 'M', '1968-05-04', '3559178923836251', '2016-09-30', 'mmacilhargyn@chicagotribune.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (25, 'Allin', 'Skep', 'M', '1963-12-11', '3544200703257561', '2019-01-16', 'askepo@google.pl');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (26, 'Horatia', 'Craighead', 'F', '1962-06-22', '30168803509099', '2017-09-19', 'hcraigheadp@vinaora.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (27, 'Hedy', 'Hambatch', 'F', '1966-09-25', '5443182305143505', '2019-06-24', 'hhambatchq@topsy.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (28, 'Seamus', 'Andryushchenko', 'M', '1991-06-22', '630472893043270124', '2015-08-02', 'sandryushchenkor@mail.ru');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (29, 'Sonny', 'Skain', 'M', '1965-02-12', '490594762308497783', '2017-01-13', 'sskains@booking.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (30, 'Corbie', 'Dugget', 'M', '1973-06-08', '4026509608167294', '2015-05-18', 'cduggett@goo.ne.jp');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (31, 'Yanaton', 'Darlington', 'M', '1961-06-19', '3557400304850434', '2015-02-06', 'ydarlingtonu@time.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (32, 'Alene', 'Bernocchi', 'F', '1984-09-20', '3531660293450634', '2019-08-24', 'abernocchiv@tinypic.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (33, 'Kati', 'Bourgaize', 'F', '1973-12-07', '5048378664177519', '2015-08-23', 'kbourgaizew@lulu.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (34, 'Malinda', 'Righy', 'F', '1967-12-19', '3580622923465135', '2018-10-14', 'mrighyx@youtu.be');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (35, 'Joyce', 'Gowler', 'F', '1959-06-10', '5602225626792225541', '2016-11-23', 'jgowlery@discuz.net');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (36, 'Ruthie', 'Newstead', 'F', '1968-05-10', '3562790364149898', '2015-06-04', 'rnewsteadz@unicef.org');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (37, 'Melisent', 'Tully', 'F', '1979-05-29', '3586098139617419', '2017-06-22', 'mtully10@java.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (38, 'Mikel', 'Bartoloma', 'M', '1997-10-27', '3567686660372363', '2016-05-07', 'mbartoloma11@marketwatch.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (39, 'Betteanne', 'Tevlin', 'F', '1977-05-14', '3529521469046073', '2018-06-10', 'btevlin12@usa.gov');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (40, 'Earvin', 'Proschek', 'M', '1959-04-12', '3561286395598592', '2015-11-03', 'eproschek13@netvibes.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (41, 'Yevette', 'Shearme', 'F', '1985-11-08', '30264112082108', '2016-07-01', 'yshearme14@nationalgeographic.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (42, 'Merill', 'Aves', 'M', '2000-03-23', '3571629485298672', '2015-05-23', 'maves15@hp.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (43, 'Gustie', 'Iacomo', 'F', '1977-05-24', '5602229735089704', '2015-07-25', 'giacomo16@studiopress.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (44, 'Cullen', 'Ruddock', 'M', '1990-12-03', '3542949031549220', '2015-11-06', 'cruddock17@nifty.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (45, 'Jedediah', 'Costain', 'M', '1979-06-21', '5602231432744182449', '2017-11-02', 'jcostain18@technorati.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (46, 'Ermengarde', 'Hayers', 'F', '1978-01-04', '5048370064072747', '2016-08-20', 'ehayers19@salon.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (47, 'Worthington', 'Pieche', 'M', '1982-09-05', '3575887671953577', '2019-04-29', 'wpieche1a@google.cn');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (48, 'Albie', 'Pinshon', 'M', '1975-07-31', '201428216204529', '2017-08-11', 'apinshon1b@netlog.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (49, 'Deanne', 'Trathan', 'F', '1994-11-26', '30003848499925', '2019-06-14', 'dtrathan1c@rakuten.co.jp');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (50, 'Mikkel', 'Peedell', 'M', '1960-01-05', '560222341621771743', '2016-11-30', 'mpeedell1d@hubpages.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (51, 'Maynord', 'Reyes', 'M', '1992-02-09', '67592666272026528', '2015-05-31', 'mreyes1e@apple.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (52, 'Manfred', 'Licquorish', 'M', '1981-03-22', '3566670355917378', '2018-02-02', 'mlicquorish1f@fotki.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (53, 'Brena', 'Ducker', 'F', '1964-09-26', '3561917870569506', '2018-03-05', 'bducker1g@uiuc.edu');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (54, 'Kaine', 'Fritschel', 'M', '1959-12-02', '3534290180186302', '2019-06-14', 'kfritschel1h@newyorker.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (55, 'Johnathon', 'Syme', 'M', '1960-08-07', '676303132250047653', '2016-06-26', 'jsyme1i@webnode.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (56, 'Kristin', 'Stapleton', 'F', '1963-12-25', '3571275728893471', '2018-04-11', 'kstapleton1j@merriam-webster.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (57, 'Mathian', 'Tyght', 'M', '1979-11-13', '5100138375615487', '2017-03-16', 'mtyght1k@wired.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (58, 'Ulick', 'Rountree', 'M', '1979-12-08', '56022439569061985', '2015-10-31', 'urountree1l@time.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (59, 'Burton', 'Callinan', 'M', '1973-05-25', '5038612034255959144', '2016-01-24', 'bcallinan1m@etsy.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (60, 'Romeo', 'Jellis', 'M', '1964-11-05', '30061259127369', '2017-01-25', 'rjellis1n@prweb.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (61, 'Ellwood', 'Coard', 'M', '1959-01-04', '3582389160123888', '2019-06-19', 'ecoard1o@sphinn.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (62, 'Melody', 'Leahair', 'F', '1983-08-03', '63040745914922679', '2017-03-15', 'mleahair1p@yellowbook.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (63, 'Claudianus', 'Poate', 'M', '1969-02-24', '30150003820948', '2017-07-01', 'cpoate1q@google.ru');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (64, 'Jan', 'Cousens', 'M', '1956-01-24', '3537758793981746', '2016-02-12', 'jcousens1r@ameblo.jp');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (65, 'Darrel', 'Bergstrand', 'M', '2000-11-06', '3586106299330127', '2019-06-05', 'dbergstrand1s@constantcontact.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (66, 'Mozes', 'McCarter', 'M', '1993-10-12', '4905672456160799', '2018-02-13', 'mmccarter1t@123-reg.co.uk');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (67, 'Lesly', 'Mowat', 'F', '1978-12-31', '6706076930890284', '2017-06-27', 'lmowat1u@godaddy.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (68, 'Alicea', 'Elphinston', 'F', '1982-06-22', '3582488679118510', '2016-10-21', 'aelphinston1v@bravesites.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (69, 'Rafaelia', 'Primo', 'F', '1985-07-30', '63047790514874196', '2015-03-23', 'rprimo1w@tamu.edu');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (70, 'Ruben', 'Dalley', 'M', '1983-11-17', '30338800591099', '2018-08-19', 'rdalley1x@ihg.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (71, 'Hilton', 'Campa', 'M', '1980-07-23', '3543633700854108', '2017-01-21', 'hcampa1y@360.cn');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (72, 'Gaye', 'Dyment', 'F', '1968-07-08', '5311328259311643', '2019-10-07', 'gdyment1z@jalbum.net');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (73, 'Caryl', 'Connor', 'M', '1981-04-17', '4911471882080081', '2017-01-05', 'cconnor20@etsy.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (74, 'Rennie', 'Trussell', 'F', '1976-02-16', '5641825286051143', '2016-11-04', 'rtrussell21@techcrunch.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (75, 'Jedidiah', 'Parkhouse', 'M', '1972-08-23', '372301232736795', '2015-06-14', 'jparkhouse22@wikia.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (76, 'Jessa', 'Doick', 'F', '1999-04-26', '3580496137014009', '2017-05-09', 'jdoick23@ucsd.edu');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (77, 'Ania', 'Crumbie', 'F', '1978-08-09', '36710473778894', '2016-07-19', 'acrumbie24@umich.edu');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (78, 'Griswold', 'Schankelborg', 'M', '1994-03-14', '3574002131484749', '2017-03-29', 'gschankelborg25@istockphoto.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (79, 'Derwin', 'Bridgement', 'M', '1961-07-16', '5435756825163430', '2019-09-25', 'dbridgement26@hud.gov');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (80, 'Alayne', 'Morville', 'F', '1967-12-07', '337941566279138', '2018-07-10', 'amorville27@dion.ne.jp');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (81, 'Editha', 'Lenoir', 'F', '1958-10-12', '6331105742035482', '2016-04-14', 'elenoir28@cloudflare.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (82, 'Agnella', 'Adamiec', 'F', '1997-11-18', '3553256368917954', '2016-04-13', 'aadamiec29@google.nl');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (83, 'Mallory', 'Everley', 'M', '1988-03-22', '4903632242516151', '2018-12-31', 'meverley2a@nih.gov');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (84, 'Skylar', 'Waterfall', 'M', '1976-03-20', '3570464740585726', '2018-07-15', 'swaterfall2b@msn.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (85, 'Tobi', 'Garley', 'F', '1978-06-20', '3534538842590596', '2017-03-12', 'tgarley2c@deliciousdays.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (86, 'Kaspar', 'Jedrzejewski', 'M', '1967-04-12', '6379485754796012', '2018-05-24', 'kjedrzejewski2d@freewebs.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (87, 'Renado', 'Tisun', 'M', '1978-02-18', '5157002149217495', '2017-10-10', 'rtisun2e@cbsnews.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (88, 'Andie', 'Codlin', 'F', '1992-07-15', '5396378487795370', '2016-03-19', 'acodlin2f@hubpages.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (89, 'Brit', 'Glandfield', 'M', '1976-11-29', '3547800489373297', '2016-05-18', 'bglandfield2g@aboutads.info');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (90, 'Tybi', 'Dafforne', 'F', '1980-01-17', '30379590337194', '2019-11-03', 'tdafforne2h@shareasale.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (91, 'Lane', 'Reder', 'M', '1994-01-16', '3545224054721552', '2018-08-14', 'lreder2i@boston.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (92, 'Sarine', 'Stammer', 'F', '1980-01-20', '4634825964345561', '2017-01-19', 'sstammer2j@businesswire.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (93, 'Marice', 'Forde', 'F', '1991-06-14', '3541430458084521', '2019-12-14', 'mforde2k@uiuc.edu');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (94, 'Baxter', 'Aslott', 'M', '1990-08-16', '3543569989124112', '2018-10-05', 'baslott2l@usnews.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (95, 'Philip', 'Dodle', 'M', '1962-02-13', '5108753850437280', '2019-09-18', 'pdodle2m@earthlink.net');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (96, 'Dougie', 'Middlewick', 'M', '1993-07-10', '3528607409479069', '2017-09-14', 'dmiddlewick2n@goodreads.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (97, 'Jens', 'McKeller', 'M', '1967-05-08', '201504138043672', '2018-06-23', 'jmckeller2o@yale.edu');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (98, 'Patsy', 'Hazelton', 'M', '1985-12-16', '30044763763903', '2016-09-13', 'phazelton2p@i2i.jp');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (99, 'Stormie', 'Dilgarno', 'F', '1960-12-09', '3580785136158027', '2015-05-04', 'sdilgarno2q@cnet.com');
insert into Clients (Id, FirstName, LastName, Gender, BirthDate, CreditCard, CardValidity, Email) values (100, 'Odette', 'Langan', 'F', '1969-10-10', '3578496871683567', '2019-06-02', 'olangan2r@dmoz.org');


SET IDENTITY_INSERT Clients OFF;

--INSERT Models
SET IDENTITY_INSERT Models ON;

insert into Models (Id, Manufacturer, Model, ProductionYear, Seats, Class, Consumption) values (1, 'Chevrolet', 'Astro', '2005-07-27', 4, 'Economy', 12.6);
insert into Models (Id, Manufacturer, Model, ProductionYear, Seats, Class, Consumption) values (2, 'Toyota', 'Solara', '2009-10-15', 7, 'Family', 13.8);
insert into Models (Id, Manufacturer, Model, ProductionYear, Seats, Class, Consumption) values (3, 'Volvo', 'S40', '2010-10-12', 3, 'Average', 11.3);
insert into Models (Id, Manufacturer, Model, ProductionYear, Seats, Class, Consumption) values (4, 'Suzuki', 'Swift', '2000-02-03', 7, 'Economy', 16.2);
insert into Models (Id, Manufacturer, Model, ProductionYear, Seats, Class, Consumption) values (5, 'Kia', 'Forte', '2008-02-17', 4, 'Average', 4.6);
insert into Models (Id, Manufacturer, Model, ProductionYear, Seats, Class, Consumption) values (6, 'Geo', 'Metro', '2006-05-19', 4, 'Economy', 9.1);
insert into Models (Id, Manufacturer, Model, ProductionYear, Seats, Class, Consumption) values (7, 'Volkswagen', 'Jetta', '2012-12-26', 3, 'Average', 14.9);
insert into Models (Id, Manufacturer, Model, ProductionYear, Seats, Class, Consumption) values (8, 'Buick', 'Park Avenue', '2016-08-07', 2, 'Luxury', 19.1);
insert into Models (Id, Manufacturer, Model, ProductionYear, Seats, Class, Consumption) values (9, 'Chevrolet', 'Silverado 1500', '2012-02-01', 2, 'Luxury', 21.2);
insert into Models (Id, Manufacturer, Model, ProductionYear, Seats, Class, Consumption) values (10, 'Dodge', 'Ram Van 1500', '2008-09-21', 8, 'Family', 4.7);
insert into Models (Id, Manufacturer, Model, ProductionYear, Seats, Class, Consumption) values (11, 'Mercedes-Benz', 'SL-Class', '2015-08-27', 6, 'Economy', 12.8);
insert into Models (Id, Manufacturer, Model, ProductionYear, Seats, Class, Consumption) values (12, 'Mitsubishi', 'Outlander', '2017-07-02', 3, 'Average', 14.6);
insert into Models (Id, Manufacturer, Model, ProductionYear, Seats, Class, Consumption) values (13, 'Mercedes-Benz', 'R-Class', '1995-03-13', 9, 'Average', 12.3);
insert into Models (Id, Manufacturer, Model, ProductionYear, Seats, Class, Consumption) values (14, 'Volkswagen', 'Passat', '1996-11-17', 7, 'Luxury', 7.7);
insert into Models (Id, Manufacturer, Model, ProductionYear, Seats, Class, Consumption) values (15, 'Cadillac', 'Eldorado', '1995-01-30', 3, 'Economy', 3.6);
insert into Models (Id, Manufacturer, Model, ProductionYear, Seats, Class, Consumption) values (16, 'Mitsubishi', 'Galant', '2007-05-05', 9, 'Luxury', 18.7);
insert into Models (Id, Manufacturer, Model, ProductionYear, Seats, Class, Consumption) values (17, 'Mercury', 'Grand Marquis', '2012-08-19', 8, 'Economy', 10.8);
insert into Models (Id, Manufacturer, Model, ProductionYear, Seats, Class, Consumption) values (18, 'Mercury', 'Mountaineer', '2014-08-27', 7, 'Economy', 14.2);
insert into Models (Id, Manufacturer, Model, ProductionYear, Seats, Class, Consumption) values (19, 'Acura', 'TL', '2004-04-30', 9, 'Family', 20.5);
insert into Models (Id, Manufacturer, Model, ProductionYear, Seats, Class, Consumption) values (20, 'Infiniti', 'J', '1997-03-28', 9, 'Luxury', 17.8);

SET IDENTITY_INSERT Models OFF;

--INSERT Towns
SET IDENTITY_INSERT Towns ON;

insert into Towns (Id, Name) values (1, 'Oakland');
insert into Towns (Id, Name) values (2, 'Betrr');
insert into Towns (Id, Name) values (3, 'Sampir');
insert into Towns (Id, Name) values (4, 'Montesson');
insert into Towns (Id, Name) values (5, 'Hachseynli');
insert into Towns (Id, Name) values (6, 'Kendari');
insert into Towns (Id, Name) values (7, 'Seboruco');
insert into Towns (Id, Name) values (8, 'Psyzh');
insert into Towns (Id, Name) values (9, 'Budapest');
insert into Towns (Id, Name) values (10, 'Gaohong');
insert into Towns (Id, Name) values (11, 'Montasik');
insert into Towns (Id, Name) values (12, 'Santa Rosa de Agun');
insert into Towns (Id, Name) values (13, 'Tabu');
insert into Towns (Id, Name) values (14, 'Liuhe');
insert into Towns (Id, Name) values (15, 'Czarna Dbrwka');
insert into Towns (Id, Name) values (16, 'Karatsu');
insert into Towns (Id, Name) values (17, 'La Escondida');
insert into Towns (Id, Name) values (18, 'Eyvn');
insert into Towns (Id, Name) values (19, 'Matsuyama');
insert into Towns (Id, Name) values (20, 'Al Ghriyah');

SET IDENTITY_INSERT Towns OFF;

--INSERT Offices
SET IDENTITY_INSERT Offices ON;

insert into Offices (Id, Name, ParkingPlaces, TownId) values (1, 'Lemke LLC', 12, 15);
insert into Offices (Id, Name, ParkingPlaces, TownId) values (2, 'Gusikowski-Lindgren', 17, 1);
insert into Offices (Id, Name, ParkingPlaces, TownId) values (3, 'Green, Jaskolski and Blick', 17, 17);
insert into Offices (Id, Name, ParkingPlaces, TownId) values (4, 'Terry-Kilback', 12, 4);
insert into Offices (Id, Name, ParkingPlaces, TownId) values (5, 'Renner-Moen', 25, 5);
insert into Offices (Id, Name, ParkingPlaces, TownId) values (6, 'Steuber Group', 14, 18);
insert into Offices (Id, Name, ParkingPlaces, TownId) values (7, 'Willms, Jakubowski and Gottlieb', 15, 15);
insert into Offices (Id, Name, ParkingPlaces, TownId) values (8, 'Rohan-Rippin', 20, 5);
insert into Offices (Id, Name, ParkingPlaces, TownId) values (9, 'Mueller-Ankunding', 29, 11);
insert into Offices (Id, Name, ParkingPlaces, TownId) values (10, 'Gleichner-Lockman', 22, 18);
insert into Offices (Id, Name, ParkingPlaces, TownId) values (11, 'Grant Group', 10, 13);
insert into Offices (Id, Name, ParkingPlaces, TownId) values (12, 'Hirthe, Schimmel and Roberts', 13, 17);
insert into Offices (Id, Name, ParkingPlaces, TownId) values (13, 'Bednar-Champlin', 15, 3);
insert into Offices (Id, Name, ParkingPlaces, TownId) values (14, 'Schmeler-Rath', 19, 8);
insert into Offices (Id, Name, ParkingPlaces, TownId) values (15, 'Lindgren-Bednar', 23, 13);
insert into Offices (Id, Name, ParkingPlaces, TownId) values (16, 'Paucek, Graham and Jacobi', 27, 6);
insert into Offices (Id, Name, ParkingPlaces, TownId) values (17, 'Haag-Watsica', 18, 11);
insert into Offices (Id, Name, ParkingPlaces, TownId) values (18, 'Welch, Hoeger and Stark', 21, 11);
insert into Offices (Id, Name, ParkingPlaces, TownId) values (19, 'Tillman-Kunze', 17, 19);
insert into Offices (Id, Name, ParkingPlaces, TownId) values (20, 'Hartmann, Leuschke and Becker', 21, 9);
insert into Offices (Id, Name, ParkingPlaces, TownId) values (21, 'Dietrich Inc', 22, 10);
insert into Offices (Id, Name, ParkingPlaces, TownId) values (22, 'Zulauf, Braun and Yundt', 25, 17);
insert into Offices (Id, Name, ParkingPlaces, TownId) values (23, 'Sanford, Gleason and Heaney', 19, 2);
insert into Offices (Id, Name, ParkingPlaces, TownId) values (24, 'McKenzie-Ebert', 10, 9);
insert into Offices (Id, Name, ParkingPlaces, TownId) values (25, 'Parisian, Armstrong and Nitzsche', 10, 9);
insert into Offices (Id, Name, ParkingPlaces, TownId) values (26, 'Bode LLC', 17, 5);
insert into Offices (Id, Name, ParkingPlaces, TownId) values (27, 'Eichmann, Kerluke and Torphy', 23, 13);
insert into Offices (Id, Name, ParkingPlaces, TownId) values (28, 'Wyman, Bernhard and Klein', 12, 11);
insert into Offices (Id, Name, ParkingPlaces, TownId) values (29, 'VonRueden-Buckridge', 21, 10);
insert into Offices (Id, Name, ParkingPlaces, TownId) values (30, 'Kemmer, Monahan and Stiedemann', 21, 10);
insert into Offices (Id, Name, ParkingPlaces, TownId) values (31, 'Rodriguez, Lebsack and Kub', 16, 2);
insert into Offices (Id, Name, ParkingPlaces, TownId) values (32, 'Breitenberg LLC', 11, 17);
insert into Offices (Id, Name, ParkingPlaces, TownId) values (33, 'Haag and Sons', 12, 18);
insert into Offices (Id, Name, ParkingPlaces, TownId) values (34, 'Johnston-Gleichner', 18, 9);
insert into Offices (Id, Name, ParkingPlaces, TownId) values (35, 'Gibson-Kulas', 16, 13);
insert into Offices (Id, Name, ParkingPlaces, TownId) values (36, 'Cassin, Heathcote and Kuhlman', 26, 15);
insert into Offices (Id, Name, ParkingPlaces, TownId) values (37, 'Lang, Rosenbaum and Gutmann', 22, 19);
insert into Offices (Id, Name, ParkingPlaces, TownId) values (38, 'Bradtke, Konopelski and Gerhold', 17, 16);
insert into Offices (Id, Name, ParkingPlaces, TownId) values (39, 'Champlin Inc', 26, 10);
insert into Offices (Id, Name, ParkingPlaces, TownId) values (40, 'Block, Lueilwitz and Will', 20, 17);
insert into Offices (Id, Name, ParkingPlaces, TownId) values (41, 'Fisher Inc', 10, 20);
insert into Offices (Id, Name, ParkingPlaces, TownId) values (42, 'Friesen Inc', 13, 1);
insert into Offices (Id, Name, ParkingPlaces, TownId) values (43, 'Padberg, Schuppe and Kassulke', 18, 7);
insert into Offices (Id, Name, ParkingPlaces, TownId) values (44, 'Parisian Group', 11, 1);
insert into Offices (Id, Name, ParkingPlaces, TownId) values (45, 'Murazik-Stoltenberg', 13, 8);
insert into Offices (Id, Name, ParkingPlaces, TownId) values (46, 'White, Rath and Runte', 22, 12);
insert into Offices (Id, Name, ParkingPlaces, TownId) values (47, 'Robel, Krajcik and Olson', 26, 2);
insert into Offices (Id, Name, ParkingPlaces, TownId) values (48, 'Roob Group', 16, 20);
insert into Offices (Id, Name, ParkingPlaces, TownId) values (49, 'Dooley, Murazik and O''Keefe', 19, 14);
insert into Offices (Id, Name, ParkingPlaces, TownId) values (50, 'Mitchell-Johns', 17, 8);

SET IDENTITY_INSERT Offices OFF;

--INSERT Vehicles
SET IDENTITY_INSERT Vehicles ON;

insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (1, 12, 50, 109947);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (2, 7, 33, 109912);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (3, 12, 10, 101810);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (4, 15, 18, 161780);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (5, 11, 7, 87408);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (6, 5, 30, 30291);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (7, 17, 11, 86345);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (8, 19, 45, 230374);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (9, 4, 18, 152404);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (10, 19, 37, 240392);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (11, 10, 6, 177851);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (12, 17, 5, 175805);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (13, 6, 8, 187487);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (14, 19, 47, 160876);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (15, 9, 23, 118050);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (16, 2, 18, 57818);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (17, 15, 7, 39044);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (18, 7, 11, 165701);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (19, 19, 4, 38774);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (20, 12, 36, 204276);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (21, 14, 39, 230898);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (22, 15, 29, 45335);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (23, 18, 16, 194181);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (24, 5, 43, 31683);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (25, 2, 8, 199852);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (26, 4, 4, 160949);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (27, 3, 50, 74734);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (28, 7, 11, 194149);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (29, 3, 4, 191148);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (30, 5, 37, 236906);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (31, 7, 47, 166470);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (32, 5, 48, 191093);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (33, 8, 32, 143963);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (34, 15, 50, 23188);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (35, 3, 16, 201896);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (36, 1, 17, 147175);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (37, 12, 3, 211329);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (38, 8, 23, 69438);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (39, 18, 22, 72493);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (40, 18, 26, 233434);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (41, 18, 17, 214956);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (42, 16, 12, 154650);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (43, 2, 46, 137883);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (44, 7, 49, 99006);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (45, 4, 11, 29940);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (46, 8, 28, 130864);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (47, 8, 43, 203164);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (48, 1, 46, 175290);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (49, 16, 5, 127720);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (50, 19, 37, 79614);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (51, 1, 34, 41878);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (52, 13, 8, 143641);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (53, 20, 43, 29281);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (54, 1, 12, 157909);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (55, 9, 15, 219747);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (56, 8, 20, 154824);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (57, 19, 14, 148156);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (58, 16, 36, 50008);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (59, 18, 26, 50492);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (60, 8, 21, 214604);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (61, 14, 35, 185828);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (62, 16, 44, 203006);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (63, 19, 3, 130781);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (64, 12, 15, 36121);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (65, 17, 23, 199186);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (66, 5, 17, 241841);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (67, 11, 44, 79672);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (68, 19, 20, 46890);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (69, 3, 19, 98586);
insert into Vehicles (Id, ModelId, OfficeId, Mileage) values (70, 16, 12, 174145);

SET IDENTITY_INSERT Vehicles OFF;

--INSERT Orders
SET IDENTITY_INSERT Orders ON;

insert into Orders (Id, ClientId, TownId, VehicleId, CollectionDate, CollectionOfficeId, ReturnDate, ReturnOfficeId, Bill, TotalMileage) 
values
(1, 17, 2, 52, '2017-08-08',30, '2017-09-04', 42, 2360.00, 7434),
(2, 78, 17, 50, '2017-04-22',10, '2017-05-09', 12, 2326.00, 7326),
(3, 27, 13, 28, '2017-04-25',21, '2017-05-09', 34, 597.00, 1880),
(4, 89, 8, 12, '2017-11-16',19, '2017-11-23', 28, 603.00, 1899),
(5, 90, 16, 45, '2017-10-26',9, '2017-11-02', 12, 384.00, 1209),
(6, 80, 3, 31, '2017-12-06',46, '2017-12-11', 29, 60.00, 189),
(7, 48, 6, 70, '2017-08-28',43, '2017-09-17', 39, 2207.00, 6952),
(8, 65, 16, 30, '2017-07-16',11, '2017-08-04', 24, 1179.00, 3713),
(9, 82, 15, 16, '2017-04-14',8, '2017-07-24', 6, 2277.00, 7172),
(10, 25, 15, 29, '2017-08-20',23, '2017-12-11', 6, 1814.00, 5714),
(11, 24, 20, 33, '2017-10-26',31, '2017-12-19', 49, 385.00, 1212),
(12, 36, 17, 70, '2017-04-26',37, '2017-09-06', 44, 2133.00, 6718),
(13, 77, 1, 24, '2017-08-02',22, '2017-11-04', 35, 1890.00, 5953),
(14, 1, 9, 8, '2017-12-27',45, '2018-01-04', 31, 941.00, 2964),
(15, 52, 19, 29, '2017-03-06',24, NULL, NULL, NULL, NULL),
(16, 65, 8, 25, '2017-10-04',25, NULL, NULL, NULL, NULL),
(17, 66, 6, 44, '2017-09-12',37, '2017-09-23', 21, 1574.00, 4958),
(18, 56, 12, 7, '2017-10-20',4, '2017-11-04', 21, 1361.00, 4287),
(19, 7, 9, 54, '2017-10-06',27, '2017-10-12', 31, 417.00, 1313),
(20, 76, 5, 11, '2017-09-11',13, '2017-11-29', 8, 1536.00, 4838),
(21, 78, 17, 25, '2017-11-11',35, NULL, NULL, NULL, NULL),
(22, 23, 16, 28, '2017-08-04',34, '2017-08-19', 21, 1020.00, 3213),
(23, 12, 18, 69, '2018-01-01',42, '2018-01-20', 7, 1863.00, 5868),
(24, 19, 9, 24, '2017-05-21',47, '2017-06-03', 19, 1035.00, 3260),
(25, 58, 8, 65, '2017-04-03',29, '2017-04-14', 25, 1609.00, 5068),
(26, 19, 6, 25, '2017-05-10',14, '2017-05-25', 8, 1972.00, 6211),
(27, 53, 7, 28, '2017-12-10',16, '2017-12-25', 2, 29.00, 91),
(28, 67, 19, 29, '2017-06-21',34, '2017-08-22', 23, 1008.00, 3175),
(29, 51, 7, 11, '2017-11-22',38, '2017-12-05', 22, 1577.00, 4967),
(30, 58, 2, 24, '2017-08-17',40, '2017-08-25', 23, 2196.00, 6917),
(31, 84, 14, 33, '2017-11-08',36, '2017-11-16', 48, 803.00, 2529),
(32, 50, 10, 17, '2017-11-14',22, '2017-12-01', 17, 554.00, 1745),
(33, 5, 8, 1, '2017-08-28',41, '2017-09-17', 11, 637.00, 2006),
(34, 71, 19, 21, '2017-02-03',21, '2017-04-03', 33, 1321.00, 4161),
(35, 71, 12, 36, '2017-08-05',1, '2017-08-19', 37, 242.00, 762),
(36, 66, 15, 48, '2017-11-26',47, '2017-12-04', 21, 1097.00, 3455),
(37, 45, 1, 46, '2017-03-11',1, '2017-03-25', 45, 2297.00, 7235),
(38, 35, 1, 38, '2017-02-23',37, '2017-05-02', 39, 685.00, 2157),
(39, 92, 9, 62, '2017-10-06',43, '2017-10-23', 6, 818.00, 2576),
(40, 81, 9, 6, '2017-08-31',6, NULL, NULL, NULL, NULL),
(41, 74, 16, 40, '2017-03-13',46, '2017-03-20', 28, 347.00, 1093),
(42, 51, 14, 52, '2017-06-26',39, '2017-07-16', 11, 1152.00, 3628),
(43, 48, 6, 9, '2017-03-30',24, '2017-04-19', 34, 701.00, 2208),
(44, 3, 11, 19, '2017-07-23',6, '2017-08-08', 43, 2261.00, 7122),
(45, 16, 3, 13, '2017-05-21',32, '2017-11-28', 41, 1999.00, 6296),
(46, 7, 5, 70, '2017-11-23',40, '2017-12-06', 17, 73.00, 229),
(47, 92, 15, 67, '2017-11-21',40, '2017-12-02', 18, 26.00, 81),
(48, 2, 17, 44, '2017-07-24',4, '2017-08-13', 9, 1547.00, 4873),
(49, 88, 17, 20, '2017-06-20',24, '2017-12-14', 11, 809.00, 2548),
(50, 61, 9, 36, '2017-03-19',46, '2017-04-24', 30, 1019.00, 3209),
(51, 43, 4, 23, '2017-04-02',10, '2017-04-10', 27, 352.00, 1108),
(52, 8, 4, 10, '2017-12-26',13, '2018-01-07', 21, 451.00, 1420),
(53, 4, 17, 18, '2017-05-28',44, NULL, NULL, NULL, NULL),
(54, 59, 17, 13, '2017-10-15',16, NULL, NULL, NULL, NULL),
(55, 61, 4, 42, '2017-02-11',20, '2017-12-10', 47, 1292.00, 4069),
(56, 79, 3, 68, '2017-11-07',45, '2017-11-19', 26, 221.00, 696),
(57, 85, 12, 46, '2017-07-31',34, '2017-11-19', 14, 998.00, 3143),
(58, 8, 1, 35, '2017-12-30',23, '2018-01-09', 14, 656.00, 2066),
(59, 94, 4, 38, '2018-01-01',8, '2018-01-02', 44, 2198.00, 6923),
(60, 7, 16, 49, '2017-04-17',21, '2017-10-27', 14, 1796.00, 5657),
(61, 3, 1, 3, '2017-12-11',3, '2017-12-22', 9, 1177.00, 3707),
(62, 68, 4, 15, '2017-03-27',35, '2017-04-14', 8, 2388.00, 7522),
(63, 12, 2, 51, '2017-02-05',8, '2017-11-10', 30, 1417.00, 4463),
(64, 99, 3, 25, '2017-07-09',8, '2017-07-23', 12, 1088.00, 3427),
(65, 8, 4, 43, '2017-02-13',25, '2017-11-30', 4, 239.00, 752),
(66, 13, 9, 52, '2017-01-16',16, '2017-11-14', 43, 2316.00, 7295),
(67, 63, 14, 15, '2017-09-30',12, '2017-10-07', 34, 1760.00, 5544),
(68, 56, 5, 3, '2017-10-06',21, NULL, NULL, NULL, NULL),
(69, 47, 5, 64, '2017-09-15',16, NULL, NULL, NULL, NULL),
(70, 58, 20, 21, '2017-12-31',9, NULL, NULL, NULL, NULL),
(71, 1, 2, 2, '2017-08-10',20, NULL, NULL, NULL, NULL),
(72, 12, 13, 6, '2017-07-03',47, '2017-07-20', 9, 1783.00, 5616),
(73, 92, 5, 32, '2017-02-21',2, '2017-06-26', 30, 897.00, 2825),
(74, 64, 10, 43, '2017-06-29',42, '2017-07-13', 49, 527.00, 1660),
(75, 19, 1, 3, '2017-10-30',48, NULL, NULL, NULL, NULL),
(76, 60, 16, 9, '2017-09-27',14, '2017-09-29', 31, 1579.00, 4973),
(77, 88, 18, 48, '2017-09-24',38, '2017-10-01', 46, 1296.00, 4082),
(78, 32, 9, 36, '2017-08-21',25, '2017-08-25', 36, 1056.00, 3326),
(79, 8, 5, 60, '2017-11-14',26, '2017-11-29', 6, 383.00, 1206),
(80, 51, 13, 63, '2017-04-23',21, NULL, NULL, NULL, NULL),
(81, 12, 8, 17, '2017-07-30',27, '2017-10-13', 34, 1418.00, 4466),
(82, 27, 7, 54, '2017-01-25',3, '2017-11-02', 23, 557.00, 1754),
(83, 44, 15, 66, '2017-09-30',37, '2017-11-17', 48, 1019.00, 3209),
(84, 18, 1, 59, '2017-03-27',7, '2017-04-16', 35, 1399.00, 4406),
(85, 78, 15, 68, '2017-12-13',37, '2017-12-21', 43, 1814.00, 5714),
(86, 68, 15, 25, '2017-07-16',33, '2017-07-27', 42, 778.00, 2450),
(87, 57, 4, 30, '2017-05-30',44, '2017-12-01', 4, 573.00, 1804),
(88, 15, 19, 42, '2017-01-12',2, '2017-07-25', 27, 244.00, 768),
(89, 95, 1, 61, '2017-12-11',24, '2017-12-15', 41, 980.00, 3087),
(90, 90, 3, 44, '2017-06-03',15, '2017-12-13', 47, 2381.00, 7500),
(91, 7, 18, 48, '2017-04-06',41, '2017-04-08', 10, 2259.00, 7115),
(92, 94, 6, 70, '2017-07-31',20, '2017-09-04', 41, 2142.00, 6747),
(93, 16, 2, 39, '2017-01-06',43, '2017-08-12', 32, 1636.00, 5153),
(94, 77, 19, 66, '2017-12-16',38, '2018-01-03', 12, 188.00, 592),
(95, 68, 2, 56, '2017-08-07',9, '2017-10-14', 14, 852.00, 2683),
(96, 50, 6, 48, '2017-04-17',18, '2017-06-23', 42, 1947.00, 6133),
(97, 11, 19, 61, '2017-12-02',37, '2017-12-31', 6, 127.00, 400),
(98, 40, 15, 45, '2017-06-11',30, '2017-06-23', 37, 936.00, 2948),
(99, 36, 8, 55, '2017-04-27',50, '2017-12-31', 1, 1134.00, 3572),
(100, 68, 15, 25, '2017-09-22',7, '2017-10-05', 15, 273.00, 859),
(101, 100, 17, 14, '2017-06-03',31, '2017-09-01', 2, 1804.00, 5682),
(102, 62, 3, 32, '2017-03-10',46, '2017-09-27', 37, 1692.00, 5329),
(103, 46, 19, 6, '2017-07-23',41, '2017-08-08', 4, 2318.00, 7301),
(104, 55, 16, 25, '2017-11-07',43, NULL, NULL, NULL, NULL),
(105, 83, 4, 30, '2017-02-25',28, '2017-04-26', 16, 929.00, 2926),
(106, 57, 1, 15, '2017-03-25',40, '2017-03-29', 4, 1211.00, 3814),
(107, 28, 18, 65, '2017-07-06',14, '2017-07-10', 36, 1925.00, 6063),
(108, 61, 6, 15, '2017-05-02',7, '2017-10-28', 26, 291.00, 916),
(109, 21, 17, 63, '2017-11-23',45, '2017-12-06', 33, 406.00, 1278),
(110, 45, 17, 54, '2017-01-18',40, '2017-06-29', 14, 1885.00, 5937),
(111, 79, 14, 39, '2017-03-04',10, '2017-05-05', 1, 1186.00, 3735),
(112, 98, 15, 47, '2017-11-15',50, '2017-11-20', 7, 343.00, 1080),
(113, 5, 13, 32, '2017-03-06',25, '2017-06-06', 15, 1219.00, 3839),
(114, 38, 12, 30, '2017-10-26',33, '2017-11-02', 45, 1110.00, 3496),
(115, 54, 12, 4, '2017-11-30',26, '2017-12-02', 21, 2406.00, 7578),
(116, 86, 8, 16, '2017-04-08',31, '2017-04-24', 22, 48.00, 151),
(117, 95, 13, 35, '2017-10-29',20, NULL, NULL, NULL, NULL),
(118, 56, 9, 1, '2017-02-02',15, NULL, NULL, NULL, NULL),
(119, 31, 13, 51, '2017-03-01',38, '2017-11-09', 9, 1729.00, 5446),
(120, 57, 16, 31, '2017-01-25',42, '2017-05-06', 17, 2446.00, 7704);

SET IDENTITY_INSERT Orders OFF;