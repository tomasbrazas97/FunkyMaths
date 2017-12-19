using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PatternSolver
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HighScore : Page
    {
        public HighScore()
        {
            this.InitializeComponent();
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            RadioButton current = (RadioButton)sender;
            int tag = Convert.ToInt32(current.Tag);
            if (tag == 2)
            {
                ShowScore.Text = Practice.localSettings.Values["HSRadio"].ToString();
            }
        }
    }
}
