
public class GiantCargoCraneSolution
{
    public static void Main(string[] args)
    {
        Rules(); // comment it after :D

        Stack<string> stack1 = new();
        Stack<string> stack2 = new();
        Stack<string> stack3 = new();

        Console.WriteLine("Please enter the number of cargo containers for the first row: ");
        stack1 = AddCargoOnStack(stack1);
        Console.WriteLine("Please enter the number of cargo containers for the second row: ");
        stack2 = AddCargoOnStack(stack2);
        Console.WriteLine("Please enter the number of cargo containers for the third row: ");
        stack3 = AddCargoOnStack(stack3);

        Console.WriteLine("Number of Instructions:");
        int moves = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < moves; i++) {
            
            (int howMany, int fromWhere, int toThere) = SetInstructions();

            (stack1, stack2, stack3) = ApplyInstruction(howMany, fromWhere, toThere, stack1, stack2, stack3);

        }

        string topStack1 = stack1.Count > 0 ? stack1.Peek() : "_";
        string topStack2 = stack2.Count > 0 ? stack2.Peek() : "_";
        string topStack3 = stack3.Count > 0 ? stack3.Peek() : "_";


        Console.WriteLine(topStack1 + topStack2 + topStack3);

    }


    public static (int, int, int) SetInstructions()
    {
        Console.Write("     Move ");
        int howMany = Convert.ToInt32(Console.ReadLine());
        Console.Write("     From ");
        int fromWhere = Convert.ToInt32(Console.ReadLine());
        Console.Write("     To   ");
        int toThere = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();

        return (howMany, fromWhere, toThere);
    }


    public static (Stack<string>, Stack<string>, Stack<string>) ApplyInstruction(int howMany, int fromWhere, int toThere, Stack<string> stack1, Stack<string> stack2, Stack<string> stack3) {

        (Stack<string> moveFromHere, int a) = CheckWhichStack(fromWhere, stack1, stack2, stack3);
        (Stack<string> moveToHere, int b) = CheckWhichStack(toThere, stack1, stack2, stack3);


        for (int i = 0;i < howMany; i++)
        {
            string topCrane = moveFromHere.Peek();
            moveFromHere.Pop();
            moveToHere.Push(topCrane);
        }

        Stack<string>[] stacks = [stack1, stack2, stack3];

        if (a != b)
        {
            stacks[a - 1] = moveFromHere;
            stacks[b - 1] = moveToHere;
        }

        return (stacks[0], stacks[1], stacks[2]);

    }


    public static (Stack<string>, int) CheckWhichStack(int chosenNumber, Stack<string> stack1, Stack<string> stack2, Stack<string> stack3)
    {
        switch (chosenNumber)
        {
            case 1: return (stack1, 1);
            case 2: return (stack2, 2);
            case 3: return (stack3, 3);
            default:
                Console.WriteLine("Invalid stack number.");
                return (new Stack<string>(), 0) ;
        }
    }


    public static Stack<string> AddCargoOnStack(Stack<string> rowStack)
    {

        
        int row = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Please enter the letters for each cargo container (bottom to top): ");
        for (int i = 0; i < row; i++)
        {
            string cargo = Console.ReadLine();
            rowStack.Push(cargo);
        }

        return rowStack;

    }


    public static void ReadStack(Stack<string> myStack) {
        foreach (var element in myStack)
        {
            Console.WriteLine($"{element}");
        }
    }

 
    public static void Rules() 
    {
        Console.WriteLine("-------------------------------------------------------------------------------------------------------------------\n");
        Console.WriteLine("Hi! My name is Alex and my solution only works for 3 rows.");
        Console.WriteLine("Here are the rules for data input:\n");
        Console.WriteLine("\t\t1. Enter the number of containers for the first row.");
        Console.WriteLine("\t\t2. Enter letters that represent each container on the first row.");
        Console.WriteLine("\t\t   (bottom to top)");
        Console.WriteLine("\t\t3. Do the same for the second and the third floor.");
        Console.WriteLine("\t\t4. Now enter the instructions:");
        Console.WriteLine("\t\t   (move X from Y to Z)");
        Console.WriteLine("\t\t5. It should output the top letters for each row (after all instructions are completed).");

        Console.WriteLine("\n\n PS: If I want to implement a different number of rows, I will ask you to enter the number of rows,");
        Console.WriteLine("     then I'll create that many stacks and add them inside a list<stack<string>> and select them from there.");

        Console.WriteLine("\n\n PSS: I tried to read them from a file and I kinda succeeded, but I got lost (the code is commented at the bottom).\n      I'm sorry that you guys have to enter them manually.");
        Console.WriteLine("-------------------------------------------------------------------------------------------------------------------\n");
    }

}

////--- Here I have tried to read data from file and copy the exact format for input, also it is a different approach ---
////    I tracked the values with the debugger, but still... 

//List<int> instructions = new List<int>();
//List<string> cranes = new List<string>();
//List<List<char>> gameBoard = new List<List<char>>();
//List<(int, int, int)> moves = new List<(int, int, int)>();
//List<(string, int, int)> fullCranes = new List<(string, int, int)>();

//string[] lines = File.ReadAllLines("C:\\VisualStudioMVC Projects\\Algorithms\\GiantCargoCrane\\GiantCargoCrane\\GiantCargoCrane\\input.txt");

//int boardSize = 0;

//for (int i = 0; i < lines.Length; i++)

//{
//    string[] row = lines[i].Split(' ');
//    int index = 0;
//    boardSize = Math.Max(boardSize, row.Length);
//    for (int j = 0; j<row.Length; j++)
//    {
//        if (row[j] == "")
//        {
//            index++;
//        }
//        else if (row[j] != "" && index == 0 && row[j].StartsWith("["))
//        {
//            fullCranes.Add( (row[j], i+1, j+1) );
//        }
//        else if(row[j].StartsWith("["))
//        {
//            fullCranes.Add((row[j], i + 1, j + 1 - 3));
//            index = 0;
//        }
//    }

//}

//for (int i = 0; i < fullCranes.Count; i++)
//{
//    Console.WriteLine(fullCranes[i].Item1 + fullCranes[i].Item2 + fullCranes[i].Item3);
//}

//for (int i = 0; i < lines.Length; i++)
//{
//    if (lines[i].StartsWith("move"))
//    {
//        string[] parts = lines[i].Split(' ');
//        instructions.Add(int.Parse(parts[1]));
//        instructions.Add(int.Parse(parts[3]));
//        instructions.Add(int.Parse(parts[5]));

//    }
//}

//for (int i = 0; i < instructions.Count; i++)
//{
//    Console.WriteLine(instructions[i]);
//}

//(string, int, int) x;
//int y, z;

//for (int i = 0; i < instructions.Count; i = i+2) {
//    x = fullCranes[instructions[i] - 1];

//    y = instructions[i];

//    z = instructions[i+1];

//    //fullCranes[instructions[i] - 1] = (x.Item1, y, z); // somehow

//}