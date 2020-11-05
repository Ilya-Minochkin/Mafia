using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer;
using DataLayer.Entities;
using PresentationLayer.Models;

namespace PresentationLayer.Services
{
    public class RecordServices
    {
        private readonly DataManager _dataManager;

        public RecordServices(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public RecordViewModel RecordDbModelToView(int recordId)
        {
            var rec = new RecordViewModel()
            {
                Record = _dataManager.Records.GetRecordById(recordId)
            };
            return rec;
        }

        public RecordEditModel GetRecordEditModel(int recordId)
        {
            var recDbModel = _dataManager.Records.GetRecordById(recordId);
            var recEditModel = new RecordEditModel()
            {
                GameId = recDbModel.GameId,
                Id = recDbModel.Id,
                PlayerId = recDbModel.PlayerId,
                Result = recDbModel.Result,
                Role = recDbModel.Role
            };
            return recEditModel;
        }

        public RecordViewModel SaveRecordEditModelToDb(RecordEditModel recordEditModel)
        {
            var record = recordEditModel.Id != 0 ? _dataManager.Records.GetRecordById(recordEditModel.Id) : new Record();

            record.GameId = recordEditModel.GameId;
            record.Game = _dataManager.Games.GetGameById(recordEditModel.GameId);
            record.PlayerId = recordEditModel.PlayerId;
            record.Player = _dataManager.Players.GetPlayerById(recordEditModel.PlayerId);
            record.Result = recordEditModel.Result;
            record.Role = recordEditModel.Role;
            _dataManager.Records.SaveRecord(record);

            return RecordDbModelToView(record.Id);
        }

        public RecordEditModel CreateNewRecordEditModel()
        {
            return new RecordEditModel();
        }
    }
}
