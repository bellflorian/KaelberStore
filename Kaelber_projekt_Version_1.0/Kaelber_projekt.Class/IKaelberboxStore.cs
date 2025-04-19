namespace Kaelber_projekt.Class
{
    public interface IKaelberboxStore
    {
        public List<Kaelberbox> GetAllKaelberBoxes();
        public Kaelberbox GetKaelberBoxById(string id);
        public void SetBox(Kaelberbox box);
        public void SaveToBoxFile();
        public bool GenerateBoxTxtFile(List<string> names);
    }
}
