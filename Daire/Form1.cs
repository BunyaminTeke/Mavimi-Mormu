using Accessibility;
using System.Reflection.Metadata.Ecma335;

namespace Daire
{
    public partial class Form1 : Form
    {
        int k;
        List<Label> kareler = new List<Label>();
        List<Label> labels = new List<Label>();
        Label sagKarakter = new Label();
        Label solKarakter = new Label();


        int sagKarakterdx;
        int sagKarakterdy;

        int solKarakterdx;
        int solKarakterdy;
        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < 18; i++)
            {
                for (int j = 0; j < 18; j++)
                {
                    labels.Add(new Label()
                    {
                        Width = 25,
                        Height = 25,
                        Location = new Point(i * 25, j * 25),
                        BackColor = Color.RoyalBlue,
                        BorderStyle = BorderStyle.Fixed3D,

                    });

                    kareler.Add(new Label()
                    {
                        Width = 25,
                        Height = 25,
                        Location = new Point((i * 25) + 25 * 18, j * 25),
                        BackColor = Color.RebeccaPurple,
                        BorderStyle = BorderStyle.Fixed3D,
                    });

                    labels[i].SendToBack();
                    kareler[i].SendToBack();
                    this.Controls.Add(kareler[k]);
                    this.Controls.Add(labels[k]);
                    k++;


                }
            }


            solKarakter.Width = 25;
            solKarakter.Height = 25;
            solKarakter.BackColor = Color.RebeccaPurple;
            solKarakter.Location = new Point((new Random().Next(0, 17)) * 25, (new Random().Next(0, 17)) * 25);
            solKarakter.BorderStyle = BorderStyle.FixedSingle;




            sagKarakter.Width = 25;
            sagKarakter.Height = 25;
            sagKarakter.BackColor = Color.RoyalBlue;
            sagKarakter.Location = new Point(((new Random().Next(0, 17)) * 25) + 25 * 18, (new Random().Next(0, 17)) * 25);
            sagKarakter.BorderStyle = BorderStyle.FixedSingle;

            

            this.Controls.Add(sagKarakter);
            sagKarakter.BringToFront();

            this.Controls.Add(solKarakter);
            solKarakter.BringToFront();
            timer1.Start();



            m = new Random().Next(-3, 3);
            m = Sifirmi(m);
            sagKarakterdx = m * 6 ;

            m = new Random().Next(-3, 3);
            m = Sifirmi(m);
            sagKarakterdy = m * 6;

            m = new Random().Next(-3, 3);
            m = Sifirmi(m);
            solKarakterdx = m * 6;

            m = new Random().Next(-3, 3);
            m = Sifirmi(m);
            solKarakterdy = m * 6;
        }

        public int Sifirmi(int sayi)
        {
            if (sayi == 0)
            {
                return new Random().Next(-3, 3);
            }
            else
            {
                return sayi;
            }
        }

        int m;
        int maviSayisi;
        int morSayisi;
        int sayac;

        private void Kazanan()
        {
            foreach (Label item in Controls)
            {
                if (item.BackColor == sagKarakter.BackColor)
                {
                    morSayisi++;
                }
                else
                {
                    maviSayisi++;
                }
            }

            if(maviSayisi > morSayisi)
            {
                MessageBox.Show("Maviler " + maviSayisi + " skor ile kazandý " + "Morlar ise " + morSayisi + " puanda kaldý");
            }
            else
            {
                MessageBox.Show("Morlar " + morSayisi + " skor ile kazandý" + "Maviler ise " + maviSayisi + " puanda kaldý");
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;
            if (sayac == 25 * 60)
            {
                timer1.Stop();
                Kazanan();
            }

            sagKarakter.Location = new Point(sagKarakter.Location.X + sagKarakterdx, sagKarakter.Location.Y + sagKarakterdy);
            solKarakter.Location = new Point(solKarakter.Location.X + solKarakterdx, solKarakter.Location.Y + solKarakterdy);

            foreach (Label item in Controls)
            {
                if (solKarakter.Bounds.IntersectsWith(item.Bounds) || item.BackColor == solKarakter.BackColor)
                {
                    item.BackColor = Color.RoyalBlue;
                }
             


            }

            foreach (Label item in this.Controls)
            {
             
                if (sagKarakter.Bounds.IntersectsWith(item.Bounds) || item.BackColor == sagKarakter.BackColor)
                {
                    item.BackColor = Color.RebeccaPurple;
                }
            }


            if (sagKarakter.Location.X <= 0 || sagKarakter.Location.X >= ClientSize.Width -25)
            {
                sagKarakterdx = -sagKarakterdx;

            }else if (sagKarakter.Location.Y <= 0 || sagKarakter.Location.Y >= ClientSize.Height- 25)
            {
                sagKarakterdy = -sagKarakterdy;
            }

            if(solKarakter.Location.X <= 0 || solKarakter.Location.X >= ClientSize.Width -25)
            {
                solKarakterdx = -solKarakterdx;

            }else if (solKarakter.Location.Y <= 0 || solKarakter.Location.Y >= ClientSize.Height -25)
            {
                solKarakterdy = -solKarakterdy;
            }

        }
    }
}
