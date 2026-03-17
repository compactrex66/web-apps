import {getConnection,getGames} from './MySqlRepo.js';

export async function testConnection() {
    try {
        const connection = await getConnection();
        const [rows] = await connection.execute('SELECT NOW() AS now');
        console.log('Connection successful:', rows);
        connection.end();
    } catch (error) {
        console.error('Connection failed:', error);
    }
}
async function main() {
    const books =  await getGames();
    console.log(books);
}
main();