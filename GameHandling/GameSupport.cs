using System;

namespace LiveSplit.MVGSplit.GameHandling
{
    internal abstract class GameSupport
    {
        internal abstract void PrintValues();
        internal abstract TimeSpan GetGameTime();
        internal abstract bool StartTimer();
        internal abstract string TimerAction();

        internal abstract bool IsAlive();
    }
}
