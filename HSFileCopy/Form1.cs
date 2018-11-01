using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace HSFileCopy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            int temp1, temp2;
            string str, str1;
            try
            {
                DirectoryInfo dir = new DirectoryInfo("Object");
                FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //返回目录中所有文件和子目录
                foreach (FileSystemInfo i in fileinfo)
                {
                    if (i is DirectoryInfo)            //判断是否文件夹
                    {
                        DirectoryInfo subdir = new DirectoryInfo(i.FullName);
                        subdir.Delete(true);          //删除子目录和文件
                    }
                    else
                    {
                        File.Delete(i.FullName);      //删除指定文件
                    }
                }
                txtOutMsg .Text+= "Object文件夹已清空！\r\n";

                int.TryParse(txtStart.Text.ToString().Trim(), out temp1);
                int.TryParse(txtEnd.Text.ToString().Trim(), out temp2);
                str = txtSourceFile.Text.ToString().Trim();
                str1 = txtObjectFile.Text.ToString().Trim();
                for (int i = temp1; i <= temp2; i++)
                {
                    str1 = str1 + i.ToString() + ".xml";
                    str1= Path.Combine("Object", str1);
                    //c#实现把一个文件从一个文件夹复制到另外一个文件夹并改名
                    File.Copy(str, str1, true);//允许覆盖目的地的同名文件
                    txtOutMsg.Text += str1 + "生成成功！\r\n";
                    str1 = txtObjectFile.Text.ToString().Trim();
                }
            }
            catch (Exception ex)
            {
                txtOutMsg.Text += ex.ToString() + "\r\n";
            }
        }
    }
}