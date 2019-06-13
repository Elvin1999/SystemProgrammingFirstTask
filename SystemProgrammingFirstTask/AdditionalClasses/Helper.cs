using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemProgrammingFirstTask.Entities;

namespace SystemProgrammingFirstTask.AdditionalClasses
{
   public class Helper
    {
        public List<EncryptData> EnDatas { get; set; }
        public List<DecryptData> DeDatas { get; set; }

        public void SeriailizeEndatasToJson()
        {

            using (StreamWriter sw = new StreamWriter("configEndata.json"))
            {
                var item = JsonConvert.SerializeObject(EnDatas);
                sw.WriteLine(item);
            }
        }
        public List<EncryptData> DeserializeEnDatasFromJson()
        {
            try
            {
                var context = File.ReadAllText("configEndata.json");
                EnDatas = JsonConvert.DeserializeObject<List<EncryptData>>(context);
            }
            catch (Exception)
            {
            }

            return EnDatas;
        }
    }
}
