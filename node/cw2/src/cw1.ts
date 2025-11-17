import readLine from "node:readline/promises";
import { nwd, nwdRecursive } from "./nwd.js";

const readObject = readLine.createInterface({
    input: process.stdin,
    output: process.stdout
});

const main = async () => {
    let number1, number2, nwdResult, choice;
    number1 = parseInt(await readObject.question("Podaj pierwszą liczbę: "));
    number2 = parseInt(await readObject.question("Podaj drugą liczbę: "));
    choice = parseInt(await readObject.question("Podaj metodę jakiej chcesz użyć:\n1. Iteracyjnie\n2. Rekurencyjnie\n"));
    readObject.close();
    switch(choice) {
        case 1:
            nwdResult = await nwd(number1, number2);
            break;
        case 2:
            nwdResult = await nwdRecursive(number1, number2);
            break;
        default:
            console.log("Nie ma takiej opcji");
            return
    }
    console.log(`Nwd liczb ${number1} i ${number2}: ${nwdResult}`);
};
main();