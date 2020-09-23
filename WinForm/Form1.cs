using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic;
using Microsoft.Win32;

namespace WinForm
{
    public partial class Form1 : Form
    {
       private BindingList<BankAccount> m_bankAccounts = new BindingList<BankAccount>();

        public Form1()
        {
            InitializeComponent();
            BindList();
        }

        private void BindList()
        {
            lstAccounts.DataSource = null;
            lstAccounts.DataSource = m_bankAccounts;
            lstAccounts.DisplayMember = nameof(BankAccount.AccountInfo);
            lstAccounts.ValueMember = nameof(BankAccount.CustomerName);
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtKonto.Text))
            {
                m_bankAccounts.Add(new BankAccount(txtKonto.Text,0));
            }
        }

        private void btnDebit_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtAmount.Text, out double amount))
            {
                var bankAccount = (BankAccount) lstAccounts.SelectedItem;
                bankAccount.Debit(amount);
                BindList();
            }
        }

        private void btnCredit_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtAmount.Text, out double amount))
            {
                var bankAccount = (BankAccount)lstAccounts.SelectedItem;
                bankAccount.Credit(amount);
                BindList();
            }
        }
    }
}
