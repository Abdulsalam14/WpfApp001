using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp001
{
    public class Authorss:ObservableCollection<Author>
    {
        public void GetAuthors()
        {
            Clear();
            string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Library;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(@"SELECT * FROM Authors", connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Author temp = new Author((int)reader[0], reader[1].ToString(), reader[2].ToString());
                    Add(temp);
                }
            }
        }

        public void AddAuthor(Author author)
        {
            string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Library;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string insertQuery = $"INSERT INTO Authors (Id, FirstName, LastName) VALUES ({author.Id}, '{author.Name}', '{author.Surname}')";

                SqlCommand command = new SqlCommand(insertQuery, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }

            Add(author);
        }

    }
}
