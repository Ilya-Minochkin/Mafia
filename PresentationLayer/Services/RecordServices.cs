using BusinessLayer;
using DataLayer.Entities;
using DataLayer.Enums;
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
                Record = _dataManager.Records.GetRecordById(recordId),
            };
            rec.Result = GetResultString(rec.Record.Result);
            rec.Role = GetRoleString(rec.Record.Role);
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
            Record record;

            if (recordEditModel.Id != 0)
            {
                record = _dataManager.Records.GetRecordById(recordEditModel.Id);
            }
            else
            {
                record = new Record();
            }

            record.GameId = recordEditModel.GameId;
            record.Game = _dataManager.Games.GetGameById(recordEditModel.GameId);
            record.PlayerId = recordEditModel.PlayerId;
            //record.Player = _dataManager.Players.GetPlayerById(recordEditModel.PlayerId);
            record.Result = recordEditModel.Result;
            record.Role = recordEditModel.Role;
            _dataManager.Records.SaveRecord(record);

            return RecordDbModelToView(record.Id);
        }

        public RecordEditModel CreateNewRecordEditModel()
        {
            return new RecordEditModel();
        }

        private string GetResultString(int result)
        {
            var viewResult = result switch
            {
                1 => "Победа",
                0 => "Поражение",
                -1 => "Ведущий",
                _ => "Неопределено"
            };

            return viewResult;
        }

        private string GetRoleString(RolesEnum.Role role)
        {
            var viewRole = role switch
            {
                RolesEnum.Role.Don => "Дон мафии",
                RolesEnum.Role.Host => "Ведущий",
                RolesEnum.Role.Innocent => "Мирный житель",
                RolesEnum.Role.Mafia => "Мафия",
                RolesEnum.Role.Sheriff => "Шериф",
                _ => "Неопределено"
            };

            return viewRole;
        }
    }
}

