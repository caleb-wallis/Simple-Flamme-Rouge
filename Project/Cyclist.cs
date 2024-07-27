using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Made by Caleb Wallis - 1637640
namespace Project
{
    /// <summary>
    /// A cyclist that is used to win the game
    /// </summary>
    public class Cyclist
    {
        // Deck for the cyclist
        private Deck _deck;

        // The tile that the cyclist is on
        private Tile tile;

        // The player that owns this cyclist
        private string _player;

        // Whether the cyclist is a roller or a sprinter
        private CyclistType _type;

        // Color used for brush
        private Color _color;

        /// <summary>
        /// Gets the deck
        /// </summary>
        public Deck Deck
        {
            get { return _deck; }
            set {  _deck = value; }
        }

        /// <summary>
        /// Sets and gets the type of the cyclist
        /// </summary>
        public CyclistType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        /// <summary>
        /// Gets and sets the tile the cyclist is currently on
        /// </summary>
        public Tile Tile
        {
            get { return tile; }
            set
            {
                tile = value;
            }
        }

        /// <summary>
        /// Gets and sets the player that the cyclist is for
        /// </summary>
        public string Player
        {
            get { return _player; }
            set { _player = value; }
        }

        /// <summary>
        /// Gets the color of the cyclist to help identify it
        /// </summary>
        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

        /// <summary>
        /// Creates a new cyclist object
        /// </summary>
        /// <param name="tile">The tile that the cyclist is on</param>
        /// <param name="player">The player that the cylist is for</param>
        /// <param name="type">The type of cyclist it is</param>
        public Cyclist(Tile tile, string player, CyclistType type) 
        {
            // Sets the above variables
            Tile = tile;
            Tile.AddCyclist(this);
            Player = player;
            Type = type;
            Deck = new Deck(Type);
            SetColor();
        }

        /// <summary>
        /// Moves the cyclist to a new tile
        /// </summary>
        /// <param name="moveToTile"></param>
        public void Move(Tile moveToTile)
        {
            Tile.RemoveCyclist(this);
            Tile = moveToTile;
            Tile.AddCyclist(this);
        }

        /// <summary>
        /// Sets the color used for the cyclist
        /// </summary>
        public void SetColor()
        {
            // Depending on the player change the color
            switch (Player)
            {
                case "p1":
                    Color = Color.Gold;
                    break;

                case "p2":
                    Color = Color.Silver;
                    break;

                case "p3":
                    Color = Color.Green;
                    break;

                default:
                    Color = Color.Magenta;
                    break;

            }
        }

        /// <summary>
        /// Draws the cyclist
        /// </summary>
        /// <param name="g">Graphics used</param>
        /// <param name="x">Start X Position</param>
        /// <param name="y">Start Y Position</param>
        /// <param name="width">The width of the cyclist</param>
        /// <param name="height">The height of the cyclist</param>
        public void Draw(Graphics g, int x, int y, int width, int height)
        {
            Font font1 = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point);

            // Create a StringFormat object so that we can have a number centered on the input source.
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            // Create a solid brush
            SolidBrush brush = new SolidBrush(Color);

            // Create and fill a rectangle which is the cyclist
            Rectangle cyclist = new Rectangle(x, y, width, height);
            g.FillRectangle(Brushes.Black, cyclist);

            // Depending on the type of cyclist display different letter
            if (Type == CyclistType.Rouleur)
            {
                g.DrawString("R", font1, brush, cyclist, stringFormat);
            }
            else
            {
                g.DrawString("S", font1, brush, cyclist, stringFormat);
            }
        }

        /// <summary>
        /// String describing the cyclist
        /// </summary>
        /// <returns>String with the Player, Type and Color of the cyclist</returns>
        public override string ToString()
        {
            return Player + " " + Type + " (" + Color + ")";
        }
    }
}
