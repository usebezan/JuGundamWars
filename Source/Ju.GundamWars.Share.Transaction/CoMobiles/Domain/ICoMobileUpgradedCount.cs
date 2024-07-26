namespace Ju.GundamWars.Share.CoMobiles.Domain;

public interface ICoMobileUpgradedCount
{

    #region Primitives

    int Hp { get; set; }
    int BeamAttack { get; set; }
    int PhysicalAttack { get; set; }
    int BeamDefence { get; set; }
    int PhysicalDefence { get; set; }
    int CriticalDamage { get; set; }
    int Accuracy { get; set; }
    int Evasion { get; set; }
    int Mobility { get; set; }
    int Startup { get; set; }
    int SuperMove { get; set; }

    #endregion

}
