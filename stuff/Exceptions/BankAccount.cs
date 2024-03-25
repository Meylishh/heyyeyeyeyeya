using System;
using stuff.Carsss;

namespace stuff.Exceptions
{
    /*Создайте класс, представляющий банковский счет, с полями для хранения баланса и номера счета.
Напишите метод для списания средств со счета, который будет принимать сумму списания в качестве параметра.
Обеспечьте обработку исключений для следующих ситуаций:
Попытка списания суммы, превышающей текущий баланс.
Попытка списания отрицательной суммы.
Используйте блоки try, catch для обработки исключений.
В блоке catch выведите сообщение об ошибке.*/
    
    public class BankAccount
    { 
        public float Money { get; private set; }
        public readonly int AccountNumber;

        public BankAccount()
        {
            AccountNumber = AccountNumber.GetHashCode();
            Money = 1000;
        }

        private void WriteOffMoney(float amount)
        {
            if (amount > Money)
            {
                throw new InsufficientFundsException();
            }
            
            if(amount < 0)
            {
                throw new WriteOffNegativeNumberException();
            }

            Money -= amount;
        }

        public void HandleWriteOffMoney(float amount)
        {
            try
            {
                WriteOffMoney(amount);
            }
            catch (InsufficientFundsException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (WriteOffNegativeNumberException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Unexpected error: " + exception.Message);
            }
            finally
            {
                Console.WriteLine($"Current money: {Money}");
            }
        }
    }

    public class InsufficientFundsException : Exception
    {
        public override string Message { get; } = "Insufficient Funds Exception: couldn't write off money, " +
                                                  "since the amount is bigger than current bank account's money";
    }
    public class WriteOffNegativeNumberException : Exception
    {
        public override string Message { get; } = "Write Off Negative Number Exception: couldn't write off money, since the number of money to write off was negative";
    }
}