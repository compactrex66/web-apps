import mysql from 'mysql2/promise';

export type Game = {
    id: number;
    title: string;
    developer: string;
    price: number;
}

let connection: mysql.Connection | null = null;

async function createNewConnection() {
    return await mysql.createConnection({
        host: 'localhost',
        user: 'root',
        password: '',
        database: 'games'
    });
}

export async function getConnection(): Promise<mysql.Connection> {
    if (!connection) {
        connection = await createNewConnection();
        return connection;
    }
    return connection;    
}

// convenience helper: executes a query, ensuring the connection is open


export const getGames = async (): Promise<Game[]> =>{
    connection = await getConnection();
    const [rows] = await connection.execute('SELECT title, developer, price, genre FROM games, genres WHERE games.genre_id=genres.id');
    await connection.end();
    connection = null;
    return rows as Game[];
};

export const getGameById = async (id: string): Promise<Game|undefined> =>{
    connection = await getConnection();
    const [rows] = await connection.execute('SELECT * FROM games WHERE id = ?', [id]);
    console.log(`Fetching book with id=${id}`, rows);
    await connection.end();
    connection = null;
    if((rows as Game[]).length === 0){
        console.log(`No book found with id=${id}`);
        return  undefined;
    }

    console.log(`Book found with id=${id}`);
    return (rows as Game[])[0];
}
export const deleteGameById = async (id: string): Promise<boolean> => {
    connection = await getConnection();
    const [result] = await connection.execute<mysql.ResultSetHeader>(
        'DELETE FROM games WHERE id = ?',
        [id]
    );
    await connection.end();
    connection = null;
    return result.affectedRows > 0;
};

export const addGame = async (game:Game): Promise<number> => {
    connection = await getConnection();
    const [result] = await connection.execute<mysql.ResultSetHeader>(
        'INSERT INTO games (title, developer, price) VALUES (?, ?, ?)',
        [game.title, game.developer, game.price]
    );
    await connection.end();
    connection = null;
    return result.insertId;
};
export const updateGame = async (game: Game): Promise<boolean> => {
    connection = await getConnection();
    const [result] = await connection.execute<mysql.ResultSetHeader>(   
        'UPDATE games SET title = ?, author = ?, price = ? WHERE id = ?',
        [game.title, game.developer, game.price, game.id]
    );  
    await connection.end();
    connection = null;
    return result.affectedRows > 0;
}
