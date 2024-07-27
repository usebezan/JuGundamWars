using Ju.GundamWars.Share.Pilots.Domain;

namespace Ju.GundamWars.Share.Pilots;

public static class PilotShareExtension
{

    public static T Set<T>(this T self, IPilotStatus src)
        where T : IPilotStatus
    {
        self.Shooting = src.Shooting;
        self.Melee = src.Melee;
        self.Accuracy = src.Accuracy;
        self.Evasion = src.Evasion;
        self.Awakened = src.Awakened;
        self.Defense = src.Defense;
        return self;
    }

}
