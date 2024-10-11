using Application.Transection.Update;

namespace Infrastructure.Repository.Transection;

public class TransectionUpdateRepository(SqlContext sqlContext) : ITransectionUpdateRepository
{
    private readonly SqlContext _dbContext = sqlContext;

    public async Task UpdateTransection(CancellationToken cancellationToken)
    {
        try
        {
            var transectionId = Guid.Parse("ece9d1fd-1333-4c9a-a766-ed9007b8f407");

            var transation = await _dbContext
                .Transection.AsNoTracking()
                .FirstOrDefaultAsync(r => r.TransectionId == transectionId, cancellationToken);

            if (transation == null)
            {
                return;
            }

            transation.TransectionId = Guid.NewGuid(); // mock error: https://go.microsoft.com/fwlink/?LinkId=527962
            //transation.Description = $"Updated time: {DateTime.Now}";
            //transation.No = new Random().Next(1, 100);
            //transation.CreateDate = DateTime.Now;

            _dbContext.Update(transation);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
