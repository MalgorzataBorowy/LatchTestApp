using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

using LatchApp.Model;

namespace LatchApp.DataAccess
{
    public class LatchRepository : BaseRepository, IElementRepository<ILatchModel>
    {
        public LatchRepository() { }

        public LatchRepository(string connString)
        {
            this._connString = connString;
        }

        public void Add(ILatchModel elementModel)
        {
            string queryString = $"INSERT INTO sql_latch_tests1.latches (type, component_id) VALUES (@type,@component_id);";
            using (MySqlConnection connection = new MySqlConnection(_connString))
            using (MySqlCommand command = new MySqlCommand(queryString, connection))
            {
                try
                {
                    command.Parameters.AddWithValue("@type", elementModel.Type);
                    command.Parameters.AddWithValue("@component_id", elementModel.ComponentID);
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

        public void Delete(ILatchModel elementModel)
        {
            DeleteById(elementModel.ComponentID);
        }

        public void DeleteById(int elementModelID)
        {
            string queryString = $"DELETE FROM sql_latch_tests1.latches WHERE latch_id = {elementModelID} ";

            using (MySqlConnection connection = new MySqlConnection(_connString))
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

        public IEnumerable<ILatchModel> GetAll()
        {
            List<LatchModel> latchModelList = new List<LatchModel>();
            using (MySqlConnection connection = new MySqlConnection(_connString))
            {
                try
                {
                    string queryString = "SELECT * FROM sql_latch_tests1.latches";
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(queryString, connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            LatchModel model = new LatchModel();
                            model.ComponentID = Int32.Parse(reader["component_id"].ToString());
                            model.LatchID = Int32.Parse(reader["latch_id"].ToString());
                            model.Type = reader["type"].ToString();
                            latchModelList.Add(model);
                        }
                        
                    }
                }
                catch (MySqlException ex)
                {
                    throw new Exception(ex.Message.ToString(), ex);
                }
                finally { connection.Close();}                    

                return latchModelList;
            }
        }

        public void Update(ILatchModel elementModel)
        {
            string queryString = "UPDATE sql_latch_tests1.latches SET type = @type, component_id = @component_id WHERE latch_id = @latch_id;";
            using (MySqlConnection connection = new MySqlConnection(_connString))
            using (MySqlCommand command = new MySqlCommand(queryString, connection))
            {
                try
                {
                    command.Parameters.AddWithValue("@type", elementModel.Type);
                    command.Parameters.AddWithValue("@latch_id", elementModel.LatchID);
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
            List<int> latchIdsList = new List<int>();
            foreach(var latchModel in GetAll())
                latchIdsList.Add(latchModel.LatchID);
            return latchIdsList;
        }

        public IEnumerable<int> GetReferenceIds()
        {
            List<int> componentIdsList = new List<int>();
            using (MySqlConnection connection = new MySqlConnection(_connString))
            {
                try
                {
                    string queryString = "SELECT component_id FROM sql_latch_tests1.components";
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(queryString, connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            componentIdsList.Add(Int32.Parse(reader["component_id"].ToString()));
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    throw new Exception(ex.Message.ToString(), ex);
                }
                finally { connection.Close(); }
            }
            return componentIdsList;
        }
    }
}
