using Iyun25_2024_StoreManager.Abstraction;
using Iyun25_2024_StoreManager.Entities;

namespace Iyun25_2024_StoreManager.Managers
{
    public class ProductManager : Session, IProductManager
    {
        private int _productId = 1;
        private int _productCategoryId = 1;
        public int _invoiceId = 1;
        public ProductManager()
        {
            DepoProduct = new List<Product>();
            Categories = new List<ProductCategory>();
            Invoices = new List<Invoice>();
        }

        public List<Product> DepoProduct { get; set; }
        private List<ProductCategory> Categories { get; set; }
        public List<Invoice> Invoices { get; set; }

        public void AddToDepo(string name, decimal price, int count)
        {
            var product = new Product
            {
                Id = _productId,
                Name = name,
                Price = price,
            };
            for (int i = 1;  i <= count; i++)
            {
                DepoProduct.Add(product);
            }

            _productId++;
        }

        public Product GetProductById(int id)
        {
            foreach(Product product in DepoProduct)
            {
                if(product.Id == id)
                {
                    return product;
                }
            }
            return null;
        }

        //public Product GetProductByName(string name)
        //{
        //    foreach (Product product in DepoProduct)
        //    {
        //        if (product.Name.Contains(name))
        //        {
        //            return product;
        //        }
        //    }
        //    return null;
        //}

        public List<Product> GetAllProducts()
        {
            return DepoProduct;
        }

        public void DeleteProduct(int id)
        {
            Product product = GetProductById(id);
            DepoProduct.Remove(product);
        }

        public void AddToCategory(string categoryName)
        {
          ProductCategory category = new ProductCategory
            {
                Id = _productCategoryId,
                Name = categoryName,
            };
            Categories.Add(category);
            _productCategoryId++;
        }

        public void DeleteCategory(int id)
        {
           ProductCategory category = GetProductCategoryById(id);
            Categories.Remove(category);
        }

        public List<ProductCategory> GetAllCategories()
        {
            return Categories;
        }

        public void UpdateCategory(int productId, int categoryId)
        {
           Product product = GetProductById(productId);
            if (categoryId == 0)
            {
                product.Category = null;
            }
            else
            {
                ProductCategory category = GetProductCategoryById(categoryId);
                product.Category = category;
            }
        }

        public ProductCategory GetProductCategoryById(int id)
        {
            foreach(ProductCategory category in Categories)
            {
                if(category.Id == id)
                {
                    return category;
                }
            }
            return null;
        }

    }
}
