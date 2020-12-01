using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

using LatchApp.Model;

namespace LatchApp.DataAccess
{
    public class TestRepository : BaseRepository, IElementRepository<ITestModel>
    {
        public TestRepository() { }

        public TestRepository(string connString)
        {
            this._connString = connString;
        }

        public void Add(ITestModel elementModel)
        {
            string queryString = "INSERT INTO sql_latch_tests1.tests (`latch_id`,`end_time`,`date`,`status`,`cycles`,`video_link`,`comments`) VALUES (@latch_id, @end_time, @date, @status, @cycles, @video_link, @comments);";
            using (MySqlConnection connection = new MySqlConnection(_connString))
            using (MySqlCommand command = new MySqlCommand(queryString, connection))
            {
                try
                {
                    command.Parameters.AddWithValue("@latch_id", elementModel.LatchID);
                    command.Parameters.AddWithValue("@end_time", elementModel.EndTime);
                    command.Parameters.AddWithValue("date", elementModel.Date);
                    command.Parameters.AddWithValue("@status", elementModel.Status);
                    command.Parameters.AddWithValue("@cycles", elementModel.Cycles);
                    command.Parameters.AddWithValue("@video_link", elementModel.VideoLink);
                    command.Parameters.AddWithValue("@comments", elementModel.Comments);
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

        public void Delete(ITestModel elementModel)
        {
            DeleteById(elementModel.TestID);
        }

        public void DeleteById(int elementModelID)
        {
            string queryString = $"DELETE FROM sql_latch_tests1.tests WHERE test_id = {elementModelID} ";

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

        public IEnumerable<ITestModel> GetAll()
        {
            List<TestModel> testModelList = new List<TestModel>();
            using (MySqlConnection connection = new MySqlConnection(_connString))
            {
                try
                {
                    string queryString = "SELECT * FROM sql_latch_tests1.tests";
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(queryString, connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TestModel model = new TestModel();
                            model.TestID = Int32.Parse(reader["test_id"].ToString());
                            model.LatchID = Int32.Parse(reader["latch_id"].ToString());
                            model.EndTime = Convert.ToDateTime((reader["end_time"].ToString()));
                            model.Date = Convert.ToDateTime((reader["date"].ToString()));
                            model.Status = Convert.ToBoolean(Convert.ToInt32(reader["status"].ToString()));
                            model.Cycles = Int32.Parse(reader["cycles"].ToString());
                            model.VideoLink = reader["video_link"].ToString();
                            model.Comments = reader["comments"].ToString();
                            testModelList.Add(model);
                        }                        
                    }
                }
                catch (MySqlException ex)
                {
                    throw new Exception(ex.Message.ToString(), ex);
                }
                finally { connection.Close();}                    

                return testModelList;
            }
        }

        public void Update(ITestModel elementModel)
        {
            string queryString = $"UPDATE sql_latch_tests1.latches SET latch_id = @latch_id, end_time = @end_time, date = @date, status = @status, cycles = @cycles, video_link = @video_link, comments = @comments WHERE test_id = @test_id;"; 

            using (MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.connString))
            using (MySqlCommand command = new MySqlCommand(queryString, connection))
            {
                try
                {
                    command.Parameters.AddWithValue("@latch_id", elementModel.LatchID);
                    command.Parameters.AddWithValue("@end_time", elementModel.EndTime);
                    command.Parameters.AddWithValue("date", elementModel.Date);
                    command.Parameters.AddWithValue("@status", elementModel.Status);
                    command.Parameters.AddWithValue("@cycles", elementModel.Cycles);
                    command.Parameters.AddWithValue("@video_link", elementModel.VideoLink);
                    command.Parameters.AddWithValue("@comments", elementModel.Comments);
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
            List<int> testIdsList = new List<int>();
            foreach(var compModel in GetAll())
                testIdsList.Add(compModel.LatchID);
            return testIdsList;
        }

        public IEnumerable<int> GetReferenceIds()
        {
            List<int> latchIdsList = new List<int>();
            using (MySqlConnection connection = new MySqlConnection(_connString))
            {
                try
                {
                    string queryString = $"SELECT latch_id FROM sql_latch_tests1.latches WHERE latch_id NOT IN (SELECT latch_id FROM sql_latch_tests1.tests);";
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(queryString, connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            latchIdsList.Add(Int32.Parse(reader["latch_id"].ToString()));
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    throw new Exception(ex.Message.ToString(), ex);
                }
                finally { connection.Close(); }
            }
            return latchIdsList;
        }
    }
}
