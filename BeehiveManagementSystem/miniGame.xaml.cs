using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

/* Things to do:
 * Display how much honey was won
 * Pause the beehive game while the minigame is playing
 */

namespace BeehiveManagementSystem 
{
    using System.Linq;

    /// <summary>
    /// Interaction logic for miniGame.xaml
    /// </summary>
    using System.Windows.Threading;
    public partial class MiniGame
    {
        DispatcherTimer timer = new DispatcherTimer();
        int tenthsofSecondsElapsed;
        public int matchesFound;
        private void Timer_Tick(object sender, EventArgs e)
        {
            tenthsofSecondsElapsed++;
            timeTextBlock.Text = (tenthsofSecondsElapsed / 10F).ToString("0.0s");
            if (matchesFound == 8)
            {
                timer.Stop();
                timeTextBlock.Text = timeTextBlock.Text;
                int winTime = tenthsofSecondsElapsed;
                int awardWon =  HoneyVault.honeyAward(winTime);
               // awardAmount.Text = "You won " + awardWon + " honey!!";
            }
            
        }
        public MiniGame()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += Timer_Tick;
            SetUpGame();
        }

        private void SetUpGame()
        {
            List<string> animalEmoji = new List<string>()
            {
                "🐝", "🐝",
                "👑", "👑",
                "🌷", "🌷",
                "🌸", "🌸",
                "🌺", "🌺",
                "🌻", "🌻",
                "🥀", "🥀",
                "💐", "💐",
            };

            Random random = new Random();

            foreach (TextBlock textBlock in miniGameGrid.Children.OfType<TextBlock>())
            {
                if (textBlock.Name != "timeTextBlock")
                {
                    textBlock.Visibility = Visibility.Visible;
                    int index = random.Next(animalEmoji.Count);
                    string nextEmoji = animalEmoji[index];
                    textBlock.Text = nextEmoji;
                    animalEmoji.RemoveAt(index);
                }

            }

            timer.Start();
            tenthsofSecondsElapsed = 0;
            matchesFound = 0;
        }

        TextBlock lastTextBlockClicked;
        bool findingMatch = false;
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            if (findingMatch == false)
            {
                textBlock.Visibility = Visibility.Hidden;
                lastTextBlockClicked = textBlock;
                findingMatch = true;
            }
            else if (textBlock.Text == lastTextBlockClicked.Text)
            {
                matchesFound++;
                textBlock.Visibility = Visibility.Hidden;
                findingMatch = false;
            }

            else
            {
                lastTextBlockClicked.Visibility = Visibility.Visible;
                findingMatch = false;
            }
        }

        private void timeTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (matchesFound == 8)
            {
                SetUpGame();
            }
        }

        private void endGame(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
