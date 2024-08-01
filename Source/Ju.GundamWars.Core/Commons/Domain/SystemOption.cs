namespace Ju.GundamWars.Commons.Domain;

public class SystemOption
{
    public string GitHubUri { get; set; } = string.Empty;
    public string MasterDbFileRelativePath { get; set; } = string.Empty;
    public string TxnBaseDbFileRelativePath { get; set; } = string.Empty;
    public string TxnDbFileRelativePath { get; set; } = string.Empty;

    public string ExecutingLocation { get; set; } = string.Empty;

    public string MasterDbFilePath => $"{ExecutingLocation}{MasterDbFileRelativePath}";
    public string TxnBaseDbFilePath => $"{ExecutingLocation}{TxnBaseDbFileRelativePath}";
    public string TxnDbFilePath => $"{ExecutingLocation}{TxnDbFileRelativePath}";
}
