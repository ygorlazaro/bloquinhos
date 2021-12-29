using System.Drawing;

namespace BloquinhosWin
{
    public class ResourceColor
    {
        public Bitmap Resource { get; set; }

        public string Name { get; set; }

        public ResourceColor(Bitmap resource, string name)
        {
            Resource = resource;
            Name = name;
        }
    }
}