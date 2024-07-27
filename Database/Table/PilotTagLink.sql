DROP TABLE IF EXISTS [PilotTagLink];
CREATE TABLE [PilotTagLink] (
  [PilotId] INTEGER NOT NULL
  , [TagId] INTEGER NOT NULL
  , PRIMARY KEY (PilotId, TagId)
);
