// See https://aka.ms/new-console-template for more information
//Prompt the user to enter the sides for each dice
Console.WriteLine("***Welcome to the Grand Circus Casino!***");
repeat:
Console.WriteLine("How many sides should each dice have?");
string strSides = Console.ReadLine();
//validating the user entered integer value
try
{
    int nofSides = Convert.ToInt32(strSides);
    bool continuePlay = true;
    int countRolling = 1;
    //loop continues till the user wants to continue
    while (continuePlay)
    {
        Console.WriteLine("Roll "+ countRolling);
        //Calling method to generate random number 
        GenerateRandomNumbers(nofSides);
        Console.WriteLine("Roll Again? y/n");
        string response = Console.ReadLine();
        //getting the user to continue or not
        if (response.ToLower() == "n")
        {
            continuePlay = false;
            Console.WriteLine("Thanks for playing");
        }
        countRolling++;
    }
}
catch (FormatException)
{
    Console.WriteLine($"{strSides} is not an integer.");
    goto repeat;
}

static void GenerateRandomNumbers(int sideCount)
{
    Random randomDiceOne = new Random();
    Random randomDiceTwo = new Random();
    //next method will generate randon numbers
    int valueDiceOne = randomDiceOne.Next(1, sideCount+1);
    int valueDiceTwo = randomDiceTwo.Next(1, sideCount+1);
    Console.WriteLine($"You rolled a {valueDiceOne} and a {valueDiceTwo} ({valueDiceOne + valueDiceTwo} total)");
    //calling method which return message based the dice value
    string message = DisplayMessage(valueDiceOne, valueDiceTwo);
    Console.WriteLine(message);

    //calling method DisplayMessageTotal which return message based the dice value
    string messageTotal = DisplayMessageTotal(valueDiceOne, valueDiceTwo);
    Console.WriteLine(messageTotal);
}
    
//Passing dice value as parameters which return the message based on the dice value
static string DisplayMessage(int numDiceOne , int numDiceTwo)
{
    int sumNumber = numDiceOne + numDiceTwo;
   if ((numDiceOne == 1) && (numDiceTwo == 1)) 
  // if(sumNumber == 2)
    {
        return "SnakeEye";
    }
    else /*if (sumNumber == 3)*/    if ((numDiceOne == 1) && (numDiceTwo == 2))
    {
        return "Ace Deuce:";
    }
    else /*if (sumNumber == 12) */  if ((numDiceOne == 6) && (numDiceTwo == 6))
    {
        return "Box Cars";
    }
   
        return "";
       
}
//Passing dice value as parameters which return the message based on the dice value
static string DisplayMessageTotal(int numDiceOne, int numDiceTwo) 
{
    int sumNumber = numDiceOne + numDiceTwo;
    if ((sumNumber == 7 ) || (sumNumber == 11))
    {
        return "Win!";
    }
    else if ((sumNumber == 2) || (sumNumber == 3) || (sumNumber == 12))
    {
        return "Craps!";
    }
    return "";
}

