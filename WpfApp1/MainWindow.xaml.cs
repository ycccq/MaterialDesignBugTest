using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            Thread thread = new Thread(ThreadVa);
            thread.IsBackground = true;
            thread.Start();
        }
        int testvar = 0;
        private void ThreadVa()
        {
            while (true)
            {
                for (int i = 0; i < 10000; i++)
                {
                    testvar++;
                    testvalue1 = testvar;
                    testvalue2 = testvar;
                }
                Thread.Sleep(1);
            }
        }
        private int _testvalue1;
        public int testvalue1
        {
            get
            {
                return _testvalue1;
            }
            set
            {
                _testvalue1 = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("testvalue1"));
                }
            }
        }
        private int _testvalue2;
        public int testvalue2
        {
            get
            {
                return _testvalue2;
            }
            set
            {
                _testvalue2 = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("testvalue2"));
                }
            }
        }



    }
}
