using Helping_Hands.Data.GRID;
using System;


namespace Helping_Hands.Data.Repositories
{
    public class CareVisitQueryOptions : QueryOptions<CareVisits>
    {
        Helping_Hands.GRP0452HelpingHandsDBContext _context;



        public void her()
        {

        }
        public void SortFilter(CareVisitGridBuilder builder)
        {

            ///Filter Section
            if (builder.IsFilterByVisitStatus)
            {
                if (builder.CurrentRoute.VisitStatusFilter == "Open")
                {
                    Where = b => b.Status == "Open";
                }
                if (builder.CurrentRoute.VisitStatusFilter == "Closed")
                {
                    Where = b => b.Status == "Closed";
                }

            }

            //if (builder.IsFilterByNurse)
            //{

            //    int id = builder.CurrentRoute.NurseFilter.ToInt();
            //    if (id > 0)
            //        Where = b => b.NurseUserID == id;
            //}

            if (builder.IsFilterByPeriod)
            {
                if (builder.CurrentRoute.PeriodFilter == "Week")
                {
                    DateTime filt = DateTime.Today;

                    Where = b => b.VisitDate >= filt.AddDays(-7) && b.VisitDate <= DateTime.Today;
                }

                if (builder.CurrentRoute.PeriodFilter == "Month")
                {
                    DateTime filt = DateTime.Today;
                    Where = x => x.VisitDate >= filt.AddDays(-30) && x.VisitDate <= DateTime.Today;
                }
            }

            if (builder.IsFilterByContractDate)
            {
                int id = builder.CurrentRoute.ContractDateFilter.ToInt();
                if (id > 0)
                    Where = b => b.ContractNumberID == id;

               

            }

            //Testing

            if (builder.IsSortBy)
            {
                int id = builder.CurrentRoute.ContractDateFilter.ToInt();
                OrderBy = b => b.VisitDate;
            }
        }

    }
}
