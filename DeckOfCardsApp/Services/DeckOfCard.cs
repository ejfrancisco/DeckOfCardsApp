using DeckOfCardsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeckOfCardsApp.Services
{
    public class DeckOfCard: IDeckOfCard
    {
        private string[] Suits = new string[] { "Hearts", "Diamonds", "Clubs", "Spades" };
        private string[] Ranks = new string[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };


        private const int NumCardsPerDeck = 52;
        private static Random rand = new Random();

        public Card[] ShuffleDeck()
        {
            var idxs = Shuffle();
            var defaultDeck = GetDefaultDeck();

            List<Card> newDeck = new List<Card>();
            Array.ForEach(idxs, idx => newDeck.Add(defaultDeck[idx]));

            return newDeck.ToArray();
        }

        private int[] Shuffle()
        {
            int[] deck = new int[NumCardsPerDeck];

            for (byte i = 0; i < NumCardsPerDeck; i++)
                deck[i] = i;

            for (byte i = NumCardsPerDeck - 1; i > 0; i--)
            {
                int j = rand.Next(0, i + 1);

                int curVal = deck[i];
                deck[i] = deck[j];
                deck[j] = curVal;
            }

            return deck;
        }


        public Card[] GetDefaultDeck()
        {
            List<Card> deck = new List<Card>();
            for (int i = 0; i < Suits.Length; i++)
            {
                for (int j = 0; j < Ranks.Length; j++)
                {
                    Card card = new Card()
                    {
                        Suit = Suits[i],
                        Rank = Ranks[j]
                    };
                    deck.Add(card);
                }
            }

            return deck.ToArray();
        }
       
    }
}
