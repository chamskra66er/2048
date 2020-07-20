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
    public class Serializ
    {
        private readonly Gamer _gamer;
        private readonly List<Gamer> _gamers;
        private readonly string path = Environment.CurrentDirectory + @"\gamers.json";
        public Serializ()
        {
            _gamer = new Gamer();
            _gamers = new List<Gamer>();
        }
        public Serializ(List<Gamer> gamers)
        {
            _gamers = gamers;
        }
        public void DataSave(Gamer gamer)
        {
            //string name = gamer.Name;
            //var model = GetAllGamers().Where(x=>x.Name==name);

            var newGamer = new Gamer()
            {
                Name = gamer.Name,
                Score = gamer.Score,
                DateTimes = DateTime.Now
            };

            using (FileStream file = new FileStream(path, FileMode.OpenOrCreate))
            {
                file.Seek(-1, SeekOrigin.End);
                using (StreamWriter writer = new StreamWriter(file))
                {
                    writer.Write(",");
                    writer.WriteAsync(JsonConvert.SerializeObject(newGamer));
                    writer.Write("]");
                }
            }

            //if (model.Count()==0)
            //{
            //    using (FileStream file = new FileStream(path, FileMode.OpenOrCreate))
            //    {
            //        file.Seek(-1, SeekOrigin.End);
            //        using (StreamWriter writer = new StreamWriter(file))
            //        {
            //            writer.Write(",");
            //            writer.WriteAsync(JsonConvert.SerializeObject(gamer));
            //            writer.Write("]");
            //        }
            //    }
            //}
            //else
            //{
            //    var found = GetAllGamers().Find(x => x.Name == name);
            //    found.Score = gamer.Score;

            //    using (FileStream file = new FileStream(path, FileMode.Create))
            //    {
            //        using (StreamWriter writer = new StreamWriter(file))
            //        {
            //            writer.Write("[");
            //            writer.WriteAsync(JsonConvert.SerializeObject(GetAllGamers()));
            //            writer.Write("]");
            //        }
            //    }
            //}

        }
        public List<Gamer> GetAllGamers()
        {
            var model = JsonConvert.DeserializeObject<List<Gamer>>(File.ReadAllText(path));
            //using (StreamReader reader = new StreamReader(path))
            //{
            //    var model = JsonConvert.DeserializeObject<List<Gamer>>(reader.ReadToEnd());
            //    reader.Dispose();
            //    return model;
            //} 
            return model;
        }
        

    }
}
