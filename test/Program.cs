//Написать программу, которая из имеющегося массивастрок формирует массив из строк, длина которых
//меньше или равна 3.
const int MaxRandomStringLength = 8; // определяет максимальную длину строки при случайном создании массива строк
const int StringLength = 3; // отбираем строки, количество символов в которой меньше либо равно этому значению 
const int MaxArraySize = 15; // определяет максимальное количество элементов при создании массива строк
const int MinChar = 97, MaxChar = 122; // для англ алфавита 
//const int MinChar = 1072, MaxChar = 1103; // для русского алфавита
string[] FillArray()
{
    string[] StringArrayToFill;
    string enteredSymbol = string.Empty;
    int arraySize = 0;
    do
    {
        Console.Clear();
        Console.Write("Создать случайный массив случайных строк? Нажмите y/n: ");
        enteredSymbol = Console.ReadLine();
        if (enteredSymbol == "y")
        {
            arraySize = new Random().Next(3, MaxArraySize + 1);
            StringArrayToFill = CreateRandomStrArray(arraySize);
            Console.WriteLine("Сгенерированный массив строк:");
            Console.WriteLine($"{String.Join(' ', StringArrayToFill)}");
            break;
        }
        else if (enteredSymbol == "n")
        {
            StringArrayToFill = ManualCreateStrArray();
            break;
        }
    } while (true);

    return StringArrayToFill;
}
string[] ManualCreateStrArray()
{
    int arraySize = 0;
    do
    {
        Console.Clear();
        Console.Write("Введите количество элементов массива не больше {0}: ", MaxArraySize);
        arraySize = Convert.ToInt32(Console.ReadLine());
        if (arraySize > 0 && arraySize <= MaxArraySize)
            break;

    } while (true);

    string[] newStringArray = new string[arraySize];
    for (int i = 0; i < arraySize; i++)
    {
        Console.Write("Введите {0} строку:", i + 1);
        newStringArray[i] = Console.ReadLine();
    }
    return newStringArray;
}
string AssembleStringFromArray(string[] arrayToCollect)
{
    string resultString = string.Empty;
    int arrayLength = arrayToCollect.Length;
    if (arrayLength == 0) return resultString;
    for (int i = 0; i < arrayLength; i++)
    {
        resultString += $"\"{arrayToCollect[i]}\"";
        if (i < arrayLength - 1) resultString += ", ";
    }

    return resultString += ".";
}
string[] PickElementsFromArray(string[] StringToSeek, int strLength)
{
    int resArrayCount = 0;
    for (int i = 0; i < StringToSeek.Length; i++)
        if (StringToSeek[i].Length <= strLength) resArrayCount++;

    string[] resultArray = new string[resArrayCount];

    for (int k = 0, l = 0; k < StringToSeek.Length; k++)
    {
        if (StringToSeek[k].Length <= strLength)
        {
            resultArray[l] = StringToSeek[k];
            l++;
        }
    }
    return resultArray;
}
string CreateRandomString(int minBorder, int maxBorder)
{
    string newString = string.Empty;
    int length = new Random().Next(1, MaxRandomStringLength+1);
    char newSymbol = '0';
    for (int i = 0; i < length; i++)
    {
        newSymbol = (char)new Random().Next(minBorder, maxBorder+1);
        newString += newSymbol;
    }
    return newString;
}
string[] CreateRandomStrArray(int elementsNumber)
{
    string[] newStringArray = new string[elementsNumber];
    for (int i = 0; i < elementsNumber; i++)
    {
        newStringArray[i] = CreateRandomString(MinChar,MaxChar);
    }
    return newStringArray;
}
string[] inputArray = FillArray();
string[] outputArray = PickElementsFromArray(inputArray, StringLength);
string outputString = AssembleStringFromArray(outputArray); 

if (outputString == string.Empty)
    Console.WriteLine("\nВ массиве нет строк, длина которых меньше либо равна {0} символам", StringLength);
else
{
    Console.WriteLine("\nРезультатом выборки из массива строк является массив,\n в котором строки длиной меньше либо равны {0} символам", StringLength);
    Console.WriteLine(outputString);
} 
