using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//On VS Studio got to project--->Manage NugetPackage-->Search FireSharp--> insall one with Newtonsoft.Json
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;

namespace firebaseTestApp
{
    public partial class Login : System.Web.UI.Page
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            //Create a project on Firebase to find AuthSecret and DB location
            AuthSecret = "",
            BasePath = ""
        };
        //Client
        IFirebaseClient client;
        //When the page load the program will connect to the client
        protected void Page_Load(object sender, EventArgs e)
        {
            //configuring client with the project credentials
            client = new FireSharp.FirebaseClient(config);
            if (client != null)
            {
                //connected to the fbClient
                tf_result.Text = "Connected";
            }
        }
        //inserting data to the database
        protected void Button1_Click(object sender, EventArgs e)
        {
            //inserting a single record
            var data = new Data{
                name = tf_firstname.Text,
                age = tf_age.Text
            };
            SetResponse response;
            //information is the table name in the DB
            response = client.Set("Information/" + data.name,data);
            Data result = response.ResultAs<Data>();
            tf_result.Text = "Record Inseted";
        }
        //Updating data to the database
        protected void Button2_Click(object sender, EventArgs e)
        {
            var data = new Data();
            data.name = tf_firstname.Text;
            data.age = tf_age.Text;

            FirebaseResponse response;
            response = client.Get("Information/" + tf_firstname.Text);
            if (response.Body != null)
            {
     
                response = client.Update("Information/" + tf_firstname.Text, data);
                Data result = response.ResultAs<Data>();
                tf_result.Text = "Record Updated";
            }
            else
            {
                tf_result.Text = "Record not found";
            }
        }
        //Reading data from the database
        protected void Button3_Click(object sender, EventArgs e)
        {
            FirebaseResponse response;
            response = client.Get("Information/" + tf_firstname.Text);
            if (response.Body != null)
            {
                Data result = response.ResultAs<Data>();
                tf_firstname.Text = result.name;
                tf_age.Text = result.age;
                tf_result.Text = "Record Retrieved";
            }
            else
            {
                tf_result.Text = "Record not found";
            }
        }
        //Deleting data from the database
        protected void Button4_Click(object sender, EventArgs e)
        {
            FirebaseResponse response;
            response = client.Delete("Information/" + tf_firstname.Text);
            tf_result.Text = "Record Deleted";
        }
        //Deleting all data from the database
        protected void Button5_Click(object sender, EventArgs e)
        {
            FirebaseResponse response;
            response = client.Delete("Information");
            tf_result.Text = "All records deleted";
        }
        //Reading multiple records from the database
        protected void Button6_Click(object sender, EventArgs e)
        {
            FirebaseResponse response;
            response = client.Get("Information");
            Data obj = response.ResultAs<Data>();
            var json = response.Body;
            lb_records.Items.Clear();
            Dictionary<string, Data> elist = JsonConvert.DeserializeObject<Dictionary<string, Data>>(json);
            foreach (KeyValuePair<string, Data> entry in elist)
            {
                lb_records.Items.Add(entry.Value.name);
            }
        }
        //Searching records in the database
        protected void Button7_Click(object sender, EventArgs e)
        {
            String searchStr = lb_records.SelectedValue;
            FirebaseResponse response;
            response = client.Get("Information/" + searchStr);
            Data result = response.ResultAs<Data>();
            tf_firstname.Text = result.name;
            tf_age.Text = result.age;
            tf_result.Text = "Record Retriaved";
        }
    }
}