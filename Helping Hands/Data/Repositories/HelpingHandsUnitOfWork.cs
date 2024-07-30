
using Helping_Hands.Models;

namespace Helping_Hands.Data.Repositories
{
    public class HelpingHandsUnitOfWork : IHelpingHandsUnitOfWork
    {
        private GRP0452HelpingHandsDBContext context { get; set; }

        public HelpingHandsUnitOfWork(GRP0452HelpingHandsDBContext ctx) => context = ctx;

        private Repository<Nurses> nurseData;
        public Repository<Nurses> Nurses
        {
            get
            {
                if (nurseData == null)
                    nurseData = new Repository<Nurses>(context);
                return nurseData;
            }
        }


        private Repository<Managers> managerData;
        public Repository<Managers> Managers
        {
            get
            {
                if (managerData == null)
                    managerData = new Repository<Managers>(context);
                return managerData;
            }
        }


        private Repository<CareContracts> carecontractsData;
        public Repository<CareContracts> CareContracts
        {
            get
            {
                if (carecontractsData == null)
                    carecontractsData = new Repository<CareContracts>(context);
                return carecontractsData;
            }
        }

        private Repository<PreferedSuburbs> PreferedSubData;
        public Repository<PreferedSuburbs> PreferedSub
        {
            get
            {
                if (PreferedSubData == null)
                    PreferedSubData = new Repository<PreferedSuburbs>(context);
                return PreferedSubData;
            }
        }

        private Repository<Suburbs> suburbData;
        public Repository<Suburbs> Suburb
        {
            get
            {
                if (suburbData == null)
                    suburbData = new Repository<Suburbs>(context);
                return suburbData;
            }
        }

        private Repository<CareVisits> CareVisitData;
        public Repository<CareVisits> CareVisits
        {
            get
            {
                if (CareVisitData == null)
                    CareVisitData = new Repository<CareVisits>(context);

                return CareVisitData;
            }
        }

        private Repository<Patients> PatientData;
        public Repository<Patients> Patients
        {
            get
            {
                if (PatientData == null)
                    PatientData = new Repository<Patients>(context);
                return PatientData;
            }
        }

        private Repository<Cities> CitiesData;
        public Repository<Cities> Cities
        {
            get
            {
                if (CitiesData == null)
                    CitiesData = new Repository<Cities>(context);
                return CitiesData;
            }
        }

        private Repository<Provinces> ProvincesData;
        public Repository<Provinces> Provinces
        {
            get
            {
                if (ProvincesData == null)
                    ProvincesData = new Repository<Provinces>(context);
                return ProvincesData;
            }
        }

        private Repository<ChronicAccoms> ChronicAccomData;
        public Repository<ChronicAccoms> ChronicAccoms
        {
            get
            {
                if (ChronicAccomData == null)
                {
                    ChronicAccomData = new Repository<ChronicAccoms>(context);
                }
                return ChronicAccomData;
            }
        }

        private Repository<ChronicInfections> ChronicInfectionsData;
        public Repository<ChronicInfections> ChronicInfections
        {
            get
            {
                if (ChronicInfectionsData == null)
                {
                    ChronicInfectionsData = new Repository<ChronicInfections>(context);
                }

                return ChronicInfectionsData;
            }
        }

        public void Save() => context.SaveChanges();
    }
}