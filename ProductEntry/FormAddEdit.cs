using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductEntry
{
    public partial class FormAddEdit : Form
    {
        private Product proToEdit;
        private bool isAddingProduct;
        public FormAddEdit(string title, Product proToEdit = null)
        {
            InitializeComponent();
            Text = title;
            this.proToEdit = proToEdit;
            isAddingProduct = (title == "Adding Product");
            if (!isAddingProduct && proToEdit != null)
            {
                txtId.Text = proToEdit.Id;
                txtName.Text = proToEdit.Name;
                txtPrice.Text = proToEdit.Price.ToString();
            }
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "" || txtName.Text == "" || txtPrice.Text == null)
            {
                MessageBox.Show("Fill all the info");
                return;
            }
            if (isAddingProduct)
            {
                Product newProduct = new Product
                {
                    Id = txtId.Text,
                    Name = txtName.Text,
                    Price = double.Parse(txtPrice.Text)
                };
                FormProductView.lst.Add(newProduct);
            }
            else
            {
                proToEdit.Id = txtId.Text;
                proToEdit.Name = txtName.Text;
                proToEdit.Price = double.Parse(txtPrice.Text);
            }
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
