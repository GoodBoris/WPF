using System.Collections.Generic;

namespace AmberCatel.Services.Interfaces
{
    public interface ISerializerService<T>
    {
        IEnumerable<T> LoadData();
        void SaveData(IEnumerable<T> data);
    }
}