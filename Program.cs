
static int[] CreateRandomArray(int m, int minLimitRandom, int maxLimitRandom)
{
    int[] randomArray = new int[m];
    Random rand = new Random();
    for (int i = 0; i < m; i++)
    {
        randomArray[i] = rand.Next(minLimitRandom, maxLimitRandom + 1);
    }
    return randomArray;
}

static int[,] CreateRandomMatrix(int m, int n, int minLimitRandom, int maxLimitRandom)
{
    int[,] randomMatrix = new int[m, n];
    Random rand = new Random();
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            randomMatrix[i, j] = rand.Next(minLimitRandom, maxLimitRandom);
        }
    }
    return randomMatrix;
}

static void PrintArray(int[] arr)
{
    //Вывод в консоль входящего массива
    foreach (var item in arr)
    {
        Console.Write($"{item}\t");
    }
    Console.WriteLine();
}

static void PrintMatrix(int[,] matrix)
{
    int row = matrix.GetLength(0);
    int column = matrix.GetLength(1);
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < column; j++)
        {
            Console.Write($"{matrix[i, j]}\t");
        }
        Console.WriteLine();
    }


}



//__________________________________________________________
//
// 1. Реализовать сортировку выбором на одномерном массиве 
// целых чисел. Сортировка выбором - найти максимум, 
// установить последним, в следующий раз найти максимум 
// (кроме последнего) и сделать предпоследним, и т.д. 
// Пример - массив [6,2,0,9,7,1,3] должен выводится как [0,1,2,3,6,7,9]. 
// Подумать, как реализовать сортировку по убыванию  [9,7,6,3,2,1,0]


static int[] SortArrayUp(int[] arr)
{
    int arrLength = arr.Length;
    int indexMaxNumber = 0;

    //Сортировка
    for (int i = 1; i < arrLength; i++)
    {
        for (int j = 1; j < arrLength + 1 - i; j++)
        {
            if (arr[j] > arr[indexMaxNumber])
            {
                indexMaxNumber = j;
            }
        }
        int tmpValue = arr[arrLength - i];
        arr[arrLength - i] = arr[indexMaxNumber];
        arr[indexMaxNumber] = tmpValue;

        indexMaxNumber = 0;
    }
    return arr;
}

static int[] SortArrayDown(int[] arr)
{
    int arrLength = arr.Length;
    int[] sortDown = arr;
    int indexMinNumber = 0;

    //Сортировка
    for (int i = 1; i < arrLength; i++)
    {
        for (int j = 1; j < arrLength + 1 - i; j++)
        {
            if (sortDown[j] < sortDown[indexMinNumber])
            {
                indexMinNumber = j;
            }
        }
        int tmpValue = sortDown[arrLength - i];
        sortDown[arrLength - i] = sortDown[indexMinNumber];
        sortDown[indexMinNumber] = tmpValue;

        indexMinNumber = 0;
    }
    return sortDown;
}

int[] examArr = new int[] { 6, 2, 0, 9, 7, 1, 3 };
int[] rndArr = CreateRandomArray(7, -10, 10);

Console.WriteLine("ОДНОМЕРНЫЙ МАССИВ, СОРТИРОВКА ВЫБОРОМ");
Console.WriteLine("Исходный массив:");
PrintArray(examArr);
Console.WriteLine("\nСортировка по увеличению:");
PrintArray(SortArrayUp(examArr));
Console.WriteLine("\nСортировка по убыванию:");
PrintArray(SortArrayDown(examArr));

// PrintArray(rndArr);
// Console.WriteLine(PrintArray(SortArrayUp(rndArr)));
// Console.WriteLine(PrintArray(SortArrayDown(rndArr)));



//__________________________________________________________
//
// 2. Реализовать сортировку выбором на двухмерном массиве построчно - 
// отсортировать только строки
// Например:
// 2 8 0 1
// 3 8 2 5
// 9 4 5 7
// Станет:
// 0 1 2 8
// 2 3 5 8
// 4 5 7 9

static void SortMatrixRow(int[,] arr)
{
    int rows = arr.GetLength(0);
    int columns = arr.GetLength(1);

    for (int i = 0; i < rows; i++)
    {
        //Пустой массив
        int[] row = new int[columns];

        //Извлечение строки 
        for (int j = 0; j < columns; j++)
        {
            row[j] = arr[i, j];
        }
        //Сортировка строки
        row = SortArrayUp(row);

        //Замена отсортированным значением
        for (int k = 0; k < columns; k++)
        {
            arr[i, k] = row[k];
        }
    }
    //Вывод в консоль отсортированного массива
    Console.WriteLine("\nСортировка строк матрицы по возрастанию:");
    PrintMatrix(arr);
}

int[,] examMatrix = new int[,] { { 2, 8, 0, 1 }, { 3, 8, 2, 5 }, { 9, 4, 5, 7 } };
int[,] rndMatrix = CreateRandomMatrix(3, 4, 0, 9);

Console.WriteLine("\nДВУМЕРНЫЙ МАССИВ, ПОСТРОЧНАЯ СОРТИРОВКА");
Console.WriteLine("Исходный массив:");
PrintMatrix(examMatrix);
SortMatrixRow(examMatrix);

// PrintMatrix(rndMatrix);
// SortMatrixRow(rndMatrix);



//__________________________________________________________
//
// 3. Реализовать сортировку выбором на двухмерном массиве - 
// отсортировать все элементы
// 2 8 0 1
// 3 8 2 5
// 9 4 5 7
// Станет
// 0 1 2 2
// 3 4 5 5
// 7 8 8 9

static void SortMatrixAll(int[,] arr)
{
    int rows = arr.GetLength(0);
    int columns = arr.GetLength(1);

    //Пустой массив
    int[] row = new int[arr.Length];

    for (int i = 0; i < rows; i++)
    {
        //Извлечение строки 
        for (int j = 0; j < columns; j++)
        {
            row[i * columns + j] = arr[i, j];
        }
    }

    //Сортировка строки
    row = SortArrayUp(row);

    //Замена отсортированным значением
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            arr[i, j] = row[i * columns + j];
        }
    }
    //Вывод в консоль отсортированного массива
    Console.WriteLine("\nСортировка всех значений матрицы по возрастанию:");
    PrintMatrix(arr);
}

Console.WriteLine("\nДВУМЕРНЫЙ МАССИВ, СОРТИРОВКА ВСЕХ ЭЛЕМЕНТОВ");
Console.WriteLine("Исходный массив:");
PrintMatrix(examMatrix);
SortMatrixAll(examMatrix);

// PrintMatrix(rndMatrix);
// SortMatrixAll(rndMatrix);
