using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

// Made by Caleb Wallis - 1637640
namespace Project
{
    /// <summary>
    /// Types of Cyclist in the game
    /// </summary>
    public enum CyclistType
    {
        Sprinteur, Rouleur
    };

    /// <summary>
    /// Types of Tile on the track
    /// </summary>
    public enum TileType
    {
        START, END, REGULAR, ASCENDING, DESCENDING
    };


    /// <summary>
    /// Main form for the game
    /// </summary>
    public partial class Game : Form
    {
        // Number of players
        int numPlayers = 3;
        // Track for the cyclists
        Track track;

        // Stores the movement the cyclist is going to make
        Dictionary<Cyclist, int> movementValues = new Dictionary<Cyclist, int>();

        // The original lineup of the cyclists
        List<Cyclist> startingLineUp = new List<Cyclist>();

        // The current lineup of the cyclists
        List<Cyclist> cyclists = new List<Cyclist>();

        // Number of cards selected (used for energy phase)
        int numCardSelected;


        /// <summary>
        /// Start the game
        /// </summary>
        public Game()
        {
            InitializeComponent();
            // Create track
            track = new Track(numPlayers);
            // Generate the track
            track.GenerateTrack();
            // Add Cyclists
            AddCyclists();

            // Enable the correct buttons and disable the others
            buttonEnergyPhase.Enabled = true;
            buttonMovementPhase.Enabled = false;
            buttonEndPhase.Enabled = false;
        }

        /// <summary>
        /// Sorts a list in order of their tile indexes
        /// </summary>
        /// <param name="c">List of cyclists</param>
        /// <param name="reverse">Whether you want to reverse the list</param>
        /// <returns>A sorted list of cyclists</returns>
        public List<Cyclist> sortByTileIndex(List<Cyclist> c, bool reverse)
        {
            // Wasn't sure why it didn't like being outside a method. Something to do with static? Still not sure what static really does.
            Comparison<Cyclist> sortByTileIndex = (Cyclist c1, Cyclist c2) =>
            {
                int c1Index = track.Tiles.IndexOf(c1.Tile);
                int c2Index = track.Tiles.IndexOf(c2.Tile);

                return c1Index - c2Index;
            };

            // Sort the list
            c.Sort(sortByTileIndex);
            if (reverse)
            {
                // Reverse the list if wanted
                c.Reverse();
            }
            return c;
        }

        /// <summary>
        /// Moves the cyclist and places them in an available tile
        /// </summary>
        /// <param name="c">Cyclist to move</param>
        /// <param name="t">Tile to move to</param>
        public void OrderCyclists(Cyclist c, Tile t)
        {
            // Check if there are 2 cyclists there
            // If not move to that tile otherwise check 1 behind and continue / repeat
            if (t.Cyclists.Count >= 2 && !t.Cyclists.Contains(c))
            {
                // Should continue to find a tile for the cyclist
                int moveTo = track.Tiles.IndexOf(t) - 1;
                t = track.Tiles[moveTo];
                OrderCyclists(c, t);
            }
            else if(!t.Cyclists.Contains(c))
            {
                // The cyclist can move to the tile
                listBox1.Items.Add(c + " moved to tile " + track.Tiles.IndexOf(t));
                c.Move(t);
            }
        }

        /// <summary>
        /// Creates a track with different tiles
        /// </summary>
        public void AddCyclists()
        {
            // For every player create a rouleur and a sprinteur
            for (int i = 0; i<numPlayers; i++)
            {
                Cyclist rouleur = new Cyclist(track.Tiles[i], "p" + (i+1), CyclistType.Rouleur);
                Cyclist sprinteur = new Cyclist(track.Tiles[i], "p" + (i+1), CyclistType.Sprinteur);

                cyclists.Add(rouleur);
                cyclists.Add(sprinteur);
            }

            startingLineUp = cyclists.ToList();

            this.Invalidate(); // Draw track + Cyclists
        }

