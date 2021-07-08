using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Configuration;

namespace K173795_Q3
{

    public partial class Form1 : Form
    {
        public string outputDirPath = ConfigurationManager.AppSettings["outputDirPath"];


        public Form1()
        {
            
            if (!Directory.Exists(outputDirPath)){
                MessageBox.Show("Output Directory Not Found ...");
            }
            else
            {
                InitializeComponent();
                Form1_Load();
            }
            


        }
        private void Form1_Load()
        {
            var categoryName = new List<string>(File.ReadAllLines(outputDirPath + "CategoryName.txt"));
            categoryName.Sort();
            string[] subdirectoryEntries = Directory.GetDirectories(outputDirPath);

            List<ComboBoxPairs> cbp = new List<ComboBoxPairs>();

            for (int i = 0; i < categoryName.Count; i++)
            {
                cbp.Add(new ComboBoxPairs(categoryName[i], new DirectoryInfo(subdirectoryEntries[i]).Name));
            }

            comboBox1.DisplayMember = "script";
            comboBox1.SelectedValue = "directory";

            comboBox1.DataSource = cbp;
            comboBox1.SelectedIndex = comboBox1.FindStringExact("ALL");

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form1_Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1_Refresh();

        }
        private void Form1_Refresh()
        {
            ComboBoxPairs item = (ComboBoxPairs)comboBox1.SelectedItem;

            DirectoryInfo dir = new DirectoryInfo(outputDirPath + item.directory);
            var filePath = dir.GetFiles().OrderByDescending(f => f.LastWriteTime).First().Name;
            filePath = outputDirPath + item.directory + "\\" + filePath;
            XmlRootAttribute root = new XmlRootAttribute("xml");
            XmlSerializer ser = new XmlSerializer(typeof(List<Scripts>), root);

            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            using (StreamReader sr = new StreamReader(filePath))
            {
                List<Scripts> sp = (List<Scripts>)ser.Deserialize(sr);
                dataGridView1.DataSource = sp;
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

    public class Scripts
    {
        public string Script { get; set; }
        public string Price { get; set; }
    }


    public class ComboBoxPairs
    {
        public string script { get; set; }
        public string directory { get; set; }

        public ComboBoxPairs(string _script,
                             string _directory)
        {
            script = _script;
            directory = _directory;
        }

    }
}
