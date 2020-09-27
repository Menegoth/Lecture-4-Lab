using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

/// Week 4		Lab 1
/// File Name: MainWindow.xaml.cs
/// @author: Antonio Monteiro
/// Date:  September 27th 2020

namespace Lecture_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {

            //take in label values
            int currentSpeed = Int32.Parse(speedTextBox.Text);
            int speedLimit = Int32.Parse(limitTextBox.Text);

            int fine;

            //check if over speed limit
            if (currentSpeed < speedLimit)
            {
                //set background and message
                fineCanvas.Background = Brushes.Green;
                resultLabel.Content = "You are driving under the speed limit.";

            } else if (currentSpeed == speedLimit)
            {
                //set background and message
                fineCanvas.Background = Brushes.Yellow;
                resultLabel.Content = "You are matching the speed limit";

            } else
            {

                //calculate fine with function and assign it to variable
                fine = calculateFine(currentSpeed, speedLimit);

                //set background and message
                fineCanvas.Background = Brushes.Red;
                resultLabel.Content = "You are going over the speed limit. Your fine is " + fine;

            }

        }

        //calculate fine function
        public int calculateFine(int speed, int limit)
        {

            //declare 
            int fine = 0;
            int startingFine = 60;
            int incrementFine = 7;
            int extremeFine = 250;

            //calculate fine
            if (speed < limit + 25)
            {
                //calculate without 25mph+ fine
                fine = startingFine + (incrementFine * (speed - limit));

            } else
            {
                //calculate with 25mph+ fine
                //calculate original fine first
                fine = startingFine + (incrementFine * (speed - limit));

                //add 25mph+ fine
                fine += (extremeFine * ((speed - limit) / 25));

            }

            return fine;
        }

    }
}
