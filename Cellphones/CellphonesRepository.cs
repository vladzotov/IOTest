using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;

namespace Cellphones
{
    public class CellphonesRepository : ICellphonesRepository
    {
        public const string RepositoryFilePath = @"D:\CellphonesData\cellphones.txt";

        /// <summary>
        /// Adds phones to the repository
        /// </summary>
        /// <param name="phone">Cellphone</param>
        public void Add(Cellphone phone)
        {
            if (phone == null)
                throw new ArgumentNullException(nameof(phone));

            var phoneString = JsonConvert.SerializeObject(phone);

            using (var streamWriter = new StreamWriter(RepositoryFilePath, true))
                streamWriter.WriteLine(phoneString);
        }

        public IEnumerable<Cellphone> GetAll()
        {
            var phones = File.ReadAllLines(RepositoryFilePath);
            return phones.Select(x => JsonConvert.DeserializeObject<Cellphone>(x));
        }

        public void Remove(int id)
        {
            var phones = GetAll().Where(x => x.Id != id);
            File.Open(RepositoryFilePath, FileMode.Truncate)
                .Close();

            foreach (var phone in phones)
                Add(phone);
        }

        public void Print(IEnumerable<Cellphone> phones)
        {
            foreach (var phone in phones)
                Console.WriteLine(phone);
        }
    }
}
