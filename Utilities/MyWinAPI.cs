using LiveSplit.MVGSplit.MemoryHandling;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace LiveSplit.MVGSplit.MemoryHandling
{
    public class MyWinAPI
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct MODULEINFO
        {
            public IntPtr lpBaseOfDll;
            public uint SizeOfImage;
            public IntPtr EntryPoint;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ReadProcessMemory(IntPtr pHandle, IntPtr Address, byte[] Buffer, int Size, IntPtr NumberofBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetModuleHandleA(IntPtr pHandle, IntPtr Address, byte[] Buffer, int Size, IntPtr NumberofBytesRead);

        [DllImport("kernel32", SetLastError = true)]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, IntPtr bInheritHandle, IntPtr dwProcessId);

        [DllImport("psapi.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EnumProcessModulesEx(IntPtr hProcess, [Out] IntPtr[] lphModule, uint cb, out uint lpcbNeeded, uint dwFilterFlag);

        [DllImport("psapi.dll", SetLastError = true)]
        public static extern uint GetModuleFileNameEx(IntPtr hProcess, IntPtr hModule, [Out] StringBuilder lpBaseName,
            uint nSize);

        [DllImport("psapi.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetModuleInformation(IntPtr hProcess, IntPtr hModule, [Out] out MODULEINFO lpmodinfo,
            uint cb);

        [DllImport("psapi.dll")]
        public static extern uint GetModuleBaseName(IntPtr hProcess, IntPtr hModule, [Out] StringBuilder lpBaseName,
            uint nSize);

        public const int PROCESS_VM_READ = 0x10;

        public static Process process;
        public static IntPtr handle;
        public IntPtr entryAddr;
        public MODULEINFO moduleInfo;

        private readonly string processName;
        private readonly string moduleName;

        public MyWinAPI(string processName, string moduleName)
        {
            Debug.WriteLine("init mywinapi");
            this.processName = processName;
            this.moduleName = moduleName;
            // FindGameProcess();
#if DEBUG
            Debug.WriteLine("winapi print debug");
            // Print();
#endif
        }

        public void Print()
        {
            Console.WriteLine("print winapi");
            Console.WriteLine("Process Name: " + processName);
            Console.WriteLine("Process Handle: " + handle);
            Console.WriteLine("Process Handle: " + process.Handle);
            Console.WriteLine("Process ID: " + process.Id);
            Console.WriteLine("Module Name: " + moduleName);
            Console.WriteLine("Base Name: " + this.moduleName);
            Console.WriteLine("Base Address: " + moduleInfo.lpBaseOfDll.ToString("X"));
            Console.WriteLine("Size: " + moduleInfo.SizeOfImage.ToString("X"));
            Console.WriteLine("Entry Point: " + moduleInfo.EntryPoint.ToString("X"));
        }

        public Process GetProcess()
        {
            return process;
        }

        public bool FindGameProcess()
        {
            Debug.WriteLine("searching for" + processName);
            try
            {
                process = Process.GetProcessesByName(processName)[0];
                handle = OpenProcess(PROCESS_VM_READ, IntPtr.Zero, new IntPtr(process.Id));
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("process not found");
                return false;
            }

            if (process.Handle == IntPtr.Zero)
            {
                Console.WriteLine("failed");
                return false;
            }
            moduleInfo = GetModuleInfo();
            Debug.WriteLine("game found");
            return true;
        }

        public bool FindAnyGameProcess(string gameName)
        {
            Debug.WriteLine("searching for any " + gameName);
            try
            {
                process = Process.GetProcessesByName(gameName)[0];
                handle = OpenProcess(PROCESS_VM_READ, IntPtr.Zero, new IntPtr(process.Id));
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("process not found");
                return false;
            }

            if (process.Handle == IntPtr.Zero)
            {
                Console.WriteLine("failed");
                return false;
            }
            moduleInfo = GetModuleInfo();
            Debug.WriteLine("any game found");
            return true;
        }

        public MODULEINFO GetModuleInfo()
        {
            Debug.WriteLine("get module info " + moduleName);
            const int LIST_MODULES_ALL = 3;
            const int MAX_PATH = 260;

            var modules = new IntPtr[1024];
            uint cb = (uint)IntPtr.Size * (uint)modules.Length;
            uint cbNeeded;

            if (!MyWinAPI.EnumProcessModulesEx(process.Handle, modules, cb, out cbNeeded, LIST_MODULES_ALL))
                Console.WriteLine("cant get modules");
            uint nModules = cbNeeded / (uint)IntPtr.Size;
            Debug.WriteLine("Number of Modules: " + nModules);
#if DEBUG
            Console.WriteLine("Number of Modules: " + nModules);
#endif

            var sb = new StringBuilder(MAX_PATH);
            for (int i = 0; i < nModules; i++)
            {
                sb.Clear();
                GetModuleBaseName(process.Handle, modules[i], sb, (uint)sb.Capacity);
                string baseName = sb.ToString();
                var moduleInfo = new MODULEINFO();
                GetModuleInformation(process.Handle, modules[i], out moduleInfo, (uint)Marshal.SizeOf(moduleInfo));

                if (baseName == moduleName)
                    return moduleInfo;
            }

            return new MODULEINFO();
        }

        public static int ReadMemory(int addr)
        {
            byte[] buffer = new byte[4];
            IntPtr bytesRead = IntPtr.Zero;
            if (!ReadProcessMemory(handle, (IntPtr)addr, buffer, buffer.Length, bytesRead))
                Console.WriteLine("Could not read address " + addr);
#if DEBUG
            Console.WriteLine("Read addr: " + (IntPtr)addr);
#endif
            return BitConverter.ToInt32(buffer, 0);
        }

        public int ReadPointer(MyPointer pointer)
        {
            int addr = ReadMemory((int)moduleInfo.lpBaseOfDll + pointer.Address);
            for (int i = 0; i < pointer.Offsets.Length; i++)
            {
                addr = ReadMemory(addr + pointer.Offsets[i]);
            }
            return addr;
        }
    }
}
