import {type Request,type Response,Router } from "express";
import { getGameById, getGames,type Game,
    getConnection, 
    deleteGameById ,
    updateGame,
    addGame
} from "./MySqlRepo.js";

export const router = Router();

router.get('/games', async (req: Request, res: Response) => {
    const connection = await getConnection();
    const games = await getGames();
    connection.end();
    res.json(games);
});

router.get('/games/:id', async (req: Request, res: Response) => {
    const connection = await getConnection();
    const gameId = req.params.id ?? '1';
    console.log(`Fetching book with id=${gameId}`);
    const  game:Game|undefined = await getGameById(gameId);
    if(!game){
        res.status(404).send(`Game with id=${gameId} not found`);
        connection.end();
        return;
    }
    res.json(game);
    connection.end();
});
router.delete('/games/:id', async (req: Request, res: Response) => {
    const connection = await getConnection();
    const gameId = req.params.id ?? '1';    
    console.log(`Deleting book with id=${gameId}`);
    const deleted: boolean = await deleteGameById(gameId);
    if(!deleted){
        res.status(404).send(`Book with id=${gameId} not found`);
        connection.end();
        return;
    }   
    res.status(204).send();
    connection.end();
});
router.post('/games', async (req: Request, res: Response) => {
    const connection = await getConnection();
    const newBookData: Game = req.body;
    console.log('Creating new book with data:', newBookData);
    const createdBookId: number = await addGame(newBookData);
    res.status(201).json({ id: createdBookId });
    connection.end();
});
router.put('/games/:id', async (req: Request, res: Response) => {
    const connection = await getConnection();   
    const gameId = req.params.id ?? '1'; 
    const updateData: Game = req.body;
    updateData.id = parseInt(gameId);
    console.log(`Updating book with id=${gameId} with data:`, updateData);
    const result: boolean = await updateGame( updateData);
    if(!result){
        res.status(404).send(`Book with id=${gameId} not found`);
        connection.end();
        return;
    }   
    res.json(updateData);
    connection.end();
});