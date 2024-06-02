using Dapper;
using HHTDotNetCore.shared;
using HHTDotNetCore.WindowForms.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HHTDotNetCore.WindowForms
{
    public partial class FrmBlogList : Form
    {
        private readonly DapperService _dapperService;
        private readonly int _blogId; 
        public FrmBlogList()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            _dapperService = new DapperService(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
        }

        private void FrmBlogList_Load_1(object sender, EventArgs e)
        {
            BlogList();
        }
        private void BlogList()
        {
            List<BlogModel> lst = _dapperService.Query<BlogModel>("select * from Table_1");
            dgvData.DataSource = lst;
        }
        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var blogId = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["colId"].Value);
            if (e.ColumnIndex == (int)EnumFormControl.Edit)
            #region If Case
            {

                FrmBlog frm = new FrmBlog(blogId);
                frm.ShowDialog();
                BlogList();
            }
            else if (e.ColumnIndex == (int)EnumFormControl.Delete)
            {
                var dialogResult = MessageBox.Show("Are you sure want to delete?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult != DialogResult.Yes) return;
                DeleteBlog(blogId);
                BlogList();
            }
            #endregion
            #region Switch Case 

            int index = e.ColumnIndex;
            EnumFormControl enumFormControl = (EnumFormControl)index;
          switch(enumFormControl)
            {
                case EnumFormControl.Delete:
                    break;

                case EnumFormControl.Edit:
                    FrmBlog frm = new FrmBlog(blogId);
                    frm.ShowDialog();
                    BlogList();
                    break;

                case EnumFormControl.None:
                    break;
                default:
                    MessageBox.Show("Invalid Case.");
                    break;
            }
            #endregion
            //    EnumFormControl enumFormControl = EnumFormControl.None;
            //    switch (enumFormControl)
            //    {
            //        case EnumFormControl.None:
            //            break;
            //        case EnumFormControl.Delete:
            //            break;
            //        case EnumFormControl.Edit:
            //            break;
            //    }
            //    string formControlType = "None";
            //    switch (formControlType)
            //    {
            //        case "asskfsdjfkjasd;f":
            //            break;
            //        case "adfkajd;":
            //            break;
            //        case "asdfjdskfjd":
            //            break;
            //        default:
            //            break;         
            //    }

        }

        private void DeleteBlog(int id)
        {
            string query = @"delete from [dbo].[Table_1] where BlodId = @BlodId";
            int result = _dapperService.Execute(query, new { BlodId = 4 });
            string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
            MessageBox.Show(message);
        }
    }
}
