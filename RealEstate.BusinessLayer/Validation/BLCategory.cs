using RealEstate.EntityLayer.Entities;
using RealEstate.FacadeLayer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealEstate.BusinessLayer.Validation
{
    public class BLCategory
    {

        public static List<Category> BLCategoryList()
        {
            //yekisi var mı
            return DALCategory.CategoryList();
        }
        public static void BLCategoryAdd(Category category)
        {
            if (category.CategoryName.Length <= 15 && category.CategoryName != "" && category.CategoryName.Length >= 4)
            {
                DALCategory.AddCategory(category);
            }
            else
            {
                MessageBox.Show("Girilen değer uygun değil", "Hata-Validation");

            }
        }

        public static void BLCategoryDelete(int id)
        {
            if (id != 0)
            {
                DALCategory.DeleteCategory(id);
            }
            else
            {
                MessageBox.Show("ID bilgisi hatalı", "Hata-Validation");

            }
        }

        public static void BLCategoryUpdate(Category category)
        {
            if (category.CategoryName != "" && category.CategoryName.Length >= 5)
            {
                DALCategory.UpdateCategory(category);
            }
            else
            {
                MessageBox.Show("Güncellenen değer uygun değil", "Hata-Validation");
            }
        }
    }
}
