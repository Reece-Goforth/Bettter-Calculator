using System.Diagnostics.Metrics;

while (true)
{
    Console.Write(">> ");
    string? str = Console.ReadLine();

    if (str == null) continue;

    int value;
    value = AddSubtractString(str);

    Console.WriteLine(value.ToString());
}

static bool IsDigit(char chr)
{
    return chr switch
    {
        '0' or '1' or '2' or '3' or '4' or '5' or '6' or '7' or '8' or '9' => true,
        _ => false,
    };
}

static int AddSubtractString(string str)
{
    int result = 0;
    for (int i = 0; i < str.Length; i++)
    {
        if (!IsDigit(str[i])) continue;

        if (i > 0 && str[i - 1] == '-')
        {
            int number = 0;
            int j = 0;
            while ((i + j) < (str.Length) && IsDigit(str[i + j]))
            {
                j++;
            }
            int k = 0;
            while (j > 0)
            {
                j--;
                int multiplier = (int)Math.Pow(10, j);
                number += (int)Char.GetNumericValue(str[i + k]) * multiplier;
                k++;
            }
            result -= number;
            i += k;
        }
        else if (i == 0 || str[i - 1] == '+')
        {
            int number = 0;
            int j = 0;
            while ((i + j) < (str.Length) && IsDigit(str[i + j]))
            {
                j++;
            }
            int k = 0;
            while (j > 0)
            {
                j--;
                int multiplier = (int)Math.Pow(10, j);
                number += (int)Char.GetNumericValue(str[i + k]) * multiplier;
                k++;
            }
            result += number;
            i += k;
        }
    }
    return result;
}