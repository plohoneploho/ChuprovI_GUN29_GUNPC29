class BestCalcInWorld
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter first number: ");
        if (!Int32.TryParse(Console.ReadLine(), out var a))
        {
            Console.WriteLine("Not a number");
            return;
        }

        Console.WriteLine("Enter second number: ");
        if (!Int32.TryParse(Console.ReadLine(), out var b))
        {
            Console.WriteLine("Not a number");
            return;
        }

        Console.WriteLine("Choose Arithmetic Operation(+,-,*,/): ");
        var s = Console.ReadLine();
        if (s.Length != 1)
        {
            Console.WriteLine("Wrong Length of Sign");
            return;
        }

        Console.WriteLine("Choose Bitwise Operation(&,|,^): ");
        var o = Console.ReadLine();
        if (o.Length != 1)
        {
            Console.WriteLine("Wrong Length of Bitwise Operation");
            return;
        }

        int result;

        switch (s[0])
        {
            case '+':
                result = a + b;
                break;
            case '-':
                result = a - b;
                break;
            case '*':
                result = a * b;
                break;
            case '/':
                if (b == 0)
                {
                    Console.WriteLine("0? really?");
                    return;
                }
                result = a / b;
                break;
            default:
                Console.WriteLine("Critical Error.Formating C:/Windows/");
                return;
        }

        int bitwiseResult;

        switch (o[0])
        {
            case '&':
                bitwiseResult = a & b;
                break;
            case '|':
                bitwiseResult = a | b;
                break;
            case '^':
                bitwiseResult = a ^ b;
                break;
            default:
                Console.WriteLine("Critical Error.Reboot in 10 seconds");
                return;
        }

        Console.WriteLine("Result of Arithmetic Operation: " + result);

        Console.WriteLine("Result of Bitwise Operation: " + bitwiseResult);

        Console.WriteLine("Convertation: ");
        Console.WriteLine("In 2: " + Convert.ToString(bitwiseResult, 2));

        Console.WriteLine("In 16: " + Convert.ToString(bitwiseResult, 16));
    }
}
