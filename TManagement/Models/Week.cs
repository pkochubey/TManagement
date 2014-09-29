using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace TManagement.Models
{
    internal class Week
    {
        public int Number { get; set; }

        public string Hours { get; set; }

        public string Day { get; set; }

        public long Tick { get; set; }

        public int Buy { get; set; }
        public Image ImageBuy { get; set; }
    }
}