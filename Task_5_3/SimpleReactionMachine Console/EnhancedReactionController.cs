using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleReactionMachine;

namespace SimpleReactionMachine
{
    class EnhancedReactionController : IController
    {
        //Instance variable
        Phase phase;

        //Properties
        IGui Gui 
        { 
            get;
            set; 
        }

        IRandom Random 
        { 
            get; 
            set;
        }

        //Counts the number of ticks based on contoller.Tick() is called
        int NumberOfTicks 
        { 
            get;
            set; 
        }

        //Total time taken in each game
        int TotalTime
        {
            get;
            set;
        }

        //Counts the number of games
        int NumberOfGames 
        { 
            get;
            set;
        }
    
        //Connects the contoller to the Gui
        public void Connect(IGui gui, IRandom random)
        {
            Gui = gui;
            Random = random;
            Init();
        }

        //Initialises the phase of the controller that is GameOn
        public void Init()
        {
            phase = new GameOnPhase(this);
        }

       
        //Coin is inserted into the machine. Calls the CoinInserted() of that phase
        public void CoinInserted()
        {
            phase.CoinInserted();
        }

        // Go/Stop button is pressed. Calls the GoStopPressed() of that phase
        public void GoStopPressed()
        {
            phase.GoStopPressed();
        }

        //Delivers the tick to the controller of that phase
        public void Tick()
        {
            phase.Tick();
        }

        //Base class for different phases in the machine (Nested class)
        private abstract class Phase
        {
            //Protected instance variable
            protected EnhancedReactionController _controller;

            //Constructor
            public Phase(EnhancedReactionController controller)
            {
                _controller = controller;
            }

            //Abstract methods
            public abstract void CoinInserted();
            public abstract void GoStopPressed();
            public abstract void Tick();

        }

        //Derived class GameOnphase : when the machine is on and waiting for coin to be inserted 
        private class GameOnPhase : Phase
        {
            //Constructor
            public GameOnPhase(EnhancedReactionController controller) : base(controller)
            {
                _controller.Gui.SetDisplay("Insert Coin");
                _controller.NumberOfGames = 0;
                _controller.TotalTime = 0;

            }

            //Coin is inserted, now new phase is called (GameReadyPhase)
            public override void CoinInserted()
            {
                _controller.phase = new GameReadyPhase(_controller);
            }

            //Nothing happens when go/stop button is pressed
            public override void GoStopPressed()
            {

            }

            public override void Tick()
            {

            }
        }

        //Derived class GameReadyphase : when the coin is inserted but game is not started
        private class GameReadyPhase : Phase
        {
            //Constructor
            public GameReadyPhase(EnhancedReactionController controller) : base(controller)
            {
                _controller.Gui.SetDisplay("Press Go!");
                _controller.NumberOfTicks = 0;

            }

            //Nothing happens when coin is inserted
            public override void CoinInserted()
            {
                
            }

            // Go/Stop button is pressed, now new phase is called (GameWaitingPhase)
            public override void GoStopPressed()
            {
                _controller.phase = new GameWaitingPhase(_controller);
            }

            public override void Tick()
            {
                _controller.NumberOfTicks++;

                //When the time is 10 secs, game restarts
                if(_controller.NumberOfTicks == 1000)
                {
                    _controller.phase = new GameOnPhase(_controller);
                }
            }
        }

        //Derived class GameWaitingphase : when the game is started but waiting for the random time
        private class GameWaitingPhase : Phase
        {
            //Insatnce variable to store the random waiting time
            int _waitingTime;

            //Constructor
            public GameWaitingPhase(EnhancedReactionController controller) : base(controller)
            {
                _controller.Gui.SetDisplay("Wait...");

                _controller.NumberOfTicks = 0;

                _waitingTime = _controller.Random.GetRandom(100, 250);

               
            }

            //Nothing happens when coin is inserted
            public override void CoinInserted()
            {

            }

