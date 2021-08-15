using System.Security.Claims;

namespace GameTheoryProject.Dto
{
    public class WebResponse<T> where T : class
    {
        public bool Success { get; set; }

        public T Data { get; set; }
    }
}