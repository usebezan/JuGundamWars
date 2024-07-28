DROP TABLE IF EXISTS [Support];
CREATE TABLE [Support] (
  [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
  , [Name] TEXT NOT NULL
  , [ForUnitType] INTEGER NOT NULL
  , [SerialId] INTEGER NOT NULL
  , [GradeType] INTEGER NOT NULL
  , [Memo] TEXT NULL
  , [IsPinned] INTEGER not null default true
);
