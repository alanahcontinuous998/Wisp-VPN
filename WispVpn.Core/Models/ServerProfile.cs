namespace WispVpn.Core.Models;

public sealed record ServerProfile(
    string Id,
    string DisplayName,
    string CountryCode,
    string Host,
    int Port)
{
    public override string ToString() => $"{CountryCode} {DisplayName}";
}
