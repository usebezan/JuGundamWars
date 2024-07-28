DROP TABLE IF EXISTS [SupportLimitedSerialLink];
CREATE TABLE [SupportLimitedSerialLink] (
  [SupportId] INTEGER NOT NULL
  , [SerialId] INTEGER NOT NULL
  , PRIMARY KEY (SupportId, SerialId)
);
