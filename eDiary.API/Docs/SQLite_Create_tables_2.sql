﻿CREATE TABLE IF NOT EXISTS Folders (
	Id INTEGER PRIMARY KEY,
	Name TEXT NOT NULL,
	ParentFolderId INTEGER REFERENCES Folders (Id) ON DELETE CASCADE ON UPDATE CASCADE
)

CREATE TABLE IF NOT EXISTS Notes (
	Id INTEGER PRIMARY KEY,
	Header TEXT NOT NULL,
	Description TEXT,
	StatusId INTEGER NOT NULL REFERENCES Statuses (Id) ON DELETE RESTRICT ON UPDATE CASCADE,
	FolderId INTEGER NOT NULL REFERENCES Folders (Id) ON DELETE CASCADE ON UPDATE CASCADE
) 

DROP TABLE AttachedLinks 
CREATE TABLE AttachedLinks (
	Id INTEGER PRIMARY KEY,
	Name TEXT,
	Link TEXT NOT NULL,
	TaskId INTEGER REFERENCES Tasks (Id) ON DELETE CASCADE ON UPDATE CASCADE,
	NoteId INTEGER REFERENCES Notes (Id) ON DELETE CASCADE ON UPDATE CASCADE
)

CREATE TABLE TagReferences (
	Id INTEGER PRIMARY KEY,
	TagId INTEGER NOT NULL REFERENCES Tags (Id) ON DELETE CASCADE ON UPDATE CASCADE,
	TaskId INTEGER REFERENCES Tasks (Id) ON DELETE CASCADE ON UPDATE CASCADE,
	NoteId INTEGER REFERENCES Notes (Id) ON DELETE CASCADE ON UPDATE CASCADE
)

CREATE TABLE IF NOT EXISTS AttachedFiles (
	Id INTEGER PRIMARY KEY,
	Name TEXT NOT NULL,
	Link TEXT NOT NULL,
	NoteId INTEGER REFERENCES Notes (Id) ON DELETE CASCADE ON UPDATE CASCADE,
	TaskId INTEGER REFERENCES Tasks (Id) ON DELETE CASCADE ON UPDATE CASCADE
)

CREATE TABLE IF NOT EXISTS Users (
	Id INTEGER PRIMARY KEY,
	FirstName TEXT NOT NULL,
	LastName TEXT
)

CREATE TABLE IF NOT EXISTS ProjectCategories (
	Id INTEGER PRIMARY KEY,
	Name TEXT NOT NULL,
	UserId INTEGER NOT NULL REFERENCES Users (Id) ON DELETE CASCADE ON UPDATE CASCADE
)

DROP TABLE Projects
CREATE TABLE Projects (
	Id INTEGER PRIMARY KEY,
	Name TEXT NOT NULL,
	CategoryId INTEGER REFERENCES ProjectCategories (Id) ON DELETE CASCADE ON UPDATE CASCADE,
	UserId INTEGER NOT NULL REFERENCES Users (Id) ON DELETE CASCADE ON UPDATE CASCADE
)

DROP TABLE Sections
CREATE TABLE IF NOT EXISTS Sections (
	Id INTEGER PRIMARY KEY,
	Name TEXT NOT NULL,
	ProjectId INTEGER NOT NULL REFERENCES Projects (Id) ON DELETE SET NULL ON UPDATE CASCADE
)

ALTER TABLE Users
RENAME TO UserProfiles

CREATE TABLE AppUsers (
	Id INTEGER PRIMARY KEY,
	UserProlifeId INTEGER NOT NULL REFERENCES UserProfiles (Id) ON DELETE CASCADE ON UPDATE CASCADE,
	PasswordHash TEXT NOT NULL
)

CREATE TABLE IF NOT EXISTS Languages(
	Id INTEGER PRIMARY KEY,
	ShortCode TEXT NOT NULL
)

CREATE TABLE IF NOT EXISTS UserSettings (
	Id INTEGER PRIMARY KEY,
	UserId INTEGER NOT NULL REFERENCES UserProfiles (Id) ON DELETE CASCADE ON UPDATE CASCADE,
	LanguageId INTEGER REFERENCES Languages (Id) ON DELETE SET NULL ON UPDATE CASCADE,
	RootFolderId INTEGER NOT NULL REFERENCES Folders (Id) ON DELETE RESTRICT ON UPDATE CASCADE
)
