using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rock.Model;

namespace Rock.UniversalSearch.IndexModels
{
    public class ContentChannelItemIndex : IndexModelBase
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int ContentChannelId { get; set; }
        public int Priority { get; set; }
        public string Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public string Permalink { get; set; }
        public bool IsApproved { get; set; }

        public override string IconCssClass
        {
            get
            {
                return iconCssClass;
            }
            set
            {
                iconCssClass = value;
            }
        }
        private string iconCssClass = "fa fa-bullhorn";

        public static ContentChannelItemIndex LoadByModel(ContentChannelItem contentChannelItem )
        {
            var contentChannelItemIndex = new ContentChannelItemIndex();
            contentChannelItemIndex.SourceIndexModel = "Rock.Model.ContentChannel";

            contentChannelItemIndex.Id = contentChannelItem.Id;
            contentChannelItemIndex.Title = contentChannelItem.Title;
            contentChannelItemIndex.Content = contentChannelItem.Content;
            contentChannelItemIndex.ContentChannelId = contentChannelItem.ContentChannelId;
            contentChannelItemIndex.Priority = contentChannelItem.Priority;
            contentChannelItemIndex.Status = contentChannelItem.Status.ToString();
            contentChannelItemIndex.StartDate = contentChannelItem.StartDateTime;
            contentChannelItemIndex.ExpireDate = contentChannelItem.ExpireDateTime;
            contentChannelItemIndex.Permalink = contentChannelItem.Permalink;
            contentChannelItemIndex.IconCssClass = string.IsNullOrWhiteSpace( contentChannelItem.ContentChannel.IconCssClass ) ? "fa fa-bullhorn" : contentChannelItem.ContentChannel.IconCssClass;
            contentChannelItemIndex.IsApproved = false;

            if ( contentChannelItem.ContentChannel != null && contentChannelItem.ContentChannel.RequiresApproval && contentChannelItem.ApprovedDateTime != null )
            {
                contentChannelItemIndex.IsApproved = true;
            }

            AddIndexableAttributes( contentChannelItemIndex, contentChannelItem );

            return contentChannelItemIndex;
        }

        /// <summary>
        /// Formats the search result.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public override string FormatSearchResult( Dictionary<string, object> displayOptions = null )
        {
            bool showSummary = true;
            string url = "/page/344?contentItemId=";

            if ( displayOptions != null )
            {
                if ( displayOptions.ContainsKey( "ChannelItem.ShowSummary" ) )
                {
                    showSummary = displayOptions["ChannelItem.ShowSummary"].ToString().AsBoolean();
                }
                if ( displayOptions.ContainsKey( "ChannelItem.Url" ) )
                {
                    url = displayOptions["ChannelItem.Url"].ToString();
                }
            }

            string result =  string.Format( "<a href='{0}{1}'>{2}</a>", url, this.Id, this.Title );                        

            if (showSummary && this["Summary"] != null )
            {
                result += "<br />" + this["Summary"];
            }

            return result;
        }
    }
}
