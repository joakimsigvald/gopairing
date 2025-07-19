namespace Sigvald.Joakim.GoPairing;

public record Player(int Id, int Rating)
{
    public static readonly Player NoPlayer = new(int.MinValue, 0);
}