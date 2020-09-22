using System;

namespace EnhancedSimpleReactionMachine
{
    public class EnhancedSimpleReactionController : IController
    {
        private State _state;
        private IGui Gui { get; set; }
        private IRandom Rng { get; set; }
        private int Ticks { get; set; }
        private int Games { get; set; }
        private int TotalReactionTime { get; set; }

        public void Connect(IGui gui, IRandom rng)
        {
            Gui = gui;
            Rng = rng;
            Init();
        }

        public void Init() => _state = new OnState(this);
        public void CoinInserted() => _state.CoinInserted();
        public void GoStopPressed() => _state.GoStopPressed();
        public void Tick() => _state.Tick();
        void SetState(State state) => _state = state;

        public void PrintGames()
        {
            Console.WriteLine("Current game count: " + Games.ToString());
        }

        abstract class State
        {
            protected EnhancedSimpleReactionController controller;
            public State(EnhancedSimpleReactionController con) => controller = con;
            public abstract void CoinInserted();
            public abstract void GoStopPressed();
            public abstract void Tick();
        }

        class OnState : State
        {
            public OnState(EnhancedSimpleReactionController con) : base(con)
            {
                controller.Games = 0;
                controller.TotalReactionTime = 0;
                controller.Gui.SetDisplay("Insert coin");
            }
            public override void CoinInserted() => controller.SetState(new ReadyState(controller));
            public override void GoStopPressed() { }
            public override void Tick() { }
        }

        class ReadyState : State
        {
            public ReadyState(EnhancedSimpleReactionController con) : base(con)
            {
                controller.Gui.SetDisplay("Press Go!");
                controller.Ticks = 0;
            }
            public override void CoinInserted() { }
            public override void GoStopPressed()
            {
                controller.SetState(new WaitState(controller));
            }
            public override void Tick()
            {
                controller.Ticks++;
                if (controller.Ticks == 1000)
                    controller.SetState(new OnState(controller));
            }
        }

        class WaitState : State
        {
            private int _waitTime;
            public WaitState(EnhancedSimpleReactionController con) : base(con)
            {
                controller.Gui.SetDisplay("Wait...");
                controller.Ticks = 0;
                _waitTime = controller.Rng.GetRandom(100, 250);
            }
            public override void CoinInserted() { }
            public override void GoStopPressed() => controller.SetState(new OnState(controller));
            public override void Tick()
            {
                controller.Ticks++;
                if (controller.Ticks == _waitTime)
                {
                    controller.Games++;
                    controller.SetState(new RunningState(controller));
                }
            }
        }

        class RunningState : State
        {
            public RunningState(EnhancedSimpleReactionController con) : base(con)
            {
                controller.Gui.SetDisplay("0.00");
                controller.Ticks = 0;
            }
            public override void CoinInserted() { }
            public override void GoStopPressed()
            {
                controller.TotalReactionTime += controller.Ticks;
                controller.SetState(new GameOverState(controller));
            }
            public override void Tick()
            {
                controller.Ticks++;
                controller.Gui.SetDisplay((controller.Ticks / 100.0).ToString("0.00"));
                if (controller.Ticks == 200)
                    controller.SetState(new GameOverState(controller));
            }
        }

        class GameOverState : State
        {
            public GameOverState(EnhancedSimpleReactionController con) : base(con)
            {
                controller.Ticks = 0;
            }
            public override void CoinInserted() { }
            public override void GoStopPressed() => CheckGames();
            public override void Tick()
            {
                controller.Ticks++;
                if (controller.Ticks == 300)
                    CheckGames();
            }
            private void CheckGames()
            {
                if (controller.Games == 3)
                {
                    controller.SetState(new ResultsState(controller));
                    return;
                }
                controller.SetState(new WaitState(controller));
            }
        }

        class ResultsState : State
        {
            public ResultsState(EnhancedSimpleReactionController con) : base(con)
            {
                controller.Gui.SetDisplay("Average: " +
                    ((double)controller.TotalReactionTime / controller.Games * 0.01)
                    .ToString("0.00"));
                controller.Ticks = 0;
            }
            public override void CoinInserted() { }
            public override void GoStopPressed() => controller.SetState(new OnState(controller));
            public override void Tick()
            {
                controller.Ticks++;
                if (controller.Ticks == 500)
                    controller.SetState(new OnState(controller));
            }
        }
    }
}
