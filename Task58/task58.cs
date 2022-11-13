/*Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18
*/

Console.Clear();

int rows1 = EnterParametrOfArray("Введите количество строк массива 1:      ", "Ошибка ввода!");
int columns1 = EnterParametrOfArray("Введите количество столбцов массива 1:   ", "Ошибка ввода!");

int rows2 = EnterParametrOfArray("Введите количество строк массива 2:      ", "Ошибка ввода!");
int columns2 = EnterParametrOfArray("Введите количество столбцов массива 2:   ", "Ошибка ввода!");

if(columns1 != rows2)
{
    Console.WriteLine("Матрицы с такими данными не могут быть умножены!");
    return;
}

int[,] array1 = GetArray(rows1, columns1);

int[,] array2 = GetArray(rows2, columns2);

int[,] arrayMulti = MultiplyMatrix(array1, array2);

PrintResult(array1, array2, arrayMulti);

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
int[,] GetArray(int m, int n)
{
   int[,] arr = new int[m, n];
   for(int i = 0; i < m; i++)
   {
        for(int j = 0; j < n; j++)
        {
            arr[i, j] = new Random().Next(1, 10 + 1);
        }
   }
   return arr; 
}

//---------------------------------------------------------------------------
static void PrintResult(int[,] arr1, int[,] arr2, int[,] arrMulty)
// Честно скажу, с выводом в консоль не справился: не хватило времени. :(
// Если матрицы не квадратные, выводятся в консоль не полностью.
// Зато с квадратными матрицами всё отлично работает!
{
Console.WriteLine(); 
    int gl = arr1.GetLength(0);
    if(gl > arr2.GetLength(0))
        gl = arr2.GetLength(0);
    for(int i = 0; i < gl; i++)
    {
        for(int j = 0; j < arr1.GetLength(1) ; j++)
        {
            Console.Write("{0}\t", arr1[i, j]);   
            if(j == arr1.GetLength(1) - 1)
                Console.Write("|\t");
        }
        for(int j = 0; j < arr2.GetLength(1); j++)
            Console.Write("{0}\t", arr2[i, j]);   
        Console.WriteLine(); 
    }
        Console.WriteLine("\nРезультирующая матрица:\n"); 

    for(int i = 0; i < arrMulty.GetLength(0); i++) 
    {
        for(int j = 0; j < arrMulty.GetLength(1); j++)
        {
           Console.Write("{0}\t", arrMulty[i, j]); 
        }
        Console.WriteLine();
    }
} 
//---------------------------------------------------------------------------
// Функция принимает 2 матрицы и возвращает матрицу, как результат их умножения 
static int[,] MultiplyMatrix(int[,] arr1, int[,]arr2)
    {
        int temp = 0;
        int[,] arrMulti = new int[arr1.GetLength(0), arr2.GetLength(1)];
        for (int i = 0; i < arr1.GetLength(0); i++)
        {
            for (int j = 0; j < arr2.GetLength(1); j++)
            {
                temp = 0;
                for (int k = 0; k < arr1.GetLength(1); k++)
                {
                    temp += arr1[i, k] * arr2[k, j];
                }
                arrMulti[i, j] = temp;
            }
        }
        return arrMulti;
    }
    