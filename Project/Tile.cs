using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

// Made by Caleb Wallis - 1637640
namespace Project
{
    /// <summary>
    /// Tile that makes up a track
    /// </summary>
    public class Tile
    {
        // Type of tile
        private TileType _type;
        // List of cyclists on the tile
        private List<Cyclist> _cyclists = new List<Cyclist>();
        // X position of the tile
        private int _x;
        // Y position of the tile
        private int _y;
        // Width of the tile
        private int _width;
        // Height of the tile
        private int _height;
        // Color used for the tile
        private Color _color;

        /// <summary>
        /// Gets and sets the tile's type
        /// </summary>
        public TileType Type 
        { 
            get { return _type; } 
            set { _type = value; } 
        }

        /// <summary>
        /// Gets the list of cyclists
        /// </summary>
        public List<Cyclist> Cyclists
        {
            get { return _cyclists; }
        }

        /// <summary>
        /// Gets and sets the X position of the tile
        /// </summary>
        public int X
        {
            get { return _x; } 
            set { _x = value; }
        }

        /// <summary>
        /// Gets and sets the Y position of the tile
        /// </summary>
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        /// <summary>
        /// Gets and sets the Width of the tile
        /// </summary>
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        /// <summary>
        /// Gets and sets the Height of the tile
        /// </summary>
        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        /// <summary>
        /// Gets the color of the cyclist to help identify it
        /// </summary>
        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }


        /// </summary>
        /// <param name="x">X Position of the tile</param>
        /// <param name="y">Y Position of the tile</param>
        /// <param name="width">Width of the tile</param>
        /// <param name="height">Height of the tile</param>
        /// <param name="type">Type of tile</param>
        public Tile(int x, int y, int width, int height, TileType type) 
        {
            // Sets the above variables
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Type = type;
            SetColor(); // Set the color for the tile
        }

        /// <summary>
        /// Adds a cyclist to the list of cyclists on the tile
        /// </summary>
        /// <param name="c">Cyclist to add</param>
        public void AddCyclist(Cyclist c)
        {
            try
            {
                Cyclists.Add(c);
            }
            catch { }
        }

        /// <summary>
        /// Removes a cyclist to the list of cyclists on the tile
        /// </summary>
        /// <param name="c">Cyclist to remove</param>
        public void RemoveCyclist(Cyclist c)
        {
            try
            {
                Cyclists.Remove(c);
            }
            catch { }
        }

        /// <summary>
        /// Sets the color used for the tile
        /// </summary>
        public void SetColor()
        {
            // Depending on the player change the color
            switch (Type)
            {
                case TileType.START:
                    Color = Color.Green;
                    break;

                case TileType.END:
                    Color = Color.Yellow;
                    break;

                case TileType.REGULAR:
                    Color = Color.Gray;
                    break;

                case TileType.ASCENDING:
                    Color = Color.Red;
                    break;

                case TileType.DESCENDING:
                    Color = Color.Blue;
                    break;
            }
        }

        /// <summary>
        /// Draws the tile
        /// </summary>
        /// <param name="g">Graphics used</param>
        public void Draw(Graphics g)
        {
            Font font1 = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point);

            // Create a StringFormat object so that we can have a number centered on the input source.
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            // Get brush and pen for the tile
            SolidBrush brush = new SolidBrush(Color);
            Pen pen = new Pen(Color.Black);

            // Draw the Tile
            Rectangle rect1 = new Rectangle(X, Y, Width, Height);
            g.FillRectangle(brush, rect1);
            g.DrawRectangle(pen, rect1);
            // Draw Tile Outline
            Point point1 = new Point(X, Height/2);
            Point point2 = new Point(X + Width, Height / 2);
            g.DrawLine(pen, point1, point2);


            // Draw The Cyclists On Tile Below

            /*
             * ---------- Top
             * 
             * Start - 1/8
             * 
             * ----------- 1/4
             * 
             * End - 1/2 lower than 1/8
             * 
             * ---------- 1/2
             * 
             * Start  - 5/8
             * 
             * ----------- 3/4
             * 
             * End - 1/2 lower than 5/8
             * 
             * ---------- Bottom
             * */

            // Standard X Positioning and Width
            double x = 1.0 / 4.0 * Width + X;     // Start at 1/4
            double width = 1.0 / 2.0 * Width;      // End at 3/4

            // Cyclist on the right/bottom
            double y = 5.0 / 8.0 * Height;         // Start between 1/2 and 3/4  - 5/8
            double height = 1.0 / 4.0 * Height;    // End between 3/4 and bottom

            // If 1 or more cyclists
            if (Cyclists.Count >= 1)
            {
                Cyclists[0].Draw(g, (int)x, (int)y, (int)width, (int)height);
            }

            // If 2 Cyclists draw Cyclist on the left
            if(Cyclists.Count == 2)
            {
                y = 1.0 / 8.0 * Height;         // Start between Top and 1/4
                height = 1.0 / 4.0 * Height;    // End between 1/4 and 1/2

                Cyclists[1].Draw(g, (int)x, (int)y, (int)width, (int)height);
            }
        }
    }
}