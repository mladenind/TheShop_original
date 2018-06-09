using System;
using TheShop.Contracts.Interfaces;

namespace TheShop.Common
{
    public class Logger : ILogger
    {
        public void WriteMessage(string level, string message)
        {
            Console.WriteLine(String.Format("{0}: {1}", level, message));
        }
    }
}
