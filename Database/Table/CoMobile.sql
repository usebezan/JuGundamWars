DROP TABLE IF EXISTS [CoMobile];
CREATE TABLE [CoMobile] (
  [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
  , [Name] TEXT NOT NULL
  , [SerialId] INTEGER NOT NULL
  , [RoleType] INTEGER NOT NULL
  , [Level] INTEGER NOT NULL
  , [Hp] INTEGER NOT NULL
  , [BeamAttack] INTEGER NOT NULL
  , [PhysicalAttack] INTEGER NOT NULL
  , [BeamDefence] INTEGER NOT NULL
  , [PhysicalDefence] INTEGER NOT NULL
  , [CriticalDamage] INTEGER NOT NULL
  , [Accuracy] INTEGER NOT NULL
  , [Evasion] INTEGER NOT NULL
  , [Mobility] INTEGER NOT NULL
  , [UpgradedHp] INTEGER NOT NULL
  , [UpgradedBeamAttack] INTEGER NOT NULL
  , [UpgradedPhysicalAttack] INTEGER NOT NULL
  , [UpgradedBeamDefence] INTEGER NOT NULL
  , [UpgradedPhysicalDefence] INTEGER NOT NULL
  , [UpgradedCriticalDamage] INTEGER NOT NULL
  , [UpgradedAccuracy] INTEGER NOT NULL
  , [UpgradedEvasion] INTEGER NOT NULL
  , [UpgradedMobility] INTEGER NOT NULL
  , [HpUpgradedCount] INTEGER NOT NULL
  , [BeamAttackUpgradedCount] INTEGER NOT NULL
  , [PhysicalAttackUpgradedCount] INTEGER NOT NULL
  , [BeamDefenceUpgradedCount] INTEGER NOT NULL
  , [PhysicalDefenceUpgradedCount] INTEGER NOT NULL
  , [CriticalDamageUpgradedCount] INTEGER NOT NULL
  , [AccuracyUpgradedCount] INTEGER NOT NULL
  , [EvasionUpgradedCount] INTEGER NOT NULL
  , [MobilityUpgradedCount] INTEGER NOT NULL
  , [StartupUpgradedCount] INTEGER NOT NULL
  , [SuperMoveUpgradedCount] INTEGER NOT NULL
  , [Memo] TEXT NULL
  , [IsPinned] INTEGER NOT NULL
);
