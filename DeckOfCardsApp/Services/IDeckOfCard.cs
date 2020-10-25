using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeckOfCardsApp.Models;


namespace DeckOfCardsApp.Services
{
    public interface IDeckOfCard
    {
        Card[] GetDefaultDeck();
        Card[] ShuffleDeck();
    }
}
