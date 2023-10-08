using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Hinzberg.BallonNotification
{
    abstract public class GeometricShapeBase
    {
        protected GraphicsPath path;
        protected Rectangle baseRectangle;

        public static implicit operator GraphicsPath(GeometricShapeBase geo)
        {
            return geo.DrawObject;
        }
        public GraphicsPath DrawObject { get { return path; } }
    }

    public class TrapezShape : GeometricShapeBase
    {
        System.Windows.Forms.ArrowDirection direction;
        public TrapezShape(Rectangle base_rec, System.Windows.Forms.ArrowDirection dir)
        {
            baseRectangle = base_rec;
            direction = dir;
            GeneratePath();
        }

        private void GeneratePath()
        {
            path = new System.Drawing.Drawing2D.GraphicsPath();
            Point p1 = new Point();
            Point p2 = new Point();
            Point p3 = new Point();
            Point p4 = new Point();
            switch (direction)
            {
                case System.Windows.Forms.ArrowDirection.Left:
                    p1 = new Point(baseRectangle.Left, baseRectangle.Top);
                    p2 = new Point(baseRectangle.Left, baseRectangle.Bottom - 1);
                    p3 = new Point(baseRectangle.Right - 1, baseRectangle.Top + 7);
                    p4 = new Point(baseRectangle.Right - 1, baseRectangle.Bottom - 8);
                    break;
                case System.Windows.Forms.ArrowDirection.Right:
                    p1 = new Point(baseRectangle.Right - 1, baseRectangle.Top);
                    p2 = new Point(baseRectangle.Right - 1, baseRectangle.Bottom - 1);
                    p3 = new Point(baseRectangle.Left, baseRectangle.Top + 7);
                    p4 = new Point(baseRectangle.Left, baseRectangle.Bottom - 8);
                    break;
            }

            path.AddLine(p1, p3);
            path.AddLine(p3, p4);
            path.AddLine(p4, p2);
            path.AddLine(p2, p1);
            path.CloseAllFigures();
        }
    }

    public class XShape : GeometricShapeBase
    {
        int _width = 0;
        public XShape(Rectangle rec, int width)
        {
            baseRectangle = rec;
            _width = width;
            GeneratePath();
        }

        private void GeneratePath()
        {
            path = new GraphicsPath();
            List<Point> points = new List<Point>();
            int w = (int)System.Math.Sqrt(System.Math.Pow(_width, 2) / 2);

            points.Add(new Point(baseRectangle.Left + w, baseRectangle.Top));
            points.Add(new Point(baseRectangle.Left, baseRectangle.Top + w));
            points.Add(new Point(baseRectangle.Left + (baseRectangle.Width / 2) - (_width / 2), baseRectangle.Top + (baseRectangle.Height / 2)));
            points.Add(new Point(baseRectangle.Left, baseRectangle.Bottom - w));
            points.Add(new Point(baseRectangle.Left + w, baseRectangle.Bottom));
            points.Add(new Point(baseRectangle.Left + (baseRectangle.Width / 2), baseRectangle.Top + (baseRectangle.Height / 2) + (_width / 2)));
            points.Add(new Point(baseRectangle.Right - w, baseRectangle.Bottom));
            points.Add(new Point(baseRectangle.Right, baseRectangle.Bottom - w));
            points.Add(new Point(baseRectangle.Left + (baseRectangle.Width / 2) + (_width / 2), baseRectangle.Top + (baseRectangle.Height / 2)));
            points.Add(new Point(baseRectangle.Right, baseRectangle.Top + w));
            points.Add(new Point(baseRectangle.Right - w, baseRectangle.Top));
            points.Add(new Point(baseRectangle.Left + (baseRectangle.Width / 2), baseRectangle.Top + (baseRectangle.Height / 2) - (_width / 2)));


            for (int i = 0; i < points.Count; i++)
            {
                int next_pos = i + 1;
                if (next_pos > points.Count - 1) { next_pos = 0; }
                path.AddLine(points[i], points[next_pos]);
            }
            path.CloseFigure();
        }
    }

    public class RoundRectangleShape : GeometricShapeBase
    {
        private int _cornerWidth = 0;

        public RoundRectangleShape(Rectangle rec, int cornerWidth)
        {
            baseRectangle = rec;
            _cornerWidth = cornerWidth;
            GeneratePath();
        }

        private void GeneratePath()
        {
            int x = baseRectangle.X, y = baseRectangle.Y, w = baseRectangle.Width, h = baseRectangle.Height;
            path = new GraphicsPath();
            path.AddArc(x, y, _cornerWidth, _cornerWidth, 180, 90);				//Upper left corner
            path.AddArc(x + w - _cornerWidth, y, _cornerWidth, _cornerWidth, 270, 90);			//Upper right corner
            path.AddArc(x + w - _cornerWidth, y + h - _cornerWidth, _cornerWidth, _cornerWidth, 0, 90);		//Lower right corner
            path.AddArc(x, y + h - _cornerWidth, _cornerWidth, _cornerWidth, 90, 90);			//Lower left corner
            path.CloseFigure();
        }
    }
}