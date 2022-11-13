/* Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка
*/

Console.Clear();
int rows = 0;
int columns = 0;
while(rows <= 0 || columns <= 0)
{
	rows = EnterParametrOfArray("Введите количество строк массива:      ", "Ошибка ввода!");
	columns = EnterParametrOfArray("Введите количество столбцов массива:   ", "Ошибка ввода!");
	if(rows <= 0 || columns <= 0)
    		Console.WriteLine("Ошибка ввода!");   
}
int minValue = 0;
int maxValue = 0;
while(maxValue - minValue <= 0) //Проверяем правильность ввода границ значений массива
{
    minValue = EnterParametrOfArray("Введите минимальное значение массива:  ", "Ошибка ввода!");
    maxValue = EnterParametrOfArray("Введите максимальное значение массива: ", "Ошибка ввода!");
    if(maxValue - minValue <= 0)
        Console.WriteLine("Ошибка ввода!");
}
int[,] array = GetArray(rows, columns);

int indexRowMin = FindMinSumOfRows(array);

PrintResult(array, indexRowMin);

//==============================FUNCTIONS=====================================
// Функция возвращает пользовательское натуральное число
static int EnterParametrOfArray(string message, string messageError)
{
    while (true)
    {
        Console.Write(message);
        bool isCorrect = int.TryParse(Console.ReadLine() ?? "", out int parametr);
        if(isCorrect)
            return parametr;
        Console.WriteLine(messageError);
    }
}
//----------------------------------------------------------------------------
// Функция возвращает двухмерный массив
int[,] GetArray(int m, int n)
{
   int[,] arr = new int[m, n];
   for(int i = 0; i < m; i++)
   {
        for(int j = 0; j < n; j++)
        {
            arr[i, j] = new Random().Next(minValue, maxValue + 1);
        }
   }
   return arr; 
}
//----------------------------------------------------------------------------
// Функция возвращает номер строки с минимальной суммой элементов
static int FindMinSumOfRows(int[,] arr)
{
    int index = 0;
    int summRowMin = 0;

    for(int i = 0; i < arr.GetLength(0); i++)
    {
        int summRowTemp = 0;
       
        for(int j = 0; j < arr.GetLength(1); j++)
          summRowTemp += arr[i, j]; 
         
        if(i == 0)
            summRowMin = summRowTemp;
        else
            if(summRowTemp < summRowMin)
            {
                summRowMin = summRowTemp;
                index = i;
            }
    }
    return index + 1; 
}
//----------------------------------------------------------------------------
// Функция выводит в консоль двухмерный массив и номер строки с минимальной суммой элементов
static void PrintResult(int[,] arr,  int index)
{
    for(int i = 0; i < arr.GetLength(0); i++)
    {
        for(int j = 0; j < arr.GetLength(1); j++)
        {
           Console.Write("{0}\t", arr[i, j]); 
        }
        Console.WriteLine();
    }
    Console.WriteLine(new string('-', arr.GetLength(1) * 7));
    Console.WriteLine($"\nНаименьшую сумму элементов имеет {index} строка\n");

} 