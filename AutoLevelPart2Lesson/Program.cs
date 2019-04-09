using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data;
using System.Configuration;

namespace AutoLevelPart2Lesson
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Подготовка подключения и запросов select для таблиц
            var providerName = ConfigurationManager.ConnectionStrings["appConnection"].ProviderName;
            var connectionString = ConfigurationManager.ConnectionStrings["appConnection"].ConnectionString;

            var factory = DbProviderFactories.GetFactory(providerName);
            var connection = factory.CreateConnection();
            var selectUsersCommand = connection.CreateCommand();

            connection.ConnectionString = connectionString;
            selectUsersCommand.CommandText = "select * from Users";
            #endregion

            var dataSet = new DataSet("app");

            var usersAdapter = factory.CreateDataAdapter();
            usersAdapter.SelectCommand = selectUsersCommand;

            var usersCommandBuilder = factory.CreateCommandBuilder();
            usersCommandBuilder.DataAdapter = usersAdapter;

            usersAdapter.Fill(dataSet, "Users");

            List<User> users = new List<User>();
            for (int i = 0; i < dataSet.Tables["Users"].Rows.Count; i++)
            {
                users.Add(new User
                {
                    Id = (int)dataSet.Tables["Users"].Rows[i]["Id"],
                    Login = dataSet.Tables["Users"].Rows[i]["Login"].ToString(),
                    Password = dataSet.Tables["Users"].Rows[i]["Password"].ToString()
                });
            }

            // 0 - индекс для простого теста
            var firstRow = dataSet.Tables["Users"].Rows[0];
            firstRow.BeginEdit();
            firstRow.ItemArray = new object[] { users[0].Id, "root", "123123" };
            firstRow.EndEdit();

            usersAdapter.Update(dataSet, "Users");

            connection.Dispose();
        }
    }
}