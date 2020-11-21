using BusinessLayer;
using DataLayer.Entities;
using PresentationLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace PresentationLayer.Services
{
    public class PlayerServices
    {
        private readonly DataManager _dataManager;
        private readonly RecordServices _recordServices;

        public PlayerServices(DataManager dataManager)
        {
            _dataManager = dataManager;
            _recordServices = new RecordServices(dataManager);
        }

        public List<PlayerViewModel> GetPlayersList()
        {
            var players = _dataManager.Players.GetAllPlayers();

            return players.Select(item => PlayerDbToViewModel(item.Id)).ToList();
        }


        public PlayerViewModel PlayerDbToViewModel(int playerId)
        {
            var playerDb = _dataManager.Players.GetPlayerById(playerId);
            var playerRecordsViewModels = new List<RecordViewModel>();
            foreach (var item in playerDb.PlayerRecords)
            {
                {
                    playerRecordsViewModels.Add(_recordServices.RecordDbModelToView(item.Id));
                }
            }

            return new PlayerViewModel() {Player = playerDb, PlayerRecords = playerRecordsViewModels};
        }

        public PlayerViewModel SavePlayerEditModelToDb(PlayerEditModel playerEditModel)
        {
            var dbModel = playerEditModel.Id != 0
                ? _dataManager.Players.GetPlayerById(playerEditModel.Id)
                : new Player();
            dbModel.Name = playerEditModel.Name;
            dbModel.NickName = playerEditModel.NickName;
            _dataManager.Players.SavePlayer(dbModel);
            return PlayerDbToViewModel(dbModel.Id);
        }


        public PlayerEditModel GetPlayerEditModel(int playerId)
        {
            PlayerEditModel playerEditModel;
            if (playerId != 0)
            {
                var playerDb = _dataManager.Players.GetPlayerById(playerId);
                playerEditModel = new PlayerEditModel()
                {
                    Id = playerDb.Id,
                    Name = playerDb.Name,
                    NickName = playerDb.NickName
                };

            }
            else
            {
                playerEditModel = CreateNewPlayerEditModel();
            }
            return playerEditModel;
        }

        public void DeletePlayer(PlayerViewModel model)
        {
            if (model.Player.Id != 0)
            {
                var dbModel = _dataManager.Players.GetPlayerById(model.Player.Id);
                _dataManager.Players.DeletePlayer(dbModel);
            }
        }

        public RecordEditModel AddNewRecord(PlayerViewModel model)
        {
            var rec = _recordServices.CreateNewRecordEditModel();
            rec.PlayerId = model.Player.Id;
            model.PlayerRecordEditModels.Add(rec);
            return rec;
        }

        public PlayerEditModel CreateNewPlayerEditModel()
        {
            return new PlayerEditModel();
        }
    }
}
