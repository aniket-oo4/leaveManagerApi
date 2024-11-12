using LM.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Data
{
    public  class ActionDataManager
    {
         private readonly DbConnectionHelper _dbConnectionHelper;
         public ActionDataManager()
            {
            _dbConnectionHelper = new DbConnectionHelper();
            }

        //By role
        public List<ActionMasterModel> GetActionsByRole(int roleId)
        {
            List<ActionMasterModel> actions = new List<ActionMasterModel>();
            using (SqlConnection connection = _dbConnectionHelper.CreateConnection())
            {
                connection.Open();
                SqlCommand command;
                const string Query = @"select actionMasterId,roleId,AM.actionId,updatedStatusId,actionName From ActionMaster AM left join Actions A on AM.actionId=A.actionId  where roleId=@roleId  order by Am.actionId";
                command = new SqlCommand(Query, connection);
                command.Parameters.Add("@roleId", roleId);
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    ActionMasterModel action = new ActionMasterModel();
                    action.actionMasterId = int.Parse(dataReader["actionMasterId"].ToString());
                    action.roleId = int.Parse(dataReader["roleId"].ToString());
                    action.actionId = int.Parse(dataReader["actionId"].ToString());
                    action.updatedStatusId = int.Parse(dataReader["updatedStatusId"].ToString());
                    action.actionName = dataReader["actionName"].ToString();
                    actions.Add(action);
                }
                return actions;
                connection.Close();
            }
            return null;
        }

    }
}
