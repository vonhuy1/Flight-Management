using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HangVe
    {
        private string mahangve, tenhangve, machuyenbay;
        private int khoiluongtoida, dongia;
        public HangVe() { }
        public HangVe(string mahangve, string tenhangve, string machuyenbay, int khoiluongtoida, int dongia)
        {
            this.Mahangve = mahangve;
            this.Tenhangve = tenhangve;
            this.Machuyenbay = machuyenbay;
            this.Khoiluongtoida = khoiluongtoida;
            this.Dongia = dongia;
        }

        public string Mahangve { get => mahangve; set => mahangve = value; }
        public string Tenhangve { get => tenhangve; set => tenhangve = value; }
        public string Machuyenbay { get => machuyenbay; set => machuyenbay = value; }
        public int Khoiluongtoida { get => khoiluongtoida; set => khoiluongtoida = value; }
        public int Dongia { get => dongia; set => dongia = value; }
    }
}
