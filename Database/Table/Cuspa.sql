DROP TABLE IF EXISTS [Cuspa];
CREATE TABLE [Cuspa] (
  [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
  , [ForUnitType] INTEGER NOT NULL
  , [CuspaKindType] INTEGER NOT NULL
  , [Level] INTEGER NOT NULL
  , [BoostStatusType] INTEGER NOT NULL
  , [BasicValue] INTEGER NOT NULL
  , [BonusHp] INTEGER NOT NULL
  , [BonusBeamAttack] INTEGER NOT NULL
  , [BonusPhysicalAttack] INTEGER NOT NULL
  , [BonusBeamDefence] INTEGER NOT NULL
  , [BonusPhysicalDefence] INTEGER NOT NULL
  , [BonusCriticalRate] INTEGER NOT NULL
  , [BonusCriticalDamage] INTEGER NOT NULL
  , [BonusAccuracy] INTEGER NOT NULL
  , [BonusEvasion] INTEGER NOT NULL
  , [BonusMobility] INTEGER NOT NULL
  , [BonusEnRecovery] INTEGER NOT NULL
  , [Memo] TEXT NULL
);
