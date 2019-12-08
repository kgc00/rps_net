using Assets.Scripts.Model;

namespace Assets.Scripts.System
{
    public interface ISystem {
        Game owner { get; set; }
    }
}