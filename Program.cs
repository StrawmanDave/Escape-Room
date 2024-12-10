/// David Barlow  Escape Room  Final Project for Programming fundamentals 1400

using System.Diagnostics;
Random rand = new Random();
(string username, long Points, int Level) score = ("Username", 0, 0);
string save = File.ReadAllText("ScoreBoard.txt");

Console.Clear();
int notValid = -1;
do
{
    Console.WriteLine("Hello, Please enter your username? Do not use any numbers, parantheses or commas.");
    try
    {
        score.username = Console.ReadLine();
        bool containsDigit = score.username.All(char.IsDigit);
        for(int i = 0; i<score.username.Length; i++)
        {
            if(containsDigit == true || score.username.Contains("(") || score.username.Contains(",") || score.username.Contains(")"))
            {
                throw new ArgumentException("You can not use that username.");
            }else
            {
                notValid = 1;
            }
        }
    }catch(ArgumentException e)
    {
        Console.WriteLine($"{e.Message} Press anthing to try again");
        Console.ReadKey();
        notValid = -1;
    }
}while(notValid == -1);


string[] DataBase = File.ReadAllLines("ScoreBoard.txt");
string hold = "";

MainMenu();
int Difficulty = numberDifficulty();
getEscapeRoom(Difficulty);

if(save.Contains(score.username))
{
    for(int i = 0; i<DataBase.Length; i++)
    {
        if(DataBase[i].Contains(score.username))
        {
            //Console.WriteLine($"Welcome back {score.username}");
            DataBase[i] = Convert.ToString(score);
            //Console.WriteLine(DataBase[i]);
        }
        hold = hold + DataBase[i] + "\n";
    }
    //Console.Write(hold);
    save = hold;
}else if(!save.Contains(score.username))
{
    save = save + score + "\n";
}

File.WriteAllText("ScoreBoard.txt", save);

void MainMenu()
{
    Console.Clear();
    Console.WriteLine("What difficulty would you like?");
    Console.WriteLine("Be careful once you enter the room there is only one way to escape");
}

int numberDifficulty()
{
    int numDifficulty = -1;
   do
   {
        Console.WriteLine("Choose a number between 1 and 8.");
        string textDifficulty = Console.ReadLine();
        try
        {
            numDifficulty = Convert.ToInt32(textDifficulty);
            if(numDifficulty < 1 || numDifficulty > 8)
            {
                throw new ArgumentException("Not a number between 1 and 8. Press enter to try again.");
                numDifficulty = -1;
            }
            return numDifficulty;
        }catch(FormatException)
        {
            Console.WriteLine("That was not a number. Press enter to try again.");
            Console.ReadLine();
            numDifficulty = -1;
        }catch(ArgumentException e)
        {
            Console.WriteLine(e.Message);
            Console.ReadLine();
            numDifficulty = -1;
        }
    }while(numDifficulty == -1);
    return numDifficulty;
}

void getEscapeRoom(int levelOfDifficulty)
{
    switch(levelOfDifficulty)
    {
        case 1:
            EscapeOne();
            ///Run simple one level escape room
            break;
        case 2:
            EscapeTwo();
            ///Run escape room with 2 levels
            break;
        case 3:
            EscapeThree();
            //3 level escape
            break;
        case 4:
            EscapeFour();
            ///4 level escape
            break;
        case 5:
            EscapeFive();
            ///5 level escape
            break;
        case 6:
            EscapeSix();
            ///6 level escape
            break;
        case 7:
            EscapeSeven();
            ///7 level escape
            break;
        case 8:
            EscapeEight();
            ///8 level escape
            break;
    }
}

