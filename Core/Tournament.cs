namespace Sigvald.Joakim.GoPairing;

public class Tournament
{
    public Pairing CreatePairing(Player[] players)
    {
        var orderedPlayers = OrderByRating(players).ToArray();
        var evenPlayers = orderedPlayers.Length % 2 == 0
            ? orderedPlayers
            : [.. orderedPlayers, Player.NoPlayer];
        return new()
        {
            Matches = [
                .. evenPlayers
                .Chunk(2)
                .Select(_ => new Match(_.First(), _.Last()))
                ]
        };
    }

    private static IEnumerable<Player> OrderByRating(IEnumerable<Player> players) 
    {
        var ratedPlayers = players.OrderByDescending(p => p.Rating).ToArray();
        for (var i = 0; i < ratedPlayers.Length / 2; i++)
        {
            yield return ratedPlayers[i];
            yield return ratedPlayers[^(i + 1)];
        }
        if (ratedPlayers.Length % 2 == 1)
            yield return ratedPlayers[ratedPlayers.Length / 2];
    }
}