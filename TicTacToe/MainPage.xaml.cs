using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace TicTacToe
{
    /// <summary>
    /// 자체적으로 사용하거나 프레임 내에서 탐색할 수 있는 빈 페이지입니다.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        bool turn;
        bool isUseAIPlayer;
        int turnCount;
        int scorePlayerA;
        int scorePlayerB;
        const int TWO_OF_O = 18;
        const int TWO_OF_X = 50;
        List<int> lstCell = null;

        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
            
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            turn = true; // true == O, false == X
            turnCount = 0;
            scorePlayerA = 0;
            scorePlayerB = 0;
            Refresh_Score();
        }
        private void Refresh_Score()
        {
            scoreA.Text = scorePlayerA.ToString();
            scoreB.Text = scorePlayerB.ToString();
        }
        private void Button_Show()
        {
            txtResult.Visibility = Visibility.Visible;
            btnRestart.Visibility = Visibility.Visible;
        }
        private void Button_Hide()
        {
            txtResult.Visibility = Visibility.Collapsed;
            btnRestart.Visibility = Visibility.Collapsed;
        }
        private void nextTurn()
        {
            turnCount++;
            turn = !turn;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            button.IsEnabled = false;
            if (turn)
            {
                button.Content = "O";
                tsAIMode.IsEnabled = false;
                //button.Foreground = new SolidColorBrush(Color.FromArgb(61, 255, 216, 255));
            }
            else
            {
                button.Content = "X";
                tsAIMode.IsEnabled = true;
                //button.Foreground = new SolidColorBrush(Color.FromArgb(255, 59, 88, 255));
            }
            nextTurn();
            checkWinner();
            if (isUseAIPlayer && !turn)
                AI_Calculate();
        }

        private void checkWinner()
        {
            bool isFinished = false;

            if ((A1.Content == A2.Content) && (A2.Content == A3.Content) && (!A1.IsEnabled))
                isFinished = true;
            else if ((B1.Content == B2.Content) && (B2.Content == B3.Content) && (!B1.IsEnabled))
                isFinished = true;
            else if ((C1.Content == C2.Content) && (C2.Content == C3.Content) && (!C1.IsEnabled))
                isFinished = true; // 수평

            else if ((A1.Content == B1.Content) && (B1.Content == C1.Content) && (!A1.IsEnabled))
                isFinished = true;
            else if ((A2.Content == B2.Content) && (B2.Content == C2.Content) && (!A2.IsEnabled))
                isFinished = true;
            else if ((A3.Content == B3.Content) && (B3.Content == C3.Content) && (!A3.IsEnabled))
                isFinished = true; // 수직

            else if ((A1.Content == B2.Content) && (B2.Content == C3.Content) && (!A1.IsEnabled))
                isFinished = true;
            else if ((A3.Content == B2.Content) && (B2.Content == C1.Content) && (!C1.IsEnabled))
                isFinished = true; // 교차

            if (isFinished)
            {
                disableButtons();
                string winner;

                if (turn)
                {
                    winner = "Player B";
                    scorePlayerB++;
                }
                else
                {
                    winner = "Player A";
                    scorePlayerA++;
                }
                txtResult.Text = winner + " is winner!";
                Button_Show();
                Refresh_Score();
            }
            else
            {
                if (turnCount == 9)
                {
                    txtResult.Text = "It's a draw.";
                    Button_Show();
                    Refresh_Score();
                }
            }
        }
        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            turn = true;
            turnCount = 0;
            Button_Hide();

            A1.IsEnabled = true;
            A2.IsEnabled = true;
            A3.IsEnabled = true;
            B1.IsEnabled = true;
            B2.IsEnabled = true;
            B3.IsEnabled = true;
            C1.IsEnabled = true;
            C2.IsEnabled = true;
            C3.IsEnabled = true;


            A1.Content = "";
            A2.Content = "";
            A3.Content = "";
            B1.Content = "";
            B2.Content = "";
            B3.Content = "";
            C1.Content = "";
            C2.Content = "";
            C3.Content = "";
        }

        private void disableButtons()
        {
            A1.IsEnabled = false;
            A2.IsEnabled = false;
            A3.IsEnabled = false;
            B1.IsEnabled = false;
            B2.IsEnabled = false;
            B3.IsEnabled = false;
            C1.IsEnabled = false;
            C2.IsEnabled = false;
            C3.IsEnabled = false;
        }

        private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            ToggleSwitch ts = sender as ToggleSwitch;
            isUseAIPlayer = ts.IsOn;
        }

        private void AI_Calculate()
        {
            int index = -1;

            if (lstCell == null) lstCell = new List<int>();
            else if(lstCell.Count > 0) lstCell.Clear();
            setCellsValue();

            index = centerChecker();
            if (isActivate(index)) return; // 중앙이 비어있는지 체크

            index = cellsChecker(TWO_OF_X); // X가 두 개인지 체크 == 이길 수 있는지
            if (isActivate(index)) return;

            index = cellsChecker(TWO_OF_O); // O가 두 개인지 체크 == 위험한 자리 막기
            if (isActivate(index)) return;

            index = edgeChecker(); // 빈 변이 있는지 체크
            if (isActivate(index)) return;

            index = sideChecker(); // 빈 모서리가 있는지 체크
            if (isActivate(index)) return;
        }

        private bool isActivate(int index)
        {
            if (index >= 0)
            {
                AI_Click(index);
                return true;
            }
            return false;
        }
        private void setCellsValue()
        {
            foreach(Button item in ButtonGrid.Children)
            {
                if (item.Content == null || item.Content.ToString() == "") lstCell.Add(2);
                else if (item.Content.ToString() == "O") lstCell.Add(3);
                else if (item.Content.ToString() == "X") lstCell.Add(5);
            }
        }
        private int cellsChecker(int twoCells) // twoCells == 두 개인지 확인할 모양 값
        {
            for(int i = 0; i < 3; i++)
            {
                int index = i * 3;
                int result = findNullIndex(index, 1,twoCells);
                if (result >= 0) return result + (i*3);
            }//수평
            for (int i = 0; i < 3; i++)
            {
                int index = i ;
                int result = findNullIndex(index, 3,twoCells);
                if (result >= 0) return i + result * 3;
            }//수직
            for(int i = 0; i < 2; i++)
            {
                int index = i * 2;
                int checkNum = 4 - index;
                if((i == 0) && (lstCell[index] * lstCell[index + checkNum] * lstCell[index + checkNum * 2] == twoCells))
                {
                    List<int> lstIndex = new List<int>();
                    lstIndex.Add(lstCell[index]);
                    lstIndex.Add(lstCell[index + checkNum]);
                    lstIndex.Add(lstCell[index + checkNum * 2]);

                    int idxNull = lstIndex.FindIndex(x => x == 2);

                    return checkNum * idxNull + index;
                }
            } //교차
            return -1;
        }
        private int findNullIndex(int idx,int checkNum, int checkShape) // 18 == Two O, 50 == Two X
        {
            if (lstCell[idx] * lstCell[idx + checkNum] * lstCell[idx + checkNum * 2] == checkShape)
            {
                List<int> lstIndex = new List<int>();
                lstIndex.Add(lstCell[idx]);
                lstIndex.Add(lstCell[idx + checkNum]);
                lstIndex.Add(lstCell[idx + checkNum * 2]);

                int idxNull = lstIndex.FindIndex(x => x == 2);
                    
                return idxNull;
            }
            return -1;
        }

        private int centerChecker()
        {
            int index = 4; // 중앙
            if (lstCell[index] == 2)
                return index;
            return -1;
        }
        private int edgeChecker()
        {
            bool isEnabled = false;

            for(int i = 0; i < 5; i++) // 빈 모서리가 있는지 확인
            {
                if (lstCell[i * 2] == 2)
                {
                    isEnabled = true;
                    break;
                }
            }

            if (!isEnabled) return -1;

            while (true)
            {
                Random rand = new Random();
                int result = rand.Next(0, 4) * 2;
                if (lstCell[result] == 2)
                {
                    return result;
                }
            }
        }
        private int sideChecker()
        {
            bool isEnabled = false;

            for (int i = 1; i <=7; i+=2) // 빈 변이 있는지 확인
            {
                if (lstCell[i] == 2)
                {
                    isEnabled = true;
                    break;
                }
            }
            if (!isEnabled) return -1;
            while (true)
            {
                Random rand = new Random();
                int result = rand.Next(1,7);
                if ((result % 2 != 0) && (lstCell[result] == 2)) // 홀수이면서 빈칸
                {
                    return result;
                }
            }
        }
        private void AI_Click(int idx)
        {
            Button btn = ButtonGrid.Children[idx] as Button;
            Button_Click(btn, new RoutedEventArgs());
        }
    }
}
