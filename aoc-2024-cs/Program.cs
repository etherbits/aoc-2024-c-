using aoc_2024_cs.d1;

Main();
return;

void Main(){
    if (args.Length != 3)
    {
        Console.WriteLine("Usage: aoc-2024-cs <day> <part>");
        return;
    }
    
    
    var q = args[1] + "-"+args[2];

    switch (q)
    {
        case "1-1":
            Console.WriteLine("Running d1 p1:");
            D1.P1();
            break;
        case "1-2":
            Console.WriteLine("Running d1 p2:");
            D1.P2();
            break;
        case "2-1":
            Console.WriteLine("Running d2 p1:");
            D2.P1();
            break;
        case "2-2":
            Console.WriteLine("Running d2 p2:");
            D2.P2();
            break;
        default:
            Console.WriteLine("No problem found for day {0} part {1}", args[1], args[2]);
            break;
    } 
}

