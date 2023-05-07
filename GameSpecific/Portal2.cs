using LiveSplit.ComponentUtil;
using LiveSplit.MVGSplit.GameHandling;
using LiveSplit.MVGSplit.MemoryHandling;
using System;
using System.Diagnostics;

namespace LiveSplit.MVGSplit.GameSpecific
{
    internal class Portal2 : GameSupport
    {
        private readonly MyWinAPI _api;
        private readonly Process proc;
        // public static IntPtr handle;
        private readonly MemoryWatcherList mwl;
        private MemoryWatcher total;
        private MemoryWatcher ipt;
        private MemoryWatcher action;

        public Portal2()
        {
            _api = new MyWinAPI("portal2", "");
            mwl = new MemoryWatcherList();
            proc = _api.GetProcess();
            FindInterface(proc);
        }

        public bool FindInterface(Process proc)
        {
            Debug.WriteLine("find interface with " + proc.ProcessName);
            // TimerInterface
            var target = new SigScanTarget(16,
                "53 41 52 5F 54 49 4D 45 52 5F 53 54 41 52 54 00", // char start[16]
                "?? ?? ?? ??", // int total
                "?? ?? ?? ??", // float ipt
                "?? ?? ?? ??", // TimerAction action
                "53 41 52 5F 54 49 4D 45 52 5F 45 4E 44 00"); // char end[14]

            var result = IntPtr.Zero;
            foreach (var page in proc.MemoryPages(true))
            {
                var scanner = new SignatureScanner(proc, page.BaseAddress, (int)page.RegionSize);
                result = scanner.Scan(target);

                if (result != IntPtr.Zero)
                {
                    Debug.WriteLine("[ASL] total = 0x" + result.ToString("X"));
                    Debug.WriteLine("[ASL] ipt = 0x" + (result + sizeof(int)).ToString("X"));
                    Debug.WriteLine("[ASL] action = 0x" + (result + sizeof(int) + sizeof(float)).ToString("X"));
                    Debug.WriteLine("[ASL] sizeof int = " + sizeof(int));
                    Debug.WriteLine("[ASL] sizeof float = " + sizeof(float));
                    total = new MemoryWatcher<int>(result);
                    ipt = new MemoryWatcher<float>(result + sizeof(int));
                    action = new MemoryWatcher<int>(result + sizeof(int) + sizeof(float));

                    mwl.Clear();
                    mwl.AddRange(new MemoryWatcher[] { total, ipt, action });
                    mwl.UpdateAll(proc);

                    Debug.WriteLine("[ASL] pubInterface->ipt = " + ipt.Current.ToString());
                    return true;
                }
            }

            Debug.WriteLine("[ASL] Memory scan failed!");
            return false;
        }

        internal override void PrintValues()
        {
            Debug.WriteLine("Print Portal 2 total: " + total.Current.ToString());
            Debug.WriteLine("Print Portal 2 ipt: " + ipt.Current.ToString());
            Debug.WriteLine("Print Portal 2 action: " + action.Current.ToString());
        }

        internal override TimeSpan GetGameTime()
        {
            total.Update(proc);
            ipt.Update(proc);
            // Debug.WriteLine("get game time");
            var curTime = double.Parse(total.Current.ToString());
            // Debug.WriteLine("curTime " + curTime);
            var curIPT = double.Parse(ipt.Current.ToString());
            // Debug.WriteLine("curIPT " + curIPT);
            // Debug.WriteLine("game time " + TimeSpan.FromSeconds(curTime * curIPT));
            return TimeSpan.FromSeconds(curTime * curIPT);
        }

        internal override bool StartTimer()
        {
            action.Update(proc);
            if (action.Current.ToString() == "1")
            {
                Debug.WriteLine("start portal 2 timer");
                return true;
            }
            return false;
        }

        internal override string TimerAction()
        {
#if DEBUG
            if (action.Changed)
                Debug.WriteLine("portal 2 timer action " + action.Current.ToString());
#endif
            return action.Current.ToString();
        }

        internal override bool IsAlive()
        {
            return !proc.HasExited;
        }
    }
}
