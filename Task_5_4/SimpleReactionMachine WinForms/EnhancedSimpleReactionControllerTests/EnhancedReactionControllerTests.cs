using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleReactionMachine;
using System;

namespace EnhancedSimpleReactionControllerTests
{
    [TestClass]
    public class EnhancedReactionControllerTests
    {
        private static IController controller;
        private static IGui gui;
        private static IRandom rng;
        private static string displayText;
        private static int RandomNumber { get; set; }
       
        [TestMethod]
        public void Test_Create_Controller()
        {
            // Tests that the controller can be created and is not null
            // after creation
            controller = new EnhancedReactionController();
            Assert.IsNotNull(controller);
        }

        [TestMethod]
        public void Test_Connect_And_Initialise_Controller()
        {
            controller = new EnhancedReactionController();
            gui = new DummyGui();
            gui.Connect(controller);
            controller.Connect(gui, new RndGenerator());
            
            // Controller Init() sets initial state to OnState
            // and display should be "Insert coin"
            controller.Init();
            Assert.AreEqual("Insert coin", displayText);
        }

        [TestMethod]
        public void Test_OnState_GoStopPressed()
        {
            controller = new EnhancedReactionController();
            gui = new DummyGui();
            rng = new RndGenerator();
            InitialiseToOnState(controller, gui, rng);

            // GoStopPressed has no effect in OnState
            Assert.AreEqual("Insert coin", displayText);
            controller.GoStopPressed();
            Assert.AreEqual("Insert coin", displayText);
        }

        [TestMethod]
        public void Test_OnState_Tick()
        {
            controller = new EnhancedReactionController();
            gui = new DummyGui();
            rng = new RndGenerator();
            InitialiseToOnState(controller, gui, rng);

            // Tick has no effect in OnState
            Assert.AreEqual("Insert coin", displayText);
            controller.Tick();
            Assert.AreEqual("Insert coin", displayText);
        }

        [TestMethod]
        public void Test_OnState_CoinInserted()
        {
            controller = new EnhancedReactionController();
            gui = new DummyGui();
            rng = new RndGenerator();
            InitialiseToOnState(controller, gui, rng);

            // Inserting a coin sets the state to ReadyState
            // Display should then be "Press Go!"
            Assert.AreEqual("Insert coin", displayText);
            controller.CoinInserted();
            Assert.AreEqual("Press Go!", displayText);
        }

        [TestMethod]
        public void Test_ReadyState_CoinInserted()
        {
            controller = new EnhancedReactionController();
            gui = new DummyGui();
            rng = new RndGenerator();
            InitialiseToReadyState(controller, gui, rng);

            // Inserting a coin has no effect in ReadyState
            Assert.AreEqual("Press Go!", displayText);
            controller.CoinInserted();
            Assert.AreEqual("Press Go!", displayText);
        }

        [TestMethod]
        public void Test_ReadyState_Tick()
        {
            controller = new EnhancedReactionController();
            gui = new DummyGui();
            rng = new RndGenerator();
            InitialiseToReadyState(controller, gui, rng);

            // Tick has no effect in ReadyState
            Assert.AreEqual("Press Go!", displayText);
            controller.Tick();
            Assert.AreEqual("Press Go!", displayText);
        }

        [TestMethod]
        public void Test_ReadyState_GoStopPressed()
        {
            controller = new EnhancedReactionController();
            gui = new DummyGui();
            rng = new RndGenerator();
            InitialiseToReadyState(controller, gui, rng);

            // Pressing Go/Stop sets the state to WaitState
            // Display should then be "Wait..."
            Assert.AreEqual("Press Go!", displayText);
            controller.GoStopPressed();
            Assert.AreEqual("Wait...", displayText);
        }

        [TestMethod]
        public void Test_ReadyState_Too_Long()
        {
            controller = new EnhancedReactionController();
            gui = new DummyGui();
            rng = new RndGenerator();
            InitialiseToReadyState(controller, gui, rng);

            // Waiting for 10 seconds in WaitState resets the
            // controller back to OnState
            // Display should then be "Insert coin"
            for (int t = 0; t < 999; t++) controller.Tick();    
            Assert.AreEqual("Press Go!", displayText);
            controller.Tick();
            Assert.AreEqual("Insert coin", displayText);
        }