        /// <summary>
        /// Allows you to select the cards for the cyclists
        /// </summary>
        public void EnergyPhase()
        {
            // If we are starting the energy phase
            if (numCardSelected == 0)
            {
                // Clear previous movements
                movementValues.Clear();
                // Disable the button for energy phase
                buttonEnergyPhase.Enabled = false;
                // Allow card choices
                groupBoxSelectCard.Enabled=true;
            }

            try
            {
                // Get the cyclist and get card options from the deck
                Cyclist c = startingLineUp[numCardSelected];

                listBox1.Items.Add("Select Card for: " + c);

                // Display card options
                radioButtonCard1.Text = c.Deck.DealCard().Value.ToString();
                radioButtonCard2.Text = c.Deck.DealCard().Value.ToString();
                radioButtonCard3.Text = c.Deck.DealCard().Value.ToString();
                radioButtonCard4.Text = c.Deck.DealCard().Value.ToString();
            }
            catch
            {
                listBox1.Items.Add(new string ('-', 100));

                // No more cyclists so reset number of cards selected
                numCardSelected = 0;
                // Disable the ability to choose cards
                groupBoxSelectCard.Enabled = false;
                // Allow movement phase now
                buttonMovementPhase.Enabled = true;
            }
        }
    
        /// <summary>
        /// Moves the cyclists based on cards picked
        /// </summary>
        public void MovementPhase()
        {
            // Starting from the front player move the cyclists using the value given in dictionary holding cyclist and value
            sortByTileIndex(cyclists, true);

            // Move each cyclist
            foreach (Cyclist c in cyclists)
            {
                int value = movementValues[c];
                int tileIndex = track.Tiles.IndexOf(c.Tile);
                int moveTo = tileIndex + value;

                Tile tileMoveTo;
                try
                {
                    // If descending minimum 5
                    if (track.Tiles[tileIndex].Type == TileType.DESCENDING)
                    {
                        if (value < 5)
                        {
                            listBox1.Items.Add(c + " Descending Used Unless Overriden");
                            value = 5;
                            moveTo = tileIndex + value;
                        }
                    }

                    // If ascending max 5
                    for(int i = tileIndex; i<moveTo; i++)
                    {
                        if (track.Tiles[i].Type == TileType.ASCENDING)
                        {
                            if (value > 5)
                            {
                                listBox1.Items.Add(c + " Ascending Used");
                                value = 5;
                                moveTo = tileIndex + value;
                            }
                        }
                    }

                    // Move and order the cyclists properly
                    tileMoveTo = track.Tiles[moveTo];
                    OrderCyclists(c, tileMoveTo);
                }
                catch{ } // At the end (as far as you can go)
            }

            listBox1.Items.Add(new string('-', 100));

            // Enable End Phase and Disable Movement Phase
            buttonMovementPhase.Enabled = false;
            buttonEndPhase.Enabled = true;

            this.Invalidate();
        }

