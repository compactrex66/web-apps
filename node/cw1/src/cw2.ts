import { appendFileSync, readFileSync, writeFileSync } from "node:fs";
import { data } from "./cw_data.js";

const fileContent: string = readFileSync("dane.txt", "utf-8");
console.log(fileContent);
writeFileSync("output.txt", data.join("\n"))
appendFileSync("output.txt", "\nAppend line.")