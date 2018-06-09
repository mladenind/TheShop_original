namespace TheShop.Contracts.Interfaces
{
    /// <summary>
    /// Logger interface
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Basic message logger that supports multiple levels of logging
        /// </summary>
        /// <param name="level"">Level of logging</param>
        /// <param name="message">Message we want to log</param>
        void WriteMessage(string level, string message);
    }
}
