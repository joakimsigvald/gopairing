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
        [Fact] public void ThenGetOneUnmatched() => Result.Matches.Has().Single().That.IsMatched.Is(false);
    }

    public class GivenTwoParticipants : WhenCreatePairing
    {
        public GivenTwoParticipants() => Given(Two<Player>());

        [Fact]
        public void ThenGetOneMatch()
        {
            var match = Result.Matches.Has().Single().That;
            match.IsMatched.Is(true);
            Two<Player>().Is().Like([match.Black, match.White]);
        }
    }

    //public class GivenThreeParticipants : WhenCreatePairing
    //{
    //    public GivenThreeParticipants() => Given(Three<Player>());

    //    [Fact]
    //    public void ThenGetOneMatch()
    //    {
    //        var match = Result.Matches.Has().Single().That;
    //        match.IsMatched.Is(true);
    //        Two<Player>().Is().Like([match.Black, match.White]);
    //    }
    //}
}