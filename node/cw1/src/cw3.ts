import fs from "node:fs/promises";

const getAsyncFileContent = async (filePath: string) => {
    const fileContent = await fs.readFile(filePath, 'utf-8');
    console.log(fileContent);
}

const setAsyncFileContent = async (filePath: string, data: string): Promise<boolean> => {
    await fs.writeFile(filePath, data);
    return true;
}

getAsyncFileContent("output.txt");
const result = await setAsyncFileContent("output.txt", "Async to jest cos tam");
console.log(result);