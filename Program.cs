using System;
using System.Collections.Generic;

namespace TicTacToe;

class Program
{
    public static List<char> field = new List<char>(9);
    public static char course = 'O';
    static void Main()
    {
        while(true)
        {
            Init();
            Console.Clear();
            while(!IsWin())
            {
                // question players
                int NumCage = QuestionPlayer();
                // change place on X/O
                ChangeField(NumCage);
            }
            Console.WriteLine("Play the game again? (Y/N): ");
            string ans = Console.ReadLine();
            if(!(ans == "Y" || ans == "y" || ans == "yes" || ans == "YES")) break;

        }
    }

    static void Init()
    {
        course = 'O';
        field.Clear();
        for(int i=0; i<field.Capacity; ++i) field.Add((char)('0' + (i+1)));
    }

    static void WriteField()
    {
        Console.WriteLine("-------------");
        Console.WriteLine($"| {field[0]} | {field[1]} | {field[2]} |");
        Console.WriteLine("-------------");
        Console.WriteLine($"| {field[3]} | {field[4]} | {field[5]} |");
        Console.WriteLine("-------------");
        Console.WriteLine($"| {field[6]} | {field[7]} | {field[8]} |");
        Console.WriteLine("-------------");
    }

    static int QuestionPlayer()
    {
        int NumPlayer = -1;
        WriteField();
        while(true)
        {
            Console.Write($"It is Player {course} turn choose a number 1-9: ");
            NumPlayer = Console.Read() - 49;
            Console.ReadLine();

            if(NumPlayer >= 0)
            {
                if(field[NumPlayer] != 'X' && field[NumPlayer] != 'O') break;
                else Console.WriteLine("This cage is already occupied.");
            } else Console.WriteLine("You need to enter a number from 1 to 9.");
        }
        Console.WriteLine("");
        return NumPlayer;
    }

    static void ChangeField(int cage)
    {
        field[cage] = course;

        if(course == 'O') course = 'X';
        else course = 'O';
    }

    static bool IsWin()
    {
        char WhoWin = ' ';

        bool IsDraw = true;
        for(int i=0; i<9; ++i)
        {
            if(field[i] != 'O' && field[i] != 'X')
            {
                IsDraw = false;
                break;
            }
        }

        if(IsDraw) WhoWin = '-';

        for(int i=0; i<2; ++i)
        {
            char playerWin = 'O';
            if(i == 1) playerWin = 'X';

            if(field[0] == playerWin && field[1] == playerWin && field[2] == playerWin) WhoWin = playerWin;
            if(field[3] == playerWin && field[4] == playerWin && field[5] == playerWin) WhoWin = playerWin;
            if(field[6] == playerWin && field[7] == playerWin && field[8] == playerWin) WhoWin = playerWin;
            if(field[0] == playerWin && field[3] == playerWin && field[6] == playerWin) WhoWin = playerWin;
            if(field[1] == playerWin && field[4] == playerWin && field[7] == playerWin) WhoWin = playerWin;
            if(field[2] == playerWin && field[5] == playerWin && field[8] == playerWin) WhoWin = playerWin;
            if(field[0] == playerWin && field[4] == playerWin && field[8] == playerWin) WhoWin = playerWin;
            if(field[2] == playerWin && field[4] == playerWin && field[6] == playerWin) WhoWin = playerWin;
        }

        if(WhoWin != ' ') WriteField();

        if(WhoWin == 'O')
        {
            Console.WriteLine("Player O won!");
            return true;
        } else if(WhoWin == 'X')
        {
            Console.WriteLine("Player X won");
            return true;
        }else if(WhoWin == '-')
        {
            Console.WriteLine("Draw!");
            return true;
        }

        return false;
    }
}