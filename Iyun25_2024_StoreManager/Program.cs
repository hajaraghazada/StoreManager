

using Iyun25_2024_StoreManager.Managers;


UserManager userManager = new UserManager();
userManager.CreateSystem();
ViewManager view =  new ViewManager(userManager);

view.MainPage();