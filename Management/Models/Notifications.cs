using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class Notifications
    {
        public Notifications()
        {
            NotificationDelivary = new HashSet<NotificationDelivary>();
        }

        public long Id { get; set; }
        public string Notification { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public short? Status { get; set; }

        public ICollection<NotificationDelivary> NotificationDelivary { get; set; }
    }
}
