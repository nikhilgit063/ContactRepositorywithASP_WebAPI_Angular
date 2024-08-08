
namespace MajorProjctAPI.Model
{
    public class ReturnType<T>
    {
        public T ReturnVal { get; set; }
        public ReturnStatus ReturnStatus { get; set; }
        public List<User> ReturnList { get; internal set; }
    }
}
