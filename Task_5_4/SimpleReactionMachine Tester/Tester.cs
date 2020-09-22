using System;

namespace EnhancedSimpleReactionMachine
{
    class Tester
    {
        private static IController controller;
        private static IGui gui;
        private static string displayText;
        private static int randomNumber;
        private static int passed = 0;

        static void Main(string[] args)
        {
            // run simple test
            SimpleTest();
            Console.WriteLine("\n=====================================\nSummary: {0} tests passed out of 38", passed);
            Console.ReadKey();
        }

        private static void SimpleTest()
        {
            // EnhancedReactionController can be created
            controller = new EnhancedSimpleReactionController();
            gui = new DummyGui();

            // Connect gui and rng
            gui.Connect(controller);
            controller.Connect(gui, new RndGenerator());

            // Reset the components
            gui.Init();

            // Test the EnmhancedSimpleReactionController

            // IDLE
            DoReset(1, controller, "Insert coin");
            DoGoStop(2, controller, "Insert coin");
            DoTicks(3, controller, 1, "Insert coin");

            // CoinInserted
            DoInsertCoin(4, controller, "Press GO!");

            //READY
            DoInsertCoin(5, controller, "Press GO!");

            // No GoStop for 10 seconds
            DoTicks(6, controller, 999, "Press GO!");
            DoTicks(7, controller, 1, "Insert coin");

            // Return back to the ready state, silently
            // This is already tested, so no need to test
            // again
            DoInsertCoin(8, controller, "Press GO!");

            // READY goStop
            // GoStopPressed
            DoGoStop(9, controller, "Wait...");

            // Pressing GoStop in the wait period, resets the machine
            DoGoStop(10, controller, "Insert coin");

            // Return back to the wait state , silently
            // This is already tests, so no need to test
            // again
            randomNumber = 111;
            DoInsertCoin(11, controller, "Press GO!");
            DoGoStop(12, controller, "Wait...");

            //WAIT tick(s)
            DoTicks(13, controller, randomNumber - 1, "Wait...");

            // ********************************* play game 1
            //RUN tick(s)
            DoTicks(14, controller, 1, "0.00");
            DoTicks(15, controller, 1, "0.01");
            DoTicks(16, controller, 10, "0.11");
            DoTicks(17, controller, 100, "1.11");

            //goStop
            DoGoStop(18, controller, "1.11");

            //STOP tick(s)
            DoTicks(19, controller, 299, "1.11");
            DoTicks(20, controller, 1, "Wait...");


            // ********************************* play game 2
            DoTicks(21, controller, randomNumber - 1, "Wait...");
            DoTicks(22, controller, 1, "0.00");
            DoTicks(23, controller, 1, "0.01");
            DoTicks(24, controller, 10, "0.11");
            DoTicks(25, controller, 100, "1.11");
            DoGoStop(26, controller, "1.11");

            // STOP ticks
            DoTicks(27, controller, 299, "1.11");
            DoTicks(28, controller, 1, "Wait...");

            // ********************************* play game 3
            //tick
            DoTicks(27, controller, randomNumber - 1, "Wait...");
            DoTicks(28, controller, 1, "0.00");
            DoTicks(29, controller, 1, "0.01");
            DoTicks(30, controller, 10, "0.11");
            DoTicks(31, controller, 100, "1.11");
            DoGoStop(32, controller, "1.11");

            // STOP ticks
            DoTicks(33, controller, 299, "1.11");

            // AVERAGE time
            DoTicks(34, controller, 1, "Average: 1.11");

            // Return to idle
            DoTicks(35, controller, 499, "Average: 1.11");
            DoTicks(36, controller, 1, "Insert coin");

            // Play 1 game and then press GoStop in the wait period
            randomNumber = 156;
            DoInsertCoin(37, controller, "Press GO!");
            DoGoStop(38, controller, "Wait...");
            DoTicks(39, controller, randomNumber - 1, "Wait...");
            DoTicks(40, controller, 1, "0.00");
            DoTicks(41, controller, 1, "0.01");
            DoTicks(42, controller, 10, "0.11");
            DoTicks(43, controller, 100, "1.11");

            //goStop
            DoGoStop(44, controller, "1.11");

            //GOSTOP in GameOver
            DoGoStop(45, controller, "Wait...");

            // WAIT GoStop during playing of 3 games -> return to IDLE
            // Go back to IDLE
            // *********************************cheating?
            DoGoStop(46, controller, "Insert coin");

            // PLAY 3 games and press GoStop to go straight to Average display
            DoInsertCoin(47, controller, "Press GO!");
            DoGoStop(48, controller, "Wait...");

            //WAIT tick(s)
            DoTicks(49, controller, randomNumber - 1, "Wait...");

            // ********************************* play game 1
            //RUN tick(s)
            DoTicks(50, controller, 1, "0.00");
            DoTicks(51, controller, 1, "0.01");
            DoTicks(52, controller, 10, "0.11");
            DoTicks(53, controller, 100, "1.11");

            //goStop
            DoGoStop(54, controller, "1.11");

            //STOP tick(s)
            DoTicks(55, controller, 299, "1.11");
            DoTicks(56, controller, 1, "Wait...");


            // ********************************* play game 2
            DoTicks(57, controller, randomNumber - 1, "Wait...");
            DoTicks(58, controller, 1, "0.00");
            DoTicks(59, controller, 1, "0.01");
            DoTicks(60, controller, 10, "0.11");
            DoTicks(61, controller, 100, "1.11");
            DoGoStop(62, controller, "1.11");

            // STOP ticks
            DoTicks(63, controller, 299, "1.11");
            DoTicks(64, controller, 1, "Wait...");

            // ********************************* play game 3
            //tick
            DoTicks(65, controller, randomNumber - 1, "Wait...");
            DoTicks(66, controller, 1, "0.00");
            DoTicks(67, controller, 1, "0.01");
            DoTicks(68, controller, 10, "0.11");
            DoTicks(69, controller, 100, "1.11");
            DoGoStop(70, controller, "1.11");

            // STOP ticks
            DoTicks(71, controller, 299, "1.11");

            // AVERAGE time
            DoTicks(72, controller, 1, "Average: 1.11");

            // Return to idle
            DoGoStop(73, controller, "Insert coin");


            /*
            DoTicks('R', controller, randomNumber - 1, "Wait...");
            DoGoStop('S', controller, "Insert coin");
            // *********************************new game?
            //IDLE init
            gui.Init();
            DoReset('T', controller, "Insert coin");

            //IDLE -> READY init
            randomNumber = 123;
            DoInsertCoin('U', controller, "Press GO!");
            // *********************************new game?	
            gui.Init();
            DoReset('V', controller, "Insert coin");

            //IDLE -> READY ->WAIT init
            randomNumber = 123;
            DoInsertCoin('W', controller, "Press GO!");
            DoGoStop('X', controller, "Wait...");
            // *********************************new game?
            gui.Init();
            DoReset('Y', controller, "Insert coin");

            //IDLE -> READY -> WAIT -> RUN init
            randomNumber = 137;
            DoInsertCoin('Z', controller, "Press GO!");
            DoGoStop('a', controller, "Wait...");
            DoTicks('b', controller, randomNumber + 98, "0.98");
            // *********************************new game?
            gui.Init();
            DoReset('c', controller, "Insert coin");

            //IDLE -> READY -> WAIT -> RUN -> STOP init
            randomNumber = 119;
            DoInsertCoin('d', controller, "Press GO!");
            DoGoStop('e', controller, "Wait...");
            DoTicks('f', controller, randomNumber + 135, "1.35");
            DoGoStop('g', controller, "1.35");
            // *********************************new game?
            gui.Init();
            DoReset('h', controller, "Insert coin");

            //IDLE -> READY -> WAIT -> RUN (timeout) -> STOP
            randomNumber = 120;
            DoInsertCoin('i', controller, "Press GO!");
            DoGoStop('j', controller, "Wait...");
            DoTicks('k', controller, randomNumber + 199, "1.99");
            DoTicks('l', controller, 50, "2.00");
            */
        }

