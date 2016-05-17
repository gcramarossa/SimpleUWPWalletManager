using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// Il modello di elemento per la pagina vuota è documentato all'indirizzo http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x410

namespace WalletManager
{
    /// <summary>
    /// Pagina vuota che può essere utilizzata autonomamente oppure esplorata all'interno di un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Wallet wallet;

        public MainPage()
        {
            this.InitializeComponent();
            wallet = new Wallet();
        }

        /// <summary>
        /// Executed when a user press the button "Add"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, RoutedEventArgs e)
        {
            ListView list = credits;

            if (addCredit.IsChecked == false)
            {
                list = debits;
            }

            try
            {
                AddItemToListView(list, reason.Text, float.Parse(value.Text));
                wallet.AddPayment(reason.Text, float.Parse(value.Text), addCredit.IsChecked.Value);
                textBlock.Text = wallet.MoneyCounter.ToString("c");
            }
            catch (FormatException exc)
            {
                value.Text = "Value is not a number. Please correct it";
            }
        }

        /// <summary>
        /// Adds an item to a ListView
        /// </summary>
        /// <param name="list">ListView target</param>
        /// <param name="reason">Reason</param>
        /// <param name="value">Value</param>
        private void AddItemToListView(ListView list, string reason, float value)
        {
            ListBoxItem item = new ListBoxItem();
            item.Content = "" + value.ToString() + Environment.NewLine + reason;
            list.Items.Add(item);
        }
    }
}
