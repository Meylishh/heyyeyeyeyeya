using System.Threading;

namespace stuff.Bank
{
    public static class WalletOperations
    {
        public static void IncreaseBalanceByPercent(ref float balance, float percent)
        {
            var percentOfBalance = balance / 100 * percent;
            balance += percentOfBalance;
        }

        public static bool TryPurchase(float cost, float balance, out float newBalance)
        {
            newBalance = balance;
            if (cost > balance)
            {
                return false;
            }
            newBalance -= cost;
            return true;
        }
        
    }
}