using XspecT;
using XspecT.Assert;
using Xunit;

namespace Sigvald.Joakim.GoPairing.Test.Tournament;

public class WhenCreatePairing : Spec<GoPairing.Tournament, Pairing>
{
    public WhenCreatePairing()
        => When(_ => _.CreatePairing());

    public class GivenNoParticipants : WhenCreatePairing 
    {
        [Fact]
        public void ThenGetEmptyPairing()
            => Result.Matches.Is().Empty();
    }
}
