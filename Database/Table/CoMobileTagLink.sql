DROP TABLE IF EXISTS [CoMobileTagLink];
CREATE TABLE [CoMobileTagLink] (
  [CoMobileId] INTEGER NOT NULL
  , [TagId] INTEGER NOT NULL
  , PRIMARY KEY (CoMobileId, TagId)
);
