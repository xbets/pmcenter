﻿using System;
using static pmcenter.Methods;

namespace pmcenter
{
    public partial class EventHandlers
    {
        public static void CtrlCHandler(object sender, ConsoleCancelEventArgs e)
        {
            Vars.CtrlCCounter++;
            if (Vars.CtrlCCounter > 3)
            {
                Log("More than 3 interrupts has received, terminating...", Type: LogLevel.WARN);
                Environment.Exit(137);
            }
            if (Vars.IsCtrlCHandled) return;
            if (Vars.CurrentConf.IgnoreKeyboardInterrupt)
            {
                Log("Keyboard interrupt is currently being ignored. To change this behavior, set \"IgnoreKeyboardInterrupt\" key to \"false\" in pmcenter configurations.", Type: LogLevel.WARN);
                e.Cancel = true;
                return;
            }
            Vars.IsCtrlCHandled = true;
            Log("Interrupt! pmcenter is exiting...", Type: LogLevel.WARN);
            Log("If pmcenter was unresponsive, press Ctrl-C 3 more times.");
            ExitApp(130);
        }
    }
}