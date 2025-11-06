using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
namespace Tarabi_119

{
    //اگر روی هر دکمه نگه دارید خودش میره نیازی نیست هربار دکمه رو بزنید ولی میتونید دکمه هم بزنید
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {



        }
        int count = 0;
        bool start = false;
        int speed = 5;
        bool up = false;
        bool down = false;
        bool left = false;
        bool right = false;
        bool score17 = false;
        bool score3 = false;
        bool score25 = false;
        bool a = false;
        bool b = false;

        private Random random = new Random();

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button1.Text = "شروع شده";

            start = true;
           
            up = false;
            down = false;
            left = false;
            right = false;
            pictureBox1.Visible = true;
            pictureBox8.Visible = false;
          
            timer1.Stop();
             MessageBox.Show("به بازی خوش آمدی! برای عبور از این مرحله باید به دو سؤال ریاضی پاسخ درست بدی و اگر هرکدام را رد کنی بازی به پایان می رسد.", "شروع بازی");

             Random random = new Random();
             int corr = 0;

             for (int i = 1; i <= 2; i++)
             {
                 int a = random.Next(1, 10);
                 int b1 = random.Next(1, 10);
                 int x = random.Next(1, 5);
                 int res = a * x + b1;

                 string que = "سؤال " + i + ":\n" + a + "x + " + b1 + " = " + res + "\n x:";
                 string input = Microsoft.VisualBasic.Interaction.InputBox(que, "پرسش ریاضی", "");


                 if (String.IsNullOrEmpty((input)))
                 {
                     MessageBox.Show("سوالات را رد نکنید!دوباره شروع کنید", "پایان");
                    button1.Enabled = true;
                    button1.Text = "شروع";
                        start = false;

                    return;
                 }

                 int userAnswer;
                 if (int.TryParse(input, out userAnswer))
                 {
                     if (userAnswer == x)
                     {
                         corr++;
                         MessageBox.Show("درسته", "پاسخ درست");
                     }
                     else
                     {
                         MessageBox.Show($"اشتباه گفتی پاسخ درست {x} بود.", "پاسخ اشتباه");
                     }
                 }
                 else
                 {
                     MessageBox.Show("ورودی معتبر نیست", "خطا");
                     i--; 
                     continue;
                 }
             }

             if (corr == 2)
             {
                 MessageBox.Show(" هر دو پاسخ درست بودن، حالا می‌تونی وارد بازی بشی و در آخر هم باید از حصار خارج شوی تا امتیازت نمایش داده شود و حتی اگر منصرف شدی هم می توانی در وسط بازی پایان را بزنی", "موفقیت");
                 pictureBox4.Visible = false;
                 label5.Visible = false;

             }
             else if (corr == 1)
             {
                 MessageBox.Show("فقط یکی از پاسخ‌ها درست بود دوباره تلاش کن.", "تلاش دوباره");
               
                button1.Enabled = true;
                button1.Text = "شروع دوباره";
                 start = false;
            }
             else
             {
                 MessageBox.Show("هیچ پاسخی درست نبود بازی تمام شد.", "پایان");
                 this.Close();
             }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (!start)
            {
                MessageBox.Show("لطفا دکمه شروع را بزنید", "هشدار");

                return;
            }
            pictureBox1.Top -= speed;

