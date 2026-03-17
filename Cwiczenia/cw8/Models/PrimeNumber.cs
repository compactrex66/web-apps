using System;

namespace cw8.Models;

public class PrimeNumber
{
    public static bool isPrimeNumber(int number) {
        for(int i = 2; i * i < number; i++) {
            if(number % i == 0) {
                return false;
            }
        }
        return true;
    }

    public static List<int> generatePrimeNumbers(int amount) {
        List<int> primeNumbers = new List<int>();

        for(int i = 2; primeNumbers.Count() < amount; i++) {
            if(isPrimeNumber(i)) {
                primeNumbers.Add(i);
            }
        }

        return primeNumbers;
    }
}
