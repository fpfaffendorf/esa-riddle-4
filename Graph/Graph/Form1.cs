using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graph
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }        

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            int xCenter = pictureBox1.Width / 2;
            int yCenter = pictureBox1.Height / 2;

            int raSearch = 312825;
            int decSearch = -14280;
            int raDeltaSearch = 400;
            int decDeltaSearch = 200;

            this.Width = (raSearch + raDeltaSearch) - (raSearch - raDeltaSearch);
            this.Height = (decSearch + decDeltaSearch) - (decSearch - decDeltaSearch);

            int[][] data = new int[][]
            {
                new int[] {  312775 , -14104 , 312766 , -14104 }, //  (45778) 2000 OG5  |  17.49
                new int[] {  312924 , -14329 , 312917 , -14330 }, //  (118266) 1998 HQ17  |  18.2
                new int[] {  313178 , -14404 , 313172 , -14408 }, //  (161956) 2007 HG39  |  18.18
                new int[] {  313033 , -14355 , 313026 , -14358 }, //  (191046) 2002 CN39  |  19.73
                new int[] {  312988 , -14227 , 312980 , -14229 }, //  (195159) 2002 CY222  |  20.02
                new int[] {  312750 , -14442 , 312743 , -14444 }, //  (210316) 2007 TZ213  |  20.34
                new int[] {  312943 , -14420 , 312936 , -14421 }, //  (245593) 2005 VL15  |  20.11
                new int[] {  312676 , -14282 , 312669 , -14284 }, //  (261752) 2006 BX25  |  20.41
                new int[] {  312782 , -14298 , 312773 , -14300 }, //  (370009) 1999 WD25  |  21.73
                new int[] {  313040 , -14136 , 313033 , -14137 }, //  (376895) 2001 XF142  |  21.46
                new int[] {  312516 , -14408 , 312508 , -14411 }, //  (540286) 2017 RA67  |  21.88
                new int[] {  313043 , -14407 , 313036 , -14408 }, //  () 2013 AB189  |  21.4
                new int[] {  312959 , -14114 , 312954 , -14121 }, //  () 2015 GT22  |  19.72
                new int[] {  312722 , -14331 , 312717 , -14336 }, //  () 2015 GT43  |  19.33
                new int[] {  312881 , -14430 , 312874 , -14435 }, //  () 2015 KH146  |  20.66
                new int[] {  312460 , -14467 , 312453 , -14468 }, //  () 2015 TL212  |  21.14
                new int[] {  312779 , -14198 , 312855 , -14144 }, //  () 2020 OM3  |  19.56
            };

            string[] names = new string[]
            {
                "(45778) 2000 OG5 | 17.49",
                "(118266) 1998 HQ17 | 18.2",
                "(161956) 2007 HG39 | 18.18",
                "(191046) 2002 CN39 | 19.73",
                "(195159) 2002 CY222 | 20.02",
                "(210316) 2007 TZ213 | 20.34",
                "(245593) 2005 VL15 | 20.11",
                "(261752) 2006 BX25 | 20.41",
                "(370009) 1999 WD25 | 21.73",
                "(376895) 2001 XF142 | 21.46",
                "(540286) 2017 RA67 | 21.88",
                "() 2013 AB189 | 21.4",
                "() 2015 GT22 | 19.72",
                "() 2015 GT43 | 19.33",
                "() 2015 KH146 | 20.66",
                "() 2015 TL212 | 21.14",
                "() 2020 OM3 | 19.56"
            };

            for (int y = 0; y < data.Length; y++)
            {

                int x1 = raSearch + raDeltaSearch - data[y][0];
                int y1 = decSearch + decDeltaSearch - data[y][1];
                int x2 = raSearch + raDeltaSearch - data[y][2];
                int y2 = decSearch + decDeltaSearch - data[y][3];

                Pen penWhite = new Pen(Color.White);
                e.Graphics.DrawLine(
                    penWhite,
                    x1, y1, x2, y2);

                Pen penRed = new Pen(Color.Red);
                e.Graphics.DrawArc(
                    penRed,
                    x1, y1, 2, 2, 0, 360);

                Pen penGreen = new Pen(Color.Green);
                e.Graphics.DrawArc(
                    penGreen,
                    x2, y2, 2, 2, 0, 360);

                Font drawFont = new Font("Arial", 10);
                SolidBrush drawBrush = new SolidBrush(Color.White);
                e.Graphics.DrawString(names[y].ToString(), drawFont, drawBrush, x2, y2);

            }

        }
    }
}
