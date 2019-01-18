using System;
using System.ComponentModel;
using System.Windows.Forms;
using NavWebServiceDemo.Forms.NavJobListService;

namespace NavWebServiceDemo.Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            NavService.UserName = "admin";
            NavService.Password = "Start2018Start2018";
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var jobs = NavService.JobListPortClient().ReadMultiple(null, null, 0);
            foreach (var job in jobs)
            {
                jobListBindingSource.Add(job);
            }
        }

        private void JobListBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemChanged)
            {
                var currentJob = (Job_List) jobListBindingSource[e.NewIndex];
                NavService.JobListPortClient().Update(ref currentJob);
                jobListBindingSource[e.NewIndex] = currentJob;
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
