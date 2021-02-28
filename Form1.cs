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

namespace _6._13.RichTextBox_et_compagnie
{
    public partial class Form1 : Form
    {
        List<string> Cilivité = new List<string> { "M", "Mme", "Mlle" };
        string path = @"C:\Users\Devman\Desktop\Test";
        ToolStripMenuItem PolicemenuItem;  
        ToolStripMenuItem ColorMenuItem;  
        ContextMenuStrip menuStrip;  

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = Cilivité;
            toolStripStatusLabel2.Text = DateTime.Now.ToString("d");
            richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, 12);
            if (File.Exists(path))
            richTextBox1.LoadFile(path, RichTextBoxStreamType.RichText);
            menuStrip = new ContextMenuStrip();
            PolicemenuItem = new ToolStripMenuItem("Polices");
            ColorMenuItem = new ToolStripMenuItem("Colors");
            ColorMenuItem.DropDownItems.Add("Red").Click += new EventHandler(ColorspopupMenu_Click);
            ColorMenuItem.DropDownItems.Add("Green").Click += new EventHandler(ColorspopupMenu_Click);
            ColorMenuItem.DropDownItems.Add("Bleu").Click += new EventHandler(ColorspopupMenu_Click);
            ColorMenuItem.DropDownItems.Add("White").Click += new EventHandler(ColorspopupMenu_Click);
            ColorMenuItem.DropDownItems.Add("Yellow").Click += new EventHandler(ColorspopupMenu_Click);
            foreach(FontFamily font in FontFamily.Families)
            PolicemenuItem.DropDownItems.Add(font.Name).Click += new EventHandler(PolicepopupMenu_Click);  //6.4. Menus Contextuels
            menuStrip.Items.Add(PolicemenuItem);
            menuStrip.Items.Add(ColorMenuItem);
            richTextBox1.ContextMenuStrip = menuStrip;

            // The Icon property sets the icon that will appear
            // in the systray for this application.
          //  notifyIcon1.Icon = new Icon("appicon.ico");

            Bitmap myBitmap = new Bitmap(@"C:\Users\Devman\Downloads\youtube.png"); 

            // Get an Hicon for myBitmap.
            IntPtr Hicon = myBitmap.GetHicon();

            // Create a new icon from the handle. 
            notifyIcon1.Icon = Icon.FromHandle(Hicon); // notifyIcon accepts just .ico exstention so i have to convert .png to .ico


        }

        private void PolicepopupMenu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            FontFamily font = new FontFamily(item.Text);
            richTextBox1.SelectionFont = new Font(font, richTextBox1.Font.Size);
        }

        private void ColorspopupMenu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            switch (item.Text)
            {
                case "Red":
                    richTextBox1.SelectionColor = Color.Red;
                    break;
                case "Green":
                    richTextBox1.SelectionColor = Color.Green;
                    break;
                case "Bleu":
                    richTextBox1.SelectionColor = Color.Blue;
                    break;
                case "White":
                    richTextBox1.SelectionColor = Color.White;
                    break;
                case "Yellow":
                    richTextBox1.SelectionColor = Color.Yellow;
                    break;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = comboBox1.SelectedItem.ToString()+" "+ textBox1.Text+" "+textBox2.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = comboBox1.SelectedItem.ToString() + " " + textBox1.Text + " " + textBox2.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = comboBox1.SelectedItem.ToString() + " " + textBox1.Text + " " + textBox2.Text;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            richTextBox1.SaveFile(path);
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }
    }
}
