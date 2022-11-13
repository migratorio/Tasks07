/*Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07
*/

Console.Clear();

int size = EnterSizeOfArray("Введите размер прямоугольного массива:  ", "Ошибка ввода!");

int[,] arraySpiral = new int[size, size];
arraySpiral = FillingArray(size);

PrintArray(arraySpiral);

//==============================FUNCTIONS=====================================
// Функция возвращает пользовательское натуральное число
static int EnterSizeOfArray(string message, string messageError)
{
    while (true)
    {
        Console.Write(message);
        bool isCorrect = int.TryParse(Console.ReadLine() ?? "", out int parametr) && parametr >0;
        if(isCorrect)
            return parametr;
        Console.WriteLine(messageError);
    }
}

//---------------------------------------------------------------------
//Функция возвращает спирально заполненный прямоугольный массив размером, заданным пользователем  
int[,] FillingArray(int n)
{
int temp = 1;
int i = 0;
int j = 0;
int[,] arr = new int[n, n];

    while (temp <= n * n)
    {
    arr[i, j] = temp;
    temp++;
    if (i <= j + 1 && i + j < arraySpiral.GetLength(1) - 1)
        j++;
    else if (i < j && i + j >= arraySpiral.GetLength(0) - 1)
        i++;
    else if (i >= j && i + j > arraySpiral.GetLength(1) - 1)
        j--;
    else
        i--;
    }
     return arr;
}
//---------------------------------------------------------------------
// Функция выводит в консоль переданный в нее массив
static void PrintArray(int[,] arr)
{  
    for(int i = 0; i < arr.GetLength(0); i++)
    {
        for(int j = 0; j < arr.GetLength(1); j++)
        {
           Console.Write("{0}\t", arr[i, j]);   //Выводим массив в консоль красиво
        }
        Console.WriteLine("\n");
    }
    Console.WriteLine(new string('-', arr.GetLength(1) * 7)); //Это для красоты
} 