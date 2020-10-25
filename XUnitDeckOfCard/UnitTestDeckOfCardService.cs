using System;
using Xunit;
using DeckOfCardsApp.Services;


namespace XUnitDeckOfCard
{
    public class UnitTestDeckOfCardService
    {
        [Fact]
        public void TestShuffle()
        {
            DeckOfCard service = new DeckOfCard();
            var deck = service.ShuffleDeck();
            Assert.Equal(52, deck.Length);
        }
    }
}
