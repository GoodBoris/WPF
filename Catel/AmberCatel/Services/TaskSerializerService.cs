using System;
using System.Collections.Generic;
using AmberCatel.Models;
using AmberCatel.Services.Interfaces;

namespace AmberCatel.Services
{
    public class TaskSerializerService : ISerializerService<Task>
    {
        public IEnumerable<Task> LoadData()
        {
            throw new NotImplementedException();
        }

        public void SaveData(IEnumerable<Task> data)
        {
            throw new NotImplementedException();
        }
    }
}