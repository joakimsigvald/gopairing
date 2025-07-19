using XspecT;
using XspecT.Assert;
using Xunit;

namespace Sigvald.Joakim.GoPairing.Test.Tournament;

public class WhenCreatePairing : Spec<GoPairing.Tournament, Pairing>
{
    public WhenCreatePairing() => When(_ => _.CreatePairing(AnyNumberOf<Player>()));

    [Fact]
    public void ThenPlayersAreNotDoubleMatched()
        => Result.Matches.SelectMany(m => m.Players).Is().Distinct();

    public class GivenNoParticipants : WhenCreatePairing
    {
        public GivenNoParticipants() => Given(Zero<Player>());
        [Fact] public void ThenGetEmptyPairing() => Result.Matches.Is().Empty();
    }

    public class GivenOneParticipant : WhenCreatePairing
    {
        public GivenOneParticipant() => Given(One<Player>());
        [Fact] public void ThenGetOneUnmatched() => Result.Matches.Has().OneItem().That.IsMatched.Is(false);
    }

    public class GivenTwoParticipants : WhenCreatePairing
    {
        public GivenTwoParticipants() => Given(Two<Player>());

        [Fact]
        public void ThenGetOneMatch()
        {
            var match = Result.Matches.Has().OneItem().That;
            match.IsMatched.Is(true);
            Two<Player>().Is().Like(match.Players)
                .And(match).Players.Is().Like([match.Black, match.White]);
        }
    }

    public class GivenThreeParticipants : WhenCreatePairing
    {
        public GivenThreeParticipants() => Given(Three<Player>());

        [Fact]
        public void ThenGetOneMatchedAndOneUnmatched()
        {
            var (first, second) = Result.Matches.Has().TwoItems().That;
            first.IsMatched.Is(true);
            second.IsMatched.Is(false);
        }
    }

    public class GivenFourParticipants : WhenCreatePairing
    {
        public GivenFourParticipants() => Given(Four<Player>());

        [Fact]
        public void ThenGetTwoMatched()
        {
            var matches = Result.Matches;
            var (first, second) = Result.Matches.Has().TwoItems().That;
            first.IsMatched.Is(true);
            second.IsMatched.Is(true);
        }

        public class WithIncreasingRating : GivenFourParticipants
        {
            public WithIncreasingRating()
                => Given(Four<Player>((p, i) => p with { Rating = i + 1 }));

            [Fact]
            public void Then_HighestRankedMeetsLowestRanked_InFirstMatch() 
                => FirstMatch.Players.Is().Like([TheFirst<Player>(), TheFourth<Player>()]);
        }

        protected Match FirstMatch => Result.Matches[0];
        protected Match SecondMatch => Result.Matches[1];
    }
}