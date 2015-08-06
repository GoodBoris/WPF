using System.Collections.Generic;
using System.IO;
using AmberCatel.Models;
using AmberCatel.Services.Interfaces;
using Catel.Collections;
using Catel.Data;
using Path = Catel.IO.Path;

namespace AmberCatel.Services
{
    public class AccountService : ISerializerService<Account>
    {
        private readonly string _path;

        public AccountService()
        {
            var directory = Path.GetApplicationDataDirectory();
            _path = Path.Combine(directory, "accounts.xml");
        }
        public IEnumerable<Account> LoadData()
        {
            if (!File.Exists(_path))
                return new Account[] { };
            using (var fileStream = File.Open(_path, FileMode.Open))
            {
                var settings = Settings.Load(fileStream, SerializationMode.Xml);
                return settings.Accounts;
            }
        }

        public void SaveData(IEnumerable<Account> accounts)
        {
            var settings = new Settings();
            settings.Accounts.ReplaceRange(accounts);
            settings.Save(_path, SerializationMode.Xml);
        }

    }
}