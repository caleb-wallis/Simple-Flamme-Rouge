using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Made by Caleb Wallis - 1637640
namespace Project
{
    /// <summary>
    /// Holds a single card, with a value
    /// </summary>
    public class Card
    {
        // Value of the card
        private int _value;
       
        /// <summary>
        /// Creates a card object with a value
        /// </summary>
        /// <param name="value">Value of the card</param>
        public Card(int value)
        {
            Value = value;
        }

        /// <summary>
        /// Gets and sets the value of the card
        /// </summary>
        public int Value
        {
            get
            {
                return _value;
            }
            set { _value = value; }
        }
    }
}

