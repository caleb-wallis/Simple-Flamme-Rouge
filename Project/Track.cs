using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

// Made by Caleb Wallis - 1637640
namespace Project
{
    /// <summary>
    /// A track that is made out of tiles and is raced on by cyclists
    /// </summary>
    public class Track
    {
        // The tracks tiles
        private List<Tile> _tiles;
        // The number of tiles
        private int _numTiles;
        // The tile width
        private const int TileWidth = 100;
        // The tile height
        private const int TileHeight = 200;
        // Number of players
        private int _numPlayers;

        /// <summary>
        /// Gets and sets the list of tiles
        /// </summary>
        public List<Tile> Tiles
        {
            get { return _tiles; }
            set { _tiles = value; }
        }

        /// <summary>
        /// Gets and sets the number of tiles
        /// </summary>
        public int NumTiles
        {
            get { return _numTiles; }
            set { _numTiles = value; }
        }

        /// <summary>
        /// Gets and sets the number of players
        /// </summary>
        public int NumPlayers
        {
            get { return _numPlayers; }
            set { _numPlayers = value; }
        }

        /// <summary>
        /// Creats a track object
        /// </summary>
        /// <param name="numPlayers">Number of players</param>
        public Track(int numPlayers)
        {
            Tiles = new List<Tile>();
            NumPlayers = numPlayers;   
        }

        /// <summary>
        /// Draws the track
        /// </summary>
        /// <param name="g">Graphics used</param>
        public void Draw(Graphics g)
        {
            // Draw every tile in tiles
            foreach (Tile tile in Tiles)
            {
                tile.Draw(g);
            }
        }

        /// <summary>
        /// Creates a track made out of different tiles
        /// </summary>
        public void GenerateTrack()
        {
            NumTiles = 0;
            // If more than 5 players increase the number of start tiles to match
            if(NumPlayers > 5)
            {
                AddTiles(TileType.START, NumPlayers);
            }
            else
            {
                AddTiles(TileType.START, 5);
            }
            AddTiles(TileType.REGULAR, 3);
            AddTiles(TileType.ASCENDING, 3);
            AddTiles(TileType.DESCENDING, 3);
            AddTiles(TileType.END, 5);
        }

        /// <summary>
        /// Adds tiles to the list of tiles
        /// </summary>
        /// <param name="type">Type of tile</param>
        /// <param name="number">Number of tiles to add</param>
        public void AddTiles(TileType type, int number)
        {
            for (int i = 0; i < number; i++)
            {
                Tile tile = new Tile(NumTiles * TileWidth, 0, TileWidth, TileHeight, type);
                Tiles.Add(tile);
                NumTiles++;
            }
        }
    }
}
