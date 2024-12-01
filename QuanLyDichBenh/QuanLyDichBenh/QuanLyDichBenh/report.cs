using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using QuanLyDichBenh.DAO;

namespace QuanLyDichBenh
{
    public partial class report : Form
    {
        public report()
        {
            InitializeComponent();
        }

        private void report_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyDichBenh.Report1.rdlc";
            ReportDataSource r = new ReportDataSource();
            r.Name = "DataSet1";
            r.Value = NhaNongDAO.Instance.loadNhaNong1();
            reportViewer1.LocalReport.DataSources.Add(r);
            reportViewer1.RefreshReport(); 
        }
    }
}
