namespace DrugStore.Repositories.PhotoRepository
{
    public interface IPhotoRepository
    {
        public Task<string> WriteFile(IFormFile file);
    }
}
