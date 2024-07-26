namespace Ju.GundamWars.Share.Cuspas.Domain;

public interface ICuspaStatus
{

    #region Primitives

    int Hp { get; set; }
    int BeamAttack { get; set; }
    int PhysicalAttack { get; set; }
    int BeamDefence { get; set; }
    int PhysicalDefence { get; set; }
    int CriticalRate { get; set; }
    int CriticalDamage { get; set; }
    int Accuracy { get; set; }
    int Evasion { get; set; }
    int Mobility { get; set; }
    int EnRecovery { get; set; }

    #endregion

}
