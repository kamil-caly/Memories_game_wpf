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

namespace Memories_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ImageSource[] picturesUri = new ImageSource[]
        {
            new BitmapImage(new Uri("img/blank.png", UriKind.Relative)),
            new BitmapImage(new Uri("img/white.png", UriKind.Relative)),
            new BitmapImage(new Uri("img/cheeseburger.png", UriKind.Relative)),
            new BitmapImage(new Uri("img/fries.png", UriKind.Relative)),
            new BitmapImage(new Uri("img/hotdog.png", UriKind.Relative)),
            new BitmapImage(new Uri("img/ice-cream.png", UriKind.Relative)),
            new BitmapImage(new Uri("img/milkshake.png", UriKind.Relative)),
            new BitmapImage(new Uri("img/pizza.png", UriKind.Relative)),
        };

        private Image[] pictures;
        public Board board;
        private int selectedPictures = 0;
        private bool canClick = true;
        private List<int> guessingPictures = new List<int>();
        SwapLogic swapLogic;
        public MainWindow()
        {
            InitializeComponent();
            pictures = new Image[] { img1, img2, img3, img4,img5, img6, img7, img8, img9, img10, img11, img12 };

            board = new Board();
            swapLogic = new SwapLogic();
        }

        private int getNumberOfClickedPicture(object sender)
        {
            Image image = sender as Image;

            var splitName = image.Name.Split("g");

            return Convert.ToInt32(splitName[1]) - 1;
        }

        private void setSpecyficImageSource(object sender)
        {
            Image image = sender as Image;
            int element = board.getField(getNumberOfClickedPicture(sender));
            image.Source = picturesUri[element];
        }

        private void setWhiteImageSource()
        {
            for (int i = 0; i < 12; i++)
            {
                int element = board.getField(i);
                if(element == 1)
                pictures[i].Source = picturesUri[element];
            }
        }

        private void hidePictureAfterNotGuess()
        {
            pictures[guessingPictures[0]].Source = picturesUri[0];
            pictures[guessingPictures[1]].Source = picturesUri[0];
        }

        private void gameOver()
        {
            if(GameOver.isGameOver(board))
            {
                this.ScoreBlock.Text = "You win";
                this.playAgainButton.Visibility = Visibility.Visible;
                canClick = false;
            }
        }

        private async void imgClick(object sender, MouseButtonEventArgs e)
        {
            if (canClick)
            {
                Image image = sender as Image;
                setSpecyficImageSource(sender);
                selectedPictures++;
                GuessCounter.updateCounter();
                this.GuessBlock.Text = "Guess: " + GuessCounter.getCounter();

                if (guessingPictures.Count < 2)
                {
                    guessingPictures.Add(getNumberOfClickedPicture(sender));
                }


                if (selectedPictures == 2)
                {
                    canClick = false;
                    await Task.Delay(1000);

                    if (guessingPictures.Count == 2)
                    {
                        if (swapLogic.isTheSamePictures(board, guessingPictures))
                        {
                            if (!swapLogic.isWhitePicture(board, guessingPictures))
                                Points.updatePoints();

                            swapLogic.setWhiteFieldAfterGuess(board, guessingPictures);
                            setWhiteImageSource();
                            
                            this.ScoreBlock.Text = "Score: " + Points.getPoints();
                        }
                        else 
                        {
                            hidePictureAfterNotGuess();
                        }
                        guessingPictures.Clear();
                    }

                    selectedPictures = 0;
                    canClick = true;
                    this.gameOver();
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //updatePictures();
        }

        private void playAgainButton_Click(object sender, RoutedEventArgs e)
        {
            board = new Board();
            Points.resetPoints();
            this.ScoreBlock.Text = "Score: " + Points.getPoints();
            GuessCounter.resetCounter();
            this.GuessBlock.Text = "Score: " + GuessCounter.getCounter();
            this.playAgainButton.Visibility = Visibility.Hidden;

            pictures.ToList().ForEach(p => p.Source = picturesUri[0]);
            canClick = true;
        }
    }
}