            if (pictureBox1.Bounds.IntersectsWith(label1.Bounds) ||
          pictureBox1.Bounds.IntersectsWith(label6.Bounds) ||
          pictureBox1.Bounds.IntersectsWith(label26.Bounds)||
          pictureBox1.Bounds.IntersectsWith(label4.Bounds) ||
          pictureBox1.Bounds.IntersectsWith(label7.Bounds) ||
          pictureBox1.Bounds.IntersectsWith(label8.Bounds) ||
          pictureBox1.Bounds.IntersectsWith(label9.Bounds) ||
          pictureBox1.Bounds.IntersectsWith(label10.Bounds) ||
          pictureBox1.Bounds.IntersectsWith(label11.Bounds) ||
          pictureBox1.Bounds.IntersectsWith(label12.Bounds) ||
          pictureBox1.Bounds.IntersectsWith(label13.Bounds) ||
          pictureBox1.Bounds.IntersectsWith(label14.Bounds) ||
          pictureBox1.Bounds.IntersectsWith(label15.Bounds) ||
          pictureBox1.Bounds.IntersectsWith(label16.Bounds) ||
          pictureBox1.Bounds.IntersectsWith(label18.Bounds) ||
          pictureBox1.Bounds.IntersectsWith(label19.Bounds) ||  
          pictureBox1.Bounds.IntersectsWith(label20.Bounds) ||
          pictureBox1.Bounds.IntersectsWith(label21.Bounds) ||
          pictureBox1.Bounds.IntersectsWith(label22.Bounds) ||
          pictureBox1.Bounds.IntersectsWith(label23.Bounds) ||
          pictureBox1.Bounds.IntersectsWith(label27.Bounds) ||
          pictureBox1.Bounds.IntersectsWith(label28.Bounds) ||
          pictureBox1.Bounds.IntersectsWith(label24.Bounds))
            {
                timer1.Stop();
                MessageBox.Show("نمی‌توانید از اینجا عبور کنید! یک امتیاز کسر شد.", "خطا");
                count--;
                timer1.Start();
            }
            if (pictureBox1.Bounds.IntersectsWith(label2.Bounds))
            {
                pictureBox2.Visible = false;
                MessageBox.Show("بازی به اتمام رسید", "پایان");
                MessageBox.Show($"شما موفق به دریافت{count} امتیاز شدید ", "پایان");
                Close();
            }
            if (!score17 && pictureBox1.Bounds.IntersectsWith(label17.Bounds))
            {
                timer1.Stop();
                MessageBox.Show("شما 5 امتیاز گرفتید", "امتیاز");
                count+=5;
                pictureBox6.Visible = false;
                label17.Visible = false;
                score17 = true;
                timer1.Start();
            }

            if (!score3 && pictureBox1.Bounds.IntersectsWith(label3.Bounds))
            {
                timer1.Stop();
                MessageBox.Show("شما 4 امتیاز گرفتید", "امتیاز");
                count+=4;
                pictureBox5.Visible = false;
                label3.Visible = false;
                score3 = true;
                timer1.Start();
            }

            if (!score25 && pictureBox1.Bounds.IntersectsWith(label25.Bounds))
            {
                timer1.Stop();
                MessageBox.Show("شما 8 امتیاز گرفتید", "امتیاز");
                count+=8;
                pictureBox7.Visible = false;
                label25.Visible = false;
                score25 = true;
                timer1.Start();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!start)
            {
               
                MessageBox.Show("لطفا دکمه شروع را بزنید", "هشدار");
              
                return;
            }
            pictureBox1.Left -= speed;
            pictureBox8.Visible = true;
            pictureBox8.Location = pictureBox1.Location;
            pictureBox8.Size = pictureBox1.Size;
            pictureBox1.Visible = false;
            if (pictureBox1.Bounds.IntersectsWith(label1.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label6.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label4.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label7.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label8.Bounds) ||
            pictureBox1.Bounds.IntersectsWith(label26.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label9.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label10.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label11.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label12.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label13.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label14.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label15.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label16.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label18.Bounds) ||
             pictureBox1.Bounds.IntersectsWith(label27.Bounds) ||
          pictureBox1.Bounds.IntersectsWith(label28.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label19.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label20.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label21.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label22.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label23.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label24.Bounds))
            {
                timer1.Stop();
                MessageBox.Show("نمی‌توانید از اینجا عبور کنید! یک امتیاز کسر شد.", "خطا");
                count--;
                timer1.Start();
            }
            if (pictureBox1.Bounds.IntersectsWith(label2.Bounds))
            {
                pictureBox2.Visible = false;
                MessageBox.Show("بازی به اتمام رسید", "پایان");
                MessageBox.Show($"شما موفق به دریافت{count} امتیاز شدید ", "پایان");
                Close();
            }
            if (!score17 && pictureBox1.Bounds.IntersectsWith(label17.Bounds))
            {
                timer1.Stop();
                MessageBox.Show("شما 5 امتیاز گرفتید", "امتیاز");
                count += 5;
                pictureBox6.Visible = false;
                label17.Visible = false;
                score17 = true;
                timer1.Start();
            }

