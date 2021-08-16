using System.Security.Claims;

namespace GameTheoryProject.Dto
{
    public class WebResponse<T>
    {
        public bool Success { get; set; }

        public T Data { get; set; }
    }
}