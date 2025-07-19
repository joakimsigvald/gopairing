namespace Sigvald.Joakim.GoPairing;

public record Match(Player Black, Player White)
{
    public static readonly Match EmptyMatch = new(Player.NoPlayer, Player.NoPlayer);

    public IEnumerable<Player> Players 
    { 
        get 
        {
            yield return Black;
            yield return White;
        }
    } 

    public bool IsMatched => Black != Player.NoPlayer && White != Player.NoPlayer;
}