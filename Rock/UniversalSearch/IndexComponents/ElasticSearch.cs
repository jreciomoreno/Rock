using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rock.Attribute;

namespace Rock.UniversalSearch.IndexComponents
{
    [Description( "ElasticSearch Universal Search Index" )]
    [Export( typeof( IndexComponent ) )]
    [ExportMetadata( "ComponentName", "ElasticSearch" )]

    [TextField( "Node Url", "The URL of the ElasticSearch node (http://myserver:9200)", true)]
    public class ElasticSearch : IndexComponent
    {
    }
}
