using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe
{
    class Game
    {
        public static int Count = 0;
        public static int Player = 1;
        public static List<string> tables = new List<string>();
        public static int PlayerWon = 0;
        public static bool GameFinished = false;

        //Random gridChoice = new Random();

        public Game()
        {
            // Construction method
            tables.Add("000000000");
            Player = 1;
            PlayerWon = 0;
            GameFinished = false;

        }

        public static void Add(int location, int letter)
        {
            string character = Convert.ToString(letter);
            location--;
            string ID = tables[Count];
            if(ID[location] != '0'){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("You can't play on an already occupied space.\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else{
                StringBuilder result = new StringBuilder(ID);
                result.Remove(location, 1);
                result.Insert(location, character);
                tables[Count] = result.ToString();
                Switch();
            }
            Display();
            CheckForWin();
            DrawCheck();
        }

        public void End(int player)
        {
            Count++;
            Console.WriteLine("Press any key to play again.");
            Console.ReadKey();
            Console.WriteLine("\n");
            Play();
        }

        public static void Display()
        {
            // Parses number values to Xs Os and -s
            string table = tables[Count];
            //Console.WriteLine(table);
            List<string> display = new List<string>();
            for (int i = 0; i < 9;i++){
                if(table[i] == '0') {
                    display.Add("-");
                }
                if(table[i] == '1') {
                    display.Add("X");
                }
                if(table[i] == '2') {
                    display.Add("O");
                }
            }
    
            // Displays the grid
            Console.WriteLine($"\n\t{display[0]} | {display[1]} | {display[2]}\n\t--+---+--\n\t{display[3]} | {display[4]} | {display[5]}\n\t--+---+--\n\t{display[6]} | {display[7]} | {display[8]}\n");
        }

        public static void Guide()
        {
            Console.WriteLine($"\n\t1 | 2 | 3\n\t--+---+--\n\t4 | 5 | 6\n\t--+---+--\n\t7 | 8 | 9\n");
        }

        public static void CheckForWin()
        {
            // Prepare for the if elseif elseif elseif elseif elseif elseif elseif elseif elseif elseif
            string toCheck = tables[Count];
            //Console.WriteLine(toCheck);
            // X win conditions
            // Horizontal
            if(toCheck[0] == '1' & toCheck[1] == '1' & toCheck[2] == '1'){
                P1Won();
            }
            else if(toCheck[3] == '1' & toCheck[4] == '1' & toCheck[5] == '1'){
                P1Won();
            }
            else if(toCheck[6] == '1' & toCheck[7] == '1' & toCheck[8] == '1'){
                P1Won();
            }
            // Veritcal
            else if(toCheck[0] == '1' & toCheck[3] == '1' & toCheck[6] == '1'){
                P1Won();
            }
            else if(toCheck[1] == '1' & toCheck[4] == '1' & toCheck[7] == '1'){
                P1Won();
            }
            else if(toCheck[2] == '1' & toCheck[5] == '1' & toCheck[8] == '1'){
                P1Won();
            }
            // Diagonal
            else if(toCheck[0] == '1' & toCheck[4] == '1' & toCheck[8] == '1'){
                P1Won();
            }
            else if(toCheck[6] == '1' & toCheck[4] == '1' & toCheck[2] == '1'){
                P1Won();
            }

            // O win conditions
            // Horizontal
            else if(toCheck[0] == '2' & toCheck[1] == '2' & toCheck[2] == '2'){
                P2Won();
            }
            else if(toCheck[3] == '2' & toCheck[4] == '2' & toCheck[5] == '2'){
                P2Won();
            }
            else if(toCheck[6] == '2' & toCheck[7] == '2' & toCheck[8] == '2'){
                P2Won();
            }
            // Veritcal
            else if(toCheck[0] == '2' & toCheck[3] == '2' & toCheck[6] == '2'){
                P2Won();
            }
            else if(toCheck[1] == '2' & toCheck[4] == '2' & toCheck[7] == '2'){
                P2Won();
            }
            else if(toCheck[2] == '2' & toCheck[5] == '2' & toCheck[8] == '2'){
                P2Won();
            }
            // Diagonal
            else if(toCheck[0] == '2' & toCheck[4] == '2' & toCheck[8] == '2'){
                P2Won();
            }
            else if(toCheck[6] == '2' & toCheck[4] == '2' & toCheck[2] == '2'){
                P2Won();
            }
        } 

        public static void DrawCheck()
        { 
            int full = 0;
            string localGrid = tables[Count];
            for(int d = 0; d < 9; d++){
                if(localGrid[d] != '0'){
                    full++;
                }    
            }
            if(full == 9){
                Game.PlayerWon = 3;
                Game.GameFinished = true;
                CheckForWin();
            }

        }

        public static void P1Won()
        {
            Game.PlayerWon = 1;
            Game.GameFinished = true;
        }

        public static void P2Won()
        {
            Game.PlayerWon = 2;
            Game.GameFinished = true;
        }

        public static void Switch()
        {
            if(Game.Player == 1){
                Game.Player = 2;
            }
            else if(Game.Player == 2){
                Game.Player = 1;
            }
        }

        public static void Play()
        {
            Game current = new Game();

            while(Game.GameFinished == false){
                try{
                    Guide();
                    Console.Write($"\nPlayer {Game.Player}, Where would you like to play: ");
                    int playerInput = Convert.ToInt32(Console.ReadLine());
                    if(playerInput < 1 | playerInput > 9){
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Input a Valid space.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Add(playerInput, Game.Player);
                    
                }
                catch(Exception) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input a number.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            if(PlayerWon == 1){
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Congratulations Player 1!\nYou Won!\n");
                
            }
            else if(PlayerWon == 2){
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Congratulations Player 2!\nYou Won!\n");
            }
            else if(PlayerWon == 3){
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Draw!\nNo player has won.\n");
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Press Enter to Play Again!\n Or press Q and Enter to exit.");
            Console.ForegroundColor = ConsoleColor.White;
            string keyPressed = Console.ReadLine();
            //Console.WriteLine(keyPressed);
            if( keyPressed == ""){
                ;
            }
            else if( keyPressed[0] == 'q' | keyPressed[0] == 'Q'){
                Environment.Exit(0);
            }
            Count++;
            Play();
        }

        
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Main title screen
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Welcome to...\n _____  _         _____              _____            \n|_   _|(_)       |_   _|            |_   _|           \n  | |   _   ___    | |  __ _   ___    | |  ___    ___ \n  | |  | | / __|   | | / _` | / __|   | | / _ \\  / _ \\\n  | |  | || (__    | || (_| || (__    | || (_) ||  __/\n  \\_/  |_| \\___|   \\_/ \\__,_| \\___|   \\_/ \\___/  \\___|");
            Console.ForegroundColor = ConsoleColor.White;

            // Play Game
            Console.WriteLine("\nPress Enter to Play!");
            Console.ReadKey();
            Game.Play();
        }
    }
}
