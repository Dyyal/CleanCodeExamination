var database = new Context();
IUserInterface ui = new ConsoleIO();
IPlayerInterface player = new PlayerService(database, ui);
IGameInterface game = new GameService(ui, player);
GameController gameController = new(game);
gameController.RunGame();