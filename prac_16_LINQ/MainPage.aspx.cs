using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime;

namespace prac_16_LINQ
{
    public partial class MainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        DataClasses1DataContext Dc = new DataClasses1DataContext();
        protected void Button1_Click(object sender, EventArgs e)
        {
            
            Employee E = (from student in Dc.Employees where student.Enrollment_No.ToString() == TextBox2.Text select student).FirstOrDefault();
            if (E == null)
            {
                Label5.Text = "No such type of record!";
            }
            else
            {
                Label5.Text = "Recorded Data found successfully!";
                TextBox1.Text = E.Username; 
                TextBox3.Text = E.Name;
                TextBox4.Text = E.Email;
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int no = Convert.ToInt32(TextBox2.Text);
            string uname = TextBox1.Text;
            string name = TextBox3.Text;
            string mail = TextBox4.Text;
            var r = new Employee
            {
                Username = uname,
                Enrollment_No = no,
                Name = name,
                Email = mail,
            };

            Dc.Employees.InsertOnSubmit(r);
            Dc.SubmitChanges(); //used to insert/update and delet the data after the changes submit the changes in table.
            Response.Write("<script LANGUAGE='Javascript' >alert('Data inserted successfully!!')</script>");
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int no = Convert.ToInt32(TextBox2.Text);
            string uname = TextBox1.Text;
            string name = TextBox3.Text;
            string mail = TextBox4.Text;

            var r1 = (from s in Dc.Employees where s.Enrollment_No == no select s).First();
            r1.Enrollment_No = no;
            r1.Username = uname;
            r1.Name = name;
            r1.Email = mail;
            Dc.SubmitChanges(); //used to insert/update and delet the data after the changes submit the changes in table.
            Response.Write("<script LANGUAGE='Javascript' >alert('Data Updated successfully!!')</script>");
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            int no = Convert.ToInt32(TextBox2.Text);
            var r2 = (from s in Dc.Employees where s.Enrollment_No == no select s).First();

            Dc.Employees.DeleteOnSubmit(r2);
            Dc.SubmitChanges(); //used to insert/update and delet the data after the changes submit the changes in table.
            Response.Write("<script LANGUAGE='Javascript' >alert('Data Deleted successfully!!')</script>");
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            var queryshow = from a in Dc.Employees select a;
            GridView1.DataSource = queryshow;
            GridView1.DataBind();
        }
    }
}