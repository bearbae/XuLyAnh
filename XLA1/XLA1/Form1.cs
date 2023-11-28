namespace XLA1
{
    public partial class Form1 : Form
    {

        Bitmap newbitmap;
        Image file;
        private int gray;

        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                file = Image.FromFile(openFileDialog1.FileName);
                newbitmap = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = file;
            }
        }
        private void processToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                file = Image.FromFile(openFileDialog1.FileName);
                newbitmap = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = file;
            }
        }
        // xử lý âm bản 
        private void button1_Click(object sender, EventArgs e)
        {
            xuly x = new xuly(newbitmap, newbitmap.Width, newbitmap.Height);
            x.XLA1();
            pictureBox2.Image = x.currentbitmap;
        }


        private void minFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xuly x = new xuly(newbitmap, newbitmap.Width, newbitmap.Height);
            x.Min_Filter();
            pictureBox2.Image = x.currentbitmap;
            this.Cursor = Cursors.Default;
        }
        // xử lý bộ lọc min filter
        private void button2_Click(object sender, EventArgs e)
        {
            xuly x = new xuly(newbitmap, newbitmap.Width, newbitmap.Height);
            x.Min_Filter();
            pictureBox2.Image = x.currentbitmap;
            this.Cursor = Cursors.Default;
        }
        // bộ lọc max filter
        private void button3_Click(object sender, EventArgs e)
        {
            xuly x = new xuly(newbitmap, newbitmap.Width, newbitmap.Height);
            x.Max_Filter();
            pictureBox2.Image = x.currentbitmap;
            this.Cursor = Cursors.Default;
        }
        // lọc trung vị
        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap bm = xuly.LocTrungVi(newbitmap);
            pictureBox2.Image = bm;
            MessageBox.Show("Lọc trung vị thành công.");
        }
        // xử lý ảnh thành ảnh nhị phân
        public void nhiphan()
        {
            for (int i = 0; i < newbitmap.Width; i++)
            {
                for (int j = 0; j < newbitmap.Height; j++)
                {
                    Color x = newbitmap.GetPixel(i, j);
                    if (x.R < 128)
                    {
                        newbitmap.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                    }
                    else
                    {
                        newbitmap.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                    }
                }
                pictureBox2.Image = newbitmap;
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            this.nhiphan();
        }

        // xử lý ảnh chuyển thành màu xám 
        private void xam()
        {
            for (int i = 0; i < newbitmap.Width; i++)
            {
                for (int j = 0; j < newbitmap.Height; j++)
                {
                    Color x = newbitmap.GetPixel(i, j);
                    int y = (int)((x.R * 0.2989) + (x.G * 0.5880) + (x.B * 0.1140));
                    Color k = Color.FromArgb(y, y, y);
                    newbitmap.SetPixel(i, j, k);
                }
            }
            pictureBox2.Image = newbitmap;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.xam();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Bitmap resert;
            newbitmap = (Bitmap)Bitmap.FromFile(openFileDialog1.FileName); 
            resert = (Bitmap)newbitmap.Clone();
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.ClientSize = new Size(pictureBox1.Width, pictureBox1.Height); 
            pictureBox2.Image = newbitmap;
        }
    }
}
