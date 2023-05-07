using LiveSplit.ComponentUtil;
using LiveSplit.MVGSplit.GameHandling;
using LiveSplit.MVGSplit.MemoryHandling;
using System;
using System.Diagnostics;

namespace LiveSplit.MVGSplit.GameSpecific
{
    internal class Portal1 : GameSupport
    {
        private readonly MyWinAPI _api;
        private readonly Process proc;
        private MemoryWatcherList mwl;
        private MemoryWatcher total;


        public Portal1()
        {
            _api = new MyWinAPI("hl2", "engine.dll");
            proc = _api.GetProcess();
            mwl = new MemoryWatcherList();
            FindInterface(proc);
        }

        public bool FindInterface(Process proc)
        {
            Debug.WriteLine("find interface with " + proc.ProcessName);

            // TimerInterface
            var target = new SigScanTarget(22,
                "A3 ?? ?? ?? ??",           // mov     dword_2038BA6C, eax
                "B9 ?? ?? ?? ??",           // mov     ecx, offset unk_2038B8E8
                "A3 ?? ?? ?? ??",           // mov     dword_2035DDA4, eax
                "E8 ?? ?? ?? ??",           // call    sub_20048110
                "D9 1D ?? ?? ?? ??",        // fstp    curTime
                "B9 ?? ?? ?? ??",           // mov     ecx, offset unk_2038B8E8
                "E8 ?? ?? ?? ??",           // call    sub_20048130
                "D9 1D"                     // fstp    frametime
            );

            Console.WriteLine("Base Address: " + _api.moduleInfo.lpBaseOfDll.ToString("X"));
            Console.WriteLine("Size: " + _api.moduleInfo.SizeOfImage.ToString("X"));

            var result = IntPtr.Zero;
            var scanner = new SignatureScanner(proc, _api.moduleInfo.lpBaseOfDll, (int)_api.moduleInfo.SizeOfImage);
            result = scanner.Scan(target);
            if (result != IntPtr.Zero)
            {
                Debug.WriteLine("[ASL] total = 0x" + result.ToString("X"));
                total = new MemoryWatcher<int>(result);

                mwl.Clear();
                mwl.AddRange(new MemoryWatcher[] { total });
                mwl.UpdateAll(proc);

                Debug.WriteLine("[ASL] pubInterface->total = " + total.Current.ToString());
                return true;
            }

            Debug.WriteLine("[ASL] Memory scan failed!");
            return false;
        }

        internal override void PrintValues()
        {
            Debug.WriteLine("Print Portal 1 total: " + total.Current.ToString());
        }

        internal override TimeSpan GetGameTime()
        {
            total.Update(proc);
            var curTime = double.Parse(total.Current.ToString());
            return TimeSpan.FromSeconds(curTime);
        }

        internal override bool StartTimer()
        {
            return false;
        }

        internal override string TimerAction()
        {
            return "0";
        }

        internal override bool IsAlive()
        {
            return !proc.HasExited;
        }
    }
}
