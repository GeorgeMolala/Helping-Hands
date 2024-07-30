namespace Helping_Hands.Data.Repositories
{
    public interface IHelpingHandsUnitOfWork
    {
        Repository<Nurses> Nurses { get; }
        Repository<Suburbs> Suburb { get; }
        Repository<CareContracts> CareContracts { get; }

        Repository<Provinces> Provinces { get; }
        Repository<Cities> Cities { get; }

        Repository<CareVisits> CareVisits { get; }

        //  Repository<BookAuthor> BookAuthors { get; }
        // Repository<Genre> Genres { get; }

        //void DeleteCurrentBookAuthors(Nurses Nurse);
        //void AddNewBookAuthors(Nurses Nurse, int[] authorids);
        void Save();
    }
}
