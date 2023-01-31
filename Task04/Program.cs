/*
Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)
*/
using static System.Console;
Clear();
Write("Введите измерения массива X, Y, Я через пробел: ");
int[] inParams = Array.ConvertAll(ReadLine()!.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
int[,,] array = new int[inParams[0], inParams[1], inParams[2]];
GetMatrixArray(array);

PrintMatrixArray(array);
WriteLine();



void GetMatrixArray(int[,,] inArray)
{
    int[] temp = new int[inArray.GetLength(0) * inArray.GetLength(1) * inArray.GetLength(2)];
    int number;
    for (int i = 0; i < temp.GetLength(0); i++)
    {
        temp[i] = new Random().Next(10, 100);
        number = temp[i];
        if (i >= 1)
        {
            for (int j = 0; j < i; j++)
            {
                while (temp[i] == temp[j])
                {
                    temp[i] = new Random().Next(10, 100);
                    j = 0;
                    number = temp[i];
                }
                number = temp[i];
            }
        }
    }
    int count = 0;
    for (int x = 0; x < inArray.GetLength(0); x++)
    {
        for (int y = 0; y < inArray.GetLength(1); y++)
        {
            for (int z = 0; z < inArray.GetLength(2); z++)
            {
                inArray[x, y, z] = temp[count];
                count++;
            }
        }
    }
}

void PrintMatrixArray(int[,,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            for (int h = 0; h < inArray.GetLength(2); h++)
            {
                WriteLine($"{inArray[i, j, h],4} ({i}, {j}, {h})");
            }

        }

    }
}