            if (!score3 && pictureBox1.Bounds.IntersectsWith(label3.Bounds))
            {
                timer1.Stop();
                MessageBox.Show("شما 4 امتیاز گرفتید", "امتیاز");
                count += 4;
                pictureBox5.Visible = false;
                label3.Visible = false;
                score3 = true;
                timer1.Start();
            }

            if (!score25 && pictureBox1.Bounds.IntersectsWith(label25.Bounds))
            {
                timer1.Stop();
                MessageBox.Show("شما 8 امتیاز گرفتید", "امتیاز");
                count += 8;
                pictureBox7.Visible = false;
                label25.Visible = false;
                score25 = true;
                timer1.Start();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!start)
            {
                MessageBox.Show("لطفا دکمه شروع را بزنید", "هشدار");
                return;
            }
            pictureBox1.Left += speed;
            if (pictureBox1.Bounds.IntersectsWith(label1.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label6.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label4.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label7.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label8.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label9.Bounds) ||
            pictureBox1.Bounds.IntersectsWith(label26.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label10.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label11.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label12.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label13.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label14.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label15.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label16.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label18.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label19.Bounds) ||
             pictureBox1.Bounds.IntersectsWith(label27.Bounds) ||
          pictureBox1.Bounds.IntersectsWith(label28.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label20.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label21.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label22.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label23.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label24.Bounds))
            {
                timer1.Stop();
                MessageBox.Show("نمی‌توانید از اینجا عبور کنید! یک امتیاز کسر شد.", "خطا");
                count--;
                timer1.Start();
            }
            if (pictureBox1.Bounds.IntersectsWith(label2.Bounds))
            {
                pictureBox2.Visible = false;
                MessageBox.Show("بازی به اتمام رسید", "پایان");
                MessageBox.Show($"شما موفق به دریافت{count} امتیاز شدید ", "پایان");
                Close();
            }
            if (!score17 && pictureBox1.Bounds.IntersectsWith(label17.Bounds))
            {
                timer1.Stop();
                MessageBox.Show("شما 5 امتیاز گرفتید", "امتیاز");
                count += 5;
                pictureBox6.Visible = false;
                label17.Visible = false;
                score17 = true;
                timer1.Start();
            }

            if (!score3 && pictureBox1.Bounds.IntersectsWith(label3.Bounds))
            {
                timer1.Stop();
                MessageBox.Show("شما 4 امتیاز گرفتید", "امتیاز");
                count += 4;
                pictureBox5.Visible = false;
                label3.Visible = false;
                score3 = true;
                timer1.Start();
            }

            if (!score25 && pictureBox1.Bounds.IntersectsWith(label25.Bounds))
            {
                timer1.Stop();
                MessageBox.Show("شما 8 امتیاز گرفتید", "امتیاز");
                count += 8;
                pictureBox7.Visible = false;
                label25.Visible = false;
                score25 = true;
                timer1.Start();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!start)
            {
                MessageBox.Show("لطفا دکمه شروع را بزنید", "هشدار");
                return;
            }
            pictureBox1.Top += speed;
            if (pictureBox1.Bounds.IntersectsWith(label1.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label6.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label4.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label7.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label8.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label9.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label10.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label11.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label12.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label13.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label14.Bounds) ||
             pictureBox1.Bounds.IntersectsWith(label27.Bounds) ||
          pictureBox1.Bounds.IntersectsWith(label28.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label15.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label16.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label18.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label19.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label20.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label21.Bounds) ||
            pictureBox1.Bounds.IntersectsWith(label26.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label22.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label23.Bounds) ||
           pictureBox1.Bounds.IntersectsWith(label24.Bounds))
            {
                timer1.Stop();
                MessageBox.Show("نمی‌توانید از اینجا عبور کنید! یک امتیاز کسر شد.", "خطا");
                count--;
                timer1.Start();
            }
            if (pictureBox1.Bounds.IntersectsWith(label2.Bounds))
            {
                pictureBox2.Visible = false;
                MessageBox.Show("بازی به اتمام رسید", "پایان");
                MessageBox.Show($"شما موفق به دریافت{count} امتیاز شدید ", "پایان");
                Close();
            }
            if (!score17 && pictureBox1.Bounds.IntersectsWith(label17.Bounds))
            {
                timer1.Stop();
                MessageBox.Show("شما 5 امتیاز گرفتید", "امتیاز");
                count += 5;
                pictureBox6.Visible = false;
                label17.Visible = false;
                score17 = true;
                timer1.Start();
            }

