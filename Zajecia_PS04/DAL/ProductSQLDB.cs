using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Text;
using Zajecia_PS04.Models;
using System.Xml;
using Zajecia_PS04.DAL;
using System.Data;

namespace Zajecia_PS04.DAL
{
    public class ProductSQLDB : IproductDB
    {
        
        string ConnectionString;
        SqlConnection connection = new SqlConnection();

        public ProductSQLDB(IConfiguration _configuration)
        {
            ConnectionString = _configuration.GetConnectionString("myCompanyDB");
            connection.ConnectionString = ConnectionString;
        }

        public List<Product> List()
        {
            List<Product> ProductList = new List<Product>();

            SqlCommand cmd = new SqlCommand("sp_GetProductList", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Product x = new Product
                {
                    id = Convert.ToInt32(reader["Id"]),
                    name = reader.GetString(1),
                    price = Convert.ToDecimal(reader["Price"]),
                    Category = Convert.ToString(reader["Category"])
                };
                ProductList.Add(x);
            }
            reader.Close();
            connection.Close();

            return ProductList;
        }
        public Product Get(int _id)
        {
            Product foundedProduct = new Product();

            SqlCommand cmd = new SqlCommand("sp_DetailProduct", connection);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter id_DetailParam = new SqlParameter("@Id", System.Data.SqlDbType.Int);
            id_DetailParam.Value = _id;
            cmd.Parameters.Add(id_DetailParam);

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Product x = new Product
                {
                    id = Convert.ToInt32(reader["Id"]),
                    name = reader.GetString(1),
                    price = Convert.ToDecimal(reader["Price"]),
                    CategoryLongName = Convert.ToString(reader["CategoryLong"])
                };
                foundedProduct = x;
            }
            reader.Close();
            connection.Close();

            return foundedProduct;
        }
        public int Update(Product _product)
        {
            SqlCommand cmd = new SqlCommand("sp_EditProduct", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter sql_EditidParam = new SqlParameter("@Id", System.Data.SqlDbType.Int);
            sql_EditidParam.Value = _product.id;
            cmd.Parameters.Add(sql_EditidParam);

            SqlParameter sql_EditnameParam = new SqlParameter("@Name", System.Data.SqlDbType.NVarChar, 50);
            sql_EditnameParam.Value = _product.name;
            cmd.Parameters.Add(sql_EditnameParam);

            SqlParameter sql_EditpriceParam = new SqlParameter("@price", System.Data.SqlDbType.Money);
            sql_EditpriceParam.Value = _product.price;
            cmd.Parameters.Add(sql_EditpriceParam);

            SqlParameter sql_EditCategoryParam = new SqlParameter("@Category", SqlDbType.NVarChar, 100);
            sql_EditCategoryParam.Value = _product.Category;
            cmd.Parameters.Add(sql_EditCategoryParam);

            connection.Open();

            cmd.ExecuteNonQuery();

            connection.Close();

            return 0;
        }
        public int Delete(int _id)
        {
            SqlCommand cmd = new SqlCommand("sp_DeleteProduct", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter productID_SqlParam = new SqlParameter("@Id", SqlDbType.Int);
            productID_SqlParam.Value = _id;
            cmd.Parameters.Add(productID_SqlParam);

            connection.Open();

            cmd.ExecuteNonQuery();

            connection.Close();
            return 0;
        }
        public int Add(Product _product)
        {
            SqlCommand cmd = new SqlCommand("sp_productAdd", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter name_SqlParam = new SqlParameter("@name", SqlDbType.VarChar, 50);
            name_SqlParam.Value = _product.name;
            cmd.Parameters.Add(name_SqlParam);

            SqlParameter price_SqlParam = new SqlParameter("@price", SqlDbType.Money);
            price_SqlParam.Value = _product.price;
            cmd.Parameters.Add(price_SqlParam);

            SqlParameter productID_SqlParam = new SqlParameter("@productID", SqlDbType.Int);
            productID_SqlParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(productID_SqlParam);

            SqlParameter productCategory_SqlParam = new SqlParameter("@Category", SqlDbType.NVarChar, 100);
            productCategory_SqlParam.Value = _product.Category;
            cmd.Parameters.Add(productCategory_SqlParam);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

            return 0;
        }

        //Polecenia do kategori

        public List<Category> CatList()
        {
            List<Category> Categories = new List<Category>();

            SqlCommand cmd = new SqlCommand("sp_GetCategoryList", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Category x = new Category { Id = Convert.ToInt32(reader["Id"]), ShortName = Convert.ToString(reader["ShortName"]), LongName = Convert.ToString(reader["LongName"]) };
                Categories.Add(x);
            }
            connection.Close();

            return Categories;
        }
        public Category CatGet(int _id)
        {
            Category DetailCategory = new Category();

            SqlCommand cmd = new SqlCommand("sp_DetailCategory", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter id_DetailParam = new SqlParameter("@Id", System.Data.SqlDbType.Int);
            id_DetailParam.Value = _id;
            cmd.Parameters.Add(id_DetailParam);

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Category x = new Category
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    ShortName = Convert.ToString(reader["ShortName"]),
                    LongName = Convert.ToString(reader["LongName"])
                };
                DetailCategory = x;
            }
            reader.Close();
            connection.Close();

            return DetailCategory;
        }
        public int CatUpdate(Category _category)
        {
            SqlCommand cmd = new SqlCommand("sp_EditCategory", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter ShortNameParam = new SqlParameter("@ShortName", SqlDbType.NVarChar, 50);
            ShortNameParam.Value = _category.ShortName;
            cmd.Parameters.Add(ShortNameParam);

            SqlParameter LongNameParam = new SqlParameter("@LongName", SqlDbType.NVarChar, 200);
            LongNameParam.Value = _category.LongName;
            cmd.Parameters.Add(LongNameParam);

            SqlParameter IdParam = new SqlParameter("@ID", SqlDbType.Int);
            IdParam.Value = _category.Id;
            cmd.Parameters.Add(IdParam);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            return 0;
        }
        public int CatDelete(int _id)
        {
            SqlCommand cmd = new SqlCommand("sp_DeleteCategory", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter IdParam = new SqlParameter("@Id", SqlDbType.Int);
            IdParam.Value = _id;
            cmd.Parameters.Add(IdParam);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            return 0;
        }
        public int CatAdd(Category _category)
        {
            SqlCommand cmd = new SqlCommand("sp_AddCategory", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter ShortNameParam = new SqlParameter("@ShortName", SqlDbType.NVarChar, 50);
            ShortNameParam.Value = _category.ShortName;
            cmd.Parameters.Add(ShortNameParam);

            SqlParameter LongNameParam = new SqlParameter("@LongName", SqlDbType.NVarChar, 200);
            LongNameParam.Value = _category.LongName;
            cmd.Parameters.Add(LongNameParam);

            SqlParameter CategoryIDParam = new SqlParameter("@CategoryID", SqlDbType.Int);
            CategoryIDParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(CategoryIDParam);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            return 0;
        }



    }
}