        private static void DoReset(int testNum, IController controller, string msg)
        {
            try
            {
                controller.Init();
                GetMessage(testNum, msg);
            }
            catch (Exception exception)
            {
                Console.WriteLine("test {0,2}: failed with exception {1})", testNum, msg, exception.Message);
            }
        }

        private static void DoGoStop(int testNum, IController controller, string msg)
        {
            try
            {
                controller.GoStopPressed();
                GetMessage(testNum, msg);
            }
            catch (Exception exception)
            {
                Console.WriteLine("test {0,2}: failed with exception {1})", testNum, msg, exception.Message);
            }
        }

        private static void DoInsertCoin(int testNum, IController controller, string msg)
        {
            try
            {
                controller.CoinInserted();
                GetMessage(testNum, msg);
            }
            catch (Exception exception)
            {
                Console.WriteLine("test {0,2}: failed with exception {1})", testNum, msg, exception.Message);
            }
        }

        private static void DoTicks(int testNum, IController controller, int n, string msg)
        {
            try
            {
                for (int t = 0; t < n; t++) controller.Tick();
                GetMessage(testNum, msg);
            }
            catch (Exception exception)
            {
                Console.WriteLine("test {0,2}: failed with exception {1})", testNum, msg, exception.Message);
            }
        }

        private static void GetMessage(int testNum, string msg)
        {
            if (msg.ToLower() == displayText.ToLower())
            {
                Console.WriteLine("test {0,2}: passed successfully", testNum);
                passed++;
            }
            else
                Console.WriteLine("test {0,2}: failed with message ( expected {1} | received {2})", testNum, msg, displayText);
        }

        private class DummyGui : IGui
        {

            private IController _controller;

            public void Connect(IController controller)
            {
                _controller = controller;
            }

            public void Init()
            {
                displayText = "?reset?";
            }

            public void SetDisplay(string msg)
            {
                displayText = msg;
            }
        }

        private class RndGenerator : IRandom
        {
            public int GetRandom(int from, int to)
            {
                return randomNumber;
            }
        }

    }

}
