using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
namespace SchedulingApplication
{
    public partial class DirectoryPathForm : Form
    {
        private DataTable dataRoom;
        private DataTable dataCourseResults;
        private GraphColoring solution;
        private Boolean bClicked1;
        private Boolean bClicked2;
        public DirectoryPathForm()
        {
            InitializeComponent();
            
            bClicked1 = false;
            bClicked2 = false;
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            string fileExt = string.Empty;
            OpenFileDialog file = new OpenFileDialog(); //open dialog to choose file  
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK) //if there is a file choosen by the user  
            {
                filePath = file.FileName; //get the path of the file  
                fileExt = Path.GetExtension(filePath); //get the file extension  
                if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
                {
                    try
                    {
                        dataRoom = new DataTable();
                        dataRoom = readExcel(filePath, fileExt); //read excel file  
                        
                        bClicked1 = true;
                        roomList_label.Text = file.FileName;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Please choose .xls or .xlsx file only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error  
                }
            }


        }
        private void button2_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            string fileExt = string.Empty;
            OpenFileDialog file = new OpenFileDialog(); //open dialog to choose file  
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK) //if there is a file choosen by the user  
            {
                filePath = file.FileName; //get the path of the file  
                fileExt = Path.GetExtension(filePath); //get the file extension  
                if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
                {
                    try
                    {
                        dataCourseResults = new DataTable();
                        this.dataCourseResults = readExcel(filePath, fileExt); //read excel file  
                        
                        bClicked2 = true;
                        courseRes_label.Text = file.FileName;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Please choose .xls or .xlsx file only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error  
                }
            }
        }

        private DataTable readExcel(string fileName, string fileExt)
        {
            string conn = string.Empty;
            DataTable dtexcel = new DataTable();
            if (fileExt.CompareTo(".xls") == 0)
                conn = @"provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties='Excel 8.0;HRD=Yes;IMEX=1';"; //for below excel 2007  
            else
                conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0;HDR=NO';"; //for above excel 2007  
            using (OleDbConnection con = new OleDbConnection(conn))
            {
                try
                {
                    //Get sheet1's name
                    Excel.Application ExcelObj = new Excel.Application();
                    Excel.Workbook theWorkbook = null;
                    theWorkbook = ExcelObj.Workbooks.Open(fileName);
                    Excel.Sheets sheets = theWorkbook.Worksheets;
                    Excel.Worksheet worksheet = (Excel.Worksheet)sheets.get_Item(1);//Get the reference of second worksheet
                    string strWorksheetName = worksheet.Name;//Get the name of worksheet.
                    theWorkbook.Close();

                    OleDbDataAdapter oleAdpt = new OleDbDataAdapter("select * from ["+strWorksheetName+"$]", con); //here we read data from sheet1  
                    oleAdpt.Fill(dtexcel); //fill excel data into dataTable  
                }
                catch (Exception e){
                    MessageBox.Show(e.Message);
                }
            }
            return dtexcel;
        }

        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.vietcombank.com.vn");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:"+linkLabel1.Text);
        }

        

        private void DirectoryPathForm_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!bClicked1 && !bClicked2)
            {
                MessageBox.Show("Please choose your files");
            }
            else if (!bClicked1)
                MessageBox.Show("Please choose your room data file");
            else if (!bClicked2)
                MessageBox.Show("Please choose your registration results file");
            else {
                
                solution = new GraphColoring(this.dataRoom, this.dataCourseResults);
                
            }
            
        }
    }
}
