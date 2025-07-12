namespace Sigvald.Joakim.GoPairing;

public record Pairing 
{
    public Match[] Matches { get; set; } = [];
}

public record Match;
