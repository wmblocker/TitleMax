using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TitleMax
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            initializeData();
            searchByLoanControl.Visible = false;
            searchByPropertyControl.Visible = false;
            hideComponents();
        }

        private void initializeData()
        {
            // TODO: This line of code loads data into the 'titlemaxDataSet.Sellers' table. You can move, or remove it, as needed.
            this.sellersTableAdapter.Fill(this.titlemaxDataSet.Sellers);
            // TODO: This line of code loads data into the 'titlemaxDataSet.Property_Information' table. You can move, or remove it, as needed.
            this.property_InformationTableAdapter.Fill(this.titlemaxDataSet.Property_Information);
            // TODO: This line of code loads data into the 'titlemaxDataSet.Loans' table. You can move, or remove it, as needed.
            this.loansTableAdapter.Fill(this.titlemaxDataSet.Loans);
            // TODO: This line of code loads data into the 'titlemaxDataSet.Listing_Agreement' table. You can move, or remove it, as needed.
            this.listing_AgreementTableAdapter.Fill(this.titlemaxDataSet.Listing_Agreement);
            // TODO: This line of code loads data into the 'titlemaxDataSet.Lien' table. You can move, or remove it, as needed.
            this.lienTableAdapter.Fill(this.titlemaxDataSet.Lien);
            // TODO: This line of code loads data into the 'titlemaxDataSet.Hardships' table. You can move, or remove it, as needed.
            this.hardshipsTableAdapter.Fill(this.titlemaxDataSet.Hardships);
            // TODO: This line of code loads data into the 'titlemaxDataSet.Conversation_Log' table. You can move, or remove it, as needed.
            this.conversation_LogTableAdapter.Fill(this.titlemaxDataSet.Conversation_Log);
            // TODO: This line of code loads data into the 'titlemaxDataSet.Contracts' table. You can move, or remove it, as needed.
            this.contractsTableAdapter.Fill(this.titlemaxDataSet.Contracts);
            // TODO: This line of code loads data into the 'titlemaxDataSet.Condo_HOA_Information' table. You can move, or remove it, as needed.
            this.condo_HOA_InformationTableAdapter.Fill(this.titlemaxDataSet.Condo_HOA_Information);
            // TODO: This line of code loads data into the 'titlemaxDataSet.Cases' table. You can move, or remove it, as needed.
            this.casesTableAdapter.Fill(this.titlemaxDataSet.Cases);
            // TODO: This line of code loads data into the 'titlemaxDataSet.Buyers' table. You can move, or remove it, as needed.
            this.buyersTableAdapter.Fill(this.titlemaxDataSet.Buyers);
            // TODO: This line of code loads data into the 'titlemaxDataSet.Borrower' table. You can move, or remove it, as needed.
            this.borrowerTableAdapter.Fill(this.titlemaxDataSet.Borrower);
            // TODO: This line of code loads data into the 'titlemaxDataSet.Agents' table. You can move, or remove it, as needed.
            this.agentsTableAdapter.Fill(this.titlemaxDataSet.Agents);
        }

        private void searchByCaseNumButton_Click(object sender, EventArgs e)
        {
            searchByCase();
            showComponents();
        }

        private void searchByCase()
        {
            case_NumToolStripTextBox.Text = searchByCaseNumberInput.Text;
            try
            {
                this.casesTableAdapter.Where(this.titlemaxDataSet.Cases, ((int)(System.Convert.ChangeType(case_NumToolStripTextBox.Text, typeof(int)))));
                int seller_ssn = ((int)(System.Convert.ChangeType((dataGridView1.Rows[0].Cells[1].Value), typeof(int))));
                String property_address = ((String)(System.Convert.ChangeType((dataGridView1.Rows[0].Cells[2].Value), typeof(String))));
                this.property_InformationTableAdapter.FindByPropertyAddress(this.titlemaxDataSet.Property_Information, property_address);
                this.sellersTableAdapter.FindSellerBySSN(this.titlemaxDataSet.Sellers, seller_ssn);
                this.contractsTableAdapter.FindBySeller_SSN(this.titlemaxDataSet.Contracts, seller_ssn);
                int buyer_ssn = ((int)(System.Convert.ChangeType((dataGridView7.Rows[0].Cells[1].Value), typeof(int))));
                this.buyersTableAdapter.FindByBuyerSSN(this.titlemaxDataSet.Buyers, buyer_ssn);
                this.listing_AgreementTableAdapter.FindListingBySellerSSN(this.titlemaxDataSet.Listing_Agreement, seller_ssn);
                String agent_license_num = ((String)(System.Convert.ChangeType((dataGridView8.Rows[0].Cells[1].Value), typeof(String))));
                this.agentsTableAdapter.FindByAgentLicense(this.titlemaxDataSet.Agents, agent_license_num);

            }
            catch (System.Exception ex)
            {
                if (ex.GetType().Equals(typeof(InvalidCastException)))
                {
                    System.Windows.Forms.MessageBox.Show("The case number that you entered could not be found");
                    hideComponents();
                }
                if (ex.GetType().Equals(typeof(ArgumentNullException)))
                {
                    System.Windows.Forms.MessageBox.Show("Some fields could not be found");
                    showComponents();
                }
            }
        }

        private void searchByCaseNumbe_Click(object sender, EventArgs e)
        {
            hideComponents();
            searchByLoanControl.Visible = false;
            searchByPropertyControl.Visible = false;
            searchByCaseControl.Visible = true;
        }

        private void searchByProperty_Click(object sender, EventArgs e)
        {
            hideComponents();
            searchByLoanControl.Visible = false;
            searchByPropertyControl.Visible = true;
            searchByCaseControl.Visible = false;
        }

        //THIS IS THE UPDATE BUTTON ONCLICK EVENT
        private void button2_Click(object sender, EventArgs e)
        {

            this.sellersTableAdapter.Update(this.titlemaxDataSet.Sellers);
        
            this.property_InformationTableAdapter.Update(this.titlemaxDataSet.Property_Information);

            this.loansTableAdapter.Update(this.titlemaxDataSet.Loans);

            this.listing_AgreementTableAdapter.Update(this.titlemaxDataSet.Listing_Agreement);

            //this.lienTableAdapter.Fill(this.titlemaxDataSet.Lien);

            this.conversation_LogTableAdapter.Update(this.titlemaxDataSet.Conversation_Log);

            this.contractsTableAdapter.Update(this.titlemaxDataSet.Contracts);


            this.casesTableAdapter.Update(this.titlemaxDataSet.Cases);

            this.buyersTableAdapter.Update(this.titlemaxDataSet.Buyers);

            this.borrowerTableAdapter.Update(this.titlemaxDataSet.Borrower);

            this.agentsTableAdapter.Update(this.titlemaxDataSet.Agents);
            MessageBox.Show("All tables have been updated");
        }

        //THIS IS THE CANCEL CHANGES ONCLICK EVENT
        private void button1_Click(object sender, EventArgs e)
        {
            sellersBindingSource.CancelEdit();
            propertyInformationBindingSource.CancelEdit();
            listingAgreementBindingSource.CancelEdit();
            loansBindingSource.CancelEdit();
            contractsBindingSource.CancelEdit();
            casesBindingSource.CancelEdit();
            buyersBindingSource.CancelEdit();
            borrowerBindingSource.CancelEdit();
            agentsBindingSource.CancelEdit();
            MessageBox.Show("All edits have been canceled");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //THIS IS THE Search By Property Address OnClick Event
        private void button7_Click(object sender, EventArgs e)
        {
            searchByAddress();
        }

        private void searchByAddress()
        {
            String address = textBox40.Text + " " + textBox39.Text;
            try
            {
                this.casesTableAdapter.FindByPropertyAddress(this.titlemaxDataSet.Cases, ((String)(System.Convert.ChangeType(address, typeof(String)))));
                int seller_ssn = ((int)(System.Convert.ChangeType((dataGridView1.Rows[0].Cells[1].Value), typeof(int))));
                String property_address = ((String)(System.Convert.ChangeType((dataGridView1.Rows[0].Cells[2].Value), typeof(String))));
                this.property_InformationTableAdapter.FindByPropertyAddress(this.titlemaxDataSet.Property_Information, property_address);
                this.sellersTableAdapter.FindSellerBySSN(this.titlemaxDataSet.Sellers, seller_ssn);
                this.contractsTableAdapter.FindBySeller_SSN(this.titlemaxDataSet.Contracts, seller_ssn);
                int buyer_ssn = ((int)(System.Convert.ChangeType((dataGridView7.Rows[0].Cells[1].Value), typeof(int))));
                this.buyersTableAdapter.FindByBuyerSSN(this.titlemaxDataSet.Buyers, buyer_ssn);
                this.listing_AgreementTableAdapter.FindListingBySellerSSN(this.titlemaxDataSet.Listing_Agreement, seller_ssn);
                String agent_license_num = ((String)(System.Convert.ChangeType((dataGridView8.Rows[0].Cells[1].Value), typeof(String))));
                this.agentsTableAdapter.FindByAgentLicense(this.titlemaxDataSet.Agents, agent_license_num);
                showComponents();
            }
            catch (System.Exception ex)
            {
                if (ex.GetType().Equals(typeof(InvalidCastException)))
                {
                    System.Windows.Forms.MessageBox.Show("The property address that you entered could not be found");
                    hideComponents();
                }
                if (ex.GetType().Equals(typeof(ArgumentNullException)))
                {
                    System.Windows.Forms.MessageBox.Show("Some fields could not be found");
                    showComponents();
                }
            }
        }

        //THIS IS THE Search by Loan Button to show the search box
        private void button3_Click(object sender, EventArgs e)
        {
            hideComponents();
            searchByPropertyControl.Visible = false;
            searchByCaseControl.Visible = false;
            searchByLoanControl.Visible = true;
        }

        private void searchByLoan()
        {
            long loan_number = ((long)(System.Convert.ChangeType(loanNumberInput.Text, typeof(long))));
            try
            {
                this.loansTableAdapter.FindByLoanNum(this.titlemaxDataSet.Loans, loan_number);
                this.conversation_LogTableAdapter.FindConversationByLoan(this.titlemaxDataSet.Conversation_Log, loan_number);
                showComponents();
            }
            catch (System.Exception ex)
            {
                if (ex.GetType().Equals(typeof(InvalidCastException)))
                {
                    System.Windows.Forms.MessageBox.Show("The loan number that you entered could not be found");
                    hideComponents();
                }
                if (ex.GetType().Equals(typeof(ArgumentNullException)))
                {
                    System.Windows.Forms.MessageBox.Show("Some fields could not be found");
                    showComponents();
                }
            }
        }

        //Search By Loan OnClick Event
        private void loanNumberSearchButton_Click(object sender, EventArgs e)
        {
            searchByLoan();
        }

        private void showComponents()
        {
            button1.Visible = true;
            button2.Visible = true;
            dataGridView1.Visible = true;
            infoControl.Visible = true;
        }

        private void hideComponents()
        {
            button1.Visible = false;
            button2.Visible = false;
            dataGridView1.Visible = false;
            infoControl.Visible = false;
        }
    }
}
