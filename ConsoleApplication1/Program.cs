using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Data.SQLite;
using System.Data;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new WebReference.ImportDataService();
            //string str = s.UpdateLayerState("acv", "qqqq", 1, "sdaas");
            //string str = s.QueryLayer("qqqq", -1, "");
            //List<Person> list = new List<Person>() {
            //    new Person() { age=1,name="jack"},
            //    new Person() { age=2,name="panda"}
            //};

            //string str = JsonConvert.SerializeObject(list);
            //List<Person> l = JsonConvert.DeserializeObject<List<Person>>(str);
            //var list = new List<UploadMsgEntity>() {
            //    new UploadMsgEntity()
            //{
            //    RYNAME = "123",
            //    FILENAME = "123",
            //    XZQDM = "123",
            //    HCTBNAME = "123",
            //    HCTBGS = "123",
            //    TBZS = "123",
            //    ENCODE = "123"
            //},
            //    new UploadMsgEntity()
            //{
            //    RYNAME = "124",
            //    FILENAME = "124",
            //    XZQDM = "124",
            //    HCTBNAME = "124",
            //    HCTBGS = "124",
            //    TBZS = "124",
            //    ENCODE = "124"
            //}
            //};
            //string str = JsonConvert.SerializeObject(list);
            //s.Uploadattachmsg(str);
            //var l = new ReceiveEntity() {
            //    XZQDM= "110112",
            //    FILENAME= "HCRW_201705071525135435036.hcdb",
            //    BSM= "4594",
            //    RYNAME= "测试"

            //};
            //var list = new List<ReceiveEntity>();
            //list.Add(l);
            //var data=s.ReceiveDatas(new WebReference.ReceiveEntity[] {
            //    new WebReference.ReceiveEntity() {
            //    XZQDM = "130602",
            //    FILENAME = "HCRW.db",
            //    BSM = "4594",
            //    RYNAME = "测试"
            //    }
            //});
            //Console.ReadKey();
            if (System.IO.File.Exists(@"F:\1\HCRW_201705191057338145445.hcdb"))
            {
                string conn= "Data Source=F:\\1\\HCRW_201705191057338145445.hcdb";

                using (SQLiteConnection cnn = new SQLiteConnection(conn))
                {
                    string sql = "select * from wyhcfj";
                    SQLiteCommand cmd = new SQLiteCommand(sql, cnn);
                    SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
                    var dt = new DataTable();
                    sda.Fill(dt);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Console.WriteLine(dt.Rows[i].ToString()); 
                    }
                }
            }
            Console.ReadKey();
        }

        private static void EventFunction(string name)
        {
            if (name == "123")
            {
                Console.WriteLine("Helloword");
            }
        }

    }
    public class Person
    {
        public int age { get; set; }
        public string name { get; set; }
    }
    public class UploadMsgEntity
    {
        public string RYNAME { get; set; }
        public string FILENAME { get; set; }
        public string XZQDM { get; set; }
        public string HCTBNAME { get; set; }
        public string HCTBGS { get; set; }
        public string TBZS { get; set; }
        public string ENCODE { get; set; }
    }
    //public class ReceiveEntity
    //{
    //    public string XZQDM { get; set; }
    //    public string FILENAME { get; set; }
    //    public string BSM { get; set; }
    //    public string RYNAME { get; set; }
    //}
}
