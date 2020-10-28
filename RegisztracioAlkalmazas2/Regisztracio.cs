using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisztracioAlkalmazas2
{
    class Regisztracio
    {
        string nev;
        string kor;
        int korr;
        string nem;
        string hobby;

        public Regisztracio(string nev, string kor, int korr, string nem, string hobby)
        {
            this.Nev = nev;
            this.Kor = kor;
            this.Korr = korr;
            this.Nem = nem;
            this.Hobby = hobby;
        }

        public string Nev { get => nev; set => nev = value; }
        public string Kor { get => kor; set => kor = value; }
        public int Korr { get => DateTime.Now.Year - korr; set => korr = value; }
        public string Nem { get => nem; set => nem = value; }
        public string Hobby { get => hobby; set => hobby = value; }

        public override string ToString()
        {
            return string.Format("{0} ", hobby);
        }

        public string Sorba()
        {
            return string.Format($"{nev};{kor};{nem};{hobby}");
        }

        public Regisztracio(string sor)
        {
            string[] s = sor.Split(';');
            nev = s[0];
            kor = s[1];
            korr = int.Parse(s[2]);
            nem = s[3];
            hobby = s[4];
        }
    }
}
