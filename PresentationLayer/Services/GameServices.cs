using BusinessLayer;
using DataLayer.Entities;
using PresentationLayer.Models;
using System.Collections.Generic;

namespace PresentationLayer.Services
{
    public class GameServices
    {
        private readonly DataManager _dataManager;
        private readonly RecordServices _recordServices;

        public GameServices(DataManager dataManager)
        {
            _dataManager = dataManager;
            _recordServices = new RecordServices(dataManager);
        }

        public List<GameViewModel> GetGamesList()
        {
            var games = _dataManager.Games.GetAllGames();
            var gamesList = new List<GameViewModel>();
            foreach (var item in games)
            {
                gamesList.Add(GameDbToViewModel(item.Id));
            }

            return gamesList;
        }

        public GameViewModel GameDbToViewModel(int gameId)
        {
            var game = _dataManager.Games.GetGameById(gameId);
            var gameRecordsViewModels = new List<RecordViewModel>();

            foreach (var gameRecord in game.GameRecords)
            {
                gameRecordsViewModels.Add(_recordServices.RecordDbModelToView(gameRecord.Id));
            }

            return new GameViewModel() {Game = game, GameRecords = gameRecordsViewModels};
        }


        public GameEditModel GetGameEditModel(int gameId)
        {
            
            GameEditModel gameEditModel;
            if (gameId != 0)
            {
                var dbModel = _dataManager.Games.GetGameById(gameId);
                gameEditModel = new GameEditModel()
                {
                    Id = dbModel.Id,
                    Date = dbModel.Date,
                    NumberOfPlayer = dbModel.NumberOfPlayer
                };
            }
            else
            {
                gameEditModel = CreateNewGameEditModel();
            }
            return gameEditModel;
        }

        public GameViewModel SaveGameEditModelToDb(GameEditModel gameEditModel)
        {
            var game = gameEditModel.Id != 0 ? _dataManager.Games.GetGameById(gameEditModel.Id) : new Game();
            game.Date = gameEditModel.Date;
            game.NumberOfPlayer = gameEditModel.NumberOfPlayer;
            

            _dataManager.Games.SaveGame(game);

            return GameDbToViewModel(game.Id);
        }

        public GameEditModel CreateNewGameEditModel()
        {
            return new GameEditModel();
        }
    }
}