            // Go/Stop button is pressed, the game restarts
            public override void GoStopPressed()
            {
                _controller.phase = new GameOnPhase(_controller);
            }

            //New phase is called (GameRunningPhase), when the waiting time is over 
            public override void Tick()
            {
                _controller.NumberOfTicks++;

                //when the waiting time is over
                if(_controller.NumberOfTicks == _waitingTime)
                {
                    _controller.phase = new GameRunningPhase(_controller);
                    
                }
            }
        }

        //Derived class GameRunningphase : when the game is running and counting the time
        private class GameRunningPhase : Phase
        {
          
            //Constructor
            public GameRunningPhase(EnhancedReactionController controller) : base(controller)
            {
                _controller.Gui.SetDisplay("0.00");

                _controller.NumberOfTicks = 0;

                _controller.TotalTime = 0;
                
            }

            //Nothing happens when coin is inserted
            public override void CoinInserted()
            {

            }

            // Go/Stop button is pressed, the game is over
            public override void GoStopPressed()
            {
                _controller.NumberOfGames++;

                _controller.TotalTime += _controller.NumberOfTicks;

                _controller.phase = new GameOverPhase(_controller);
            }

            //New phase is called (GameOverPhase), when the max game time is over (2 secs) 
            public override void Tick()
            {
                _controller.NumberOfTicks++;

                //Displays the time-value that increments every 10 milliseconds
                _controller.Gui.SetDisplay((_controller.NumberOfTicks / 100.0).ToString("0.00"));

                

                //When the time is 2 seconds (Max game time)
                if (_controller.NumberOfTicks == 200)
                {
                    _controller.phase = new GameOverPhase(_controller);
                }
            }
        }

        //Derived class GameOverphase : when the game is over or user has pressed the button
        private class GameOverPhase : Phase
        {

            //Constructor
            public GameOverPhase(EnhancedReactionController controller) : base(controller)
            {             
                _controller.NumberOfTicks = 0;
            }

            //Nothing happens when coin is inserted
            public override void CoinInserted()
            {

            }

            // Go/Stop button is pressed, the game restarts
            public override void GoStopPressed()
            {                
                CheckGames();
            }

            //Game restarts, when the game over time is over (3 secs) 
            public override void Tick()
            {
                _controller.NumberOfTicks++;

                

                //When the time is 3 seconds (game over time)
                if (_controller.NumberOfTicks == 300)
                {
                    CheckGames();
                }
            }

            //Checks the numbner of games to call new phases 
            public void CheckGames()
            {
                //When the number of games are 3, calls GameOutcome Phase, otherwise calls GameWaiting phase
                if(_controller.NumberOfGames == 3)
                {
                    _controller.phase = new GameOutcomePhase(_controller);
                }
                else
                {
                    _controller.phase = new GameWaitingPhase(_controller);
                }
            }
        }

        //Derived class GameOutcomePhase : To display the average reaction time
        private class GameOutcomePhase : Phase
        {

            //Constructor
            public GameOutcomePhase(EnhancedReactionController controller) : base(controller)
            {
                _controller.NumberOfTicks = 0;

                //Displays the average time
                _controller.Gui.SetDisplay("Average: " + ((_controller.TotalTime / _controller.NumberOfGames) / 100.0).ToString("0.00"));
            }

            //Nothing happens when coin is inserted
            public override void CoinInserted()
            {

            }

            // Go/Stop button is pressed, the game restarts
            public override void GoStopPressed()
            {
                _controller.phase = new GameOnPhase(_controller);
            }

            //Game restarts, when the game outcome time is over (5 secs) 
            public override void Tick()
            {
                _controller.NumberOfTicks++;

                //When the time is 5 seconds (average time display)
                if (_controller.NumberOfTicks == 500)
                {
                    _controller.phase = new GameOnPhase(_controller);
                }
            }

            
        }
    }
}
