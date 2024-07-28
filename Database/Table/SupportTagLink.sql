DROP TABLE IF EXISTS [SupportTagLink];
CREATE TABLE [SupportTagLink] (
  [SupportId] INTEGER NOT NULL
  , [TagId] INTEGER NOT NULL
  , PRIMARY KEY (SupportId, TagId)
);
