using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using Cellphones;
using System.IO;

namespace Cellphones.Test
{
    [TestFixture]
    public class CellphonesRepositoryTests
    {
        private ICellphonesRepository _cellphonesRepository;

        [OneTimeSetUp]
        public void Initialize()
        {
            _cellphonesRepository = new CellphonesRepository(); 
        }

        [SetUp]
        public void CleanUp()
        {
            if (File.Exists(CellphonesRepository.RepositoryFilePath))
                File.Delete(CellphonesRepository.RepositoryFilePath);
        }

        //MethodName_StateUnderTest_ExpectedBehavior

        [Test]
        public void Add_PhoneNotNull_PhoneAdded()
        {
            //Arrange
            var phone = new Cellphone
            {
                Id = 0,
                Manufacturer = "Apple",
                Model = "X",
                Price = 1500
            };

            //Act
            _cellphonesRepository.Add(phone);
            var addedPhone = _cellphonesRepository.GetAll().FirstOrDefault();

            //Assert
            Assert.NotNull(addedPhone);
            Assert.AreEqual(phone.Model, addedPhone.Model);
            Assert.AreEqual(phone.Manufacturer, addedPhone.Manufacturer);
            Assert.AreEqual(phone.Price, addedPhone.Price);
        }

        [Test]
        public void Add_PhoneIsNull_ThrowArgumentNullException()
        {
            //Assert
            Assert.Throws<ArgumentNullException>(() => 
            {
                _cellphonesRepository.Add(null);
            });
        }
    }
}
