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
           

            // Act
           

            // Assert
        }

        [Test]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange


            // Act


            // Assert
        }

        [Test]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // Arrange


            // Act


            // Assert
        }

        [Test]
        public void Credit_WhenCreditIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange


            // Act


            // Assert
        }
    }
}