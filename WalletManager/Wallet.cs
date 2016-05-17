using Microsoft.WindowsAzure.MobileServices;

namespace WalletManager
{
    class Wallet
    {
        /// <summary>
        /// Contains how much money you have
        /// </summary>
        public double MoneyCounter { get; private set; }

        /// <summary>
        /// Mobile Service client library
        /// </summary>
        MobileServiceClient client = new MobileServiceClient("https://provafinanze.azurewebsites.net");

        /// <summary>
        /// Add a payment
        /// </summary>
        /// <param name="reason">The reason for payment</param>
        /// <param name="value">Value </param>
        /// <param name="isCredit">is it a credit or a debit</param>
        public void AddPayment(string reason, float value, bool isCredit)
        {
            if (!isCredit)
            {
                value = -1 * value;
            }

            MoneyCounter += value;

            SaveItemOnline(reason, value);
        }

        private void SaveItemOnline(string reason, float value)
        {
            WalletItem payment = new WalletItem();
            payment.Reason = reason;
            payment.Value = value;
            client.GetTable<WalletItem>().InsertAsync(payment);
        }
    }
}
