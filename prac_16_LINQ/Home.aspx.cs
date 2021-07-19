using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prac_16_LINQ
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataClasses1DataContext datacontext = new DataClasses1DataContext();
            GridView1.DataSource = from student in datacontext.Employees
                                   where student.Name == "Riya"
                                   select student;
            GridView1.DataBind();

        }
    }
}