void EscapeOne()
{
    Random rand = new Random();
    Challenges(rand.Next(1,6));
    //Challenges(1);
    score.Level ++;
}
void EscapeTwo()
{
    Random rand = new Random();
    for(int i = 0; i<2; i++)
    {
        Challenges(rand.Next(1,6));
        score.Level ++;
    }
}
void EscapeThree()
{
    Random rand = new Random();
    for(int i = 0; i<3; i++)
    {
        Challenges(rand.Next(1,6));
        score.Level ++;
    }   
}
void EscapeFour()
{
    //four random challenges
    Random rand = new Random();
    for(int i = 0; i<4; i++)
    {
        Challenges(rand.Next(1,6));
        score.Level ++;
    }
}
void EscapeFive()
{
    //five random challenges
    Random rand = new Random();
    for(int i = 0; i<5; i++)
    {
        Challenges(rand.Next(1,6));
        score.Level ++;
    }
}
void EscapeSix()
{
    //six random challenges
    Random rand = new Random();
    for(int i = 0; i<6; i++)
    {
        Challenges(rand.Next(1,6));
        score.Level ++;
    }
}
void EscapeSeven()
{
    //seven random challenges
    Random rand = new Random();
    for(int i = 0; i<7; i++)
    {
        Challenges(rand.Next(1,6));
        score.Level ++;
    }
}
void EscapeEight()
{
    //eight random challenges
    Random rand = new Random();
    for(int i = 0; i<8; i++)
    {
        Challenges(rand.Next(1,6));
        score.Level ++;
    }
}

void Challenges(int challenge)
{
    switch(challenge)
    {
        case 1:
            //maze
            Maze();
            Console.WriteLine("You survived another day by getting through the maze press any key to continue");
            Console.ReadKey(true);
            break;
        case 2:
            //mastermine
            Mastermine();
            Console.WriteLine("You survived another day by guessing the password press any key to continue");
            Console.ReadKey(true);
            break;
        case 3:
            //game of sticks
            StickGame();
            Console.WriteLine("You survived another day by not taking the last stick press any key to continue");
            Console.ReadKey(true);
            break;
        case 4:
            //cookie game
            CookieGame();
            Console.WriteLine("You survived to live another day by not eating the oatmealcookie press any key to continue");
            Console.ReadKey(true);
            break;
        case 5:
            //guess the story
            TypingChallenge();
            Console.WriteLine("You survived to live another day by completing the challenge press any key to continue");
            Console.ReadKey(true);
            break;
    }
}

