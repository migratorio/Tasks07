/*Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, 
которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)
*/

Console.Clear();

int rows = EnterSizeOfArray("Введите количество элементов 1-го измерения трёхмерного массива: ");
int columns = EnterSizeOfArray("Введите количество элементов 2-го измерения трёхмерного массива: ");
int zRows= EnterSizeOfArray("Введите количество элементов 3-го измерения трёхмерного массива: ");
int[] array = GetArray(rows, columns, zRows);

int[,,] array3dim = GetArray3dimensional(array,rows, columns, zRows);

PrintArray(array3dim);
//--------------------------------FUNCTIONS----------------------------
// Функция возвращает пользовательское натуральное число
static int EnterSizeOfArray(string message)
{
    while (true)
    {
        Console.Write(message);
        bool isCorrect = int.TryParse(Console.ReadLine() ?? "", out int userNumber) && userNumber > 0;
        if (isCorrect)
            return userNumber;
        Console.WriteLine("Ошибка ввода!");
    }
}
//---------------------------------------------------------------------------------
// Функция возвращает одномерный массив, заполненный случайными неповторяющимися двузначными числами
static int[] GetArray(int m, int n, int p)
{
    int lengsTempArr = m * n * p;
     int[] tempArr = new int [lengsTempArr]; 	// Создаём вспомогательный массив
					                        // для проверки элементов массива на уникальность

    for(int i = 0; i < lengsTempArr; i++)
    {
        int j = -1;
       while (j < i)
       {
            int temp = new Random().Next(10, 100);
            for (j = 0; j < i; j++)
            {
                if (tempArr[j] == temp)
                    break;
            }
            tempArr[i] = temp;
       }
    }
    return tempArr;
}
//---------------------------------------------------------------------------------
//Функция принимает на вход одномерный массив и его размеры, а возвращает трёхмерный
static int[,,] GetArray3dimensional(int[] arr, int m, int n, int p)
{
    int[,,] arr3d = new int[m, n, p];

    int h = 0;
    for(int i = 0; i < m; i++)
    {
        for(int j = 0; j < n; j++)
        {
            for(int k = 0; k < p; k++)
            {
                arr3d[i, j, k] = arr[h];
                h++;
            }
        }
    }
    return arr3d;
}
//---------------------------------------------------------------------------------
// Функция выводит в консоль сформированный программой массив

// Вывод массива в соответствии с примером. Но логика вывода не понятна.
static void PrintArray(int[,,] arr3d)
{
    for(int k = 0; k < arr3d.GetLength(2); k++)
    {
        for(int i = 0; i < arr3d.GetLength(0); i++)
        {
            for(int j = 0; j < arr3d.GetLength(1); j++)
            {
                Console.Write($"{arr3d[i,j,k]}({i},{j},{k}) ");
            }
            Console.WriteLine("");
        }
    }
}