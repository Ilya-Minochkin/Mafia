using BusinessLayer.Interfaces;

namespace BusinessLayer
{
    public class DataManager
    {
        private IGameRepository _gameRepository;
        private IRecordRepository _recordRepository;
        private IPlayerRepository _playerRepository;

        public DataManager(IGameRepository gameRepository, 
            IRecordRepository recordRepository, 
            IPlayerRepository playerRepository)
        {
            _gameRepository = gameRepository;
            _recordRepository = recordRepository;
            _playerRepository = playerRepository;
        }

        public IGameRepository Games
        {
            get { return _gameRepository; }
        }

        public IRecordRepository Records
        {
            get { return _recordRepository; }
        }

        public IPlayerRepository Players
        {
            get { return _playerRepository; }
        }

    }
}
