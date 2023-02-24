using NewsletterAppMVC2.Models;
using NewsletterAppMVC2.ViewModels;
using NewsletterAppMVC2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsletterAppMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly string connectionString = @"Data Source=DESKTOP-REA87JS\SQLEXPRESS;Initial Catalog=Newsletter2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";    //Connection string from our local database
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(string firstName, string lastName, string emailAddress)      //Method that exist in the View/Index newsletter form, takes in 3 parameters that user inputs in the form
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(emailAddress))        //If any of them are null, then we redirect the View to the error page
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else        //Else if all strings contain data, we redirect it to the below
            {                
                using (Newsletter2Entities db = new Newsletter2Entities())
                {
                    var signup = new SignUp();
                    signup.FirstName = firstName;
                    signup.LastName = lastName;
                    signup.EmailAddress = emailAddress;

                    db.SignUps.Add(signup);
                    db.SaveChanges();
                }
                //string queryString = @"INSERT INTO SignUps (FirstName, LastName, EmailAddress) VALUES (@FirstName, @LastName, @EmailAddress)";  //The querry that we will do in the database, I'm manually connecting and mapping so I gather experience
                //using (SqlConnection connection = new SqlConnection(connectionString))      //Creating a connection with "using" in order to prevent sql injection and close resources after finishing the sql connection, passing in the connection string
                //{
                //    SqlCommand command = new SqlCommand(queryString, connection);       //Creating an sql command passing in the querry that we need to do as well as the connection that we just created
                //    command.Parameters.Add("@FirstName", SqlDbType.VarChar);        //Adding the data type of each parameter
                //    command.Parameters.Add("@LastName", SqlDbType.VarChar); 
                //    command.Parameters.Add("@EmailAddress", SqlDbType.VarChar);

                //    command.Parameters["@FirstName"].Value = firstName;     //Adding the value of each parameter
                //    command.Parameters["@LastName"].Value = lastName;
                //    command.Parameters["@EmailAddress"].Value = emailAddress;

                //    connection.Open();      //Opening connection
                //    command.ExecuteNonQuery();      //Executing the command
                //    connection.Close();     //Closing
                //}
                return View("Success");     //Redirecting the view to the Success view we created
            }
        }

        public ActionResult Admin()
        {
            using (Newsletter2Entities db = new Newsletter2Entities())
            {
                var signUps = db.SignUps;
                var signupVms = new List<SignupVm>();       //Creating a ViewModel and a list of that in order to pass to the View only the informations that are needed, excluding Id and SocialSecurityNumber in this example
                foreach (var signup in signUps)
                {
                    var signupVm = new SignupVm();      //creating a signupVm object
                    signupVm.FirstName = signup.FirstName;      //Manually mapping properties between objects
                    signupVm.LastName = signup.LastName;
                    signupVm.EmailAddress = signup.EmailAddress;
                    signupVms.Add(signupVm);        //Adding the signupVm in the ViewModel list we just created above
                }
                return View(signupVms);     //Returning the ViewModel list instead of the Model List
            }

            //string queryString = @"SELECT Id, FirstName, LastName, EmailAddress, SocialSecurityNumber from SignUps";        //I'm manually connecting mapping to the database so I gather experience
            //List<NewsletterSignUp> signUps = new List<NewsletterSignUp>();
            //using (SqlConnection  connection = new SqlConnection(connectionString))
            //{
            //    SqlCommand command = new SqlCommand(queryString, connection);
            //    connection.Open();
            //    SqlDataReader reader = command.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        var signup = new NewsletterSignUp();
            //        signup.Id = Convert.ToInt32(reader["Id"]);
            //        signup.FirstName = reader["FirstName"].ToString();
            //        signup.LastName = reader["LastName"].ToString();
            //        signup.EmailAddress = reader["EmailAddress"].ToString();
            //        signup.SocialSecurityNumber = reader["SocialSecurityNumber"].ToString();
            //        signUps.Add(signup);
            //    }
            //}

        }
    }
}