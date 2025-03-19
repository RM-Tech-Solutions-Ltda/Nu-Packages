namespace RMTech.TestPackage;

public static class ArrayUtils
{
    // criando o package: dotnet pack -c release -o dist
    public static int SingleNumber(int[] nums)
    {
        int bitHolder = 0;

        foreach (int num in nums)        
            bitHolder ^= num;        

        return bitHolder;
    }

    public static int SingleNumberWithComments(int[] nums)
    {
        int bitHolder = 0;

        // Executa uma operação bit a bit onde 00 + 01 = 01 e 01 + 01 = 00; O bit a esquerda não se utiliza.
        foreach (int num in nums)
        {
            Console.WriteLine($"holder: {bitHolder}, num: {num}");
            Console.WriteLine($"Antes: {Convert.ToString(bitHolder, 2).PadLeft(8, '0')} ({bitHolder})");
            Console.WriteLine($"XOR  : {Convert.ToString(num, 2).PadLeft(8, '0')} ({num})");
            bitHolder ^= num;
            Console.WriteLine($"Depois: {Convert.ToString(bitHolder, 2).PadLeft(8, '0')} ({bitHolder})");
            Console.WriteLine($"Holder: {bitHolder}");

            Console.WriteLine("-----------------");
        }

        Console.WriteLine($"Holder Final: {bitHolder}");

        return bitHolder;
    }
}
