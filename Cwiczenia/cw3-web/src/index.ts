import { colors, type Book } from "./data.js";
import { books } from "./data.js";

const result1 = document.querySelector<HTMLDivElement>('#result1');
const result2 = document.querySelector<HTMLDivElement>('#result2');
const result3 = document.querySelector<HTMLDivElement>('#result3');
if (result1) {
    GenerSelect(colors,result1);
    document.querySelector<HTMLSelectElement>('#colorSelect')
            ?.addEventListener('change', (event)=>{
                document.body.style.backgroundColor = 
                     (event.target as HTMLSelectElement).value
            });
}else{
    console.error("Brak elementu o id 'result1' w dokumencie HTML.");
}

if (result2) {
    GenerTable(books, result2);
}

//const GenerSelect = () =>{};
function GenerSelect(colors: string[],elem:Element) { 
    const select = document.createElement('select');
    select.id = 'colorSelect';
    for (const color of colors) {
        const option = document.createElement('option');
        option.value = color;
        option.text = color;
        select.appendChild(option);
    } 
    elem.appendChild(select);   
};


function GenerTable(data: Book[], elem:Element) {
    const table = document.createElement("table");
    table.classList.add("table", "table-stripped");
    const thead = document.createElement("thead");
    thead.innerHTML = `
        <th>Lp.</th>
        <th>Title</th>
        <th>Author</th>
        <th>Year</th>
        <th>Pages</th>
        <th>Price</th>
    `
    table.append(thead);
    let lp: number = 0;
    const tbody = document.createElement("tbody");
    data.forEach(book => {
        lp++;
        const row = document.createElement("tr");
        row.id = `${book.id}`;
        row.style.cursor = "pointer";
        row.innerHTML = `
            <td>${lp}</td>
            <td>${book.title}</td>
            <td>${book.author}</td>
            <td>${book.year}</td>
            <td>${book.pages}</td>
            <td>${book.price.toFixed(2)}</td>
        `
        row.addEventListener("click", (e) => {
            if (result3) result3.innerText = `${book.id} ${book.title} ${book.author} ${book.year} ${book.pages} ${book.price.toFixed(2)}`;
        });
        tbody.append(row);
    });
    table.append(tbody);
    elem.append(table);
}