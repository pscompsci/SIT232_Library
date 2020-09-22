using System;
using System.Windows.Forms;

namespace SimpleReactionMachine
{
    //Implementation of GUI via Windows Form
    public partial class ReactionMachineForm : Form, IGui
    {
        private IController Controller;
        delegate void DisplayFunction(string str);

        public ReactionMachineForm()
        {
            InitializeComponent();
        }

        public void Connect(IController controller)
        {
            Controller = controller;
        }

        public void Init()
        {
            SetDisplay("Start your game!");
        }

        public void SetDisplay(string s)
        {
            if (this.InvokeRequired)
            {
                DisplayFunction DisplayLabelText = delegate (string str) { Label.Text = str; };
                BeginInvoke(DisplayLabelText, s);
            }
            else
            {
                Label.Text = s;
            }
        }

        private void InsertCoinButton_Click(object sender, EventArgs e)
        {
            Controller.CoinInserted();
        }

        private void GoStopButton_Click(object sender, EventArgs e)
        {
            Controller.GoStopPressed();
        }
    }
}
