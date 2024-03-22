//path: src\Schema\Engine\Transform.cs

namespace SouthSeas.Schema.Engine
{
    public class Transform
    {
        public Vector3 Position { get; set; } = new Vector3();
        public Vector3 Rotation { get; set; } = new Vector3();
        public Vector3 Scale { get; set; } = new Vector3();
    }
}