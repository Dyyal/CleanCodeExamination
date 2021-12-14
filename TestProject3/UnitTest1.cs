using CleanCodeExamination.Data;
using CleanCodeExamination.Data.Entities;
using CleanCodeExamination.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace TestProject3
{
    public class Tests
    {
        private static DbContextOptions<Context> dbContextOptions = new DbContextOptionsBuilder<Context>()
            .UseInMemoryDatabase("MooGameTest")
            .Options;

        Context context;

        IGameInterface game;
        IUserInterface ui;
        IPlayerInterface player;

        [OneTimeSetUp]
        public void Setup()
        {
            context = new Context(dbContextOptions);
            context.Database.EnsureCreated();

            ui = new ConsoleIO();
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
            string guess = "4479";
            string bullsAndCows = game.CheckBullsAndCows(target, guess);
            Assert.AreEqual("BBB,C", bullsAndCows);
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
        public void TestCreatePlayer()
        {
            var playerName = "Keko";
            player.CreatePlayer(playerName);

            var newPlayer = context.Players.FirstOrDefault(p => p.Name == playerName);
            Assert.AreEqual(playerName, newPlayer.Name);
        }

        [Test]
        public void TestCreateScore()
        {
            var playerName = "Keko";
            var newPlayer = context.Players.FirstOrDefault(p => p.Name == playerName);
            int guesses = 2;
            player.UpdatePlayerScore(playerName, guesses);

            Assert.AreEqual(2, newPlayer.Score.Guesses);
        }

        [Test]
        public void TestUpdateScore()
        {
            var playerName = "Keko";
            var newPlayer = context.Players.FirstOrDefault(p => p.Name == playerName);
            int guesses = 4;
            player.UpdatePlayerScore(playerName, guesses);

            Assert.AreEqual(6, newPlayer.Score.Guesses);
        }
    }
}