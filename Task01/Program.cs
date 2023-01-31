/*
Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2
*/
using static System.Console;
Clear();
Write("Введите размер матрицы и диапазон значений через пробел: ");

int[] inParams = Array.ConvertAll(ReadLine()!.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
int[,] inArray = GetMatrixArray(inParams[0], inParams[1], inParams[2], inParams[3]);
PrintMatrixArray(inArray);
WriteLine();
SortDescendingArray(inArray);
PrintMatrixArray(inArray);


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

int[,] SortDescendingArray(int[,] inArray)
{
    for (int rows = 0; rows < inArray.GetLength(0); rows++)
    {
        for (int i = 0; i < inArray.GetLength(1); i++)
        {
            for (int j = 1; j < inArray.GetLength(1) - i; j++)
            {
                if (inArray[rows, j - 1] < inArray[rows, j])
                {
                    int temp = inArray[rows, j];
                    inArray[rows, j] = inArray[rows, j - 1];
                    inArray[rows, j - 1] = temp;
                }
                
            }
        }
    }

    return inArray;
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
