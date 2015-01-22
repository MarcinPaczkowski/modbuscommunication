using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModbusCommunication.Utils
{
    internal static class ConsoleHelper
    {
        private static TreeView _console;

        internal static void InitilizeConsole(TreeView console)
        {
            _console = console;
        }

        internal static void AddMessage(string message)
        {
            _console.Nodes.Add(message);
        }

        internal static void ClearConsole()
        {
            _console.Nodes.Clear();
        }
    }
}
