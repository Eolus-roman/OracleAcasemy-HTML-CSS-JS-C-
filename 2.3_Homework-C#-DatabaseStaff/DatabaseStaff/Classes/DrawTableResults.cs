using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DatabaseStaff
{
    class DrawTableResults : IDrowTable
    {
        public string MakeTableResults(List<Employee> listEmp)
        {
            string sID = "+---+";
            string sAlias = "----------------+";
            string sName = "------------------+";
            string sSurname = "---------------------+";
            string sDepartment = "------------------------+";
            string sPosition = "--------------------------+";
            string s = sID + sAlias + sName + sSurname + sDepartment + sPosition;
            string header = "| № |   Псевдоним    |       Имя        |       Фамилия       |         Отдел          |          Должность       |";
            string table = s + "\n" + header + "\n" + s + "\n";
            
            for (int i = 0; i < listEmp.Count; i++)
            {
                string id = (i+1).ToString();
                string alias = listEmp[i].Alias;
                string name = listEmp[i].Name;
                string surname = listEmp[i].Surname;
                string department = listEmp[i].Department;
                string position = listEmp[i].Position;
                if (id.Length < sID.Length)
                {
                    int num = sID.Length - id.Length;
                    for (int j = 0; j <= num - 3; j++)
                    {
                        id += " ";
                    }
                }
                if (alias.Length < sAlias.Length)
                {
                    int num = sAlias.Length - alias.Length;
                    for (int j = 0; j <= num -2; j++)
                    {
                        alias += " ";
                    }
                }
                if (name.Length < sName.Length)
                {
                    int num = sName.Length - name.Length;
                    for (int j = 0; j <= num - 2; j++)
                    {
                        name += " ";
                    }
                }

                if (surname.Length < sSurname.Length)
                {
                    int num = sSurname.Length - surname.Length;
                    for (int j = 0; j <= num - 2; j++)
                    {
                        surname += " ";
                    }
                }
                if (department.Length < sDepartment.Length)
                {
                    int num = sDepartment.Length - department.Length;
                    for (int j = 0; j <= num - 2; j++)
                    {
                        department += " ";
                    }

                }
                if (position.Length < sPosition.Length)
                {
                    int num = sPosition.Length - position.Length;
                    for (int j = 0; j <= num - 2; j++)
                    {
                        position += " ";
                    }
                }
                string str = "|" + id + "|" + alias + "|" + name + "|" + surname + "|" + department + "|" + position + "|";
                table += str + "\n" + s + "\n";

            }


            return table;
        }
    }
}