void Maze()
{
    Console.WriteLine("Welcome to the maze avoid the % collect the ^$& reach the # to get out. Now press any key to start.");
    Console.ReadKey();
    Console.Clear();
    Random rand = new Random();
    string[] maze = getMaze(rand.Next(1,4));
    char[][] mazeChar = maze.Select(item => item.ToArray()).ToArray();

    int x = 0;
    int y = 0;


    for (int i = 0; i<maze.Length; i ++)
    {
        Console.WriteLine(maze[i]);
    }

    int mazePoints = 0;
    //Console.WriteLine($"Your score is {mazePoints}");
    Console.SetCursorPosition(x,y);

    do
    {
        var keyPressed = Console.ReadKey(true).Key;

        if(keyPressed == ConsoleKey.W)
        {
            if(tryMove(x, y, "n", mazeChar) == true)
            {
                y --;
            }
        
        }else if(keyPressed == ConsoleKey.S)
        {
        
            if(tryMove(x, y, "s", mazeChar) == true)
            {
                y ++;
            }
        
        }else if(keyPressed == ConsoleKey.A)
        {
         
            if(tryMove(x, y, "e", mazeChar) == true)
            {
                x--;   
            }
        
        }else if (keyPressed == ConsoleKey.D)
        {
        
            if(tryMove(x, y, "w", mazeChar) == true)
            {
                x++;
            }
        }
        Console.SetCursorPosition(x,y);

        int moveNum = rand.Next(0,4);
        //int moveNum = 2;
        for(int a = 0; a<mazeChar.Count(); a++)
        {
            for(int b = 0; b<mazeChar[a].Count(); b++)
            {
                if(mazeChar[a][b] == '%')
                {
                    mazeChar[a][b] = ' ';
                    Console.SetCursorPosition(b,a);
                    Console.Write(" ");
                    if(moveNum == 0)
                    {
                        //move left
                        if(canGuirdMove(a,b,"w", mazeChar) == true)
                        {
                            mazeChar[a][b-1] = '%';
                            Console.SetCursorPosition(b-1,a);
                            Console.Write("%");
                        }else
                        {
                            mazeChar[a][b] = '%';
                            Console.SetCursorPosition(b,a);
                            Console.Write("%");
                        }

                    }else if(moveNum == 1)
                    {
                        //move up
                        if(canGuirdMove(a,b,"n", mazeChar) == true)
                        {
                            mazeChar[a-1][b] = '%';
                            Console.SetCursorPosition(b,a-1);
                            Console.Write("%");
                        }else
                        {
                            mazeChar[a][b] = '%';
                            Console.SetCursorPosition(b,a);
                            Console.Write("%");
                        }

                    }else if(moveNum == 2)
                    {
                        //move right
                        if(canGuirdMove(a,b,"e", mazeChar) == true)
                        {
                            mazeChar[a][b+1] = '%';
                            Console.SetCursorPosition(b+1,a);
                            Console.Write("%");
                        }else
                        {
                            mazeChar[a][b] = '%';
                            Console.SetCursorPosition(b,a);
                            Console.Write("%");
                        }
                    }else if(moveNum == 3)
                    {
                        //move down
                        if(canGuirdMove(a,b,"s", mazeChar) == true)
                        {
                            mazeChar[a+1][b] = '%';
                            Console.SetCursorPosition(b,a+1);
                            Console.Write("%");
                        }else
                        {
                            mazeChar[a][b] = '%';
                            Console.SetCursorPosition(b,a);
                            Console.Write("%");
                        }
                    }else
                    {
                        mazeChar[a][b] = '%';
                        Console.SetCursorPosition(b,a);
                        Console.Write("%");
                    }
                }
            }
        }
        Console.SetCursorPosition(x,y);


        if(mazeChar[y][x] == '^')
        {
            //listMaze[x][y].Replace("^", " ");
            mazeChar[y][x] = ' ';
            Console.Write(" ");
            mazePoints = mazePoints + 10;
            Console.SetCursorPosition(0,21);
            Console.WriteLine($"Your score is {mazePoints}");
            Console.SetCursorPosition(x,y);
        }

        if(mazeChar[y][x] == '$')
        {
            mazeChar[y][x] = ' ';
            Console.Write(" ");
            mazePoints = mazePoints + 20;
            Console.SetCursorPosition(0,21);
            Console.WriteLine($"Your score is {mazePoints}");
            Console.SetCursorPosition(x,y);
        }

        if(mazeChar[y][x] == '&')
        {
            mazeChar[y][x] = ' ';
            Console.Write(" ");
            mazePoints = mazePoints + 30;
            Console.SetCursorPosition(0,21);
            Console.WriteLine($"Your score is {mazePoints}");
            Console.SetCursorPosition(x,y);    
        }
        
        string testString = "";
        foreach(char[] symbol in mazeChar)
        {
            foreach(char sym in symbol)
            {
                testString = testString + sym;
            }
        }

        if(testString.Contains('^') == false)
        {
            for(int i = 0; i<mazeChar.Count(); i++)
            {
                //Console.Write($"{mazeChar[i][0]}");
                for(int j = 0; j<mazeChar[i].Count(); j++)
                {
                    if(mazeChar[i][j] == '|')
                    {
                        mazeChar[i][j] = ' ';
                        Console.SetCursorPosition(j,i);
                        Console.Write(" ");
                    }
                }
            }
            Console.SetCursorPosition(x,y);
        }

        if(testString.Contains('$') == false)
        {
            for(int i = 0; i<mazeChar.Count(); i++)
            {
                //Console.Write($"{mazeChar[i][0]}");
                for(int j = 0; j<mazeChar[i].Count(); j++)
                {
                    if(mazeChar[i][j] == '-')
                    {
                        mazeChar[i][j] = ' ';
                        Console.SetCursorPosition(j,i);
                        Console.Write(" ");
                    }
                }
            }
        Console.SetCursorPosition(x,y);
        }

        if(testString.Contains('&') == false)
        {
            for(int i = 0; i<mazeChar.Count(); i++)
            {
                //Console.Write($"{mazeChar[i][0]}");
                for(int j = 0; j<mazeChar[i].Count(); j++)
                {
                    if(mazeChar[i][j] == '=')
                    {
                        mazeChar[i][j] = ' ';
                        Console.SetCursorPosition(j,i);
                        Console.Write(" ");
                    }
                }
            }
        Console.SetCursorPosition(x,y);
        }

        if(mazeChar[y][x] == '%')
        {
            loseMenu();
            break;
        }

        if(mazeChar[y][x] == '#')
        {
            break;
        }

    }while(true);
    score.Points = score.Points + mazePoints + 100;
    Console.Clear();


    bool tryMove(int x, int y, string direction, char[][] maze)
    {
        //mazeChar[y][x+1] == '|'
        if(direction == "w")
        {
            if(x+1 > mazeChar[y].Length || mazeChar[y][x+1] == '*' || mazeChar[y][x+1] == '|' || mazeChar[y][x+1] == '-' || mazeChar[y][x+1] == '=')
            {
                return false;
            }else 
            {
                return true;
            }
        }else if(direction == "e")
        {
            if(x-1 < 0 || mazeChar[y][x-1] == '*' || mazeChar[y][x-1] == '|' || mazeChar[y][x-1] == '-' || mazeChar[y][x-1] == '=')
            {
                return false;
            }else
            {
                return true;
            }
        }else if(direction == "s")
        { 
            if(y+1 > mazeChar.Count() || mazeChar[y+1][x] == '*' || mazeChar[y+1][x] == '|' || mazeChar[y+1][x] == '-' || mazeChar[y+1][x] == '=')
            {
                return false;
            }else 
            {
                return true;
            }
        }else if (direction == "n")
        {
            if (y-1 < 0 || mazeChar[y-1][x] == '*' || mazeChar[y-1][x] == '|' || mazeChar[y-1][x] == '-' || mazeChar[y-1][x] == '=')
            {
                return false;
            }else 
            {
                return true;
            }
        }else 
        {
            return false;
        }
    }

    bool canGuirdMove(int i, int j, string direction, char[][] maze)
    {
        //can it move left
        if(direction == "w")
        {
            if(j-1 < 0 || maze[i][j-1] == '*' || maze[i][j-1] == '^' || maze[i][j-1] == '$' || maze[i][j-1] == '&' || maze[i][j-1] == '#' || maze[i][j-1] == '%')
            {
                return false;
            }else
            {
                return true;
            }
        }else if(direction == "n")
        {// can it move up
            if(i-1 < 0 || maze[i-1][j] == '*' || maze[i-1][j] == '^' || maze[i-1][j] == '$' || maze[i-1][j-1] == '&' || maze[i-1][j] == '#' || maze[i-1][j] == '%')
            {
                return false;
            }else 
            {
                return true;
            }
        }else if(direction == "e")
        {// can it move right
            if(j+1 > maze.Length || maze[i][j+1] == '*' || maze[i][j+1] == '^' || maze[i][j+1] == '$' || maze[i][j+1] == '&' || maze[i][j+1] == '#' || maze[i][j+1] == '%')
            {
                return false;
            }else
            {
                return true;
            }
        }else if(direction == "s")
        {//can it move down
            if(i+1 > maze.Length || maze[i+1][j] == '*' || maze[i+1][j] == '^' || maze[i+1][j] == '$' || maze[i+1][j] == '&' || maze[i+1][j] == '%' || maze[i+1][j] == '#')
            {
                return false;
            }else
            {
                return true;
            }
        }else
        {
            return false;
        }

    }

    string[] getMaze(int mazeNumber)
    {
        string[] mazeChosen = File.ReadAllLines("maze.txt");
        
        switch(mazeNumber)
        {
            case 1:
                mazeChosen = File.ReadAllLines("maze1.txt");
                return mazeChosen;
            case 2:
                mazeChosen = File.ReadAllLines("maze2.txt");
                return mazeChosen;
            case 3:
                mazeChosen = File.ReadAllLines("maze3.txt");
                return mazeChosen;
        }
        return mazeChosen;
    }
}

