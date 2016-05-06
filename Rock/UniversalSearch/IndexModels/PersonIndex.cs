using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rock.Model;

namespace Rock.UniversalSearch.IndexModels
{
    public class PersonIndex : IndexModelBase
    {
        public string NameShort { get; set; }
        public string NameLong { get; set; }
        public string RecordStatus { get; set; }

        public override string IconCssClass
        {
            get
            {
                return "fa fa-user";
            }
        }

        public static PersonIndex LoadByModel(Person person )
        {
            var personIndex = new PersonIndex();
            personIndex.SourceIndexModel = "Rock.Model.Person";

            personIndex.Id = person.Id;
            personIndex.NameShort = person.NickName + " " + person.LastName;
            personIndex.NameLong = person.FirstName + " " + person.MiddleName + " " + person.LastName;
            personIndex.RecordStatus = person.RecordStatusValue != null ? person.RecordStatusValue.Value : "Unknown";

            AddIndexableAttributes( personIndex, person );

            return personIndex;
        }

        /// <summary>
        /// Formats the search result.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public override string FormatSearchResult( Dictionary<string, object> displayOptions = null )
        {
            string url = "/Person/";

            if (displayOptions != null )
            {
                if ( displayOptions.ContainsKey( "Person.Url" ) )
                {
                    url = displayOptions["Person.Url"].ToString();
                }
            }

            return string.Format( "<a href='{0}{1}'>{2}</a>", url, this.Id, this.NameShort );
        }
    }
}
