//using RealEstate.DataAccessLayer.ConnectionUrl;
using RealEstate.BusinessLayer.Validation;
using RealEstate.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealEstate.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        void Listele()
        {
            List<Category> values = BLCategory.BLCategoryList();
            dataGridView1.DataSource = values;
        }
        private void btnList_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.CategoryName = txtName.Text;
            BLCategory.BLCategoryAdd(category);

            Listele();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            BLCategory.BLCategoryDelete(id);

            Listele();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Category category=new Category();
            category.CategoryID = Convert.ToInt32(txtID.Text);
            category.CategoryName= txtName.Text;
            BLCategory.BLCategoryUpdate(category);

            Listele();

        }
    }
}
