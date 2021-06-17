using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Zajecia_PS04.Models;
using Microsoft.Extensions.Configuration;
using System.Runtime;

namespace Zajecia_PS04.DAL
{
    public class ProductXmlDB : IproductDB
    {
        XmlDocument xmldoc = new XmlDocument();
        string xmlDBPath;

        public ProductXmlDB(IConfiguration _configuration)
        {
            xmlDBPath= _configuration.GetValue<string>("AppSettings:XmlDB_Path");
            LoadDB();
        }

        private void LoadDB()
        {
            xmldoc.Load(xmlDBPath);
        }
        private void SaveDB()
        {
            xmldoc.Save(xmlDBPath);
        }

        private Product XmlNodeToProduct(XmlNode x)
        {
            Product y = new Product();

            y.id = Convert.ToInt32(x.Attributes["id"].Value);
            y.name = Convert.ToString(x["name"].InnerText);
            y.price = decimal.Parse(x["price"].InnerText);
            y.Category = CatGet(Convert.ToInt32(x["category"].InnerText)).ShortName;
            y.CategoryLongName = CatGet(Convert.ToInt32(x["category"].InnerText)).LongName;
            return y;
        }
        private Category XmlNodeToCategory(XmlNode x)
        {
            Category y = new Category();
            y.Id = Convert.ToInt32(x.Attributes["id"].Value);
            y.ShortName = Convert.ToString(x["ShortName"].InnerText);
            y.LongName = Convert.ToString(x["LongName"].InnerText);

            return y;
        }


        public List<Product> List()
        {
            List<Product> prodlist = new List<Product>();
            XmlNodeList xmlList = xmldoc.SelectNodes("/store/product");

            foreach (XmlNode x in xmlList)
            {
                prodlist.Add(XmlNodeToProduct(x));
            }

            return prodlist;
        }
        public Product Get(int _id)
        {
            XmlNode node = null;
            XmlNodeList xmlList = xmldoc.SelectNodes("/store/product[@id="+_id.ToString()+"]");
            node = xmlList[0];

            Product x = XmlNodeToProduct(node);
 
            return x;
        }
        public int Update(Product _product)
        {
            LoadDB();
            XmlNode node = xmldoc.SelectSingleNode("/store/product[@id=" + _product.id.ToString() + "]");
            node["name"].InnerText = _product.name;
            node["price"].InnerText = Convert.ToString(_product.price);
            SaveDB();

            return 0;
        }
        public int Delete(int _id)
        {
            System.Diagnostics.Debug.WriteLine(_id);

            LoadDB();
            XmlNode node = xmldoc.SelectSingleNode("/store/product[@id=" + _id.ToString() + "]");
            XmlNode ParentNode = xmldoc.SelectSingleNode("/store");

            ParentNode.RemoveChild(node);

            SaveDB();

            return 0;
        }
        public int Add(Product _product)
        {
            LoadDB();

            XmlNode nodex = xmldoc.CreateElement("product");
            XmlNode namenode = xmldoc.CreateElement("name");
            XmlNode pricenode = xmldoc.CreateElement("price");
            XmlNode category = xmldoc.CreateElement("category");

            XmlAttribute idati = xmldoc.CreateAttribute("id");
            idati.Value = Convert.ToString(GenerateProductID());

            nodex.Attributes.Append(idati);

            namenode.InnerText = _product.name;
            pricenode.InnerText = Convert.ToString(_product.price);
            category.InnerText = Convert.ToString(GetCategoryID(_product.Category));

            XmlNodeList xmlList = xmldoc.SelectNodes("/store/product");
            XmlNode ParentNode = xmldoc.SelectSingleNode("/store");
            ParentNode.InsertAfter(nodex,xmlList[xmlList.Count-1]);

            nodex.AppendChild(namenode);
            nodex.AppendChild(pricenode);
            nodex.AppendChild(category);

            SaveDB();
            return 0;
        }

        private int GenerateProductID()
        {
            LoadDB();
            int maxid = -200;
            XmlNodeList xmlList = xmldoc.SelectNodes("/store/product");

            foreach(XmlNode nodea in xmlList)
            {
                maxid = Math.Max(Convert.ToInt32(nodea.Attributes["id"].Value), maxid);
            }
            return maxid+=1;
        }

        private int GenerateCategoryID()
        {
            LoadDB();
            int maxid = -200;
            XmlNodeList xmlList = xmldoc.SelectNodes("/store/category");

            foreach (XmlNode nodea in xmlList)
            {
                maxid = Math.Max(Convert.ToInt32(nodea.Attributes["id"].Value), maxid);
            }
            return maxid += 1;
        }

        //Querki na kategorie
        public List<Category> CatList()
        {
            LoadDB();
            List<Category> CategoryList = new List<Category>();

            XmlNodeList xmllist = xmldoc.SelectNodes("/store/category");

            foreach(XmlNode x in xmllist)
            {
                CategoryList.Add(XmlNodeToCategory(x));
            }
         
            return CategoryList;
        }

        private int GetCategoryID(string ShortName)
        {
            LoadDB();
            
            foreach(Category c in CatList())
            {
                if(c.ShortName==ShortName)
                {
                    return c.Id;
                }
            }
            return 0;

        }

        public Category CatGet(int _id)
        {
            LoadDB();

            XmlNode node = null;
            XmlNodeList xmlList = xmldoc.SelectNodes("/store/category[@id=" + _id.ToString() + "]");
            node = xmlList[0];

            Category x = XmlNodeToCategory(node);

            return x;
        }
        public int CatUpdate(Category _category)
        {
            LoadDB();
            XmlNode node = xmldoc.SelectSingleNode("/store/category[@id=" + _category.Id.ToString() + "]");
            node["ShortName"].InnerText = Convert.ToString(_category.ShortName);
            node["LongName"].InnerText = Convert.ToString(_category.LongName);
            SaveDB();

            return 0;
        }
        public int CatDelete(int _id)
        {
            LoadDB();
            XmlNode node = xmldoc.SelectSingleNode("/store/category[@id=" + _id.ToString() + "]");
            XmlNode ParentNode = xmldoc.SelectSingleNode("/store");

            ParentNode.RemoveChild(node);

            SaveDB();

            return 0;
        }
        public int CatAdd(Category _category)
        {
            LoadDB();

            XmlNode nodex = xmldoc.CreateElement("category");
            XmlNode shortnamenode = xmldoc.CreateElement("ShortName");
            XmlNode longnamenode = xmldoc.CreateElement("LongName");

            XmlAttribute idati = xmldoc.CreateAttribute("id");
            idati.Value = Convert.ToString(GenerateCategoryID());

            nodex.Attributes.Append(idati);

            shortnamenode.InnerText = Convert.ToString(_category.ShortName);
            longnamenode.InnerText = Convert.ToString(_category.LongName);

            XmlNodeList xmlList = xmldoc.SelectNodes("/store/category");
            XmlNode ParentNode = xmldoc.SelectSingleNode("/store");
            ParentNode.InsertAfter(nodex, xmlList[xmlList.Count - 1]);

            nodex.AppendChild(shortnamenode);
            nodex.AppendChild(longnamenode);

            SaveDB();
            return 0;
        }


    }
}
