using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSS.App_Code
{
    public class Attachments
    {
        public string AttachmentID;
        public string BusnessID;
        public string FileName;
        public string FileExtension;
        public string PhysicalFileName;
        public string FilePath;
        public long EnteredBy;
        public long UpdatedBy;
        public byte[] FileBytes;
        public string BusinessTypeID;
        public string DocumentType;
        public List<Attachments> AttachmentList;
        public Int16 IsPublish { get; set; }

    }
}