using System;
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
            _console.Nodes.Add(String.Format("{0}, {1}", message, DateTime.Now));
        }

        internal static void ClearConsole()
        {
            _console.Nodes.Clear();
        }
    }
}
