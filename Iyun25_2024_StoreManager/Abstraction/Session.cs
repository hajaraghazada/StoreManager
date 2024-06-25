using Iyun25_2024_StoreManager.Entities;

namespace Iyun25_2024_StoreManager.Abstraction
{
    public abstract class Session
    {
        public static User CurrentUser { get; set; }
    }
}