        [TestMethod]
        public void Test_WaitState_CoinInserted()
        {
            controller = new EnhancedReactionController();
            gui = new DummyGui();
            rng = new RndGenerator();
            InitialiseToWaitState(controller, gui, rng);

            // Inserting a coin has no effect in WaitState
            Assert.AreEqual("Wait...", displayText);
            controller.CoinInserted();
            Assert.AreEqual("Wait...", displayText);
        }

        [TestMethod]
        public void Test_WaitState_GoStopPressed()
        {
            controller = new EnhancedReactionController();
            gui = new DummyGui();
            rng = new RndGenerator();
            InitialiseToWaitState(controller, gui, rng);

            // GoStopPressed in the WaitState is considered
            // cheating and it sets the game back to the OnState
            // Display should then by "Insert coin"
            Assert.AreEqual("Wait...", displayText);
            controller.GoStopPressed();
            Assert.AreEqual("Insert coin", displayText);
        }

        [TestMethod]
        public void Test_WaitState_Tick()
        {
            controller = new EnhancedReactionController();
            gui = new DummyGui();
            rng = new RndGenerator();
            InitialiseToWaitState(controller, gui, rng);

            // After the rendom wait time, the controller should
            // be set to the RunningState
            // Display should then be "0.00"
            for (int t = 0; t < RandomNumber - 1; t++) controller.Tick();
            Assert.AreEqual(displayText, "Wait...");
            controller.Tick();
            Assert.AreEqual(displayText, "0.00");
        }

        [TestMethod]
        public void Test_RunningState_CoinInserted()
        {
            controller = new EnhancedReactionController();
            gui = new DummyGui();
            rng = new RndGenerator();
            InitialiseToRunningState(controller, gui, rng);

            // CoinInserted has no effect in the RunningState
            Assert.AreEqual("0.00", displayText);
            controller.CoinInserted();
            Assert.AreEqual("0.00", displayText);
        }

        [TestMethod]
        public void Test_RunningState_Tick()
        {
            controller = new EnhancedReactionController();
            gui = new DummyGui();
            rng = new RndGenerator();
            InitialiseToRunningState(controller, gui, rng);

            // Ticks advance the time display in the RunningState
            Assert.AreEqual("0.00", displayText);
            controller.Tick();
            Assert.AreEqual("0.01", displayText);

            for (int t = 0; t < 10; t++) controller.Tick();
            Assert.AreEqual("0.11", displayText);

            for (int t = 0; t < 100; t++) controller.Tick();
            Assert.AreEqual("1.11", displayText);

            // GoStopPressed should advance to the GameOverState
            // and no further update to the display
            controller.GoStopPressed();
            Assert.AreEqual("1.11", displayText);
        }

        [TestMethod]
        public void Test_RunningState_GoStopPressed()
        {
            controller = new EnhancedReactionController();
            gui = new DummyGui();
            rng = new RndGenerator();
            InitialiseToRunningState(controller, gui, rng);

            // GoStopPressed records the reaction time in the RunningState
            // and advances the controller to the GameOverState
            // Display should be the same as the reaction time when
            // GoStop is pressed
            for (int t = 0; t < 164; t++) controller.Tick();
            Assert.AreEqual("1.64", displayText);
            controller.GoStopPressed();
            Assert.AreEqual("1.64", displayText);
        }

        [TestMethod]
        public void Test_RunningState_Tick_Two_Seconds()
        {
            controller = new EnhancedReactionController();
            gui = new DummyGui();
            rng = new RndGenerator();
            InitialiseToRunningState(controller, gui, rng);

            // Not reacting in 2 seconds automatically ends the game
            // Display should show 2.00 seconds
            for (int t = 0; t < 199; t++) controller.Tick();
            Assert.AreEqual("1.99", displayText);
            controller.Tick();
            Assert.AreEqual("2.00", displayText);
            controller.Tick();
            Assert.AreEqual("2.00", displayText);
        }

        [TestMethod]
        public void Test_GameOverState_CoinInserted()
        {
            controller = new EnhancedReactionController();
            gui = new DummyGui();
            rng = new RndGenerator();
            InitialiseToRunningState(controller, gui, rng);

            // Inserting a coin has no effect in GameOverState
            for (int t = 0; t < 22; t++) controller.Tick();
            Assert.AreEqual("0.22", displayText);
            controller.CoinInserted();
            Assert.AreEqual("0.22", displayText);
        }

