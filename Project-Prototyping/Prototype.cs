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

namespace Project_Prototyping
{ 

    public partial class Prototype : Form
    {
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private PrintDialog printDialog;

        private string filePath = string.Empty;
        private string fileContent = string.Empty;

        int num = 0;
        private bool a;

        public Prototype()
        {
            InitializeComponent();
        }

        //Creates a new file
        private void new_file()
        {
            try
            {
                if (!string.IsNullOrEmpty(TB_Home.Text))
                {
                    MessageBox.Show ("Are you sure you want to create a new file without saving?");      
                }
                else
                {   
                    MessageBox.Show("New file created");
                }
            }
            catch (Exception ex)
            {

            }
        }

        //Opens file
        private void open_file()
        {
            try
            {
                openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;

                    var FileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(FileStream))
                        {
                        fileContent = reader.ReadToEnd();
                        }
                }
            }
            catch
            {

            }
        }

        //saves file
        private void save_file()
        {
            try
            {
                if(!string.IsNullOrEmpty(TB_Home.Text))
                {
                    saveFileDialog = new SaveFileDialog();
                    if(saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveFileDialog.FileName, TB_Home.Text); 
                    }
                }
                else
                {
                    MessageBox.Show("File is empty");
                }
            }
            catch
            {

            }
        }

        //prints file
        private void print_file()
        {
            try
            {
                printDialog = new PrintDialog();
                printDialog.ShowDialog();
            }
            catch
            {

            }
        }
        //new file
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new_file();
        }
        //Opens file
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            open_file();
        }
        //Saves file
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save_file();
        }
        //Save as file
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save_file();
        }
        //Prints File
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            print_file();
        }

        //Creates shortcut keys
        private void SetUpMyMenuShortCuts()
        {
            cutToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            cutToolStripMenuItem.ShowShortcutKeys = true;
            MessageBox.Show("Cut");
        }
        //Cut
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TB_Home.Cut();
            
        }
        //Copy
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TB_Home.Copy();
        }
        //Paste
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TB_Home.Paste();
        }
        //Undo
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TB_Home.Undo();
        }
        //Redo
        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TB_Home.Redo();
        }
        //Changes back color
        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            int color = colorDialog1.Color.ToArgb();
            TB_Home.BackColor = Color.FromArgb(color);
        }
        //Changes fore color
        private void foreColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            int color = colorDialog1.Color.ToArgb();
            TB_Home.ForeColor = Color.FromArgb((int)color);
        }
        //Print preview
        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }
        //ruler
        private void rulerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        //tool strip cut
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            TB_Home.Cut();
        }
        //tool strip copy
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            TB_Home.Copy();
        }
        //Tool strip paste
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            TB_Home.Paste();
        }
        //Text allign left right
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            TB_Home.SelectionAlignment = HorizontalAlignment.Left;
        }
        //Text allign center
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            TB_Home.SelectionAlignment = HorizontalAlignment.Center;
        }
        //Font
        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }
        //Font size
        private void toolStripComboBox2_Click(object sender, EventArgs e)
        {

        }
        //Populate ComboBoxes
        private void Prototype_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (FontFamily font in FontFamily.Families)
                {
                    toolStripComboBox1.Items.Add(font.Name);
                }

                while (toolStripComboBox2.Items.Count < 40)
                {
                    num += 1;
                    toolStripComboBox2.Items.Add(num);
                }
            }
            
            catch (Exception ex)
            {

            }
        }
        //bold
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            TB_Home.SelectionFont = new Font(TB_Home.Font, TB_Home.SelectionFont.Style ^ FontStyle.Bold);

        }
        //Ittalic
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            TB_Home.SelectionFont = new Font(TB_Home.Font, TB_Home.SelectionFont.Style ^ FontStyle.Italic);
        }
        //Underline
        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            TB_Home.SelectionFont = new Font(TB_Home.Font, TB_Home.SelectionFont.Style ^ FontStyle.Underline);
        }
        //Right allign
        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            TB_Home.SelectionAlignment = HorizontalAlignment.Right;
        }
        //Font family
        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fontFamily = toolStripComboBox1.Text;
            Font font = new Font(fontFamily, Font.Size);
            TB_Home.Font = font;

        }
        //Font Size
        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                TB_Home.Font = new Font(TB_Home.Font.FontFamily, Convert.ToInt32(toolStripComboBox2.SelectedItem), TB_Home.Font.Style);
            }
            catch
            {

            }
        }
        //Undo tool bar
        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            TB_Home.Undo();
        }
        //Redo tool bar
        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            TB_Home.Redo();
        }
    }
}
