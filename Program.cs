
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



static void PrintArray(int[] arr)
{
    //Вывод в консоль входящего массива
    foreach (var item in arr)
    {
        Console.Write($"{item}\t");
    }
    Console.WriteLine();
}


// 1. Реализовать сортировку выбором на одномерном массиве 
// целых чисел. Сортировка выбором - найти максимум, 
// установить последним, в следующий раз найти максимум 
// (кроме последнего) и сделать предпоследним, и т.д. 
// Пример - массив [6,2,0,9,7,1,3] должен выводится как [0,1,2,3,6,7,9]. 
// Подумать, как реализовать сортировку по убыванию  [9,7,6,3,2,1,0]

static void SortArrayUp(int[] arr)
{
    //Объявление переменных
    int arrLength = arr.Length;
    int[] sortUp = arr;
    int indexMaxNumber = 0;

    //Сортировка
    for (int i = 1; i < arrLength; i++)
    {
        for (int j = 1; j < arrLength + 1 - i; j++)
        {
            if (sortUp[j] > sortUp[indexMaxNumber])
            {
                indexMaxNumber = j;
            }
        }
        int tmpValue = sortUp[arrLength - i];
        sortUp[arrLength - i] = sortUp[indexMaxNumber];
        sortUp[indexMaxNumber] = tmpValue;

        indexMaxNumber = 0;
    }
    //Вывод в консоль отсортированного массива
    Console.WriteLine("\nСортировка по возрастанию:");
    PrintArray(sortUp);

    // return sortUp;
}



static void SortArrayDown(int[] arr)
{
    //Объявление переменных
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

    //Вывод в консоль отсортированного массива
    Console.WriteLine("\nСортировка по убыванию:");
    PrintArray(sortDown);

    // return sortDown;
}

int[] examArr = new int[] { 6, 2, 0, 9, 7, 1, 3 };
int[] rndArr = CreateRandomArray(7, -10, 10);

Console.WriteLine("Исходный массив:");
// PrintArray(examArr);
// SortArrayUp(examArr);
// SortArrayDown(examArr);

PrintArray(rndArr);
// SortArrayUp(rndArr);
SortArrayDown(rndArr);


// 2. Реализовать сортировку выбором на двухмерном массиве построчно - отсортировать только строки

// Например:

// 2 8 0 1
// 3 8 2 5
// 9 4 5 7

// Станет:

// 0 1 2 8
// 2 3 5 8
// 4 5 7 9


// 3. Реализовать сортировку выбором на двухмерном массиве - отсортировать все элементы

// 2 8 0 1
// 3 8 2 5
// 9 4 5 7

// Станет

// 0 1 2 2
// 3 4 5 5
// 7 8 8 9