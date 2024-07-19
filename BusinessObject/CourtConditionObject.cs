using DataAccess.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class CourtConditionObject
    {
        private readonly ICourtConditionRepository courtConditionRepository;

        public CourtConditionObject()
        {
            this.courtConditionRepository = new CourtConditionRepository();
        }
        public void Insert(CourtCondition cc) => courtConditionRepository.Insert(cc);
    }
}
