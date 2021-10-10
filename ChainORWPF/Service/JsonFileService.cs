using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using ChainORWPF.Model;

namespace ChainORWPF.Service
{
    class JsonFileService : IFileService
    {
        public List<User> Open(string fileName)
        {
            var users = new List<User>();
            try
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<User>));
                using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    users = jsonFormatter.ReadObject(fs) as List<User>;
                }
            }
            catch (Exception)
            {
                users = new List<User>();
                User user = new User
                {
                    Code = 123456,
                    Name = "admin",
                    Password = "qwerty"
                };
                users.Add(user);
                Save(fileName, users);
                return users;
            }
            return users;
        }

        public void Save(string fileName, List<User> users)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<User>));
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                jsonFormatter.WriteObject(fs, users);
            }
        }
    }
}
