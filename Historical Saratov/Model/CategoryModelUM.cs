using System.Reflection.Metadata;

namespace Historical_Saratov.Model
{
    public class CategoryModelUM
    {
        public int CatId { get; set; }
        public string CatName { get; set; }
        public string CatTitle { get; set; }
        public Blob ImgCat { get; set; }

        public string TitleCat
        {
            get
            {
                return $"{CatTitle}";
            }
        }
    }
}