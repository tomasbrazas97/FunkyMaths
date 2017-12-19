using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI;
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
    public sealed partial class Practice : Page
    {
        //variables
        DispatcherTimer timer = new DispatcherTimer();
        const int SCORE_INCREMENT = 1;
        public int num1;
        public int num2;
        public int char1;
        public int answer;
        char[] symbol1 = "+-*".ToCharArray();
        String symbol2 = "=";

        //initialize
        public int score = 0;
        public int correctCounter = 0;
 
        public static ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

        public Practice()
        {
            this.InitializeComponent();    
          
        }

        public void Start_Click(object sender, RoutedEventArgs e)
        {

            Random ran1 = new Random();
            char1 = ran1.Next(symbol1.Length);
            firstSymbol.Text = symbol1[char1].ToString();
            
            if (firstSymbol.Text == "+")
            {
                num1 = ran1.Next(100);
                num2 = ran1.Next(100);
            }
            else
            {
                num1 = ran1.Next(100);
                num2 = ran1.Next(0, num1);
            }

            firstNum.Text = num1.ToString();
            secondNum.Text = num2.ToString();
            equals.Text = symbol2;
            score1.Text = "Score:";

            if (AnswerBox.Text != answer.ToString())
            {
                score += 1;
                score2.Text = score.ToString();
            }

            //saves to localStorage
            try
            {
                int temp = Convert.ToInt32(localSettings.Values["HSRadio"]);
                if (temp < score)
                {
                    localSettings.Values["HSRadio"] = score.ToString();
                }
            }
            catch
            {
                localSettings.Values["HSRadio"] = score.ToString();
            }

        }   


        public void AnswerBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                Start_Click(this, new RoutedEventArgs());

                e.Handled = true;
            }
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage), null);
        }

        
    }
}
