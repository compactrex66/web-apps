import fs from "node:fs/promises";
const getAsyncFileContent = async (filePath) => {
    const fileContent = await fs.readFile(filePath, 'utf-8');
    console.log(fileContent);
};
const setAsyncFileContent = async (filePath, data) => {
    await fs.writeFile(filePath, data);
    return true;
};
getAsyncFileContent("output.txt");
const result = await setAsyncFileContent("output.txt", "Async to jest cos tam");
console.log(result);
//# sourceMappingURL=cw3.js.map