void Mastermine()
{
    Console.Clear();
    Console.WriteLine("Welcome to Mastermind");
    Random rand = new Random();
    const int secretLength = 4;
    const int maxGuesses = 15; 
    Console.WriteLine($"You have {maxGuesses}guesses to guess the password.");
    string secret = "";
    List<char> getLetters = new List<char>();
    getLetters.Add('a');
    getLetters.Add('b');
    getLetters.Add('c');
    getLetters.Add('d');
    getLetters.Add('e');
    getLetters.Add('f');
    getLetters.Add('g');

    for(int i = 0; i<secretLength; i++)
    {
        secret = secret + getLetters[rand.Next(1,getLetters.Count())];

        for(int j = 0; j<getLetters.Count; j++)
        {
            if(secret.Contains(getLetters[j]))
            {
                getLetters.RemoveAt(j);
            }
        }
    }

    int numOfGuess = 0;
    int rightPosition = 0;
    int wrongPosition = 0;
    string guess = "";

    while(guess != secret)
    {
        numOfGuess ++;
        Console.WriteLine($"Guess #{numOfGuess} please guess a sequence of 4 lower case letters with no repeats");
        guess = Console.ReadLine();
        for(int i = 0; i<secret.Length; i++)
        {
            for (int j = 0; j <guess.Length; j++)
            {
                if(secret[i] == guess[j] && i == j)
                {
                    rightPosition ++;
                }else if(guess[j] == secret[i])
                {
                    wrongPosition ++;
                }
            }
        }
        Console.WriteLine($"{rightPosition} in the right position");
        Console.WriteLine($"{wrongPosition} in the wrong position");
        rightPosition = 0;
        wrongPosition = 0;

        if(numOfGuess >= 15)
        {
            loseMenu();
        }

        score.Points = score.Points + maxGuesses - numOfGuess; 
    }
    Console.WriteLine($"You guessed the password in {numOfGuess} guesses");
}

