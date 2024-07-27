namespace Project
{
    partial class Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonEnergyPhase = new System.Windows.Forms.Button();
            this.buttonMovementPhase = new System.Windows.Forms.Button();
            this.buttonEndPhase = new System.Windows.Forms.Button();
            this.radioButtonCard1 = new System.Windows.Forms.RadioButton();
            this.radioButtonCard2 = new System.Windows.Forms.RadioButton();
            this.radioButtonCard3 = new System.Windows.Forms.RadioButton();
            this.radioButtonCard4 = new System.Windows.Forms.RadioButton();
            this.groupBoxSelectCard = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBoxSelectCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonEnergyPhase
            // 
            this.buttonEnergyPhase.Location = new System.Drawing.Point(12, 326);
            this.buttonEnergyPhase.Name = "buttonEnergyPhase";
            this.buttonEnergyPhase.Size = new System.Drawing.Size(210, 73);
            this.buttonEnergyPhase.TabIndex = 1;
            this.buttonEnergyPhase.Text = "Energy Phase";
            this.buttonEnergyPhase.UseVisualStyleBackColor = true;
            this.buttonEnergyPhase.Click += new System.EventHandler(this.buttonEnergyPhase_Click);
            // 
            // buttonMovementPhase
            // 
            this.buttonMovementPhase.Location = new System.Drawing.Point(12, 405);
            this.buttonMovementPhase.Name = "buttonMovementPhase";
            this.buttonMovementPhase.Size = new System.Drawing.Size(210, 73);
            this.buttonMovementPhase.TabIndex = 2;
            this.buttonMovementPhase.Text = "Movement Phase";
            this.buttonMovementPhase.UseVisualStyleBackColor = true;
            this.buttonMovementPhase.Click += new System.EventHandler(this.buttonMovementPhase_Click);
            // 
            // buttonEndPhase
            // 
            this.buttonEndPhase.Location = new System.Drawing.Point(12, 484);
            this.buttonEndPhase.Name = "buttonEndPhase";
            this.buttonEndPhase.Size = new System.Drawing.Size(210, 73);
            this.buttonEndPhase.TabIndex = 3;
            this.buttonEndPhase.Text = "End Phase";
            this.buttonEndPhase.UseVisualStyleBackColor = true;
            this.buttonEndPhase.Click += new System.EventHandler(this.buttonEndPhase_Click);
            // 
            // radioButtonCard1
            // 
            this.radioButtonCard1.AutoSize = true;
            this.radioButtonCard1.Location = new System.Drawing.Point(6, 19);
            this.radioButtonCard1.Name = "radioButtonCard1";
            this.radioButtonCard1.Size = new System.Drawing.Size(65, 17);
            this.radioButtonCard1.TabIndex = 4;
            this.radioButtonCard1.TabStop = true;
            this.radioButtonCard1.Text = "Option 1";
            this.radioButtonCard1.UseVisualStyleBackColor = true;
            this.radioButtonCard1.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonCard2
            // 
            this.radioButtonCard2.AutoSize = true;
            this.radioButtonCard2.Location = new System.Drawing.Point(6, 60);
            this.radioButtonCard2.Name = "radioButtonCard2";
            this.radioButtonCard2.Size = new System.Drawing.Size(65, 17);
            this.radioButtonCard2.TabIndex = 5;
            this.radioButtonCard2.TabStop = true;
            this.radioButtonCard2.Text = "Option 2";
            this.radioButtonCard2.UseVisualStyleBackColor = true;
            this.radioButtonCard2.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonCard3
            // 
            this.radioButtonCard3.AutoSize = true;
            this.radioButtonCard3.Location = new System.Drawing.Point(6, 97);
            this.radioButtonCard3.Name = "radioButtonCard3";
            this.radioButtonCard3.Size = new System.Drawing.Size(65, 17);
            this.radioButtonCard3.TabIndex = 6;
            this.radioButtonCard3.TabStop = true;
            this.radioButtonCard3.Text = "Option 3";
            this.radioButtonCard3.UseVisualStyleBackColor = true;
            this.radioButtonCard3.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonCard4
            // 
            this.radioButtonCard4.AutoSize = true;
            this.radioButtonCard4.Location = new System.Drawing.Point(6, 139);
            this.radioButtonCard4.Name = "radioButtonCard4";
            this.radioButtonCard4.Size = new System.Drawing.Size(65, 17);
            this.radioButtonCard4.TabIndex = 7;
            this.radioButtonCard4.TabStop = true;
            this.radioButtonCard4.Text = "Option 4";
            this.radioButtonCard4.UseVisualStyleBackColor = true;
            this.radioButtonCard4.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // groupBoxSelectCard
            // 
            this.groupBoxSelectCard.Controls.Add(this.radioButtonCard1);
            this.groupBoxSelectCard.Controls.Add(this.radioButtonCard2);
            this.groupBoxSelectCard.Controls.Add(this.radioButtonCard4);
            this.groupBoxSelectCard.Controls.Add(this.radioButtonCard3);
            this.groupBoxSelectCard.Enabled = false;
            this.groupBoxSelectCard.Location = new System.Drawing.Point(607, 372);
            this.groupBoxSelectCard.Name = "groupBoxSelectCard";
            this.groupBoxSelectCard.Size = new System.Drawing.Size(128, 174);
            this.groupBoxSelectCard.TabIndex = 8;
            this.groupBoxSelectCard.TabStop = false;
            this.groupBoxSelectCard.Tag = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(588, 326);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 31);
            this.label1.TabIndex = 10;
            this.label1.Text = "Select Card";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(258, 326);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox1.Size = new System.Drawing.Size(324, 225);
            this.listBox1.TabIndex = 11;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1637, 573);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBoxSelectCard);
            this.Controls.Add(this.buttonEndPhase);
            this.Controls.Add(this.buttonMovementPhase);
            this.Controls.Add(this.buttonEnergyPhase);
            this.Name = "Game";
            this.Text = "Game";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.groupBoxSelectCard.ResumeLayout(false);
            this.groupBoxSelectCard.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonEnergyPhase;
        private System.Windows.Forms.Button buttonMovementPhase;
        private System.Windows.Forms.Button buttonEndPhase;
        private System.Windows.Forms.RadioButton radioButtonCard1;
        private System.Windows.Forms.RadioButton radioButtonCard2;
        private System.Windows.Forms.RadioButton radioButtonCard3;
        private System.Windows.Forms.RadioButton radioButtonCard4;
        private System.Windows.Forms.GroupBox groupBoxSelectCard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
    }
}

