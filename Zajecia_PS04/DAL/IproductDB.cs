using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zajecia_PS04.Models;

namespace Zajecia_PS04.DAL
{
    public interface IproductDB
    {
        public List<Product> List();
        public Product Get(int _id);
        public int Update(Product _product);
        public int Delete(int _id);
        public int Add(Product _product);

        public List<Category> CatList();
        public Category CatGet(int _id);
        public int CatUpdate(Category _category);
        public int CatDelete(int _id);
        public int CatAdd(Category _category);
    }
}