void StickGame()
{
    Random rand = new Random();
    Console.Clear();
    Console.WriteLine("Welcome to the game of sticks");
    int sticksLeft = 20;
    int player1 = 1;
    int player2 = 2;
    int playersSticks = 0;
    int currentPlayer = player1;
    int human = playerChosen();
    int maxSticksTaken = 3;

    do
    {
        Console.Clear();
        int sticksTaken = -1;
        for(int i = 0; i<sticksLeft; i++)
        {
            Console.Write("|");
        }
        Console.WriteLine();

        if(currentPlayer != human)
        {
            sticksTaken = rand.Next(1,maxSticksTaken);
        }else
        {
            sticksTaken = readSticks();
            playersSticks = playersSticks + sticksTaken; 
        }
        sticksLeft = sticksLeft - sticksTaken;

        if(sticksLeft < 3)
        {
            maxSticksTaken = sticksLeft;
        }

        if(currentPlayer == player1)
        {
            currentPlayer = player2;
        }else
        {
            currentPlayer = player1;
        }

    }while(sticksLeft > 1);

    if(currentPlayer == human)
    {
        Console.WriteLine("Congrats you survived you get 100 points");
    }else
    {
        loseMenu();
    }
    long goldensticks = playersSticks * 2;
    score.Points = score.Points + goldensticks + 100;

    int readSticks()
    {
        int number = -1;
        Console.WriteLine("Pick a number of sticks you want to take.");
        do
        {
            string textNumber = Console.ReadLine();
            try
            {
                number = Convert.ToInt32(textNumber);
                if(number < 1 || number > 3)
                {
                    throw new ArgumentException($"You can only take a number of sticks between 1 and {maxSticksTaken}.");
                }
                return number;
            }catch(FormatException)
            {
                Console.WriteLine("That was not a number. Press enter to try again.");
                Console.ReadLine();
                number = -1;
            }catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                number = -1;
            }
        }while(number == -1);
        return number;
    }

    int playerChosen()
    {
        int chosenPlayer = -1;
        do
        {
            Console.WriteLine("Choose a number 1 or 2.");
            string input = Console.ReadLine();
            try
            {
                chosenPlayer = Convert.ToInt32(input);
                if(chosenPlayer < 1 || chosenPlayer > 2)
                {
                    throw new ArgumentException("Not 1 or 2. Press enter to try again.");
                    chosenPlayer = -1;
                }
                return chosenPlayer;
            }catch(FormatException)
            {
                Console.WriteLine("That was not a number. Press enter to try again.");
                Console.ReadLine();
                chosenPlayer = -1;
            }catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                chosenPlayer = -1;
            }
        }while(chosenPlayer == -1);
        return chosenPlayer;
    }
}

