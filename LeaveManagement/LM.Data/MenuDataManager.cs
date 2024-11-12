using LM.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Data
{
    public class MenuDataManager
    {
          private readonly DbConnectionHelper _dbConnectionHelper;
          public MenuDataManager()
            {
            _dbConnectionHelper = new DbConnectionHelper();
            }

        //Get All Applications
        public List<MenusModel> GetAllMenus()
        {
            List<MenusModel> menus = new List<MenusModel>();
            using (SqlConnection connection = _dbConnectionHelper.CreateConnection())
            {
                connection.Open();
                SqlCommand command;
                const string Query = "select menuId,menuName,url from Menus";
                command = new SqlCommand(Query, connection);
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {

                    MenusModel menu = new MenusModel();
                    menu.menuId = int.Parse(dataReader["menuId"].ToString());
                    menu.menuName = dataReader["menuName"].ToString();
                    menu.url = dataReader["url"].ToString();
                    menus.Add(menu);
                }
                connection.Close();
                return menus;
            }
            return null;
        }


        //By role
        public List<MenusModel> GetMenusByRole(int roleId)
        {
            List<MenusModel> menus = new List<MenusModel>();
            using (SqlConnection connection = _dbConnectionHelper.CreateConnection())
            {
                connection.Open();
                SqlCommand command;
                const string Query = @"select M.menuId,menuName,url from menus M left join  MenuAccessMaster AM on M.menuId =AM.menuId   where Am.roleId=@roleId order by M.menuId";
                command = new SqlCommand(Query, connection);
                command.Parameters.Add("@roleId", roleId);
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    MenusModel menu = new MenusModel();
                    menu.menuId = int.Parse(dataReader["menuId"].ToString());                  
                    menu.menuName = dataReader["menuName"].ToString();
                    menu.url = dataReader["url"].ToString();                  
                    menus.Add(menu);
                }
                return menus;
                connection.Close();
            }
            return null;
        }


        //Add LeaveType
        public MenusModel AddMenu(MenusModel menu)
        {
            using (SqlConnection connection = _dbConnectionHelper.CreateConnection())
            {
                connection.Open();
                String Query = "insert into Menus  (menuName,url) values (@menuName,@url);select scope_identity()";
                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.Add("@menuName", menu.menuName);
                command.Parameters.Add("@url", menu.url);

                menu.menuId = int.Parse(command.ExecuteScalar().ToString());
                connection.Close();
            }
            return menu;
        }

        public MenuAccessMasterModel AddMenuToRole(MenuAccessMasterModel accessMaster)
        {
            using (SqlConnection connection = _dbConnectionHelper.CreateConnection())
            {
                connection.Open();
                String Query = "insert Into MenuAccessMaster (roleId,menuId) values (@roleId,@menuId);select scope_identity()";
                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.Add("@roleId", accessMaster.roleId);
                command.Parameters.Add("@menuId", accessMaster.menuId);
                accessMaster.accessMasterId = int.Parse(command.ExecuteScalar().ToString());
                connection.Close();
            }
            return accessMaster;
        }



    }
}
