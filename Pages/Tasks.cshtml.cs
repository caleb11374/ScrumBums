/*
 This code is for functionality of the task which pulls our tasks directly from the database. Using a nuget package

https://www.youtube.com/watch?v=YUPg41kG_kw  <-- link to youtube video where we learned how to make it run successful

     Last modified 11 / 30 / 2022
 
     Created by Philip Gaver, Jackson Coffey, Tanner Collins
*/




using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;


namespace team3.Pages
{
    public class TasksModel : PageModel
    {
        public List<TasksInfo> ListsTasks = new List<TasksInfo>();

        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=LAPTOP-361LDV89\\SQLEXPRESS;Initial Catalog=HuntDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";   
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT  * FROM Tasks";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                TasksInfo task = new TasksInfo();
                                task.TaskID = reader.GetInt32(0);
                                task.Location = reader.GetString(1);
                                task.Question = reader.GetString(2);
                                task.Answer = reader.GetString(3);


                                ListsTasks.Add(task);
                            }

                        }

                    }
                }
            
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

    public class TasksInfo
    {
        public int TaskID;
        public string Location;
        public string Question;
        public string Answer;
    
    
    
    
    
    
    
    
    
    
    
    
    }

}
