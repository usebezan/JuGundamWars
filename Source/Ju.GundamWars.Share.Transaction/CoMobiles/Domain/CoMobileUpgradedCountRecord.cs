namespace Ju.GundamWars.Share.CoMobiles.Domain;

public record CoMobileUpgradedCountRecord : ICoMobileUpgradedCount
{

    #region Primitives

    public int Hp { get; set; }
    public int BeamAttack { get; set; }
    public int PhysicalAttack { get; set; }
    public int BeamDefence { get; set; }
    public int PhysicalDefence { get; set; }
    public int CriticalDamage { get; set; }
    public int Accuracy { get; set; }
    public int Evasion { get; set; }
    public int Mobility { get; set; }
    public int Startup { get; set; }
    public int SuperMove { get; set; }

    #endregion

}
