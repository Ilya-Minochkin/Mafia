using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer;
using DataLayer.Entities;
using PresentationLayer.Models;

namespace PresentationLayer.Services
{
    public class PlayerServices
    {
        private DataManager _dataManager;
        private RecordServices _recordServices;

        public PlayerServices(DataManager dataManager)
        {
            _dataManager = dataManager;
            _recordServices = new RecordServices(dataManager);
        }

        public List<PlayerViewModel> GetPlayersList()
        {
            var players = _dataManager.Players.GetAllPlayers();
            var playersList = new List<PlayerViewModel>();
            foreach (var item in players)
            {
                playersList.Add(PlayerDbToViewModel(item.Id));
            }

            return playersList;
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

        public PlayerEditModel CreateNewPlayerEditModel()
        {
            return new PlayerEditModel();
        }
    }
}
