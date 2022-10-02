using RealEstate.EntityLayer.Entities;
using RealEstate.FacadeLayer.Connection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealEstate.FacadeLayer.DAL
{
    public class DALCategory
    {
        // sınıftan nesne türetmeden sınıfın içindeki değerleri ulaşmak için static kullanılır.
        public static List<Category> CategoryList()
        {

            List<Category> categories = new List<Category>();

            DbConnection.sqlConnection.Open();

            SqlCommand command = new SqlCommand("Select * from TblCategory", DbConnection.sqlConnection);

            //if (command.Connection.State!=System.Data.ConnectionState.Open)
            //{
            //    command.Connection.Open();
            //}

            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                Category category = new Category();
                category.CategoryID = int.Parse(dataReader["CategoryID"].ToString());
                category.CategoryName = dataReader["CategoryName"].ToString();
                categories.Add(category);
            }
            DbConnection.sqlConnection.Close();
            return categories;  
        }

        public static void AddCategory(Category category)
        {

            DbConnection.sqlConnection.Open();
            SqlCommand command = new SqlCommand("insert into TblCategory (CategoryName) values(@p1)", DbConnection.sqlConnection);
            command.Parameters.AddWithValue("@p1", category.CategoryName);
            command.ExecuteNonQuery();
            DbConnection.sqlConnection.Close();
        }

        public static void DeleteCategory(int id)
        {
            DbConnection.sqlConnection.Open();
            SqlCommand command= new SqlCommand("Delete from TblCategory Where CategoryId=@p1", DbConnection.sqlConnection);
            command.Parameters.AddWithValue("@p1", id);

            DialogResult msg = MessageBox.Show("Silmek istediğinize emin misiniz?", "İşlem", MessageBoxButtons.YesNo);
            if (msg==DialogResult.Yes)
                command.ExecuteNonQuery();

            DbConnection.sqlConnection.Close();
        }


        public static void UpdateCategory(Category category)
        {
            DbConnection.sqlConnection.Open();
            SqlCommand command = new SqlCommand("Update TblCategory set  CategoryName=@p1 where CategoryID=@p2", DbConnection.sqlConnection);
            command.Parameters.AddWithValue("@p1", category.CategoryName);
            command.Parameters.AddWithValue("@p2", category.CategoryID);

            DialogResult msg = MessageBox.Show("Güncellemek istediğinize emin misiniz?", "İşlem", MessageBoxButtons.YesNo);
            if (msg == DialogResult.Yes)
                command.ExecuteNonQuery();

            DbConnection.sqlConnection.Close();
        }
    }
}
