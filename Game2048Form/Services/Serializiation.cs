using Game2048Form.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;

namespace Game2048Form.Services
{
    public class Serializiation
    {
        private readonly Gamer _gamer;
        private readonly List<Gamer> _gamers;
        private readonly string path = Environment.CurrentDirectory + @"\gamers.json";
        public Serializiation()
        {
            _gamer = new Gamer();
            _gamers = new List<Gamer>();
        }
        public Serializiation(List<Gamer> gamers)
        {
            _gamers = gamers;
        }
        public void DataSave(Gamer gamer)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(gamer));
        }
        public List<Gamer> GetAllGamers()
        {
            var model = JsonConvert.DeserializeObject<List<Gamer>>(File.ReadAllText(path));
            return model;
        }

    }
}
