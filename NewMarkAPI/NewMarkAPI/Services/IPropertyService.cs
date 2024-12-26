using NewMarkAPI.Models;

namespace NewMarkAPI.Services
{
    public interface IPropertyService
    {
        Task<IEnumerable<Property>> GetPropertiesFromBlobAsync();
    }
}