        [TestMethod]
        public void Test_GameOverState_Tick()
        {
            controller = new EnhancedReactionController();
            gui = new DummyGui();
            rng = new RndGenerator();
            InitialiseToRunningState(controller, gui, rng);

            // Tick shows the reaction time and then sets the
            // controller to the WaitState
            // NOTE: This test does not test the transition
            // to the ResultState. That is tested in 
            // Test_Play_Three_Games_And_Wait_Ticks
            for (int t = 0; t < 50; t++) controller.Tick();
            controller.GoStopPressed();
            Assert.AreEqual("0.50", displayText);
            for (int t = 0; t < 299; t++) controller.Tick();
            Assert.AreEqual("0.50", displayText);
            controller.Tick();
            Assert.AreEqual("Wait...", displayText);
        }

        [TestMethod]
        public void Test_GameOver_GoStopPressed()
        {
            controller = new EnhancedReactionController();
            gui = new DummyGui();
            rng = new RndGenerator();
            InitialiseToRunningState(controller, gui, rng);

            // GoStopPressed immediately ends the GameOverState
            // and sets the state to WaitState
            // NOTE: This does not test the state moving
            // to the ResultState after 3 games. That is tested in
            // Test_Play_Three_Games_And_GoStopPressed
            for (int t = 0; t < 56; t++) controller.Tick();
            controller.GoStopPressed();
            Assert.AreEqual("0.56", displayText);
            controller.GoStopPressed();
            Assert.AreEqual("Wait...", displayText);
        }

        [TestMethod]
        public void Test_Play_Three_Games_And_Wait_Ticks()
        {
            controller = new EnhancedReactionController();
            gui = new DummyGui();
            rng = new RndGenerator();
            InitialiseToRunningState(controller, gui, rng);

            // Run three games and then wait the final 3 seconds
            // State should advance to ResultState
            // Display should then show the average reaction time
            for (int t = 0; t < 20; t++) controller.Tick();
            controller.GoStopPressed();
            Assert.AreEqual("0.20", displayText);
            for (int t = 0; t < 299; t++) controller.Tick();
            Assert.AreEqual("0.20", displayText);
            controller.Tick();
            Assert.AreEqual("Wait...", displayText);

            for (int t = 0; t < RandomNumber + 30; t++) controller.Tick();
            controller.GoStopPressed();
            Assert.AreEqual("0.30", displayText);
            for (int t = 0; t < 299; t++) controller.Tick();
            Assert.AreEqual("0.30", displayText);
            controller.Tick();
            Assert.AreEqual("Wait...", displayText);

            for (int t = 0; t < RandomNumber + 40; t++) controller.Tick();
            controller.GoStopPressed();
            Assert.AreEqual("0.40", displayText);
            for (int t = 0; t < 299; t++) controller.Tick();
            controller.Tick();
            Assert.AreEqual("Average: 0.30", displayText);

        }
        [TestMethod]
        public void Test_Play_Three_Games_And_GoStopPressed()
        {
            controller = new EnhancedReactionController();
            gui = new DummyGui();
            rng = new RndGenerator();
            InitialiseToRunningState(controller, gui, rng);

            // Run three games and then press GoStop
            // State should advance to ResultState immediately
            // Display should then show the average reaction time
            for (int t = 0; t < 155; t++) controller.Tick();
            controller.GoStopPressed();
            Assert.AreEqual("1.55", displayText);
            controller.GoStopPressed();
            Assert.AreEqual("Wait...", displayText);

            for (int t = 0; t < RandomNumber + 160; t++) controller.Tick();
            controller.GoStopPressed();
            Assert.AreEqual("1.60", displayText);
            controller.GoStopPressed();
            Assert.AreEqual("Wait...", displayText);

            for (int t = 0; t < RandomNumber + 165; t++) controller.Tick();
            controller.GoStopPressed();
            Assert.AreEqual("1.65", displayText);
            controller.GoStopPressed();
            Assert.AreEqual("Average: 1.60", displayText);
        }

