using SharpGL.SceneGraph;
using SharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKR_Gorbatyuk
{
    internal class ShapeRenderer
    {
        private List<Vertex> ListVertex;



        private int rectCounts;
        public ShapeRenderer(RectLocation bests)
        {
            
            ListVertex = new List<Vertex>();
            rectCounts=bests.rects.Count;
            for (int i = 0; i<bests.rects.Count; i++)
            {
                // Front Face
                ListVertex.Add(bests.rects[i].VleftUpD1Point);	// Bottom Left Of The Texture and Quad
                ListVertex.Add(bests.rects[i].VrightUpD1Point);	// Bottom Right Of The Texture and Quad
                ListVertex.Add(bests.rects[i].VrightDownD1Point);// Top Right Of The Texture and Quad
                ListVertex.Add(bests.rects[i].VleftDownD1Point);	// Top Left Of The Texture and Quad

                // Back Face
                ListVertex.Add(bests.rects[i].VleftUpD2Point);	// Bottom Right Of The Texture and Quad
                ListVertex.Add(bests.rects[i].VrightUpD2Point);	// Top Right Of The Texture and Quad
                ListVertex.Add(bests.rects[i].VrightDownD2Point);	// Top Left Of The Texture and Quad
                ListVertex.Add(bests.rects[i].VleftDownD2Point);	// Bottom Left Of The Texture and Quad

                // Top Face
                ListVertex.Add(bests.rects[i].VrightUpD1Point);	// Top Left Of The Texture and Quad
                ListVertex.Add(bests.rects[i].VrightUpD2Point);	// Bottom Left Of The Texture and Quad
                ListVertex.Add(bests.rects[i].VrightDownD2Point);// Bottom Right Of The Texture and Quad
                ListVertex.Add(bests.rects[i].VrightDownD1Point);	// Top Right Of The Texture and Quad

                // Bottom Face
                ListVertex.Add(bests.rects[i].VleftUpD1Point);	// Top Right Of The Texture and Quad
                ListVertex.Add(bests.rects[i].VleftUpD2Point);	// Top Left Of The Texture and Quad
                ListVertex.Add(bests.rects[i].VleftDownD2Point);	// Bottom Left Of The Texture and Quad
                ListVertex.Add(bests.rects[i].VleftDownD1Point);	// Bottom Right Of The Texture and Quad

                // Right face
                ListVertex.Add(bests.rects[i].VleftUpD1Point);	// Bottom Right Of The Texture and Quad
                ListVertex.Add(bests.rects[i].VleftUpD2Point);	// Top Right Of The Texture and Quad
                ListVertex.Add(bests.rects[i].VrightUpD2Point);// Top Left Of The Texture and Quad
                ListVertex.Add(bests.rects[i].VrightUpD1Point);	// Bottom Left Of The Texture and Quad

                // Left Face
                ListVertex.Add(bests.rects[i].VleftDownD1Point);	// Bottom Left Of The Texture and Quad
                ListVertex.Add(bests.rects[i].VleftDownD2Point);	// Bottom Right Of The Texture and Quad
                ListVertex.Add(bests.rects[i].VrightDownD2Point);	// Top Right Of The Texture and Quad
                ListVertex.Add(bests.rects[i].VrightDownD1Point);	// Top Left Of The Texture and Quad
            

            }
            
            
        }

        public void render(OpenGL gl)
        {

            gl.Color(1.0f, 1.0f, 1.0f);
            for (int i=0; i < rectCounts; i++)
            {
                gl.Begin(OpenGL.GL_QUADS);
                for (int j = 0; j < 6; j++) // 6 face
                {
                    gl.TexCoord(0.0f, 0.0f); gl.Vertex(ListVertex[i*24+j * 4]);  // Bottom Left Of The Texture and Quad
                    gl.TexCoord(1.0f, 0.0f); gl.Vertex(ListVertex[i*24+ j * 4 + 1]);  // Bottom Right Of The Texture and Quad
                    gl.TexCoord(1.0f, 1.0f); gl.Vertex(ListVertex[i*24+j * 4 + 2]);   // Top Right Of The Texture and Quad
                    gl.TexCoord(0.0f, 1.0f); gl.Vertex(ListVertex[i*24+j * 4 + 3]);  // Top Left Of The Texture and Quad
                }

                gl.End();
                gl.Flush();
            }
                
                       
        }

        public ShapeRenderer(RectagleC rect)
        {
            rectCounts = 1;
            ListVertex = new List<Vertex>();
            
                // Front Face
                ListVertex.Add(rect.VleftUpD1Point);	// Bottom Left Of The Texture and Quad
                ListVertex.Add(rect.VrightUpD1Point);	// Bottom Right Of The Texture and Quad
                ListVertex.Add(rect.VrightDownD1Point);// Top Right Of The Texture and Quad
                ListVertex.Add(rect.VleftDownD1Point);	// Top Left Of The Texture and Quad

                // Back Face
                ListVertex.Add(rect.VleftUpD2Point);	// Bottom Right Of The Texture and Quad
                ListVertex.Add(rect.VrightUpD2Point);	// Top Right Of The Texture and Quad
                ListVertex.Add(rect.VrightDownD2Point);	// Top Left Of The Texture and Quad
                ListVertex.Add(rect.VleftDownD2Point);	// Bottom Left Of The Texture and Quad

                // Top Face
                ListVertex.Add(rect.VrightUpD1Point);	// Top Left Of The Texture and Quad
                ListVertex.Add(rect.VrightUpD2Point);	// Bottom Left Of The Texture and Quad
                ListVertex.Add(rect.VrightDownD2Point);// Bottom Right Of The Texture and Quad
                ListVertex.Add(rect.VrightDownD1Point);	// Top Right Of The Texture and Quad

                // Bottom Face
                ListVertex.Add(rect.VleftUpD1Point);	// Top Right Of The Texture and Quad
                ListVertex.Add(rect.VleftUpD2Point);	// Top Left Of The Texture and Quad
                ListVertex.Add(rect.VleftDownD2Point);	// Bottom Left Of The Texture and Quad
                ListVertex.Add(rect.VleftDownD1Point);	// Bottom Right Of The Texture and Quad

                // Right face
                ListVertex.Add(rect.VleftUpD1Point);	// Bottom Right Of The Texture and Quad
                ListVertex.Add(rect.VleftUpD2Point);	// Top Right Of The Texture and Quad
                ListVertex.Add(rect.VrightUpD2Point);// Top Left Of The Texture and Quad
                ListVertex.Add(rect.VrightUpD1Point);	// Bottom Left Of The Texture and Quad

                // Left Face
                ListVertex.Add(rect.VleftDownD1Point);	// Bottom Left Of The Texture and Quad
                ListVertex.Add(rect.VleftDownD2Point);	// Bottom Right Of The Texture and Quad
                ListVertex.Add(rect.VrightDownD2Point);	// Top Right Of The Texture and Quad
                ListVertex.Add(rect.VrightDownD1Point);   // Top Left Of The Texture and Quad


        }


        

        //public void render(OpenGL gl)
        //{
        //    gl.Color(1.0f, 1.0f, 1.0f);
        //    for (int i = 0; i < rectCounts; i++)
        //    {
        //        gl.Begin(OpenGL.GL_QUADS);
        //        for (int j = 0; j < 6; j++) // 6 face
        //        {
        //            gl.TexCoord(0.0f, 0.0f); gl.Vertex(ListVertex[i * 24 + j * 4]);  // Bottom Left Of The Texture and Quad
        //            gl.TexCoord(1.0f, 0.0f); gl.Vertex(ListVertex[i * 24 + j * 4 + 1]);  // Bottom Right Of The Texture and Quad
        //            gl.TexCoord(1.0f, 1.0f); gl.Vertex(ListVertex[i * 24 + j * 4 + 2]);   // Top Right Of The Texture and Quad
        //            gl.TexCoord(0.0f, 1.0f); gl.Vertex(ListVertex[i * 24 + j * 4 + 3]);  // Top Left Of The Texture and Quad
        //        }

        //        gl.End();
        //        gl.Flush();
        //    }


        //}
    }
}
