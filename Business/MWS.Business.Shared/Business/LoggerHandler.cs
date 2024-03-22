using ElmahCore;
using Microsoft.Extensions.Logging;
using MWS.Business.Shared.CustomExceptions;
using MWS.Business.Shared.IBusiness;

namespace MWS.Business.Shared.Business
{
    public class LoggerHandler<T> : ILoggerHandler<T> where T : class
    {
        #region fields
        public ILogger _logger;
        private ILoggerFactory MyLoggerFactory { get; set; }
        #endregion
        #region constructor(s)
        public LoggerHandler(ILogger<T> logger)
        {

            _logger = logger;
        }
        #endregion
        #region methods
        public void logError(Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            ElmahExtensions.RaiseError(ex);
        }
        public Task logErrorAsync(Exception ex)
        {
            throw new NotImplementedException();
        }
        public void logWarning(Exception ex)
        {
            _logger.LogWarning(ex, ex.Message);
            ElmahExtensions.RaiseError(ex);
        }
        public Task logWarningAsync(Exception ex)
        {
            throw new NotImplementedException();
        }
        public void logWarning(string message)
        {
            var ex = new WarningException(message);
            _logger.LogWarning(ex, message);
            ElmahExtensions.RaiseError(ex);
        }
        public Task logWarningAsync(string message)
        {
            throw new NotImplementedException();
        }
        public void logInformation(Exception ex)
        {
            _logger.LogWarning(ex, ex.Message);
            ElmahExtensions.RaiseError(ex);
        }
        public Task logInformationAsync(Exception ex)
        {
            throw new NotImplementedException();
        }
        public void logInformation(string message)
        {
            var ex = new InfoException(message);
            _logger.LogWarning(ex, message);
            ElmahExtensions.RaiseError(ex);
        }
        public Task logInformationAsync(string message)
        {
            throw new NotImplementedException();
        }
        #endregion
    }

}
