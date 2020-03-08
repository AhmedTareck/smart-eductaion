using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class NotificationDelivary
    {
        public long Id { get; set; }
        public long? NotificationId { get; set; }
        public long? UserId { get; set; }
        public short? Status { get; set; }

        public Notifications Notification { get; set; }
    }
}
