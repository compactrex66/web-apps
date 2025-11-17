export const nwd = async (num1: number, num2: number): Promise<number> => {
    while(num1 != num2) {
        if(num1 > num2) {
            num1 -= num2;
        } else {
            num2 -= num1;
        }
    }
    return num1;
}
export const nwdRecursive = async (num1: number, num2: number): Promise<number> => {
    if(num1 > num2) {
        return nwdRecursive(num1-num2, num2);
    } else if(num1 < num2) {
        return nwdRecursive(num1, num2-num1);
    }
    return num1;
}