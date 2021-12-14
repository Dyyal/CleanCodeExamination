//using CleanCodeExamination.Controllers;
//using CleanCodeExamination.Data;
//using CleanCodeExamination.Data.Entities;
//using CleanCodeExamination.Services;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System;
//using System.Collections.Generic;
//using System.IO;

//namespace TestProject1
//{
//    [TestClass]
//    public class UnitTest1
//    {
//        GameService game;
//        MockUI ui;
//        IPlayerInterface player;
//        PlayerService playerService;
//        Context context;

//        [TestInitialize]
//        public void Init()
//        {
//            game = new(ui, player);
            
//        }

//        [TestMethod]
//        public void DB()
//        {
//            SetUp();
//            game = new(ui, player);
//            //player = new PlayerService(context, ui);
//        }

//        //private void PopulateDB(Context context)
//        //{
//        //    Player player = new Player()
//        //    {
//        //        Id = Guid.NewGuid().ToString(),
//        //        Name = "Keko"
//        //    };
//        //    Score score = new Score()
//        //    {
//        //        ScoreId = Guid.NewGuid().ToString(),
//        //        RoundsPlayed = 1,
//        //        Guesses = 1,
//        //        Average = 1.0,
//        //        PlayerId = player.Id
//        //    };

//        //    context.Add(player);
//        //    context.Add(score);
//        //    context.Database.EnsureCreated();
//        //    context.SaveChanges();
//        //}
//        private void SetUp()
//        {
//            var options = new DbContextOptionsBuilder<Context>()
//                .UseInMemoryDatabase("MooTest.db");

//            context = new Context(options.Options);

//            //PopulateDB(context);
//            player = new PlayerService(context, ui);

//        }

//        [TestMethod]
//        public void TestGuessAndTarget()
//        {
//            string target = "4579";
//            string guess = "4479";
//            string bullsAndCows = game.CheckBullsAndCows(target, guess);
//            Assert.AreEqual("BBB,C", bullsAndCows);
//            guess = "4087";
//            bullsAndCows = game.CheckBullsAndCows(target, guess);
//            Assert.AreEqual("B,C", bullsAndCows);
//            guess = "4579";
//            bullsAndCows = game.CheckBullsAndCows(target, guess);
//            Assert.AreEqual("BBBB,", bullsAndCows);
//        }

//        [TestMethod]
//        public void TestTargetCreator()
//        {
//            var target = game.CreateTargetNumber();
//            Assert.IsNotNull(target);
//            Assert.AreEqual(4, target.Length);
//        }

//        [TestMethod]
//        public void Test()
//        {
//            //Player player = PlayerFactory.CreatePlayer();
//            //player.Name = "Keko";

//            var playerName = "Keko";
//            playerService.CreatePlayer(playerName);
//            var newPlayer = context.Players.FirstOrDefaultAsync(x => x.Name == playerName);
//            Assert.AreEqual(playerName, newPlayer);
//            context.Database.EnsureDeleted();
//        }

//        //[TestMethod]
//        //public void TestEndOrNewGame()
//        //{
//        //    string answer = "y";
//        //    game.EndOrRestartGame(answer);
//        //    Assert.AreEqual(answer, game.PlayGame(true));
//        //    answer = "n";
//        //    game.EndOrRestartGame(answer);
//        //    Assert.AreEqual(answer, game.PlayGame(false));
//        //}
//    }

//    public class MockUI : IUserInterface
//    {
//        public void Exit()
//        {
//            throw new System.NotImplementedException();
//        }

//        public string Input()
//        {
//            throw new System.NotImplementedException();
//        }

//        public void Output(string text, bool newLine = true)
//        {
//            throw new System.NotImplementedException();
//        }
//    }
//}