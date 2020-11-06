using System;
using BusinessLayer;
using PresentationLayer.Services;

namespace PresentationLayer
{
    public class ServicesManager
    {
        private GameServices _gameServices;
        private PlayerServices _playerServices;
        private RecordServices _recordServices;
        private DataManager _dataManager;
        public ServicesManager(DataManager dataManager)
        {
            _dataManager = dataManager;
            _gameServices = new GameServices(dataManager);
            _playerServices = new PlayerServices(dataManager);
            _recordServices = new RecordServices(dataManager);
        }


        public GameServices Games
        {
            get { return _gameServices; }
        }
        public PlayerServices Players
        {
            get { return _playerServices; }
        }
        public RecordServices Records
        {
            get { return _recordServices; }
        }

    }
}
