using System.Threading;

namespace stuff.Bank
{
    /*1. Напишите метод IncreaseBalanceByPercent( balance, percent), который добавляет к балансу указанный процент. Он ничего не возвращает
     2. Напишите метод для покупки товара bool TryPurchase(cost, balance, newBalance). Метод пытается выполнить покупку, если покупка успешна, то возвращает true и сохраняет новый баланс в newBalance. 
     Если покупка провалена, то возвращает false, и записывает тот же баланс в newBalance.
     Вызовите два этих метода. Второй вызовите дважды, для успешного и неудачного платежа.
     После выполнения каждого метода добавьте вывод текущего баланса и успешности выполнения.
     Прикрепить скрин с кодом методов и их выполнения, а так же консоль с выводом.  */   
    
    public class WebWallet
    {
        public float Balance { get; private set; }

        public void IncreaseBalanceByPercent(float balance, float percent)
        {
            var percentOfBalance = balance / 100 * percent;
            balance += percentOfBalance;
        }

        public bool TryPurchase(float cost, float balance, out float newBalance)
        {
            newBalance = balance;
            if (cost <= balance)
            {
                newBalance -= cost;
                return true;
            }
            return false;
        }
        
    }
}