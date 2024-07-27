DROP TABLE IF EXISTS [Pilot];
CREATE TABLE [Pilot] ( 
  [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
  , [Name] TEXT NOT NULL
  , [ForUnitType] INTEGER NOT NULL
  , [SerialId] INTEGER NOT NULL
  , [GradeType] INTEGER NOT NULL
  , [Level] INTEGER NOT NULL
  , [Shooting] INTEGER NOT NULL
  , [Melee] INTEGER NOT NULL
  , [Accuracy] INTEGER NOT NULL
  , [Evasion] INTEGER NOT NULL
  , [Awakened] INTEGER NOT NULL
  , [Defense] INTEGER NOT NULL
  , [PracticedShooting] INTEGER NOT NULL
  , [PracticedMelee] INTEGER NOT NULL
  , [PracticedAccuracy] INTEGER NOT NULL
  , [PracticedEvasion] INTEGER NOT NULL
  , [PracticedAwakened] INTEGER NOT NULL
  , [PracticedDefense] INTEGER NOT NULL
  , [PilotSkillId] INTEGER NOT NULL
  , [PilotSkillText1] TEXT NULL
  , [PilotSkillText2] TEXT NULL
  , [Memo] TEXT NULL
  , IsPinned INTEGER not null default true
);
