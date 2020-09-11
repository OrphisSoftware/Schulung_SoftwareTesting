using System;
using BusinessLogic;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace NUnitTestProject1
{
    public class BankAccountTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(9.55, ExpectedResult = 10.45, TestName = "Debit_Number_With_Comma")]
        [TestCase(10, ExpectedResult = 10, TestName = "Debit_Number_Without_Comma")]
        public double Debit_WithValidAmount_UpdatesBalance(double amount)
        {
            // Arrange
            var account = new BankAccount("Max Muster", 20.00);

            // Act
            account.Debit(amount);

            // Assert
            return account.Balance;
        }

        [Test]
        public void Credit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            var account = new BankAccount("Max Muster", 100);
            double amount = 50;

            // Act
            account.Credit(amount);

            // Assert
            Assert.AreEqual(150, account.Balance);
        }

        [Test]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange([Values(-100, -200)] int debitValue)
        {
            // Arrange
            BankAccount account = new BankAccount("Mr. Bryan Walton", 10);

            //Act & Assert
            try
            {
                account.Debit(debitValue);
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsTrue(exception.Message.Contains(BankAccount.NegativeValueNotAllowed));
                return;
            }

            throw new Exception("We expected an ArgumentOutOfRangeException...");
        }

        [Test]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            BankAccount account = new BankAccount("Mr. Bryan Walton", 10);
            double debitValue = 100;

            //Act & Assert
            try
            {
                account.Debit(debitValue);
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsTrue(exception.Message.Contains(BankAccount.BalanceToLow));
                return;
            }

            throw new Exception("We expected an ArgumentOutOfRangeException...");
        }

        [Test]
        public void Credit_WhenCreditIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            BankAccount account = new BankAccount("Mr. Bryan Walton", 10);
            double creditValue = -100;

            //Act & Assert
            try
            {
                account.Credit(creditValue);
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsTrue(exception.Message.Contains(BankAccount.NegativeValueNotAllowed));
                return;
            }
            throw new Exception("We expected an ArgumentOutOfRangeException...");
        }
    }
}