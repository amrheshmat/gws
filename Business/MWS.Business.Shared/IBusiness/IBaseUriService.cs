namespace MWS.Business.Shared.IBusiness
{
    public interface IBaseUriService
    {
        string getBaseUrl(HttpRequestMessage Request = null);

        string addParameterToUrl(string url, string parameterName, string value);

        string getAbsoluteUrl();

    }

}
