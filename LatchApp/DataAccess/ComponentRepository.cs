using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

using LatchApp.Model;

namespace LatchApp.DataAccess
{
    public class ComponentRepository : BaseRepository, IElementRepository<IComponentModel>
    {
        public ComponentRepository() { }

        public ComponentRepository(string connString)
        {
            this._connString = connString;
        }

        public void Add(IComponentModel elementModel)
        {
            string queryString = $"INSERT INTO sql_latch_tests1.components (type, status) VALUES (@type,@status);";
            using (MySqlConnection connection = new MySqlConnection(_connString))
            using (MySqlCommand command = new MySqlCommand(queryString, connection))
            {
                try
                {
                    //command.Prepare();
                    command.Parameters.AddWithValue("@type", elementModel.Type);
                    command.Parameters.AddWithValue("@status", elementModel.Status);
                    connection.Open();

                    command.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    throw new Exception(ex.Message.ToString(), ex);
                }
                finally
                {
                    connection.Close();
                }
            }
            
        }

        public void Delete(IComponentModel elementModel)
        {
            DeleteById(elementModel.ComponentID);
        }

        public void DeleteById(int elementModelID)
        {
            string queryString = $"DELETE FROM sql_latch_tests1.components WHERE component_id = {elementModelID} ";

            using (MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.connString))
            using (MySqlCommand command = new MySqlCommand(queryString, connection))
            {
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    throw new Exception(ex.Message.ToString(), ex);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IEnumerable<IComponentModel> GetAll()
        {
            List<CompModel> componentModelList = new List<CompModel>();
            using (MySqlConnection connection = new MySqlConnection(_connString))
            {
                try
                {
                    string queryString = "SELECT * FROM sql_latch_tests1.components";
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(queryString, connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CompModel model = new CompModel();
                            model.ComponentID = Int32.Parse(reader["component_id"].ToString());
                            model.Status = (bool)reader["status"];
                            model.Type = reader["type"].ToString();
                            componentModelList.Add(model);
                        }
                        
                    }
                }
                catch (MySqlException ex)
                {
                    throw new Exception(ex.Message.ToString(), ex);
                }
                finally { connection.Close();}                 
            }
            return componentModelList;
        }

        public void Update(IComponentModel elementModel)
        {
            string queryString = $"UPDATE sql_latch_tests1.components SET type = @type, status = @status WHERE component_id = @componentId;";
            using (MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.connString))
            using (MySqlCommand command = new MySqlCommand(queryString, connection))
            {
                try
                {
                    command.Prepare();
                    command.Parameters.AddWithValue("@type", elementModel.Type);
                    command.Parameters.AddWithValue("@status", elementModel.Status);
                    command.Parameters.AddWithValue("@componentId", elementModel.ComponentID);
                    connection.Open();

                    command.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    throw new Exception(ex.Message.ToString(), ex);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IEnumerable<int> GetAllIds()
        {
            List<int> componentIdsList = new List<int>();
            foreach(var compModel in GetAll())
                componentIdsList.Add(compModel.ComponentID);
            return componentIdsList;
        }

        public IEnumerable<int> GetReferenceIds()
        {
            List<int> componentIdsList = new List<int>();
            return componentIdsList;
        }
    }
}
