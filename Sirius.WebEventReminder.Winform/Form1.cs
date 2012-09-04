using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sirius.WebEventReminder.Winform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://szforum/viewforum.php?f=31");
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            int count = 0;
            foreach (HtmlElement element in webBrowser1.Document.GetElementsByTagName("ul"))
            {
                if (element.GetAttribute("className") == "topiclist topics")
                {
                    if (count == 1)
                    {
                        var childCount = element.Children.Count;
                        count = 0;
                    }
                    else
                    {
                        count++;
                    }
                }
            }

            webBrowser1.Navigate("http://szforum/viewforum.php?f=31");
        }
    }
}
