namespace WispVpn.Core.Security;

/// <summary>
/// Генерация пары ключей X25519 для WireGuard.
/// </summary>
/// <remarks>
/// НЕ РЕАЛИЗОВАНО. Это заглушка — криптографию нельзя писать "на глаз".
/// План: использовать проверенную библиотеку (например, NSec.Cryptography или
/// bindings к libsodium) для X25519 (RFC 7748), а не собственную реализацию.
/// См. docs/ROADMAP.md, v0.2.
/// </remarks>
public static class KeyPairGenerator
{
    public static (string PrivateKeyBase64, string PublicKeyBase64) Generate()
    {
        throw new NotImplementedException(
            "Генерация ключей X25519 ещё не реализована. См. docs/ROADMAP.md и не используйте " +
            "самописную криптографию — только проверенные библиотеки.");
    }
}
