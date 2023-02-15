using DrugStore.Inftrastructure;
using System.IO;

namespace DrugStore.Repositories.PhotoRepository
{
    public class PhotoRepository : IPhotoRepository
    {
        public async Task<string> WriteFile(IFormFile file)
        {
            string path;
            string fileName = "";
            try
            {
                fileName = file.FileName;

                path = Path.Combine("D:\\БД\\UI\\angular15\\src\\assets\\img", fileName).ToString();

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            catch (Exception ex)
            {
            }

            return fileName;
        }
    }
}
