import { data } from "./cw_data.js"

function Hello(name: string): string {
    return `Hello ${name}`;
}

data.forEach(element => {
    console.log(Hello(element));
});
