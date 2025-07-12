using XspecT;
using XspecT.Assert;
using Xunit;

namespace Sigvald.Joakim.GoPairing.Test.Tournament;

public class WhenCreatePairing : Spec<GoPairing.Tournament, Pairing>
{
    public WhenCreatePairing() => When(_ => _.CreatePairing(AnyNumberOf<Player>()));

    public class GivenNoParticipants : WhenCreatePairing
    {
        public GivenNoParticipants() => Given(Zero<Player>());
        [Fact] public void ThenGetEmptyPairing() => Result.Matches.Is().Empty();
    }

    public class GivenOneParticipant : WhenCreatePairing
    {
        public GivenOneParticipant() => Given(One<Player>());
        [Fact] public void ThenGetOneDefault() => Result.Matches.Has().Single().That.IsUnmatched.Is(true);
    }
}