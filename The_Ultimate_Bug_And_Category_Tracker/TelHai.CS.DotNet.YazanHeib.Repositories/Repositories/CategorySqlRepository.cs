using Microsoft.Data.SqlClient;
using TelHai.CS.DotNet.YazanHeib.Repositories.Models;



namespace TelHai.CS.DotNet.YazanHeib.Repositories.Repositories
{
    public class CategorySqlRepository
    {

        private static readonly CategorySqlRepository _categoryRepository = new CategorySqlRepository();
        private readonly string _connectionString;

        /// <summary>
        /// Private C'tor, Because This Class Will Be A Singleton Class.
        /// </summary>
        private CategorySqlRepository()
        {
            // Give The Connection String Of the Data Base To Connect.
            _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Bugs;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        }


        /// <summary>
        /// Add a Category To Categories DataBase.
        /// </summary>
        /// <param name="category">The Category Will Add To The DataBase</param> 
        public void Add(Category category)
        {
            // The Command Of Adding Into The Category Data Base.
            string query = "INSERT INTO Categories (Id, CategoryName, ParentCategoryId) VALUES (@Id, @CategoryName, @ParentCategoryId)";

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {

                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    // Add A Parameters To Avoid SQL Injection.
                    command.Parameters.AddWithValue("@Id", category.Id);
                    command.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                    command.Parameters.AddWithValue("@ParentCategoryId", category.ParentCategoryId ?? (object)DBNull.Value);

                    // Open The Connection.
                    sqlConnection.Open();

                    // Execute The Command.
                    int rowsAffected = command.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Delete a Category From Categories DataBase.
        /// </summary>
        /// <param name="id">ID Of Will Delete.</param>
        public void Delete(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                // Open The Connection.
                sqlConnection.Open();

                // The Command Of Remove All The Sub Category From The Data Base.
                string querySubCategory = "DELETE FROM Categories WHERE ParentCategoryId = @id;";

                using (SqlCommand subCommand = new SqlCommand(querySubCategory, sqlConnection))
                {
                    // Delete a Category From The Data Base.
                    subCommand.Parameters.AddWithValue("@id", id);

                    //And Execute The Command.
                    subCommand.ExecuteNonQuery();
                }


                // The Command Of Remove The Base Category From The Data Base.
                string queryCategory = "DELETE FROM Categories WHERE Id = @id;";

                using (SqlCommand command = new SqlCommand(queryCategory, sqlConnection))
                {
                    // Delete a Category From The Data Base.
                    command.Parameters.AddWithValue("@id", id);

                    //Execute The Command.
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new Exception("Error : Category Not Founded, Plaese try Again");
                    }
                }
            }
        }


        /// <summary>
        /// Get A Category By Id.
        /// </summary>
        /// <param name="id">ID Of Category We Want To Get<param>
        /// <returns>Category</returns>
        public Category? Get(int id)
        {
            // Command Of All The Item's In The Data Base.
            string query = "SELECT * FROM Categories WHERE id = @id";


            Category category = null;

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {

                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {

                    command.Parameters.AddWithValue("@id", id);

                    // Open The Connection.
                    sqlConnection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Reading a Row At The DataBase, And Set it To The Bug. 
                        while (reader.Read())
                        {
                            category = new Category
                            {
                                Id = reader.GetInt32(0),
                                CategoryName = reader.GetString(1),
                                ParentCategoryId = reader.IsDBNull(2) ? null : reader.GetInt32(2)
                            };
                        }
                    }
                }
            }
            return category;
        }


        /// <summary>
        /// Get All The Categories In The Data Base As List.
        /// </summary>
        /// <returns>List<Category></returns>
        public List<Category> GetAll()
        {
            string query = "SELECT * FROM Categories";

            List<Category> categoryList = new List<Category>();

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
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
                            categoryList.Add(new Category
                            {
                                Id = reader.GetInt32(0),
                                CategoryName = reader.GetString(1),
                                ParentCategoryId = reader.IsDBNull(2) ? null : reader.GetInt32(2)
                            });
                        }
                    }
                }
            }
            return categoryList;
        }


        /// <summary>
        /// Update A Category At The DataBase.
        /// </summary>
        /// <param name="id">ID Of The Category We Want To Update At The DataBase.</param>
        /// <param name="category">Category We Want To Update At The DataBase.</param>
        public void Update(int oldId, Category category)
        {

            string query = @"UPDATE Categories SET Id = @NewId, CategoryName = @CategoryName, ParentCategoryId = @ParentCategoryId WHERE Id = @OldId;";


            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {

                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    // Add A Parmters To Avoid SQL injection.
                    command.Parameters.AddWithValue("@NewId", category.Id);
                    command.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                    command.Parameters.AddWithValue("@ParentCategoryId", category.ParentCategoryId ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@OldId", oldId);

                    // Open The Connection.
                    sqlConnection.Open();


                    //and Execute The Command.
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new Exception("Error : Category Not Founded, Plaese try Again");
                    }
                }

            }
        }

        /// <summary>
        /// Public Property To Access The Singleton Instance.
        /// </summary>
        public static CategorySqlRepository GetSqlRepositoryInstance => _categoryRepository;
    }

}
