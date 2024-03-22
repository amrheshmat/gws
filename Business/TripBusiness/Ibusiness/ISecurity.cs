namespace TripBusiness.Ibusiness
{
    public interface ISecurity
    {
        public Task<object> CreateToken(string name, string password);
    }
}
