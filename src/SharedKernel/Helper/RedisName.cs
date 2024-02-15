namespace Net6StudyCase.SharedKernel.Helper
{
    public static class RedisName
    {
        public static string GetObjectKey<T>(string key)
        {
            return $"{typeof(T).Name}:{key}";
        }
    }
}
