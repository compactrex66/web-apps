import { data } from "./cw_data.js";
function Hello(name) {
    return `Hello ${name}`;
}
data.forEach(element => {
    console.log(Hello(element));
});
//# sourceMappingURL=cw1.js.map