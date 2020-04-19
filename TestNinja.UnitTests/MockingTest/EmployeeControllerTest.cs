using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.MockingTest
{
    [TestFixture]
    public class EmployeeControllerTest
    {
        private Mock<IEmployeeStorage> _storage;
        private EmployeeController _employeeController;

        [SetUp]
        public void Setup()
        {
            _storage = new Mock<IEmployeeStorage>();
            _employeeController = new EmployeeController(_storage.Object);
        }
        [Test]
        public void DeleteEmployee_WhenCall_DeleteEmployeeFromDb()
        {
            _storage.Setup(f => f.DeleteEmployee(1));

            _employeeController.DeleteEmployee(1);    
            
            _storage.Verify(s => s.DeleteEmployee(1));
        }


        [Test]
        public void DeleteEmployee_WhenCalled_ReturnActionResult()
        {
            _storage.Setup(f => f.DeleteEmployee(1));

            var result = _employeeController.DeleteEmployee(1);

            Assert.That(result, Is.TypeOf<RedirectResult>());
        }
    }
}