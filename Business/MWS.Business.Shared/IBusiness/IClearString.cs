namespace MWS.Business.Shared.IBusiness
{
    public interface IClearString
    {
        string clearAll(string input);
        string clearAllButSpaces(string input);

        string trimSave(string input);
    }
}
