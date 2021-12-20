namespace TestProject3;

public class Tests
{
    private static DbContextOptions<Context> dbContextOptions = new DbContextOptionsBuilder<Context>()
        .UseInMemoryDatabase("MooGameTest")
        .Options;

    Context context;

    MockIU ui;
    IGameInterface game;
    IPlayerInterface player;

    [OneTimeSetUp]
    public void Setup()
    {
        context = new Context(dbContextOptions);
        context.Database.EnsureCreated();

        ui = new();
        player = new PlayerService(context, ui);
        game = new GameService(ui, player);
    }

    [OneTimeTearDown]
    public void CleanUp()
    {
        context.Database.EnsureDeleted();
    }

    [Test]
    public void TestGuessAndTarget()
    {
        string target = "4579";
        string guess = "4379";
        string bullsAndCows = game.CheckBullsAndCows(target, guess);

        Assert.AreEqual("BBB,", bullsAndCows);

        guess = "4087";
        bullsAndCows = game.CheckBullsAndCows(target, guess);

        Assert.AreEqual("B,C", bullsAndCows);

        guess = "4579";
        bullsAndCows = game.CheckBullsAndCows(target, guess);

        Assert.AreEqual("BBBB,", bullsAndCows);
    }

    [Test]
    public void TestTargetCreator()
    {
        var target = game.CreateTargetNumber();

        Assert.IsNotNull(target);
        Assert.AreEqual(4, target.Length);
    }

    [Test]
    public void TestAverageScore()
    {
        Score score = new Score
        {
            Guesses = 6,
            RoundsPlayed = 2
        };
        score.Average = ScoreFactory.Average(score);

        Assert.AreEqual(3, score.Average);
    }

    [Test]
    public void TestCreatePlayer()
    {
        var playerName = "Keko";
        player.CreatePlayer(playerName);
        var newPlayer = context.Players.FirstOrDefault(p => p.Name == playerName);

        Assert.IsNotNull(newPlayer);
        Assert.AreEqual(playerName, newPlayer.Name);
    }

    [Test]
    public void TestCreateScore()
    {
        var playerName = "Keko";
        int guesses = 2;
        player.UpdatePlayerScore(playerName, guesses);
        var playerScore = context.Scores.FirstOrDefault(p => p.Player.Name == playerName);

        Assert.IsNotNull(playerScore);
        Assert.AreEqual(2, playerScore.Guesses);
    }

    [Test]
    public void TestUpdateScore()
    {
        var playerName = "Keko";
        int guesses = 4;
        player.UpdatePlayerScore(playerName, guesses);
        var playerScore = context.Scores.FirstOrDefault(p => p.Player.Name == playerName);

        Assert.IsNotNull(playerScore);
        Assert.AreEqual(6, playerScore.Guesses);
    }

    [Test]
    public void TestGame()
    {
        GameController gameController = new(game);

        gameController.RunGame();

        Assert.IsNotNull(() => gameController.RunGame());
        Assert.DoesNotThrow(() => gameController.RunGame());
        Assert.Contains("BBBB,", ui.outputs);
    }
}

public class MockIU : IUserInterface
{

    public Stack<string> inputs = new();
    public List<string> outputs = new();
    public MockIU()
    {
        inputs.Push("PlayerName");
    }

    string IUserInterface.Input()
    {
        if (GameService.target is not null && !inputs.Contains("n"))
        {
            inputs.Push("n");
            inputs.Push(GameService.target);
        }
        return inputs.Pop();
    }

    void IUserInterface.Output(string text, bool newLine)
    {
        outputs.Add(text);
    }
}
