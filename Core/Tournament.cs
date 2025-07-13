namespace Sigvald.Joakim.GoPairing;

public class Tournament {
    public Pairing CreatePairing(Player[] players)
    {
        var evenPlayers = players.Length % 2 == 0 
            ? players 
            : [.. players, Player.NoPlayer];
        return new()
        {
            Matches = [
                .. evenPlayers.Chunk(2).Select(_ => new Match(_.First(), _.Last()))
                ]
        };
    }
}