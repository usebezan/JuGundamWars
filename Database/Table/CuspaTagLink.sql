DROP TABLE IF EXISTS [CuspaTagLink];
CREATE TABLE [CuspaTagLink] (
  [CuspaId] INTEGER NOT NULL
  , [TagId] INTEGER NOT NULL
  , PRIMARY KEY (CuspaId, TagId)
);
