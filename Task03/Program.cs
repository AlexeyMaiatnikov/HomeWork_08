/*
Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18
*/
using static System.Console;
Clear();
Write("Введите количество строк, столбцов, минимальное и максимальное значение элементов матрицы A через пробел: ");
int[] inParams = Array.ConvertAll(ReadLine()!.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
int[,] array1 = GetMatrixArray(inParams[0], inParams[1], inParams[2], inParams[3]);
Write("Введите количество столбцов, минимальное и максимальное значение элементов матрицы B через пробел: ");
int[] inParameters = Array.ConvertAll(ReadLine()!.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
int[,] array2 = GetMatrixArray(inParams[1], inParameters[0], inParameters[1], inParameters[2]);
PrintMatrixArray(array1);
WriteLine();
PrintMatrixArray(array2);
WriteLine();
PrintMatrixArray(ProductMatrixArray(array1, array2));




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

int[,] ProductMatrixArray(int[,] inArray1, int[,] inArray2)
{
    int[,] resultArray = new int[inArray1.GetLength(0), inArray2.GetLength(1)];
    for (int i = 0; i < inArray1.GetLength(0); i++)
    {
        for (int j = 0; j < inArray2.GetLength(1); j++)
        {
            for (int g = 0; g < inArray1.GetLength(1); g++)
            {
                resultArray[i, j] = resultArray[i, j] + inArray1[i, g] * inArray2[g, j];
            }
        }
    }
    return resultArray;
}



void PrintMatrixArray(int[,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            Write($"{inArray[i, j],5} ");
        }
        WriteLine();
    }
}
