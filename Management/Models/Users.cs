﻿using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class Users
    {
        public Users()
        {
            Attachments = new HashSet<Attachments>();
            Conversations = new HashSet<Conversations>();
            MessageTypeCreatedByNavigation = new HashSet<MessageType>();
            MessageTypeModifiedByNavigation = new HashSet<MessageType>();
            Messages = new HashSet<Messages>();
            Participations = new HashSet<Participations>();
            Transactions = new HashSet<Transactions>();
        }

        public long UserId { get; set; }
        public long? BranchId { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public short Gender { get; set; }
        public DateTime? LastLoginOn { get; set; }
        public string LoginName { get; set; }
        public DateTime? LoginTryAttemptDate { get; set; }
        public short LoginTryAttempts { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public byte[] Photo { get; set; }
        public short Status { get; set; }
        public short? UserType { get; set; }

        public Branches Branch { get; set; }
        public ICollection<Attachments> Attachments { get; set; }
        public ICollection<Conversations> Conversations { get; set; }
        public ICollection<MessageType> MessageTypeCreatedByNavigation { get; set; }
        public ICollection<MessageType> MessageTypeModifiedByNavigation { get; set; }
        public ICollection<Messages> Messages { get; set; }
        public ICollection<Participations> Participations { get; set; }
        public ICollection<Transactions> Transactions { get; set; }
    }
}