using System;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace SimpleReactionMachine
{
    static class SimpleReactionMachine
    {
        static private IController Contoller;
        static private IGui Gui;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Create a time for Tick event
            Timer timer = new Timer(10);
            // Hook up the Elapsed event for the timer. 
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Connect GUI with the Controller and vice versa
            ReactionMachineForm MainForm = new ReactionMachineForm();
            Contoller = new SimpleReactionController();
            Gui = MainForm;
            Gui.Connect(Contoller);
            Contoller.Connect(Gui, new RandomGenerator());

            //Reset the GUI
            Gui.Init();
            // Start the timer
            timer.Enabled = true;
            Application.Run(MainForm);
        }

        // This event occurs every 10 msec
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Contoller.Tick();
        }

        // Internal implementation of Random Generator
        private class RandomGenerator : IRandom
        {
            Random rnd = new Random(100);

            public int GetRandom(int from, int to)
            {
                return rnd.Next(from) + to;
            }
        }
    }
}
