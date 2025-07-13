namespace Sigvald.Joakim.GoPairing;

public record Player(int Id)
{
    public static readonly Player NoPlayer = new(int.MinValue);
}
