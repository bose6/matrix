using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace THREAD
{
    public partial class Form1 : Form
    {
        //Add the member variables
        public int m_width; //Width of the grid cell

        public int m_Height; // The height of the Cell

        public int m_NoOfRows; // The Number Of Rows

        public int m_NoOfCols; // The Number Of Columns

        public int m_XOffset; //Offset from which drawing start
        public int m_YOffset;

        public const int DEFAULT_X_OFFSET = 100;
        public const int DEFAULT_Y_OFFSET = 50;
        public const int DEFAULT_NO_ROWS = 2;
        public const int DEFAULT_NO_COLS = 2;
        public const int DEFAULT_WIDTH = 60;
        public const int DEFAULT_HEIGHT = 60;
        public  int rc= 8;
        public Form1()
        {
            Initialize();
            InitializeComponent();
            status = false;
        }
        public void Initialize()
        {
            //Put all the default values
            m_NoOfRows = DEFAULT_NO_ROWS;
            m_NoOfCols = DEFAULT_NO_COLS;
            m_width = DEFAULT_WIDTH;
            m_Height = DEFAULT_HEIGHT;
            m_XOffset = DEFAULT_X_OFFSET;
            m_YOffset = DEFAULT_Y_OFFSET;

        }
        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void sTARTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            flag = new Thread(new ThreadStart(ondraw));
            flag.Start();
        }

        private void rESUMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag.Resume();
       
        }

      
        private void pAUSEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag.Suspend();
        }

        void ondraw()
        {

            Graphics boardLayout = this.CreateGraphics();

            Pen layoutPen = new Pen(Color.Red);
            Pen layoutPen1 = new Pen(Color.White);
            layoutPen.Width = 5;
            layoutPen1.Width = 5;
            int counterflag = 2;
            while (counterflag <= rc)
            {
                Thread.Sleep(1000);
                if (counterflag != rc)
                {
                    m_NoOfRows = counterflag;
                    m_NoOfCols = counterflag;
                    //boardLayout.DrawLine(layoutPen, 0, 0, 100, 0);
                    int X = DEFAULT_X_OFFSET;
                    int Y = DEFAULT_Y_OFFSET;
                    //Draw The rows
                    for (int i = 0; i <= m_NoOfRows; i++)
                    {
                        boardLayout.DrawLine(layoutPen, X, Y, X + this.m_width * this.m_NoOfCols, Y);
                        Y = Y + m_Height;
                    }

                    //Draw The Cols
                    X = DEFAULT_X_OFFSET;
                    Y = DEFAULT_Y_OFFSET;
                    for (int j = 0; j <= m_NoOfCols; j++)
                    {
                        boardLayout.DrawLine(layoutPen, X, Y, X, Y + this.m_Height * this.m_NoOfRows);
                        X = X + this.m_width;
                    }
                    counterflag++;
                }
                else
                {
                    counterflag = 2;

                    Invalidate();


                }


            }

        }

        public void start()
        {
            flag = new Thread(new ThreadStart(ondraw));
            flag.Start();
            Invalidate();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            start();



        }

        private void button2_Click(object sender, EventArgs e)
        {
            flag.Suspend();
           


        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            rc = 4;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            rc = 5;
            start();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            rc = 6;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            rc = 7;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            rc = 8;
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            rc = 9;
        }
    }
}
