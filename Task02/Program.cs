/*
Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка
*/
using static System.Console;
Clear();
Write("Введите размер матрицы и диапазон значений через пробел: ");
int[] inParams = Array.ConvertAll(ReadLine()!.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
int[,] array = GetMatrixArray(inParams[0], inParams[1], inParams[2], inParams[3]);
PrintMatrixArray(array);
WriteLine();
WriteLine($"Cтрока с наименьшей суммой элементов: {GetSumMatrixLine(array)}");


int[,] GetMatrixArray(int rows, int columns, int minValue, int maxValue)
{
    Random rnd = new Random();
    int[,] resultArray = new int[rows, columns];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            resultArray[i, j] = rnd.Next(minValue, maxValue + 1);
        }
    }
    return resultArray;
}

int GetSumMatrixLine(int[,] inArray)
{
    int minSum = 0;
    int minSumInd = 0;
    for (int j = 0; j < inArray.GetLength(1); j++)
    {
        minSum = minSum + inArray[0, j];
    }
    for (int i = 1; i < inArray.GetLength(0); i++)
    {
        int sum = 0;
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            sum = sum + inArray[i, j];
        }
        if (sum < minSum)
        {
            minSum = sum;
            minSumInd = i;
        }
    }
    return minSumInd + 1;
}


void PrintMatrixArray(int[,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            Write($"{inArray[i, j],3} ");
        }
        WriteLine();
    }
}
