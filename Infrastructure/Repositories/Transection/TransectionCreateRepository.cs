//using Application.Transection.Create;

//namespace Infrastructure.Repositories.Transection;

//public class CreateRepository(SqlContext sqlContext) : ITransectionCreateRepository
//{
//    private readonly SqlContext _dbContext = sqlContext;

//    public async Task<Entities.Transection> CreateTransection(CancellationToken cancellationToken)
//    {
//        var transaction = new Entities.Transection
//        {
//            TransectionId = Guid.NewGuid(),
//            No = new Random().Next(1, 100),
//            CreateDate = DateTime.Now,
//        };

//        await _dbContext.Transection.AddAsync(transaction, cancellationToken);

//        await _dbContext.SaveChangesAsync(cancellationToken);

//        return transaction;
//    }
//}
