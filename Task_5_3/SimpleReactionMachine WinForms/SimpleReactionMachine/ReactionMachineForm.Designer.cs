namespace SimpleReactionMachine
{
    partial class ReactionMachineForm
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
            this.InsertCoinButton = new System.Windows.Forms.Button();
            this.GoStopButton = new System.Windows.Forms.Button();
            this.Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // InsertCoinButton
            // 
            this.InsertCoinButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InsertCoinButton.Location = new System.Drawing.Point(1, 93);
            this.InsertCoinButton.Name = "InsertCoinButton";
            this.InsertCoinButton.Size = new System.Drawing.Size(180, 32);
            this.InsertCoinButton.TabIndex = 0;
            this.InsertCoinButton.Text = "Insert Coin";
            this.InsertCoinButton.UseVisualStyleBackColor = true;
            this.InsertCoinButton.Click += new System.EventHandler(this.InsertCoinButton_Click);
            // 
            // GoStopButton
            // 
            this.GoStopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GoStopButton.Location = new System.Drawing.Point(186, 93);
            this.GoStopButton.Name = "GoStopButton";
            this.GoStopButton.Size = new System.Drawing.Size(180, 32);
            this.GoStopButton.TabIndex = 0;
            this.GoStopButton.Text = "Go / Stop";
            this.GoStopButton.UseVisualStyleBackColor = true;
            this.GoStopButton.Click += new System.EventHandler(this.GoStopButton_Click);
            // 
            // Label
            // 
            this.Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label.Location = new System.Drawing.Point(2, 2);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(364, 88);
            this.Label.TabIndex = 1;
            this.Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ReactionMachineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 125);
            this.Controls.Add(this.Label);
            this.Controls.Add(this.GoStopButton);
            this.Controls.Add(this.InsertCoinButton);
            this.Name = "ReactionMachineForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Simple Reaction Machine";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button InsertCoinButton;
        private System.Windows.Forms.Button GoStopButton;
        private System.Windows.Forms.Label Label;
    }
}

