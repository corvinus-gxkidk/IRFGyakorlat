using Moq;
using NUnit.Framework;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestExample.Abstractions;
using UnitTestExample.Controllers;
using UnitTestExample.Entities;

namespace UnitTestExample.text
{
    public class AccountControllerTestFixture
    {
        [
            Test,
            TestCase("abcd", "false"),
            TestCase("abcd@xyz.com", "true"),
            TestCase("abcd1234", false),
    TestCase("irf@uni-corvinus", false),
    TestCase("irf.uni-corvinus.hu", false),
    TestCase("irf@uni-corvinus.hu", true)
            ]
        public void TestValidateEmail(string email, bool expectedResult)
        {
            // Arrange
            var accountController = new AccountController();
            
            //Act
            var result = accountController.ValidateEmail(email);

            //Assert
            Assert.AreEqual(result, expectedResult);

        }
        [
            Test,
            TestCase("abcd1234", false),
            TestCase("ABCD1234", false),
            TestCase("abcdABCD", false),
            TestCase("abCD12", false),
            TestCase("abCD1234", true),
            TestCase("abCDEF1234", true)
            
           ]
        public void TestValidatePassword(string password, bool expectedResult)
        {
            // Arrange
            var accountController = new AccountController();

            //Act
            var result = accountController.ValidatePassword(password);

            //Assert
            Assert.AreEqual(expectedResult, result);

        }
        [
            Test,
            TestCase("irf@uni-corvinus.hu", "Abcd1234"),
            TestCase("irf@uni-corvinus.hu", "Abcd1234567"),
        ]

        public void TestRegisterHappyPath(string email, string password)
        {
            // Arrange
            var accountManagerMock = new Mock<IAccountManager>(MockBehavior.Strict);
            accountManagerMock.Setup(m => m.CreateAccount(It.IsAny<Account>()))
            .Returns<Account>(a => a);
            var accountController = new AccountController();
            accountController.AccountManager = accountManagerMock.Object;

            //Act
            var result = accountController.Register(email, password);


            //Assert
            Assert.AreEqual(email, result.Email);
            Assert.AreEqual(password, result.Password);
            Assert.AreNotEqual(Guid.Empty, result.ID);
            accountManagerMock.Verify(m => m.CreateAccount(result), Times.Once);
        }
        public void TestRegisterValidateException(string email, string password)
        {
            // Arrange
            var accountController = new AccountController();

            //Act
            //Assert
            try
            {
                accountController.Register(email, password);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOf<ValidationException>(ex);
            }

           
        }
    }
}
