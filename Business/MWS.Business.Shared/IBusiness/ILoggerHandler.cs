namespace MWS.Business.Shared.IBusiness
{
    public interface ILoggerHandler<T>
    {
        public void logError(Exception ex);
        public Task logErrorAsync(Exception ex);
        public void logWarning(Exception ex);
        public Task logWarningAsync(Exception ex);
        public void logWarning(string message);
        public Task logWarningAsync(string message);
        public void logInformation(Exception ex);
        public Task logInformationAsync(Exception ex);
        public void logInformation(string message);
        public Task logInformationAsync(string message);
    }
}
