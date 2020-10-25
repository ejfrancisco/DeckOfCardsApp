using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeckOfCardsApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using DeckOfCardsApp.Services;


namespace DeckOfCardsApp.Controllers
{
    [ApiController]
    public class DeckOfCardsController : ControllerBase
    {

        private readonly IDeckOfCard _deckOfCardService;
        public DeckOfCardsController(IDeckOfCard deckOfCardService)
        {
            _deckOfCardService = deckOfCardService;
        }

        [Route("deckofcards/ShuffleDeck")]
        public IActionResult ShuffleDeck(bool? reset)
        {
            IEnumerable<Card> newDeck;
            if (reset ??= false )
            {
                newDeck = _deckOfCardService.GetDefaultDeck();
            }
            else
            {
                newDeck = _deckOfCardService.ShuffleDeck();
            }

            return Ok(newDeck);
        }
    }
}
