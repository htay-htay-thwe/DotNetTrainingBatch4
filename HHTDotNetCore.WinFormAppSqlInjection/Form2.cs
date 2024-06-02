using HHTDotNetCore.shared;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HHTDotNetCore.WinFormAppSqlInjection
{
    public partial class Form2 : Form
    {
        private readonly DapperService _dapperService;
        public Form2()
        {
            InitializeComponent();
            _dapperService = new DapperService(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = $"select * from Tbl_user where email =@Email and password = @Password";
           var model =  _dapperService.QueryFirstOrDefault<UserModel>(query,new { 
               Email =txtEmail.Text.Trim(),
               Password = txtPassword.Text.Trim(),  
           });
            if(model is null)
            {
                MessageBox.Show("User doesn't exist.");
                return;
            }
            MessageBox.Show("Is Admin : " + model.Email);
        }
    }

    public class UserModel
    {
        public string? Email { get; set; }
        public string? Password { get; set; }    
        public bool IsAdmin { get; set;}
    }
}
