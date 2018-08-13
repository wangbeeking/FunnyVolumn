using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunnyVolumn.ChildForms
{
    public partial class Form1 : Form,IDisposable
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            progressBar1.Maximum = 100;
            progressBar1.Minimum = 0;
            int volume = (int)VolumnControler.VolumnHandler.GetVolumn();
            TaskChangeVolumn = Task.Factory.StartNew(() => ChangeVolumeTask(this));
            ShowVolume(volume);
        }
        #region 音量降低线程
        private static void ChangeVolumeTask(Form1 form)
        {
            try
            {
                while (true)
                {
                    int currentVolumn = (int)VolumnControler.VolumnHandler.SubVolumn();
                    int i = (int)VolumnControler.VolumnHandler.GetVolumn();
                    i = i > 0 ? --i : 0;
                    form.Invoke(new Action(() => {if(!form.IsDisposed) form.ShowVolume(i); }));
                    Thread.Sleep(100);
                    if (form.IsDisposed)
                        break;
                }
            }
            catch (ObjectDisposedException)
            {

            }
        }
        private Task TaskChangeVolumn = null;
        #endregion
        #region 按钮响应

        private void button1_Click(object sender, EventArgs e)
        {
            int volumn = (int)VolumnControler.VolumnHandler.AddVolumn(5);
            ShowVolume(volumn);
        }
        #endregion
        public void ShowVolume(int volumn)
        {
            label1.Text = volumn.ToString();
            progressBar1.Value = volumn;
        }
    }
}
