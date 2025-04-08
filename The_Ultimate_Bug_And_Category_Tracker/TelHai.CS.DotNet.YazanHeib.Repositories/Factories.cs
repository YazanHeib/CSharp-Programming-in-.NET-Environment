using System;
using TelHai.CS.DotNet.YazanHeib.Repositories.Repositories;


namespace TelHai.CS.DotNet.YazanHeib.Repositories
{

    public enum RepositoryType
    {
        InMemoryMock = 0,
        JsonFile = 1,
        SQL = 2,
        API = 3
    }

    public class Factories
    {

        public Factories() { }

        /// <summary>
        /// Return a Spicfic Repository.
        /// </summary>
        /// <param name="type">the type of the Repository in the enum</param>
        /// <returns>Spicfic Repository</returns>
        /// <exception cref="NotImplementedException"></exception>
        public static IBugRepository GetRepository(RepositoryType type)
        {
            return type switch
            {
                RepositoryType.InMemoryMock => new MockRepository(),
                RepositoryType.JsonFile => new JsonBugRepository(),
                RepositoryType.SQL => new SqlRepository(),
                _ => throw new NotImplementedException()
            };



        }


        public static IBugRepository GetBugRepository<T>() where T : IBugRepository
        {

            if (typeof(T) == typeof(MockRepository))
            {
                return new MockRepository();
            }


            else if (typeof(T) == typeof(SqlRepository))
            {
                return new SqlRepository();
            }

            else if (typeof(T) == typeof(JsonBugRepository))
            {
                return new JsonBugRepository();
            }

            else
            {
                throw new NotImplementedException();
            }

        }


    }
}
