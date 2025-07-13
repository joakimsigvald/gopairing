namespace Sigvald.Joakim.GoPairing;

public record Match(Player Black, Player White)
{
    public bool IsMatched => Black != Player.NoPlayer && White != Player.NoPlayer;
}