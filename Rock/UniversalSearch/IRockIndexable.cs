using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rock.UniversalSearch.IndexModels;

namespace Rock.UniversalSearch
{
    interface IRockIndexable
    {
        IEnumerable<IndexModelBase> BulkIndexItems();
    }
}