            if (!score3 && pictureBox1.Bounds.IntersectsWith(label3.Bounds))
            {
                timer1.Stop();
                MessageBox.Show("شما 4 امتیاز گرفتید", "امتیاز");
                count += 4;
                pictureBox5.Visible = false;
                label3.Visible = false;
                score3 = true;
                timer1.Start();
            }

            if (!score25 && pictureBox1.Bounds.IntersectsWith(label25.Bounds))
            {
                timer1.Stop();
                MessageBox.Show("شما 8 امتیاز گرفتید", "امتیاز");
                count += 8;
                pictureBox7.Visible = false;
                label25.Visible = false;
                score25 = true;
                timer1.Start();
            }

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }


        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"شما موفق به دریافت{count} امتیاز شدید ", "پایان");
            DialogResult result = MessageBox.Show("ایا قصد دارید بازی جدیدی شروع کنید؟", "سوال", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {

                a = false;
                Application.Restart();
                count = 0;

            }
            if (result == DialogResult.No)
                Close();
            Close();
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            if (!start)
            {
                MessageBox.Show("لطفا دکمه شروع را بزنید", "هشدار");
                return;
            }

            up = true;
            timer1.Start();
            pictureBox1.Visible = true;
            pictureBox8.Visible = false;
        }

        private void button3_MouseUp(object sender, MouseEventArgs e)
        {
            up = false;
            timer1.Stop();
        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (!start)
                return;

            if (up)
            {
                pictureBox1.Top -= speed;
                if (pictureBox8.Visible)
                    pictureBox8.Top -= speed;
            }
            if (right)
            {
                pictureBox1.Left += speed;
                if (pictureBox8.Visible)
                    pictureBox8.Left += speed;
            }
            if (left)
            {
                pictureBox1.Left -= speed;
                if (pictureBox8.Visible)
                    pictureBox8.Left -= speed;
            }
            if (down)
            {
                pictureBox1.Top += speed;
                if (pictureBox8.Visible)
                    pictureBox8.Top += speed;
            }

       
            bool b = false;
            Control currentPlayer = pictureBox8.Visible ? pictureBox8 : pictureBox1;

            b = currentPlayer.Bounds.IntersectsWith(label1.Bounds) ||
                currentPlayer.Bounds.IntersectsWith(label6.Bounds) ||
                currentPlayer.Bounds.IntersectsWith(label4.Bounds) ||
                currentPlayer.Bounds.IntersectsWith(label7.Bounds) ||
                currentPlayer.Bounds.IntersectsWith(label8.Bounds) ||
                currentPlayer.Bounds.IntersectsWith(label9.Bounds) ||
                currentPlayer.Bounds.IntersectsWith(label10.Bounds) ||
                currentPlayer.Bounds.IntersectsWith(label11.Bounds) ||
                currentPlayer.Bounds.IntersectsWith(label12.Bounds) ||
                currentPlayer.Bounds.IntersectsWith(label13.Bounds) ||
                currentPlayer.Bounds.IntersectsWith(label14.Bounds) ||
                currentPlayer.Bounds.IntersectsWith(label15.Bounds) ||
                currentPlayer.Bounds.IntersectsWith(label16.Bounds) ||
                currentPlayer.Bounds.IntersectsWith(label18.Bounds) ||
                currentPlayer.Bounds.IntersectsWith(label19.Bounds) ||
                currentPlayer.Bounds.IntersectsWith(label20.Bounds) ||
                currentPlayer.Bounds.IntersectsWith(label21.Bounds) ||
                currentPlayer.Bounds.IntersectsWith(label22.Bounds) ||
                currentPlayer.Bounds.IntersectsWith(label23.Bounds) ||
                currentPlayer.Bounds.IntersectsWith(label24.Bounds);

            if (b && !a)
            {
                a = true;
                timer1.Stop();
                MessageBox.Show("نمی‌توانید از اینجا عبور کنید! یک امتیاز کسر شد.", "خطا");
                count--;

                if (up)
                {
                    pictureBox1.Top += speed;
                    if (pictureBox8.Visible)
                        pictureBox8.Top += speed;
                }
                if (down)
                {
                    pictureBox1.Top -= speed;
                    if (pictureBox8.Visible)
                        pictureBox8.Top -= speed;
                }
                if (left)
                {
                    pictureBox1.Left += speed;
                    if (pictureBox8.Visible)
                        pictureBox8.Left += speed;
                }
                if (right)
                {
                    pictureBox1.Left -= speed;
                    if (pictureBox8.Visible)
                        pictureBox8.Left -= speed;
                }

                up = false;
                down = false;
                left = false;
                right = false;
                timer1.Stop();
                return;
            }
            else if (!b)
            {
                a = false;
            }

     
            if (!score17 && currentPlayer.Bounds.IntersectsWith(label17.Bounds))
            {
                score17 = true;
                timer1.Stop();
                MessageBox.Show("شما 5 امتیاز گرفتید", "امتیاز");
                count += 5;
                pictureBox6.Visible = false;
                label17.Visible = false;
                up = false;
                down = false;
                left = false;
                right = false;
                return;
            }

            if (!score3 && currentPlayer.Bounds.IntersectsWith(label3.Bounds))
            {
                score3 = true;
                timer1.Stop();
                MessageBox.Show("شما 4 امتیاز گرفتید", "امتیاز");
                count += 4;
                pictureBox5.Visible = false;
                label3.Visible = false;
                up = false;
                down = false;
                left = false;
                right = false;
                return;
            }

            if (!score25 && currentPlayer.Bounds.IntersectsWith(label25.Bounds))
            {
                score25 = true;
                timer1.Stop();
                MessageBox.Show("شما 8 امتیاز گرفتید", "امتیاز");
                count += 8;
                pictureBox7.Visible = false;
                label25.Visible = false;
                up = false;
                down = false;
                left = false;
                right = false;
                return;
            }
        }
        private void button6_MouseDown(object sender, MouseEventArgs e)
        {
            right = true;
            timer1.Start();
            pictureBox1.Visible = true;
            pictureBox8.Visible = false;
        }

        private void button6_MouseUp(object sender, MouseEventArgs e)
        {
            right = false;
            timer1.Stop();
        }

        private void button5_MouseDown(object sender, MouseEventArgs e)
        {
            left = true;
            timer1.Start();
            pictureBox8.Visible = true;
            pictureBox8.Location = pictureBox1.Location;
            pictureBox8.Size = pictureBox1.Size;
            pictureBox1.Visible = false;
        }

        private void button5_MouseUp(object sender, MouseEventArgs e)
        {
            left = false;
            timer1.Stop();
            
        }

        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            if (!start)
            {
                MessageBox.Show("لطفا دکمه شروع را بزنید", "هشدار");
                return;
            }

            down = true;
            timer1.Start();
            pictureBox1.Visible = true;
            pictureBox8.Visible = false;
        }

        private void button4_MouseUp(object sender, MouseEventArgs e)
        {
            down = false;
            timer1.Stop();
        }


        private void pictureBox6_Click(object sender, EventArgs e)
        {


        }

        private void label17_Click(object sender, EventArgs e)

        {

        }

        private void label17_Click_1(object sender, EventArgs e)
        {

        }

        private void label17_Click_2(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }
    }
}