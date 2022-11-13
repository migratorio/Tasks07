/*  Задача 54: Задайте двумерный массив. Напишите программу, которая 
упорядочит по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2
*/

Console.Clear();

int rows = EnterParametrOfArray("Введите количество строк массива:      ", "Ошибка ввода!");
int columns = EnterParametrOfArray("Введите количество столбцов массива:   ", "Ошибка ввода!");

int[,] array = GetArray(rows, columns);

Console.WriteLine(new string('-', array.GetLength(1) * 7) + "\nИсходный массив:\n"); // Это для красоты
PrintArray(array);

array = SortBulb(array);

Console.WriteLine("Сортированный массив:\n");
PrintArray(array);

//==============================FUNCTIONS=====================================
// Функция возвращает пользовательское натуральное число
static int EnterParametrOfArray(string message, string messageError)
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
//----------------------------------------------------------------------------
// Функция возвращает массив случайных целых чисел от 1 до 100 с заданными пользователем размером
int[,] GetArray(int m, int n)
{
   int[,] arr = new int[m, n];
   for(int i = 0; i < m; i++)
   {
        for(int j = 0; j < n; j++)
        {
            arr[i, j] = new Random().Next(1, 100 + 1);
        }
   }
   return arr; 
}
//----------------------------------------------------------------------------
// Функция сортирует исходный массив пузырьковым методом.
// Планировалось использовать метод QuickSort, но для освоения не хватило времени
static int[,] SortBulb(int[,] arr)
{
    for(int i = 0; i < arr.GetLength(0); i++)
    {
        int count = 1;
       
        for(int k = 0; count < arr.GetLength(1); k++)
        {
            int temp = 0;
            for(int j = 0; j < arr.GetLength(1); j++)
            {
                if(j == arr.GetLength(1) - count)
                    break;
                if(arr[i, j] < arr[i, j + 1])
                {
                    temp = arr[i, j + 1];
                    arr[i, j + 1] = arr[i, j];
                    arr[i, j] = temp;
                }
            }
        count++;
        }
    }
    return arr;
}
//----------------------------------------------------------------------------
// Функция выводит в консоль переданный в нее массив
static void PrintArray(int[,] arr)
{
    for(int i = 0; i < arr.GetLength(0); i++)
    {
        for(int j = 0; j < arr.GetLength(1); j++)
        {
           Console.Write("{0}\t", arr[i, j]);   //Выводим массив в консоль 
        }
        Console.WriteLine();
    }
    Console.WriteLine(new string('-', arr.GetLength(1) * 7)); //Это для красоты
} 