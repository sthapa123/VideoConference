namespace VideoConferenceUtils.Interfaces
{
    public interface ILogHelper
    {
        void Info(string message);
        void InfoFormat(string message, params object[] parameters);

        void Warning(string message);
        void WarningFormat(string message, params object[] parameters);

        void Error(string message);
        void ErrorFormat(string message, params object[] parameters);
    }
}