void CookieGame()
{
    Console.Clear();
    List<int> ChosenCookies = new List<int>();
    Random rand = new Random();
    int oatmealCookie = rand.Next(0, 10);
    int chosenCookie = -1;
    int roundsLeft = 9;
    int chocolatePoints = 0;

    //Console.WriteLine(oatmealCookie);

    do
    {
        Console.WriteLine("There are 10 plates numbers 0-9 with cookies under them.");
        RunCookieGame();
        ChosenCookies.Add(chosenCookie);
        roundsLeft --;
        chocolatePoints ++;
    }while(roundsLeft > 0);
    long bonus = chocolatePoints * 5;

    score.Points = score.Points + bonus;

    void RunCookieGame()
    {
        do
        {
            Console.WriteLine("Pick the number of the plate that you want.");
            try
            {
                chosenCookie = chooseYourCookie(Console.ReadLine());
                if(chosenCookie == oatmealCookie)
                {
                    throw new oatmealException("That was the oatmeal cookie you lose.");
                }
            }
            catch(oatmealException e)
            {
                Console.WriteLine(e.Message);
                roundsLeft = 0;
                loseMenu();
            }

        }while(chosenCookie == -1);
    }

    int chooseYourCookie(string? word)
    {
        int playerChoice = -1;
        try
        {
            playerChoice = Convert.ToInt32(word);
            if(playerChoice < 0 || playerChoice > 9)
            {
                throw new ArgumentOutOfRangeException();
            }

            if(ChosenCookies.Contains(playerChoice))
            {
                throw new NumberPickedException("That number was already picked choose another one.");
            }
        }
        catch(NumberPickedException e)
        {
            Console.WriteLine(e.Message);
        }
        catch(ArgumentOutOfRangeException)
        {
            playerChoice = -1;
            Console.WriteLine("That is not one of the plates try again");
        }
        catch(FormatException)
        {
            playerChoice = -1;
            Console.WriteLine("That was not a number try again.");
        }
        return playerChoice;
    }
}

