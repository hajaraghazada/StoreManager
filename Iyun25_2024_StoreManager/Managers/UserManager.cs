using Iyun25_2024_StoreManager.Abstraction;
using Iyun25_2024_StoreManager.Entities;

namespace Iyun25_2024_StoreManager.Managers
{
    public class UserManager : Session
    {
        private int _userId = 1;
        public static List<User> Users { get; set; }
        public static List<Role> Roles { get; set; }


        public void CreateSystem()
        {
            Roles = new List<Role>();
            Role sellRole = new Role
            {
                Id = 1,
                Name = "sell",
            };
            Role invoiceManageRole = new Role
            {
                Id = 2,
                Name = "invoice_manage",
            };
            Role userManageRole = new Role
            {
                Id = 3,
                Name = "user_manage",
            };
            Role productManageRole = new Role
            {
                Id = 4,
                Name = "product_manage"
            };

            Roles.Add(sellRole);
            Roles.Add(invoiceManageRole);
            Roles.Add(userManageRole);
            Roles.Add(productManageRole);


            Users = new List<User>();

            AddUser("Admin", "1");
            SetRoleForUser(1, 1);
            SetRoleForUser(1, 2);
            SetRoleForUser(1, 3);
            SetRoleForUser(1, 4);
        }

        public User GetUserById(int id)
        {
            foreach (var user in Users)
            {
                if(user.Id == id)
                {
                    return user;
                }
            }
            return null;
        }

        public Role GetRoleById(int id)
        {
            foreach (var role in Roles)
            {
                if (role.Id == id)
                {
                    return role;
                }
            }
            return null;
        }

        public bool Login(string username, string password)
        {
            foreach (User user in Users)
            {
                if(user.Name == username && user.Password == password)
                {
                    CurrentUser = user;
                    return true;
                }
            }
            return false;
        }

        public void AddUser(string username, string password)
        {
            var user = new User
            {
                Id = _userId,
                Name = username,
                Password = password,
                Roles = new List<Role>()
            };

            Users.Add(user);
            _userId++;
        }

        public void SetRoleForUser(int userId, int roleId)
        {
            User user = GetUserById(userId);
            Role role = GetRoleById(roleId);
            user.Roles.Add(role);
        }

        public void DeleteUser(int userId)
        {
            User user = GetUserById(userId);
            Users.Remove(user);
        }
    }
}
