using System;
using System.Data;
using Microsoft.Data.SqlClient;
using TelHai.CS.DotNet.YazanHeib.Repositories.Models;



namespace TelHai.CS.DotNet.YazanHeib.Repositories.Repositories
{
    public class SqlRepository : IBugRepository
    {
        private string _sqlConnectionString;


        /// <summary>
        /// Parameterized Constructor.
        /// </summary>
        /// <param name="connectionString">This String Is Used To Connect To The Database.</param>
        public SqlRepository(string connectionString)
        {
            this._sqlConnectionString = connectionString;
        }


        /// <summary>
        /// Empty C'tor.
        /// </summary>
        public SqlRepository() : this("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Bugs;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False") { }


        /// <summary>
        /// Add A Bug To The Database.
        /// </summary>
        /// <param name="bugToAdd">The Bug That Will Be Added To The Database.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Add(Bug bugToAdd)
        {
            // Command For Adding Into The Database.
            string query = "INSERT INTO Bugs (Title, Description, Status, CategoryId) VALUES (@Title, @Description, @Status, @CategoryId);";

            using (SqlConnection sqlConnection = new SqlConnection(_sqlConnectionString))
            {

                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    // Add Parameters To Avoid SQL Injection.
                    command.Parameters.AddWithValue("@Title", bugToAdd.Title);
                    command.Parameters.AddWithValue("@Description", bugToAdd.Description);
                    command.Parameters.AddWithValue("@Status", bugToAdd.Status);
                    command.Parameters.AddWithValue("@CategoryId", bugToAdd.CategoryId);


                    // Open The Connection.
                    sqlConnection.Open();


                    // Execute The Command.
                    int rowsAffected = command.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Delete A Bug From The Database.
        /// </summary>
        /// <param name="id">ID Of The Bug That Will Be Deleted From The Database.</param>
        public void Delete(int id)
        {
            // Command For Removing From The Database.
            string query = "DELETE FROM Bugs WHERE id = @id";

            using (SqlConnection sqlConnection = new SqlConnection(_sqlConnectionString))
            {

                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    // Delete A Bug From The Database.
                    command.Parameters.AddWithValue("@id", id);


                    // Open The Connection.
                    sqlConnection.Open();


                    // Execute The Command.
                    int rowsAffected = command.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Return A Bug From The Database By ID.
        /// </summary>
        /// <param name="id">ID Of The Bug In The Database.</param>
        /// <returns>The Bug Corresponding To The Given ID.</returns>
        public Bug? Get(int id)
        {
            // Command For Retrieving All Items From The Database.
            string query = "SELCET * FROM Bugs Where id = @id";

            Bug bug = null;

            using (SqlConnection sqlConnection = new SqlConnection(_sqlConnectionString))
            {

                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {

                    command.Parameters.AddWithValue("@id", id);

                    // Open The Connection.
                    sqlConnection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Reading A Row From The Database And Setting It To The Bug.
                        while (reader.Read())
                        {
                            bug = new Bug
                            {
                                BugID = reader.GetFieldValue<int>("id"),
                                Title = reader.GetString(1),
                                Description = reader.IsDBNull(2) ? null : reader.GetString(2),
                                Status = reader.GetString(3)
                            };
                        }
                    }
                }
            }
            return bug;
        }


        /// <summary>
        /// Get All The Bugs From The Database As A List.
        /// </summary>
        /// <returns>List<Bug></returns>
        public List<Bug> GetAll()
        {
            // Command For Retrieving All Items From The Database.
            string query = "SELECT * FROM Bugs";

            List<Bug> result = new List<Bug>();

            using (SqlConnection sqlConnection = new SqlConnection(_sqlConnectionString))
            {

                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {

                    // Open The Connection.
                    sqlConnection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Reading a Row At The DataBase, And Add it to List. 
                        while (reader.Read())
                        {
                            result.Add(new Bug
                            {
                                BugID = reader.GetFieldValue<int>("id"),
                                Title = reader.GetString(1),
                                Description = reader.IsDBNull(2) ? null : reader.GetString(2),
                                Status = reader.GetString(3),
                                CategoryId = reader.GetFieldValue<int>("CategoryId")
                            });
                        }
                    }
                }
            }
            return result;
        }


        /// <summary>
        /// Update A Bug In The Database By ID.
        /// </summary>
        /// <param name="id">ID Of The Bug That Will Be Updated.</param>
        /// <param name="bug">The Updated Bug Data.</param>
        public void Update(int id, Bug bug)
        {

            string query = "UPDATE Bugs SET Title = @Title, Description = @Description, Status = @Status, CategoryId = @CategoryId WHERE id = @id;";


            using (SqlConnection sqlConnection = new SqlConnection(_sqlConnectionString))
            {

                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    // Add A Parameters To avoid SQL injection.
                    command.Parameters.AddWithValue("@Title", bug.Title);
                    command.Parameters.AddWithValue("@Description", bug.Description);
                    command.Parameters.AddWithValue("@Status", bug.Status);
                    command.Parameters.AddWithValue("@CategoryId", bug.CategoryId);
                    command.Parameters.AddWithValue("@id", id);

                    // Open The Connection.
                    sqlConnection.Open();

                    // Execute The Command, And Check If Row Is Created.
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new Exception("Error : Can't Find a Bug With The Given ID.");
                    }
                }
            }
        }
    }
}