        /// <summary>
        /// Checks if a player has won the game and implements slipstreaming and exhaustion cards
        /// </summary>
        public void EndPhase()
        {
            // Check if a player has won
            if (CheckWin())
            {
                EndGame();
            }
            else
            {
                // Makes sure that the cyclists are slipstreaming from the back
                sortByTileIndex(cyclists, false);

                // Gets the tiles with at least 1 cyclist on it
                HashSet<int> tileIndexes = new HashSet<int>();
                foreach (Cyclist c in cyclists)
                {
                    int tIndex = track.Tiles.IndexOf(c.Tile);
                    tileIndexes.Add(tIndex);
                }


                // Slipstreaming
                // 1. Check that their is a space ahead and that 2 spaces ahead there is someone
                // 2. Once confirmed look behind 1 if there is someone then change their tile and repeat until no one is there

                // Exhuastion
                // 1. If there is an empty square infront of a cyclist they are given an exhaustion card


                foreach (int tIndex in tileIndexes)
                {
                    try
                    {
                        Tile tile = track.Tiles[tIndex];

                        // Exhuastion + Slipstream
                        // If space ahead and is blocked 2 spaces ahead
                        // Ascending can't recieve slipstreaming or give
                        if (track.Tiles[tIndex + 1].Cyclists.Count == 0 && track.Tiles[tIndex + 2].Cyclists.Count != 0 && track.Tiles[tIndex + 1].Type != TileType.ASCENDING && tile.Type != TileType.ASCENDING)
                        {
                            // Apply Slipstreaming
                            SlipStream(tIndex);
                        }

                        // Exhaustion
                        else if (track.Tiles[tIndex + 1].Cyclists.Count == 0)
                        {
                            for (int i = 0; i < tile.Cyclists.Count; i++)
                            {
                                Cyclist c = tile.Cyclists[i];
                                listBox1.Items.Add(c + " is given an exhuastion card");
                                c.Deck.AddToRecycleDeck(2);
                            }
                        }
                    }
                    catch { }
                }

                listBox1.Items.Add(new string('-', 100));

                // Start the energy phase again
                buttonEnergyPhase.Enabled = true;
                // Disable the end phase button
                buttonEndPhase.Enabled = false;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Check if a player has won
        /// </summary>
        /// <returns></returns>
        public bool CheckWin()
        {
            // Check for a winner starting from the back of the track
            for(int i = track.Tiles.Count-1; i > track.Tiles.Count -6; i--)
            {
                Tile t = track.Tiles[i];
                // If there are cyclists
                if(t.Cyclists.Count > 0)
                {
                    // If the cyclists are from 1 player
                    if(t.Cyclists.Count == 1 || t.Cyclists[0].Player == t.Cyclists[1].Player)
                    {
                        MessageBox.Show(t.Cyclists[0].Player + " Won!");
                        listBox1.Items.Add(t.Cyclists[0].Player + " Won!");
                    }

                    // Otherwise a tie
                    else
                    {
                        MessageBox.Show(t.Cyclists[0].Player + " Tied With " + t.Cyclists[1].Player);
                        listBox1.Items.Add(t.Cyclists[0].Player + " Tied With " + t.Cyclists[1].Player);
                    }
                    return true;
                }
            }
            // No one has won yet
            return false;
        }

        /// <summary>
        /// Moves the cyclist up 1 tile and the cyclists directly behind it up 1 tile
        /// </summary>
        /// <param name="tIndex"></param>
        public void SlipStream(int tIndex)
        {
            Tile tile = track.Tiles[tIndex];
            Tile moveToTile = track.Tiles[tIndex + 1];
            Tile behindTile;

            // Slipstream
            foreach(Cyclist c in tile.Cyclists.ToList())
            {
                listBox1.Items.Add(c + " slipstreamed from tile " + tIndex + " to " + (tIndex + 1));
                c.Move(moveToTile);
            }

            // Try check the tile behind to see if they need to also slipstream
            try
            {
                behindTile = track.Tiles[tIndex - 1];

                // Check behind the original tile
                if (behindTile.Cyclists.Count() > 0)
                {
                    SlipStream(tIndex - 1);
                }
            }
            catch { }
        }

        /// <summary>
        /// Ends the game by disabling all buttons
        /// </summary>
        public void EndGame()
        {
            groupBoxSelectCard.Enabled = false;
            buttonEnergyPhase.Enabled = false;
            buttonMovementPhase.Enabled = false;
            buttonEndPhase.Enabled = false;
        }

        /// <summary>
        /// Event that triggers when a radio button is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            // The radio button
            RadioButton rb = sender as RadioButton;

            // Check it is a radio button
            if (rb == null)
            {
                MessageBox.Show("Sender is not a RadioButton");
                return;
            }

            // Ensure that the RadioButton.Checked property changed to true.
            if (rb.Checked)
            {
                // Get the text of the radio button which acts as a card value
                int value = int.Parse(rb.Text);
                // Add value to the movement values with the cyclist who its for
                movementValues.Add(startingLineUp[numCardSelected], value);

                
                // Add all the left over card values into the recycle deck of the cyclist
                foreach (Control control in groupBoxSelectCard.Controls)
                {
                    if(control is RadioButton && control != rb)
                    {
                        RadioButton r = (RadioButton)control;
                        startingLineUp[numCardSelected].Deck.AddToRecycleDeck(int.Parse(r.Text));
                    }
                }
                
                // Increase the number of cards selected
                numCardSelected++;
                // Uncheck the radio button
                rb.Checked = false;
                // Start the energy phase
                EnergyPhase();
            }
        }

        /// <summary>
        /// Paints the track and cyclists onto the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            track.Draw(e.Graphics);
        }

        /// <summary>
        /// When clicked start the end phase
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEndPhase_Click(object sender, EventArgs e)
        {
            EndPhase();
        }

        /// <summary>
        /// When clicked start the movement phase
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonMovementPhase_Click(object sender, EventArgs e)
        {
            MovementPhase();
        }

        /// <summary>
        /// When clicked start the energy phase
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEnergyPhase_Click(object sender, EventArgs e)
        {
            EnergyPhase();
        }
    }
}