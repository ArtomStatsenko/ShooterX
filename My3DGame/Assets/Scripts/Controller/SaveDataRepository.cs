using System.IO;
using UnityEngine;


namespace StatsenkoAA
{
    public sealed class SaveDataRepository
    {
        private const string FOLDER_NAME = "Saves";
        private const string FILE_NAME = "data.bat";
        private const string PLAYER_NAME = "Player";
        private readonly IData<SerializableGameObject> _data;
        private readonly string _path;

        public SaveDataRepository()
        {
            if (Application.platform == RuntimePlatform.WebGLPlayer)
            {
                _data = new PlayerPrefsData();
            }
            else
            {
                _data = new XMLData();
            }
            _path = Path.Combine(Application.dataPath, FOLDER_NAME);

        }

        public void Save()
        {
            if (!Directory.Exists(Path.Combine(_path)))
            {
                Directory.CreateDirectory(_path);
            }
            var player = new SerializableGameObject
            {
                Position = UnitMotor.Instance.InstanceObject.position,
                Name = PLAYER_NAME,
                IsEnable = true
            };

            _data.Save(player, Path.Combine(_path, FILE_NAME));
        }

        public void Load()
        {
            var file = Path.Combine(_path, FILE_NAME);
            if (!File.Exists(file)) return;
            var newPlayer = _data.Load(file);
            UnitMotor.Instance.InstanceObject.position = newPlayer.Position;
            UnitMotor.Instance.InstanceObject.name = newPlayer.Name;
            UnitMotor.Instance.InstanceObject.gameObject.SetActive(newPlayer.IsEnable);

            Debug.Log(newPlayer);
        }
    }
}
