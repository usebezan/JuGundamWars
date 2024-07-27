DROP TABLE IF EXISTS [CoMobileSkillLink];
CREATE TABLE [CoMobileSkillLink] (
  [CoMobileId] INTEGER NOT NULL
  , [SkillId] INTEGER NOT NULL
  , PRIMARY KEY (CoMobileId, SkillId)
);
