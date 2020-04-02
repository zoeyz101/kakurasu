using System;
using static System.Console;

namespace Bme121
{
    static class Program
    {
        static bool useBoxDrawingChars = true;
        static string[ ] letters = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l" };
        static int boardSize = 8; // must be in the range 1..12.

        // TO DO: Uncomment these lines to use in game initialization.
        static double cellMarkProb = 0.2;
        static Random rGen = new Random( );

        static void Main( )
        {
            // TO DO: Game initialization
            // This is the main game-play loop.
            bool[,] userAnswer= new bool[boardSize,boardSize];
            bool[,] computerAnswer= new bool[boardSize,boardSize];
            int[] hiddenColSum=new int[boardSize];
            int[] hiddenRowSum=new int[boardSize];
            int[] userColSum=new int[boardSize];                                                          
            int[] userRowSum=new int[boardSize];

            for (int row=0; row<boardSize; row++){ // initialize board and sums
                for(int col=0; col<boardSize; col++){
                    userAnswer[row,col]=false;
                    userColSum[row]=0;
                    userRowSum[col]=0;
                    if (rGen.NextDouble()<cellMarkProb)
                    {
                        computerAnswer[row,col]=true;
                        hiddenColSum[col]+=row+1;
                        hiddenRowSum[row]+=col+1;
                    }else{
                        computerAnswer[row,col]=false;
                    }
                    Write (computerAnswer[row,col]);
                }
                WriteLine();
            }
            
            //used to check my hiddenColSum and hiddenRowSum
            //~ for (int row=0; row<boardSize; row++)
            //~ {    
                //~ Write ($"{hiddenRowSum[row]} ");
            //~ }

            //~ WriteLine ();
            
            //~ for (int col=0; col<boardSize; col++)
            //~ {  
                //~ Write ($"{hiddenColSum[col]} ");
            //~ }
            
            bool gameNotQuit = true;
            while( gameNotQuit ) // start game
            {
                Console.Clear( );
                WriteLine( );
                WriteLine( "    Play Kakurasu!" );
                
                //used to check Answers
                //~ WriteLine ("User Answer:");
                //~ for (int row=0; row<boardSize; row++){
                    //~ for(int col=0; col<boardSize; col++){
                        //~ Write (userAnswer[row,col]);
                    //~ }
                    //~ WriteLine ();
                //~ }
                //~ WriteLine ("Computer Answer:");
                //~ for (int row=0; row<boardSize; row++){
                    //~ for(int col=0; col<boardSize; col++){
                        //~ Write (computerAnswer[row,col]);
                        //~ }
                    //~ WriteLine ();
                //~ }
                WriteLine( );

                // Display the game board.
                // TO DO: Update code to correctly display the game state.

                if( useBoxDrawingChars )
                {
                    for( int row = 0; row < boardSize; row ++ )
                    {
                        if( row == 0 )
                        {
                            Write( "        " );
                            for( int col = 0; col < boardSize; col ++ )
                                Write( "  {0} ", letters[ col ] );
                            WriteLine( );

                            Write( "        " );
                            for( int col = 0; col < boardSize; col ++ )
                                Write( " {0,2} ", col + 1 );
                            WriteLine( );

                            Write( "        \u250c" );
                            for( int col = 0; col < boardSize - 1; col ++ )
                                Write( "\u2500\u2500\u2500\u252c" );
                            WriteLine( "\u2500\u2500\u2500\u2510" );
                        }

                        Write( "   {0} {1,2} \u2502", letters[ row ], row + 1 );

                        for( int col = 0; col < boardSize; col ++ ) // places x on the grid
                        {
                            if( userAnswer[row,col]==true) Write( " X \u2502" );
                            else                           Write( "   \u2502" );
                        }
                        
                        if (hiddenRowSum[row] <10 && userRowSum[row]<10){ //row values
                            WriteLine( $" 0{userRowSum[row]} 0{hiddenRowSum[row]} " ); 
                        }else if (hiddenRowSum[row] >=10 && userRowSum[row]>=10){                       
                            WriteLine( $" {userRowSum[row]} {hiddenRowSum[row]} ");
                        }else if (hiddenRowSum[row] >=10 && userRowSum[row]<10){
                            WriteLine( $" 0{userRowSum[row]} {hiddenRowSum[row]} ");
                        }else{
                            WriteLine( $" {userRowSum[row]} 0{hiddenRowSum[row]} ");
                        }

                        if( row < boardSize - 1 ){
                            Write( "        \u251c" );
                            for( int col = 0; col < boardSize - 1; col ++ )
                                Write( "\u2500\u2500\u2500\u253c" );
                            WriteLine( "\u2500\u2500\u2500\u2524" );
                        }else{
                            Write( "        \u2514" );
                            for( int col = 0; col < boardSize - 1; col ++ )
                                Write( "\u2500\u2500\u2500\u2534" );
                            WriteLine( "\u2500\u2500\u2500\u2518" );

                            Write( "         " );
                            for( int col = 0; col < boardSize; col ++ )
                            { 
                                Write($" {userColSum[col]:d2} ");
                            }
                            WriteLine( );

                            Write( "         " );
                            for( int col = 0; col < boardSize; col ++ )// computer column sums
                            {                                                
                                Write( $" {hiddenColSum[col]:d2} " )
                            }
                            WriteLine( );
                        }
                    }
                }
                else // ! useBoxDrawingChars
                {
                    for( int row = 0; row < boardSize; row ++ )
                    {
                        if( row == 0 )
                        {
                            Write( "        " );
                            for( int col = 0; col < boardSize; col ++ )
                                Write( "  {0} ", letters[ col ] );
                            WriteLine( );

                            Write( "        " );
                            for( int col = 0; col < boardSize; col ++ )
                                Write( " {0,2} ", col + 1 );
                            WriteLine( );

                            Write( "        +" );
                            for( int col = 0; col < boardSize - 1; col ++ )
                                Write( "---+" );
                            WriteLine( "---+" );
                        }

                        Write( "   {0} {1,2} |", letters[ row ], row + 1 );

                        for( int col = 0; col < boardSize; col ++ )
                        {
                            if( row == 1 && col == 1 ) Write( " X |" );
                            else                       Write( "   |" );
                        }
                        WriteLine( " 00 00 " );

                        if( row < boardSize - 1 )
                        {
                            Write( "        +" );
                            for( int col = 0; col < boardSize - 1; col ++ )
                                Write( "---+" );
                            WriteLine( "---+" );
                        }
                        else
                        {
                            Write( "        +" );
                            for( int col = 0; col < boardSize - 1; col ++ )
                                Write( "---+" );
                            WriteLine( "---+" );

                            Write( "         " );
                            for( int col = 0; col < boardSize; col ++ )
                                Write( " 00 " );
                            WriteLine( );

                            Write( "         " );
                            for( int col = 0; col < boardSize; col ++ )
                                Write( " 00 " );
                            WriteLine( );
                        }
                    }
                }

                // Get the next move.

                WriteLine( );
                WriteLine( "   Toggle cells to match the row and column sums." );
                Write(     "   Enter a row-column letter pair or 'quit': " );
                string response = ReadLine( );

                if( response == "quit" ){
                    gameNotQuit = false;
                    WriteLine ("Thank you for playing!");
                }
                else
                {
                    // TO DO: Update the game state based on the user's response.
                    //        Anything invalid can just be quietly ignored.
                    
                    if (response.Length==2)
                    {
                        string rowPick = response.Substring(0,1);
                        string colPick = response.Substring(1,1);
                        
                        int rowNum = Array.IndexOf( letters, rowPick);
                        int colNum=Array.IndexOf(letters,colPick);
                        
                        if (rowNum >= 0 && colNum >= 0 && rowNum < boardSize && colNum < boardSize)
                        {
                            if (userAnswer [rowNum, colNum] == true){
                                userAnswer[rowNum,colNum] = false;
                                userColSum[colNum] -= (rowNum+1);
                                userRowSum[rowNum] -= (colNum+1);
                            }else{
                                userAnswer [rowNum,colNum] = true;
                                userColSum[colNum] += (rowNum+1);
                                userRowSum[rowNum] += (colNum+1);
                            }
                            
                            bool answerTrue= true;
                            for (int row=0; row < boardSize; row++){
                                for(int col=0; col<boardSize; col++){
                                    if (userAnswer[row,col] != computerAnswer[row,col]){
                                        answerTrue= false;
                                    }
                                }
                            }
                            
                            if (answerTrue==true)
                            {
                                gameNotQuit=false;
                                WriteLine ("Congratulations! You won the game :)");
                            }
                        }
                    }
                }
            }
            WriteLine( );
        }
    }
}
 
