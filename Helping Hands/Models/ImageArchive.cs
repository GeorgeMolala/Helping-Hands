using System.ComponentModel.DataAnnotations;

namespace Helping_Hands
{
    public partial class ImageArchive
    {

        [Key]
        public int ImageArchiveID { get; set; }
        public byte[] ImageData { get; set; }
        public string Status { get; set; }
        public int? NpoID { get; set; }

        public Organisations Npo { get; set; }
    }
}
