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
using System.Collections;
using System.Text.RegularExpressions;

namespace TestCode
{
    public partial class Form1 : Form
    {
        int musicTotal;
        int movieTotal;
        int imageTotal;
        int otherTotal;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string S = File.ReadAllText(@"D:\file.txt", Encoding.UTF8);
            string[] ss = new string[] {"\r\n"};
            string[] temp = S.Split(ss, 500, StringSplitOptions.RemoveEmptyEntries);

            foreach(string str in temp)
            {
                GenFile(str);
            }


            string res = "music " + musicTotal.ToString() + "b\r\n"
                         + "images " + imageTotal.ToString() + "b\r\n"
                         + "movies " + movieTotal.ToString() + "b\r\n"
                         + "other " + otherTotal.ToString() + "b";

            MessageBox.Show(res);
        }


        private void GenFile(string s)
        {
            string file;

            if (s.Length > 30)
                file = s.Substring(0, 29);
            else
                file = s;


            string[] temp = file.Split(' ');
            string filename = temp[0];
            if(filename != null)
            {
                if (new Regex("[a-zA-Z0-9]").IsMatch(filename))
                {
                    string size = temp[1].Substring(0, temp[1].Length - 1);

                    int idx = filename.LastIndexOf('.');
                    string ext;

                    if (idx != -1)
                    {
                        //Console.WriteLine(filename.Substring(0, idx));
                        ext = filename.Substring(idx + 1);
                        ext = ext.ToLower();

                        if (new Regex("[a-z0-9]").IsMatch(ext))
                        {
                            if (ext.Contains("mp3") || ext.Contains("aac") || ext.Contains("flac"))
                            {
                                musicTotal = musicTotal + Int32.Parse(size);
                            }
                            else if (ext.Contains("jpg") || ext.Contains("bmp") || ext.Contains("gif"))
                            {
                                imageTotal = imageTotal + Int32.Parse(size);
                            }
                            else if (ext.Contains("mp4") || ext.Contains("avi") || ext.Contains("mkv"))
                            {
                                movieTotal = movieTotal + Int32.Parse(size);

                            }
                            else
                            {
                                otherTotal = otherTotal + Int32.Parse(size);
                            }
                        }
                    }
                }

            }
        }







        private void button2_Click(object sender, EventArgs e)
        {

            int[] A = {100,63,1,6,2,13};
            int sm = solution5(5, 6, A);


            //int sm = minimumOperations(A, A.Length);
            MessageBox.Show(sm.ToString());
        }

        public int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)

            int smallest = 0;

            for (int i = 0; i < A.Length -1 ; i++)
            {
                if (i == 0)
                    smallest = A[i];
                else
                {
                    if (smallest.CompareTo(A[i + 1]) > -1)
                    {
                        smallest = A[i];
                    }
                }
          
            }

            return smallest + 1;
        }

 

        // Function that returns minimum number of changes
        public static int minimumOperations(int[] a, int n)
        {

            int initCounter = 0;

            Dictionary<int, int> mydict = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                if (mydict.ContainsKey(a[i]))
                {
                    var val = mydict[a[i]];
                    mydict.Remove(a[i]);
                    mydict.Add(a[i], val + 1);
                }
                else
                {
                    mydict.Add(a[i], 1);
                }
            }


            foreach (KeyValuePair<int, int> item in mydict)
            {
                if (item.Value > 1)
                {
                    initCounter += (item.Value - 1);
                }
            }

            return initCounter;
        }


        public int solution5(int X, int Y, int[] A)
        {
            int N = A.Length;
            int result = -1;
            int nX = 0;
            int nY = 0;
            for (int i = 0; i < N; i++)
            {
                if (A[i] == X)
                    nX += 1;
                else if (A[i] == Y)
                    nY += 1;
                if (nX == nY && (nX > 0 || nY > 0))
                    result = i;
            }
            return result;
        }

    }
}
