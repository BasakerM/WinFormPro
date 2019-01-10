using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C___compiler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //
        //  加载窗体时首先读取本地的 cppcompiler_configfile.txt 配置文件
        //  配置文件记录了上次使用的 makefile 的路径
        //  配置文件存储于当前用户目录下的 CppCompiler 目录下
        //  若配置文件不存在则创建
        //
        private void Form1_Load(object sender, EventArgs e)
        {
            string username = System.Environment.UserName;
            string configfile_path = "C:\\Users\\" + username + "\\CppCompiler\\";
            bool result = System.IO.Directory.Exists(configfile_path);  //判断目录是否存在
            if (result)   //配置文件目录存在
            {
                configfile_path += "cppcompiler_configfile.txt";
                result = System.IO.File.Exists(configfile_path);
                if(result)  //文件存在
                {   //读取文件内容
                    System.IO.StreamReader sr = new System.IO.StreamReader(configfile_path, Encoding.Default);  //将文件内容读入流
                    string configfile_data;
                    if((configfile_data = sr.ReadLine()) != null)   //读取第一行
                    {
                        textBox_sourceCode.Text = configfile_data;  //显示
                        textBox_sourceCode.ReadOnly = true; //设置为只读
                    }
                }
                else   //创建文件
                {
                    System.IO.FileStream fs = System.IO.File.Create(configfile_path);   //创建文件
                    fs.Close(); //这里必须关闭文件,否则之后将无法打开
                }
            }
            else   //配置文件不存在
            {
                System.IO.Directory.CreateDirectory(configfile_path);   //创建目录
                configfile_path += "cppcompiler_configfile.txt";
                System.IO.FileStream fs = System.IO.File.Create(configfile_path);   //创建文件
                fs.Close(); //这里必须关闭文件,否则之后将无法打开
            }
        }
    }
}
