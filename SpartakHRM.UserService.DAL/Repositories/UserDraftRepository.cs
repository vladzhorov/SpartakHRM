using Newtonsoft.Json;
using SpartakHRM.UserService.DAL.Entities;
using SpartakHRM.UserService.DAL.Interface;
using StackExchange.Redis;
using System.Text.Json;

namespace SpartakHRM.UserService.DAL.Repositories
{
    public class UserDraftRepository : IUserDraftRepository
    {
        private readonly IDatabase _redisDatabase;

        public UserDraftRepository()
        {
        }

        public async Task<UserDraftEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var json = await _redisDatabase.StringGetAsync($"UserDraft:{id}");
            if (json.HasValue)
            {
                return JsonConvert.DeserializeObject<UserDraftEntity>(json);
            }

            return null;
        }

        public async Task<IEnumerable<UserDraftEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            // Получение всех ключей, соответствующих шаблону.
            var keysPattern = new RedisValue("UserDraft:*");
            var server = _redisDatabase.Multiplexer.GetServer(_redisDatabase.Multiplexer.GetEndPoints().First());
            var keys = server.Keys(pattern: keysPattern);

            List<UserDraftEntity> userDrafts = new List<UserDraftEntity>();

            // Обработка каждого отдельного ключа.
            foreach (var key in keys)
            {
                var json = await _redisDatabase.StringGetAsync(key);

                if (!json.IsNull)
                {
                    var userDraft = JsonConvert.DeserializeObject<UserDraftEntity>(json);
                    userDrafts.Add(userDraft);
                }
            }

            return userDrafts;
        }



        public async Task AddAsync(UserDraftEntity entity, CancellationToken cancellationToken)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(entity, new JsonSerializerOptions
            {
                // Указать параметры сериализации здесь, если необходимо
            });
            await _redisDatabase.StringSetAsync($"UserDraft:{entity.Id}", json);
        }

        public async Task UpdateAsync(UserDraftEntity entity, CancellationToken cancellationToken)
        {
            var entityId = Guid.Parse(entity.Id);
            var existingEntity = await GetByIdAsync(entityId, cancellationToken);
            if (existingEntity != null)
            {
                existingEntity.Type = entity.Type;
                existingEntity.PersonalInfo = entity.PersonalInfo;
                existingEntity.BusinessInfo = entity.BusinessInfo;

                var json = JsonConvert.SerializeObject(existingEntity);
                await _redisDatabase.StringSetAsync($"UserDraft:{entity.Id}", json);
            }
        }

        public async Task DeleteAsync(UserDraftEntity entity, CancellationToken cancellationToken)
        {
            await _redisDatabase.KeyDeleteAsync($"UserDraft:{entity.Id}");
        }

        Task<UserDraftEntity> IRepository<UserDraftEntity>.AddAsync(UserDraftEntity entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<UserDraftEntity> IRepository<UserDraftEntity>.UpdateAsync(UserDraftEntity entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
