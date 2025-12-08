import readLine from "node:readline/promises";
import { nwd, nwdRecursive } from "./nwd.js";

const readObject = readLine.createInterface({
    input: process.stdin,
    output: process.stdout
});

const main = async () => {
    let number1, number2, nwdResult, choice;
    while(!number1) {
        number1 = parseInt(await readObject.question("Podaj pierwszą liczbę: "));
    }
    while(!number2) {
        number2 = parseInt(await readObject.question("Podaj drugą liczbę: "));
    }
    while(true) {
        choice = parseInt(await readObject.question("Podaj metodę jakiej chcesz użyć:\n1. Iteracyjnie\n2. Rekurencyjnie\n"));
        switch(choice) {
            case 1:
                nwdResult = await nwd(number1, number2);
                break;
            case 2:
                nwdResult = await nwdRecursive(number1, number2);
                break;
            default:
                console.log("Nie ma takiej opcji");
                continue;
        }
        if(nwdResult) {
            readObject.close();
            console.log(`Nwd liczb ${number1} i ${number2}: ${nwdResult}`);
            return;
        }
    }
};
main();