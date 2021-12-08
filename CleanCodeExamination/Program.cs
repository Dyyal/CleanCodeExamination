//// See https://aka.ms/new-console-template for more information


IUserInterface ui = new ConsoleIO();
var database = new Context();
Player player = new();
PlayerService playerService = new(database, ui, player);
GameService game = new(ui, playerService, player);
GameController gameController = new(game);
gameController.RunGame();
