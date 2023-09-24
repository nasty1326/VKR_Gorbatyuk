using SharpGL.SceneGraph;
using SharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKR_Gorbatyuk
{
    internal class PlaneSurfaceRenderer
    {
        private float xsize; // from -size to size square by square
        private float ysize; // from -size to size square by square
        private float zsize; // from -size to size square by square

        public PlaneSurfaceRenderer(float xSize, float ySize, float zSize)
        {
            xsize = xSize;
            ysize = ySize;
            zsize = zSize;
        }

        public void render(OpenGL gl)
        {
            gl.Color(0.8f, 0.8f, 0.8f, 0.0f);
            gl.LineWidth(2.0f);
            gl.Begin(OpenGL.GL_LINES);
            for (float i = 0; i < xsize; i = i + 0.5f)
            {
                if (i <= xsize)
                {
                    gl.Vertex(i, 0.0f, 0);
                    gl.Vertex(i, 0.0f, zsize);
                }

            }
            for (float i = 0; i < ysize; i = i + 0.5f)
            {
                if (i <= ysize)
                {
                    gl.Vertex(0, 0.0f, i);
                    gl.Vertex(xsize, 0.0f, i);
                }

            }
            gl.Vertex(0, ysize, 0);
            gl.Vertex(xsize, ysize, 0);

            gl.Vertex(0, ysize, zsize);
            gl.Vertex(0, ysize, 0);

            gl.Vertex(0, ysize, zsize);
            gl.Vertex(0, 0, zsize);

            gl.Vertex(xsize, ysize, 0);
            gl.Vertex(xsize, 0, 0);

            gl.Vertex(xsize, ysize, 0);
            gl.Vertex(xsize, ysize, zsize);

            gl.Vertex(0, ysize, zsize);
            gl.Vertex(xsize, ysize, zsize);

            gl.Vertex(xsize, 0, zsize);
            gl.Vertex(xsize, ysize, zsize);

            gl.Vertex(xsize, 0, zsize);
            gl.Vertex(xsize, 0, 0);

            gl.Vertex(xsize, 0, zsize);
            gl.Vertex(0, 0, zsize);

            gl.End();
            gl.Flush();

            Axes ax = new Axes(new Vertex(0, 0, 0), new Vertex(xsize, 0, 0), new Vertex(0, ysize, 0), new Vertex(0, 0, zsize));
            ax.render(gl);
        }
    }
}
