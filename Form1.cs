namespace Breakout
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Game.Instance.ScoreChanged += () => labelScore.Text = "Score: " + Game.Instance.Score.ToString();
            Game.Instance.GameOverChanged += () => MessageBox.Show("Game Over!");
            Load += (s, e) => canvas1.Start();
        }
    }
}