void TypingChallenge()
{
    Console.Clear();
    ///Create a story from a file
    ///Then each line of that story needs to be typed out by the player
    ///If the player gets more than say 10 mistakes they die
    
    Random rand = new Random();
    List<string> noun = new List<string> () {"fortune","wolf","happiness","flock","rose","gold","cookie","sheep","money","wish"};
    List<string> ProperNoun = new List<string>() {"Dionyssus","Microsoft","Phrygia","Monday","Harry Potter","President Jefferson","Christmas","Paris","Ocean","United States"};
    List<string> adjective = new List<string>(){"excited","beautiful","greatest","energetic","hungry","sure","rich","sorry","scared","greedy"};
    List<string> adverb = new List<string>(){"very","then","always","cheerfully","fast","accordingly","almost","carefully","certainly","consequently"};
    List<string> periodOfTime = new List<string>(){"day","year","week","second","minute","hour","millennium","fortnight","decade","century"};
    List<string> verbEndingInING = new List<string>() {"counting","liking","shopping","stroking","cleaning","drawing","flying","cooking","gambling","growing"};
    List<string> verb = new List<string>() {"come","be","have","do","say","go","buy","think","take","make"};
    List<string> pluralNoun = new List<string>() {"animals","coins","things","rivers","knives","leaves","boats","classes","sandwiches","benches"};
    List<string> bodyPart = new List<string>() {"hands","eyes","ears","kidneys","lungs","nostrils","arms","legs","feet","arms"};
    List<string> pastTenseVerb = new List<string>() {"tried","touched","played","worked","rested","cooked","walked","baked","studied","stopped"};
    List<string> games = new List<string>() {"Tic tac to", "Rock paper scissors", "Muscial chairs", "Red light, green light", "Go fish", "War", "Crazy Eights", "Tag", "Simon says", "Connect four", "Hopscotch"};
    List<string> plants = new List<string>() {"Grass", "Trees", "Rose", "Cactus", "Tomato", "Strawberry", "Coconut", "Pineapple", "Eggplant", "Avocado"};
    
    Dictionary<string,List<string>> words = new Dictionary<string, List<string>>();
    
    words.Add("noun",noun);
    words.Add("Proper-Noun",ProperNoun);
    words.Add("adjective", adjective);
    words.Add("adverb",adverb);
    words.Add("period-of-time",periodOfTime);
    words.Add("verb-ending-in-ing",verbEndingInING);
    words.Add("verb",verb);
    words.Add("plural-noun",pluralNoun);
    words.Add("body-parts",bodyPart);
    words.Add("past-tense-verb",pastTenseVerb);
    words.Add("game", games);
    words.Add("plant", plants);

    int randomStory = rand.Next(1,4);
    string[] storyWords = chosenStory(randomStory).Split(' ');
    string newStory = "";

    for(int i =0; i<storyWords.Count(); i++)
    {
        char punctuation = '\0';
        bool isReplaceWord = storyWords[i].Contains("::");
        if(isReplaceWord == true)
        {
            string partOfSpeech = storyWords[i].Split("::")[1];
            if(".?!".Contains(partOfSpeech[partOfSpeech.Length-1]))
            {
                punctuation = partOfSpeech[partOfSpeech.Length-1];
                //Console.Write(punctuation);
                partOfSpeech = partOfSpeech.Substring(0, partOfSpeech.Length-1);
                storyWords[i] = words[partOfSpeech][rand.Next(0,10)] + punctuation;
            }else
            {
               storyWords[i] = words[partOfSpeech][rand.Next(0,10)];
            }
        }
        //Console.Write($"{story1Words[i]} ");
        newStory = newStory + storyWords[i] + " ";
    }
    Console.Write("This is a typing challenge you can not use backspace and mistakes will be shown with red.");
    Console.WriteLine("You will die if you do not type this story faster than 35WPM with an accuracy higher than 70%");
    Console.WriteLine();
    Console.Write(newStory);
    Console.WriteLine();

    string chosenPhrase = newStory;
    string[] wordCount = chosenPhrase.Split(' ');

    int l = 0;
    int correct = 0;
    int incorrect = 0;
    int wordAmount = 0;
    Stopwatch stopwatch = new Stopwatch();

    //Now the person has to type the newly created story.
    while(l<chosenPhrase.Length)
    {
        char keyPressed = Console.ReadKey(true).KeyChar;
        // uses background color so that spaces can be shown as mistakes as well
        if(keyPressed == chosenPhrase[l])
        {
            Console.BackgroundColor = ConsoleColor.Green;
            correct ++;
        }else
        {
            Console.BackgroundColor = ConsoleColor.Red;
            incorrect ++;
        }
        Console.Write(chosenPhrase[l]);
        Console.BackgroundColor = ConsoleColor.Black;
        stopwatch.Start();
        l ++;
    }

    Console.BackgroundColor = ConsoleColor.Black;
    stopwatch.Stop();

    //for calculating the amount of words
    foreach(string word in wordCount)
    {
        wordAmount ++;
    }


    double elapsedSeconds = stopwatch.ElapsedMilliseconds / 1000.0;
    long seconds = Convert.ToInt64(elapsedSeconds);
    //minutes is just seconds divided by 60
    double minutes = (double) elapsedSeconds/60;
    // words per minute is totalWords divided by total minutes
    double decimalWPM = (double) wordAmount/minutes;
    // convert it to just a number for better looks
    long WPM = Convert.ToInt64(decimalWPM);
    // subtract mistakes for true WPM
    long penalty = Convert.ToInt64(incorrect/2);
    long trueWPM = WPM - penalty;
    float accuracy = (float) 0;
    accuracy =  (float)correct/ l * 100;
    //converting accuracy to a int for better looks
    long trueAccuracy = Convert.ToInt64(accuracy);
    long charsCorrect = l - incorrect;
    score.Points = score.Points + wordAmount + charsCorrect;

    Console.WriteLine($"Your accuracy is {trueAccuracy}% and your WPM is {trueWPM}WPM. Press enter to continue");
    Console.ReadKey();

    if(trueAccuracy < 70 || trueWPM < 35)
    {
        loseMenu();
    }


    string chosenStory(int num)
    {
        string story = "";
        switch(num)
        {
            case 1:
                story = File.ReadAllText("story1.txt");
                break;
            case 2:
                story = File.ReadAllText("story2.txt");
                break;
            case 3:
                story = File.ReadAllText("story3.txt");
                break;
        }
        return story;
    }
}

void loseMenu()
{
    Console.Clear();
    Console.WriteLine("You died");
    Environment.Exit(0);
}

public class NumberPickedException : Exception
{
public NumberPickedException() {}
public NumberPickedException(string message) : base(message){}
}
public class oatmealException : Exception
{
public oatmealException() {}
public oatmealException(string message) : base(message){}
}