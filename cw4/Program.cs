void printTable<T>(T[] array) {
    foreach (T i in array) {
        Console.Write(i + " ");
    }
    Console.WriteLine();
}

//int[] array = new int[10];

// for (int i = 0; i < array.Length; i++) {
//     array[i] = i * i;
//     // Console.Write($"{array[i]} ");
// }

// foreach (int i in array) {
//     Console.Write(i +"");
// }

// printTable(array);

string[] stringArr = new string[10];

for(int i = 0; i < stringArr.Length; i++) {
    stringArr[i] = $"lol{i}";
}
//printTable(stringArr);

int[] generateRandomArray(int length) {
    Random rand = new Random();
    int[] randomArray = new int[length];
    for (int i = 0; i < length; i++) {
        randomArray[i] = rand.Next(100);
    }
    return randomArray;
}

//printTable(generateRandomArray(10));

int findMax(int[] array) {
    int max = array[0];
    for (int i = 0; i < array.Length; i++) {
        if(array[i] > max) {
            max = array[i];
        }
    }

    return max;
}

int findMin(int[] array) {
    int min = array[0];
    for (int i = 0; i < array.Length; i++) {
        if(array[i] < min) {
            min = array[i];
        }
    }

    return min;
}

double getSum(int[] array) {
    double sum = 0;
    for (int i = 0; i < array.Length; i++) {
        sum += array[i];
    }
    return sum;
}

double getAverage(int[] array) {
    return getSum(array) / array.Length;
}

int[] generDivBy(int length, int divisibleBy) {
    Random rand = new Random();
    int[] array = new int[length];
    int randomNumber;
    for (int i = 0; i < length; i++) {
        randomNumber = rand.Next(100)*divisibleBy;
        array[i] = randomNumber;
    }

    return array;
}

int[] array = generateRandomArray(10);
printTable(array);
Console.WriteLine(findMax(array));
Console.WriteLine(findMin(array));
Console.WriteLine(findMax(array) - findMin(array));
Console.WriteLine(getAverage(array));

array = generDivBy(30, 5);
printTable(array);

Person[] personArr = new Person[3] {new Person("Jan", "Kowalski", 20), new Person("Adam", "Duda", 40), new Person("Andrzej", "Wiadro", 41)};
printTable(personArr);