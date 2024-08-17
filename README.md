# RedisIntegration


docker pull redis

docker run -d --name my-redis-container -p 6379:6379 redis

Bağlantı Bilgileri
Redis'e bağlantı kurmak için aşağıdaki bilgileri kullanabilirsiniz:

Host: localhost

Port: 6379

Username: (Gerek yok, Redis varsayılan olarak kullanıcı adı istemez)

Password: (Varsayılan olarak yok, ancak gerekirse docker run komutunda -e REDIS_PASSWORD=yourpassword parametresini ekleyebilirsiniz)
