using System;
using System.Collections.Generic;
using System.Linq;

// Made by Caleb Wallis - 1637640
namespace Project
{
    /// <summary>
    /// Holds a list of cards and deals them out
    /// </summary>
    public class Deck
    {
        // Tracks the next card to deal
        private int _nextCard;
        // Deck of cards
        private List<Card> _cards;
        // Recycle deck of cards
        private List<Card> _recycledCards;
        // Random to randomize the deck
        private Random _rand;
        // Type of deck
        private CyclistType _type;

        /// <summary>
        /// Gets the list of cards in the deck
        /// </summary>
        public List<Card> Cards
        {
            get { return _cards; }
            set {  _cards = value; }
        }

        /// <summary>
        /// Gets the list of recycled cards in the deck
        /// </summary>
        public List<Card> RecycledCards
        {
            get { return _recycledCards; }
            set { _recycledCards = value; }
        }

        /// <summary>
        /// Gets and sets the type of deck
        /// </summary>
        public CyclistType Type 
        { 
            get { return _type; }
            set { _type = value; }
        }

        /// <summary>
        /// Gets and sets the track of the next card
        /// </summary>
        public int NextCard
        {
            get { return _nextCard; }
            set { _nextCard = value; }
        }

        /// <summary>
        /// Gets and sets the randomizer
        /// </summary>
        public Random Rand
        {
            get { return _rand; }
            set { _rand = value; }
        }

        /// <summary>
        /// Initializes a new instance of the class Deck
        /// </summary>
        /// <param name="type">Type of Deck</param>
        public Deck(CyclistType type) 
        {
            // Sets the main variables
            Cards = new List<Card>();
            RecycledCards = new List<Card>();
            Type = type;
            Rand = Program.rand;
            NextCard = 0;
            // Generates and adds cards to the deck
            GenerateCards();
        }

        /// <summary>
        /// Generates and adds cards to the deck
        /// </summary>
        public void GenerateCards()
        {
            /*
            Sprinteur deck has cards with values 2, 3, 4, 5, and 9.
            Rouleur deck has cards with values 3, 4, 5, 6, and 7.
            */

            int[] numbers;  
            if(Type == CyclistType.Rouleur)
            {
                numbers = new int[] { 3, 4, 5, 6, 7 };

            }
            else
            {
                numbers = new int[] { 2, 3, 4, 5, 9 };
            }

            foreach (int num in numbers)
            {
                Card card = new Card(num);
                Cards.Add(card);
            }

            ShuffleDeck();
        }

        /// <summary>
        /// Adds a card to the recycle deck
        /// </summary>
        /// <param name="value">Value of the card</param>
        public void AddToRecycleDeck(int value)
        {
            RecycledCards.Add(new Card(value));
        }

        /// <summary>
        /// Deals a card to a hand
        /// </summary>
        /// <returns>Returns a card</returns>
        public Card DealCard()
        {
            Card card;
            // Try deal a card
            try
            {
                card = Cards[_nextCard];
                NextCard++;
            }
            // If can't then use recycle deck
            catch {
                NextCard = 0;
                Cards = RecycledCards.ToList();
                RecycledCards.Clear();
                card = Cards[NextCard];                

            }
            return card;
        }

        /// <summary>
        /// Shuffles the deck
        /// </summary>
        public void ShuffleDeck()
        {
            for (int i = Cards.Count - 1; i > 0; i--)
            {
                var k = Rand.Next(i + 1);
                var value = Cards[k];
                Cards[k] = Cards[i];
                Cards[i] = value;
            }
        }
    }
}