using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;

namespace Bolnica
{
    public class SQLConnect
    {
        private static SqlConnection myConnection = new SqlConnection(@"Server=Huawei-MateBookD15\SQLEXPRESS;Initial Catalog=Bolnica;Integrated Security=True;");

        public class Pacient
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public DateTime Birthday { get; set; }
            public string Polis {  get; set; }
        }
        /// <summary>
        /// Данные о приеме
        /// </summary>
        public class Priem
        {
            public int Id { get; set; }
            public string Napravlenie { get; set; }
            public DateTime DataPriema { get; set; }
            public string ProfileDoctor { get; set; }
            public string NameDoctor { get; set; }
            public string SurnameDoctor { get; set; }
            public string Zacluchenie { get; set; }
            public int Id_Pacient { get; set; }
        }
        public class PriemData
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Napravlenie { get; set; }
            public string Zacluchenie { get; set; }
        }
        static public bool GetPriemData(List<PriemData> priemData)
        {
            try
            {
                myConnection.Open();
                string sqlQ = @"select Pacient.[Name], Pacient.Surname, Zacluchenie, Napravlenie from pacient join priem on pacient.id = priem.id_pacient";
                SqlCommand sqlCmd = new SqlCommand(sqlQ, myConnection);
                SqlDataReader dr = sqlCmd.ExecuteReader();
                
                while(dr.Read())
                {
                    MainWindow.priemData.Add(
                        new PriemData()
                        { 
                            Name = dr[0].ToString(),
                            Surname = dr[1].ToString(),
                            Napravlenie = dr[2].ToString(),
                            Zacluchenie = dr[3].ToString()
                        });
                }
                myConnection.Close();
                return true;
            }
            catch
            {
                
            }
            return false;
        }
    }
}
