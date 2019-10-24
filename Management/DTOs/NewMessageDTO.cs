using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Management.DTOs
{
    public class NewMessageDTO
    {
        public string Subject { get; set; }
        public bool Replay { get; set; }
        public long MessageType { get; set; }
        public string Priority { get; set; }
        public long[] Selectedusers { get; set; }
        public long[] PermissionModale { get; set; }
        public int SentGroup { get; set; }
        public string Content { get; set; }
        public int SentType { get; set; }
        public AttachmentUpload[] Files { get; set; }
    }
    public enum SelectedOption
    {
        All,
        Email,
        SMS,
        NONE
    }
    public class AttachmentUpload
    {
        public string FileName { get; set; }
        public string FileBase64 { get; set; }
        public string Type { get; set; }
    }
}
