using System;

namespace Helping_Hands.Data.Repositories
{
    public class CareContractQueryOptions : QueryOptions<CareContracts>
    {

        public void SortFilter(CareContractGridBuilder builder)
        {
            //if (builder.IsFilterByContractType)
            //{
            //    //  Where = b => b.SuburbID == builder.CurrentRoute.SuburbFilter;
            //    int id = builder.CurrentRoute.ContraTypeFilter.ToInt();
            //    if (id > 0)
            //        Where = b => b.ContractNumberID == id;
            //}

            //if (builder.IsFilterByDate)
            //{

            //    if (builder.CurrentRoute.DateFilter == "7to14")
            //        Where = b => b.Date >= 7 && b.Price <= 14;
            //    else
            //        Where = b => b.Date > 14;
            //}

            if (builder.IsFilterByNurse)
            {
                int id = builder.CurrentRoute.NurseFilter.ToInt();
                if (id > 0)
                    Where = b => b.NurseUserID == id;
            }



            if (builder.IsFilterByContractType)
            {
                if (builder.CurrentRoute.ContraTypeFilter == "Assigned")
                    Where = b => b.Status == "Assigned";
                else if (builder.CurrentRoute.ContraTypeFilter == "Closed")
                    Where = b => b.Status == "Closed";
                else
                    Where = b => b.Status == "New";

            }

            if (builder.IsFilterByPatient)
            {

                int id = builder.CurrentRoute.PatientFilter.ToInt();
                if (id > 0)
                    Where = b => b.PatientUserID == id;
            }

            if (builder.IsFilterByPeriod)
            {
                if (builder.CurrentRoute.PeriodFilter == "Week")
                {
                    DateTime filt = DateTime.Today;

                    Where = b => b.ContractDate >= filt.AddDays(-7) && b.ContractDate <= DateTime.Today;
                }

                if (builder.CurrentRoute.PeriodFilter == "Month")
                {
                    DateTime filt = DateTime.Today;
                    Where = x => x.ContractDate >= filt.AddDays(-30) && x.ContractDate <= DateTime.Today;
                }
            }

            //if (builder.IsSortBySuburb)
            //{
            //    OrderBy = b => b.Suburbs.Name;
            //}
            if (builder.IsSortBy)
            {
                int id = builder.CurrentRoute.NurseFilter.ToInt();
                OrderBy = b => b.NurseUserID;
            }

        }
    }
}
