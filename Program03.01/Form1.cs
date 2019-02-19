using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program03._01
{
    public partial class Form1 : Form
    {
        Stopwatch relogio;

        public Form1()
        {
            InitializeComponent();
            relogio = new Stopwatch();
        }

        //private void btnRelogio_Click(object sender, EventArgs e)
        //{
        //    btnRelogio.Enabled = false;
        //    relogio.Restart();
        //    while(true)
        //    {
        //        Thread.Sleep(100);
        //        //await Task.Delay(100);
        //        TimeSpan tempo = relogio.Elapsed;
        //        int minutos = tempo.Minutes;
        //        int segundos = tempo.Seconds;
        //        int milissegundos = tempo.Milliseconds;
        //        txtRelogio.Text = $"{minutos:00}:{segundos:00}:{milissegundos:000}";
        //        //this.Refresh();
        //    }
        //}

        //private async void btnRelogio_Click(object sender, EventArgs e)
        //{
        //    btnRelogio.Enabled = false;
        //    relogio.Restart();

        //    while (true)
        //    {
        //        //Thread.Sleep(100);
        //        await Task.Delay(100);
        //        TimeSpan tempo = relogio.Elapsed;
        //        int minutos = tempo.Minutes;
        //        int segundos = tempo.Seconds;
        //        int milissegundos = tempo.Milliseconds;
        //        txtRelogio.Text = $"{minutos:00}:{segundos:00}:{milissegundos:000}";
        //        //this.Refresh();
        //    }
        //}

        private async void btnRelogio_Click(object sender, EventArgs e)
        {
            btnRelogio.Enabled = false;
            relogio.Restart();

            await Task.Run(async () =>
            {
                while (true)
                {
                    //Thread.Sleep(100);
                    await Task.Delay(100);
                    TimeSpan tempo = relogio.Elapsed;
                    int minutos = tempo.Minutes;
                    int segundos = tempo.Seconds;
                    int milissegundos = tempo.Milliseconds;

                    this.Invoke((Action)delegate
                    {
                        txtRelogio.Text = $"{minutos:00}:{segundos:00}:{milissegundos:000}";
                    });

                    //this.Refresh();
                }
            });
        }
    }
}
