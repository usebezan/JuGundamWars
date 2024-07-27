DROP TABLE IF EXISTS [PilotSlotAbility];
CREATE TABLE [PilotSlotAbility] ( 
  [PilotId] INTEGER NOT NULL
  , [Seq] INTEGER NOT NULL
  , [SlotRank] INTEGER NOT NULL
  , [PilotAbilityId] INTEGER NULL
  , PRIMARY KEY (PilotId, Seq)
);
