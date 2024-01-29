using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AtosWindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //檔案存放的位子
        private string fileName = @"C:\TEMP\AtosTest.csv";
        private void btn讀取_Click(object sender, EventArgs e)
        {
            //判斷檔案是否存在
            if (File.Exists(fileName))
            {
                //System.Text.Encoding.Default (作業系統目前 ANSI 字碼頁的編碼方式) 解決亂碼問題
                StreamReader reader = new StreamReader(fileName, System.Text.Encoding.Default);
                try
                {
                    do
                    {
                        addListItem(reader.ReadLine());
                    }
                    //(reader.Peek() == -1) => 沒有資料
                    while (reader.Peek() != -1);
                }
                catch
                {
                    addListItem("File is empty");
                }
                finally
                {
                    reader.Close();
                }

            }
            else
            {
                MessageBox.Show("檔案不存在");
            }
        }
        //把讀到的資料放進listBox
        private void addListItem(string value)
        {
            this.listBox1.Items.Add(value);
        }
        private void btn寫入資料庫_Click(object sender, EventArgs e)
         {
            CAtos atos ;
            List<CAtos> LAtos = new List<CAtos>();
            for (int i = 1; i < listBox1.Items.Count; i++)
            {
                atos = new CAtos();
                var temp = listBox1.Items[i].ToString().Split(',').ToList();
                atos.acc = temp[0];
                atos.birthday = temp[1];
                atos.sex = temp[2];
                LAtos.Add(atos);
            }
            (new CInsert()).executeSQL(getinsert(LAtos));
            MessageBox.Show("新增成功");
        }

        private void lab顯示資料_Click(object sender, EventArgs e)
        {

        }
        private string getinsert(List<CAtos> cAtos)
        {
            string sql = "INSERT INTO Atos(帳號,生日,性別)VALUES";

            foreach (var item in cAtos)
            {
                sql += $"('{item.acc}','{item.birthday}','{item.sex}'),";
            }
            //sql = sql.Substring(0, sql.Length - 1);
            //移除最後一個' , '
            sql = sql.Remove(sql.LastIndexOf(","), 1);
            return sql;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        //public DataTable Read()
        //{
        //    //dt先重置
        //    DataTable dtSendDBtemp = new DataTable();
        //    string lineText;
        //    using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))   //文件已打開時也可以讀取
        //    {
        //        using (StreamReader sr = new StreamReader(fs, Encoding.Default))
        //        {
        //            if (!sr.EndOfStream) //第一個Row是標題
        //            {
        //                lineText = sr.ReadLine();//去掉第一個Row標題
        //                string[] subText = lineText.Split(',');
        //                foreach (string text in subText)
        //                {
        //                    dtSendDBtemp.Columns.Add(text, typeof(String));
        //                }
        //            }
        //            //CSV資料寫入Table
        //            while (!sr.EndOfStream)
        //            {
        //                lineText = sr.ReadLine().Trim();
        //                string[] subText = lineText.Split(',');
        //                DataRow row = dtSendDBtemp.NewRow();
        //                for (int i = 0; i < subText.Length; i++)
        //                {
        //                    row[i] = subText[i];
        //                }
        //                dtSendDBtemp.Rows.Add(row);
        //            }
        //            return dtSendDBtemp;
        //        }
        //    }
        //}

    }
}
