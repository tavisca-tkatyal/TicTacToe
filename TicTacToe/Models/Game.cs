using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace TicTacToe.Models
{
    public class Game
    {
        String player1 ;
        String player2 ;

        static String[,] board= new String[3,3];
        static int countOfTurn = 1;
        static String stateOfWin;
        public Game()
        {
            player1 = "0";
            player2 = "X";
            for (int rowIndex = 0; rowIndex < 3; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < 3; columnIndex++)
                {
                    board[rowIndex, columnIndex] = "-";
                }
            }
        }

        public String MakeAMove(int matrixCoordinates)
        {
            int rowIndex = (matrixCoordinates / 10) -1;
            int columnIndex = (matrixCoordinates % 10) - 1 ;
            if(rowIndex >= 3 || columnIndex >= 3 )
            {
                return "Please make a correct move";
            }
            else if (countOfTurn % 2 == 0)
            {
                board[rowIndex, columnIndex] = player2;
            }
            else
            {
                board[rowIndex, columnIndex] = player1;
            }
            stateOfWin = WinningPlayer(rowIndex, columnIndex);
            countOfTurn++;
            return stateOfWin;
        }
        
        public String DisplayBoard()
        {
            String display = "";
            for (int rowIndex = 0; rowIndex < 3; rowIndex++)
            {

                for (int columnIndex = 0; columnIndex < 3; columnIndex++)
                {
                    display = display + board[rowIndex, columnIndex];

                }
                display = display + " ";
            }
            return display;
        }
        public String CheckIfPlayerWinOrNot(int checkPlayerWin, String move)
        {
            if (checkPlayerWin == 0)
            {
                if (player1 == move)
                {
                    return "Player 1 Win";
                }
                else
                {
                    return "Player 2 Win";
                }

            }
            return "";
        }

        public String WinningPlayer(int rowIndex,int columnIndex)
        {
            int row = 0;
            int column;
            int checkPlayerWin = 0; // if player win value is still 0
            String move = board[rowIndex, columnIndex];
            String resultOfWinning;
            while (row < 3)
            {
                for (column = 0; column < 3; column++)
                {
                    if (board[row, column] != move)
                    {
                        checkPlayerWin = 1; //if player not win in this condition value become 1
                        break;
                    }
                }
                resultOfWinning = CheckIfPlayerWinOrNot(checkPlayerWin, move);
                if (resultOfWinning != "")
                {
                    return resultOfWinning;
                }
                row++;
            }
            checkPlayerWin = 0;
            column = 0;
            while (column < 3)
            {
                for (row = 0; row < 3; row++)
                {
                    if (board[row, column] != move)
                    {
                        checkPlayerWin = 1;
                        break;
                    }
                }
                resultOfWinning = CheckIfPlayerWinOrNot(checkPlayerWin, move);
                if (resultOfWinning != "")
                {
                    return resultOfWinning;
                }
                column++;
            }
            checkPlayerWin = 0;
            row = 0;column = 0;
             while(row<3 && column<3)
             {
                 if(board[row,column] != move)
                 {
                     checkPlayerWin = 1;
                     break;
                 }
                 row++;
                 column++;
             }
            resultOfWinning = CheckIfPlayerWinOrNot(checkPlayerWin, move);
            if (resultOfWinning != "")
            {
                return resultOfWinning;
            }
           
            checkPlayerWin = 0;
            row = 0;
            while(row<3 && column>=0)
            {
                if(board[row,column] != move)
                {
                    checkPlayerWin = 1;
                    break;
                }
                row++;
                column--;
            }
            resultOfWinning = CheckIfPlayerWinOrNot(checkPlayerWin, move);
            if (resultOfWinning != "")
            {
                return resultOfWinning;
            }
            int countEmptySpace = 0;
            for (row = 0;row < 3;row++)
            {
                for(column =0;column<3;column++)
                {
                    if(board[row,column] == "-")
                    {
                        countEmptySpace++;
                        continue;
                    }
                }
            }
            if(countEmptySpace == 0)
            {
                return "Match is tied/ No Player won the match";
            }
            return "";
        }

    }  
}