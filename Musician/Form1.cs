using System;
using System.Drawing;
using System.Drawing.Imaging;
using static Musician.Image_import;
using static Musician.Neuron;

namespace Musician;

public partial class Form1 : Form
{
    private static int[] frequency;

    private static Color[] colors;
    private TextBox lbl = new TextBox();

    private static TextBox lbl_2 = new TextBox();

    private static PictureBox preview_image = new PictureBox();

    public Form1()
    {
        InitializeComponent();

        lbl.ForeColor = Color.Orange;
        lbl.BackColor = Color.Black;
        lbl.Font = new Font("Hack", 12);
        lbl.Multiline = true;
        lbl.ScrollBars = ScrollBars.Vertical;
        lbl.Location = new Point(10, 10);
        lbl.Size = new Size(300, 300);
        this.Controls.Add(lbl);

        
        lbl_2.ForeColor = Color.Orange;
        lbl_2.BackColor = Color.Black;
        lbl_2.Font = new Font("Hack", 12);
        lbl_2.Multiline = true;
        lbl_2.ScrollBars = ScrollBars.Vertical;
        lbl_2.Location = new Point(690, 10);
        lbl_2.Size = new Size(300, 300);
        this.Controls.Add(lbl_2);

        preview_image.Location = new Point(350, 10);
        preview_image.Size = new Size(300, 300);
        preview_image.SizeMode = PictureBoxSizeMode.Zoom;
        preview_image.Paint += Preview_image_Paint_1;
        this.Controls.Add(preview_image);

        Button open = new Button();
        open.Size = new Size(150, 25);
        open.Location = new Point(10, 320);
        open.Text = "Open";
        open.Click += Open_Click;
        this.Controls.Add(open);

        Button start = new Button();
        start.Size = new Size(150, 25);
        start.Location = new Point(350, 320);
        start.Text = "Generation";
        start.Click += Start_Click;
        this.Controls.Add(start);

        Button play = new Button();
        play.Size = new Size(150, 25);
        play.Location = new Point(690, 320);
        play.Text = "Play";
        play.Click += Play_Click;
        this.Controls.Add(play);

    }

    private void Preview_image_Paint_1(object ? sender, PaintEventArgs e)
    {
        ControlPaint.DrawBorder(e.Graphics, preview_image.ClientRectangle, Color.Black, ButtonBorderStyle.Outset);
    }

    private void Open_Click(object ? sender, EventArgs e)
    {
        colors = Import();

        lbl.Text = Get_file_name() + ":  ";

        for (int i = 0; i < colors.Length; i++)
        {
            lbl.Text += Convert.ToString(colors[i]);
        }

        preview_image.Image = Image.FromFile(Get_file_name());

    }

    private void Start_Click(object ? sender, EventArgs e)
    {
        if (colors != null)
        {
            lbl_2.Text = "New generation:  ";
            Creating_neurons();
        }

        else
        {
            MessageBox.Show("Image file no detected!");
        }
    }

    private static void Creating_neurons()
    {
        frequency = new int[colors.Length];
        //Первый нейронный слой
        lbl_2.Text += "One neurons layer";
        for (int i = 0; i < colors.Length; i++)
        {
            Neuron n = new Neuron(colors[i]);
            frequency[i] = Get_n_result();
            lbl_2.Text += frequency[i] + " ";
        }

        //Второй нейронный слой
        lbl_2.Text += "Two neurons layer";
        for (int i = 0; i < colors.Length; i++)
        {
            Neuron n = new Neuron(Color.FromArgb((frequency[i])));
            frequency[i] = Get_n_result();

            lbl_2.Text += frequency[i] + " ";
        }

        lbl_2.Text += "Three neurons layer";
        for (int i = 0; i < colors.Length; i++)
        {
            Neuron n = new Neuron(Color.FromArgb(Convert.ToInt32(frequency[i])));
            frequency[i] = Get_n_result();

            lbl_2.Text += frequency[i] + " ";
        }

        
        lbl_2.Text += "Four neurons layer";
        for (int i = 0; i < colors.Length; i++)
        {
            Neuron n = new Neuron(Color.FromArgb((frequency[i])));
            frequency[i] = Get_n_result();

            lbl_2.Text += frequency[i] + " ";
        }
    }

    private void Play_Click(object ? sender, EventArgs e)
    {
        if (frequency != null)
        {
            Music_Convertation music = new Music_Convertation(frequency);
        }

        else
        {
            MessageBox.Show("No generations!");
        }
    }
}
