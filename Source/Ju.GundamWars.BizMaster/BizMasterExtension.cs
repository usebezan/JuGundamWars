namespace Ju.GundamWars.BizMaster;

public static class BizMasterExtension
{

    public static int Multiply(this int self, decimal value) =>
        (int)Math.Floor(self * value);

}
