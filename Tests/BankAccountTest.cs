using System;
using BusinessLogic;
using NUnit.Framework;

namespace NUnitTestProject1
{
    public class BankAccountTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            var account = new BankAccount("Max Muster", 100);
            double amount = 50;

            // Act
            account.Debit(amount);

            // Assert
            Assert.AreEqual(50, account.Balance);
        }

        [Test]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            BankAccount account = new BankAccount("Mr. Bryan Walton", 10);
            double debitValue = -100;

            //Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Debit(debitValue));
        }

        [Test]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            BankAccount account = new BankAccount("Mr. Bryan Walton", 10);
            double debitValue = 100;

            //Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Debit(debitValue));
        }

        [Test]
        public void Credit_WhenCreditIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            BankAccount account = new BankAccount("Mr. Bryan Walton", 10);
            double creditValue = -100;

            //Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Credit(creditValue));
        }
    }
}