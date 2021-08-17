using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            AuthSecret = "LyEGbfC2WQKqpmraLYI8yDqu3CRaJ0kiZRuUVBmw",
            BasePath = "https://fir-login-23cc4-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;
        protected void Page_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);
            if (client != null)
            {
                tf_result.Text = "Connected";
            }
        }

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
    }
}