using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
   public class Category:IEntity
    {
        //Onemli Not: Egerki bir class herhangi bir inheritance veya interface implementasyonu almıyorsa
        //proje büyüyünce problemler yaşarız #CiplakClassKalmasin
        // Boyle sorunlar çıkmasın diye bu class ı işaretleme eğilimine gireriz, yani gruplarız.
        //Bu yüzden Abstract dosyasına IEntity açtık ve ondan implement olsun.
        //Buna işaretleme diyoruz.

        public int CategoryID { get; set; }
        public string CategoryName { get; set; }


    }
}
