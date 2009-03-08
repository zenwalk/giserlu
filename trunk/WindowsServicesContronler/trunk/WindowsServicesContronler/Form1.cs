using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ServiceProcess;
using System.Collections;
using System.Threading;


namespace WindowsServicesContronler
{
    public partial class Form1 : Form
    {
        string[] ServicesName = new string[] { "iisadmin","w3svc", "ArcGIS License Manager", "ArcGIS Server Object Manager", "esri_sde", "MSSQLSERVER" };
       
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServiceController sc;
      
           for(int i = 0 ; i< checkedListBox1.Items.Count;i++)
           {
               if (checkedListBox1.GetItemChecked(i))
               {
                   sc = new ServiceController(checkedListBox1.Items[i].ToString());
                   if (sc.Status.Equals(ServiceControllerStatus.Stopped))
                   {
                       
                      
                       try
                       {
                          
                           status.Text = "正在启动" + checkedListBox1.Items[i].ToString();
                           sc.Start();
                           status.Text = "已启动 " + checkedListBox1.Items[i].ToString();
                            
                          
                       }
                       catch (Exception) 
                       { 
                           status.Text =checkedListBox1.Items[i].ToString()+ " 服务启动错误 " ;
                          // MessageBox.Show(ex.ToString());
                       }

                      
                   }
               }
               else
               {
                   sc = new ServiceController(checkedListBox1.Items[i].ToString());
                   if (sc.Status.Equals(ServiceControllerStatus.Running))
                   {

                      
                       try
                       {
                           status.Text = "正在停止 " + checkedListBox1.Items[i].ToString();
                           sc.Stop();
                           status.Text = "已停止 " + checkedListBox1.Items[i].ToString();
                       }
                       catch (Exception)
                       {
                           status.Text = checkedListBox1.Items[i].ToString() + " 服务停止错误 "; 
                       }
                       

                   }
               }
              
            }
            
           
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            GetServicesStatus();

            }

       

      
        private void GetServicesStatus()
        {


            ServiceController sc;
            checkedListBox1.Items.Clear();
            for (int i = 0; i < ServicesName.Length; i++)
            {
                sc = new ServiceController(ServicesName[i]);


                bool IsChecked = false;

                if (sc.Status.Equals(ServiceControllerStatus.Stopped))
                {
                    IsChecked = false;

                }
                else
                {
                    IsChecked = true;
                }

                this.checkedListBox1.Items.Add(ServicesName[i], IsChecked);


            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetServicesStatus();
        }

        private void selectALLSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.checkedListBox1.Items.Count; i++)
            {
                if(checkedListBox1.GetItemChecked(i)==false)
                {
                   
                }
            }
        }






    }
}
