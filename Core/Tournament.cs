namespace Sigvald.Joakim.GoPairing;

public class Tournament {
    public Pairing CreatePairing(Player[] players) =>
        new() { Matches = [.. players.Select(_ => new Match())] };
}