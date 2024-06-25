using Iyun25_2024_StoreManager.Entities;

namespace Iyun25_2024_StoreManager.Abstraction
{
    public interface IProductManager
    {
        void AddToDepo(string name, decimal price, int count);
        Product GetProductById(int id);
        List<Product> GetAllProducts();
        void DeleteProduct(int id);

        void AddToCategory(string  categoryName);
        ProductCategory GetProductCategoryById(int id);
        void DeleteCategory(int id);
        List<ProductCategory> GetAllCategories();
        void UpdateCategory(int productId, int categoryId);
    }
}