        [TestMethod]
        public void Test_ResultState_CoinInserted()
        {
            controller = new EnhancedReactionController();
            gui = new DummyGui();
            rng = new RndGenerator();
            InitialiseToRunningState(controller, gui, rng);

            // Play 3 games
            for (int t = 0; t < 10; t++) controller.Tick();
            controller.GoStopPressed();
            controller.GoStopPressed();

            for (int t = 0; t < RandomNumber + 15; t++) controller.Tick();
            controller.GoStopPressed();
            controller.GoStopPressed();

            for (int t = 0; t < RandomNumber + 20; t++) controller.Tick();
            controller.GoStopPressed();
            controller.GoStopPressed();

            // Inserting a coin in the ResultState has no effect
            Assert.AreEqual("Average: 0.15", displayText);
            controller.CoinInserted();
            Assert.AreEqual("Average: 0.15", displayText);
        }

        [TestMethod]
        public void Test_ResultState_Ticks()
        {
            controller = new EnhancedReactionController();
            gui = new DummyGui();
            rng = new RndGenerator();
            InitialiseToRunningState(controller, gui, rng);

            // Play 3 games
            for (int t = 0; t < 10; t++) controller.Tick();
            controller.GoStopPressed();
            controller.GoStopPressed();

            for (int t = 0; t < RandomNumber + 15; t++) controller.Tick();
            controller.GoStopPressed();
            controller.GoStopPressed();

            for (int t = 0; t < RandomNumber + 20; t++) controller.Tick();
            controller.GoStopPressed();
            controller.GoStopPressed();

            // Ticks displays the average reaction time for 5 seconds
            // and then the controller is set to OnState
            // Display should then be "Insert coin"
            Assert.AreEqual("Average: 0.15", displayText);
            for (int i = 0; i < 499; i++) controller.Tick();
            Assert.AreEqual("Average: 0.15", displayText);
            controller.Tick();
            Assert.AreEqual("Insert coin", displayText);
        }

        [TestMethod]
        public void Test_ResultState_GoStopPressed()
        {
            controller = new EnhancedReactionController();
            gui = new DummyGui();
            rng = new RndGenerator();
            InitialiseToRunningState(controller, gui, rng);

            // Play 3 games
            for (int t = 0; t < 10; t++) controller.Tick();
            controller.GoStopPressed();
            controller.GoStopPressed();

            for (int t = 0; t < RandomNumber + 15; t++) controller.Tick();
            controller.GoStopPressed();
            controller.GoStopPressed();

            for (int t = 0; t < RandomNumber + 20; t++) controller.Tick();
            controller.GoStopPressed();
            controller.GoStopPressed();

            // GoStopPressed displays the average reaction time for 5 seconds
            // and then the controller is set to OnState
            // Display should then be "Insert coin"
            Assert.AreEqual("Average: 0.15", displayText);
            controller.GoStopPressed();
            Assert.AreEqual("Insert coin", displayText);
        }

        // sets the controller to the OnState
        private void InitialiseToOnState(IController controller, IGui gui, IRandom rng)
        {
            gui.Connect(controller);
            controller.Connect(gui, rng);
            gui.Init();
            controller.Init();
        }

        // sets the controller to the ReadyState
        private void InitialiseToReadyState(IController controller, IGui gui, IRandom rng)
        {
            InitialiseToOnState(controller, gui, rng);
            controller.CoinInserted();
        }

        // sets the controller to the WaitState
        private void InitialiseToWaitState(IController controller, IGui gui, IRandom rng)
        {
            InitialiseToReadyState(controller, gui, rng);
            controller.GoStopPressed();
        }

        // sets the controller to the RunningState
        private void InitialiseToRunningState(IController controller, IGui gui, IRandom rng)
        {
            InitialiseToWaitState(controller, gui, rng);
            for (int t = 0; t < RandomNumber; t++)
                controller.Tick();
        }

        // Mock Gui, as implementation of the IGui, to allow the controller
        // to Connect and SetDisplay
        private class DummyGui : IGui
        {
            private IController _controller;
            public void Connect(IController controller) => _controller = controller;
            public void Init() => displayText = "?reset?";

            public void SetDisplay(string msg)
            {
                displayText = msg;
            }
        }

        // IRandom implementation that also sets the RandomNumber property 
        // to allow the test to access it, as well as the values being 
        // passed to the controller
        private class RndGenerator : IRandom
        {
            Random rnd = new Random(42);

            public int GetRandom(int from, int to)
            {
                RandomNumber = rnd.Next(from) + to;
                return RandomNumber;
            }
        }
    }
}
