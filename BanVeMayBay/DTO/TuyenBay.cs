﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TuyenBay
    {
        private string matuyenbay, masanbaydi, masanbayden, masanbaytg;
        public TuyenBay() { }
        public TuyenBay(string matuyenbay, string masanbaydi, string masanbayden, string masanbaytg)
        {
            this.Matuyenbay = matuyenbay;
            this.Masanbaydi = masanbaydi;
            this.Masanbayden = masanbayden;
            this.Masanbaytg = masanbaytg;
        }

        public string Matuyenbay { get => matuyenbay; set => matuyenbay = value; }
        public string Masanbaydi { get => masanbaydi; set => masanbaydi = value; }
        public string Masanbayden { get => masanbayden; set => masanbayden = value; }
        public string Masanbaytg { get => masanbaytg; set => masanbaytg = value; }
    }
}
