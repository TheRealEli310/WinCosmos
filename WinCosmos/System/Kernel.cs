using System;
using sysIO = System.IO;
using Cosmos.Debug.Kernel;
using Cosmos.HAL;
using Cosmos.System.ScanMaps;

namespace Cosmos.System
{
    public abstract class Kernel
    {
        public readonly Debugger mDebugger = new Debugger("User", "Kernel");
        public bool ClearScreen = true;
        protected bool mStarted = false;
        protected bool mStopped = false;
        protected virtual TextScreenBase GetTextScreen()
        {
            // null means use default
            return null;
        }
        protected ScanMapBase GetKeyboardScanMap()
        {
            return KeyboardManager.GetKeyLayout();
        }
        protected void SetKeyboardScanMap(ScanMapBase ScanMap)
        {
            KeyboardManager.SetKeyLayout(ScanMap);
        }
        public virtual void Start()
        {
            try
            {
                
                mDebugger.Send("Starting kernel");
                if (mStarted)
                {
                    Global.mDebugger.Send("ERROR: Kernel Already Started");
                    throw new Exception("Kernel has already been started. A kernel cannot be started twice.");
                }
                mStarted = true;

                if (string.Empty == null)
                {
                    throw new Exception("Compiler didn't initialize System.String.Empty!");
                }

                Global.mDebugger.Send("HW Bootstrap Init");
                HAL.Bootstrap.Init();

                Global.mDebugger.Send("Global Init");
                Global.Init(GetTextScreen());

                // Provide the user with a clear screen if they requested it
                if (ClearScreen)
                {
                    Global.mDebugger.Send("Cls");
                    Console.Clear();
                }

                Global.mDebugger.Send("Before Run");
                BeforeRun();

                // now enable interrupts:
                //HAL.Global.EnableInterrupts();

                Global.mDebugger.Send("Run");
                if (mStopped)
                {
                    Global.mDebugger.Send("Already stopped");
                }
                else
                {
                    Global.mDebugger.Send("Not yet stopped");
                }
                while (!mStopped)
                {
                    //Network.NetworkStack.Update();
                    Global.mDebugger.Send("Really before Run");
                    Run();
                    Global.mDebugger.Send("Really after Run");
                }
                Global.mDebugger.Send("AfterRun");
                AfterRun();
                //bool xTest = 1 != 3;
                //while (xTest) {
                //}
            }
            catch (Exception E)
            {
                // todo: better ways to handle?
                global::System.Console.WriteLine("Exception occurred while running kernel:");
                global::System.Console.WriteLine(E.ToString());
            }
        }
        protected virtual void BeforeRun() { }
        protected abstract void Run();
        protected virtual void AfterRun() { }
        public void Stop()
        {
            mStopped = true;
        }
        public void Restart()
        {
            mStarted = false;
            mStopped = false;
            Start();
        }
        public static void PrintDebug(string message)
        {
            Global.mDebugger.Send(message);
        }

        public static bool InterruptsEnabled
        {
            get
            {
                return HAL.Global.InterruptsEnabled;
            }
        }
    }
}
