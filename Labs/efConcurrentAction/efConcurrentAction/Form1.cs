using efConcurrentAction.Models;
using Microsoft.EntityFrameworkCore;
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

namespace efConcurrentAction
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Interval = 30 * 1000;
            timer1.Tick += timer1_Tick;
            timer1.Start();
            label1.Text = "定時器已經啟動 "+DateTime.Now.AddSeconds(30).ToString();
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            using (var context = new SchoolContext() )
            {
                await BeginProcessing(context);
            }
        }

        private async Task BeginProcessing(SchoolContext context)
        {
            var StudentGrades = await context.StudentGrade
                .AsNoTracking()
                .ToListAsync();
            foreach (var item in StudentGrades)
            {
                var currentThread = Thread.CurrentThread.ManagedThreadId;
                Debug.WriteLine($"當前執行緒 : {currentThread}");
                context.Entry(item).State = EntityState.Deleted;
                await context.SaveChangesAsync();
            }
        }
    }
}
