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

        public static ContentChannelItemIndex LoadByModel(ContentChannelItem contentChannelItem )
        {
            var contentChannelItemIndex = new ContentChannelItemIndex();

            contentChannelItemIndex.Id = contentChannelItem.Id;
            contentChannelItemIndex.Title = contentChannelItem.Title;
            contentChannelItemIndex.Content = contentChannelItem.Content;
            contentChannelItemIndex.ContentChannelId = contentChannelItem.ContentChannelId;
            contentChannelItemIndex.Priority = contentChannelItem.Priority;
            contentChannelItemIndex.Status = contentChannelItem.Status.ToString();
            contentChannelItemIndex.StartDate = contentChannelItem.StartDateTime;
            contentChannelItemIndex.ExpireDate = contentChannelItem.ExpireDateTime;
            contentChannelItemIndex.Permalink = contentChannelItem.Permalink;
            contentChannelItemIndex.IsApproved = false;

            if ( contentChannelItem.ContentChannel != null && contentChannelItem.ContentChannel.RequiresApproval && contentChannelItem.ApprovedDateTime != null )
            {
                contentChannelItemIndex.IsApproved = true;
            }

            AddIndexableAttributes( contentChannelItemIndex, contentChannelItem );

            return contentChannelItemIndex;
        }
    }
}
