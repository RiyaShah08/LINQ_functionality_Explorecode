using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prac_16_LINQ
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] a = { "Riya", "Joel", "Noah" };
            var result = from b in a where b.Contains('i') select b;
            foreach (var item in result)
            { 
                Response.Write(item+"<br>");
            }
        }
    }
}