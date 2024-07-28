DROP TABLE IF EXISTS [SupportSlotBadge];
CREATE TABLE [SupportSlotBadge] (
  [SupportId] INTEGER NOT NULL
  , [Seq] INTEGER NOT NULL
  , [SupportSlotId] INTEGER NOT NULL
  , [SupportBadgeId] INTEGER NULL
  , PRIMARY KEY (SupportId, Seq)
);
