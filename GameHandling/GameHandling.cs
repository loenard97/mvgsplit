using LiveSplit.MVGSplit.GameSpecific;
using LiveSplit.MVGSplit.MemoryHandling;
using System;
using System.Diagnostics;
using System.Threading;

namespace LiveSplit.MVGSplit.GameHandling
{
    internal class GameHandling
    {
        readonly MyWinAPI _api = new MyWinAPI("hl2", "engine.dll");

        public GameSupport FindAnyGame()
        {
            Debug.WriteLine("game support find any game");
            while (true)
            {
                Debug.WriteLine("waiting for game...");
                if (_api.FindAnyGameProcess("portal2"))
                {
                    Debug.WriteLine("found portal2");
                    return new Portal2();
                }
                else if (_api.FindAnyGameProcess("hl2"))
                {
                    Debug.WriteLine("found portal 1");
                    return new Portal1();
                }

                // Debug.WriteLine("Thread wait 1s");
                Thread.Sleep(1000);
            }
        }

        private GameSupport NullGame()
        {
            throw new NotImplementedException();
        }
    }
}
