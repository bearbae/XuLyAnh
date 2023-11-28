using System;
using System.Collections.Generic;
using System.Security.Cryptography.Xml;
using System.Windows.Forms; 
namespace XLA1
{
	class xuly
	{
		private Bitmap newbm;
		private int width = 0, height = 0;
		public xuly(Bitmap image, int w, int h)
		{
			newbm = image;
			width = w;
			height = h;	
		}

		public Bitmap currentbitmap
		{
			get
			{
				if (newbm == null)
					newbm = new Bitmap(1, 1); 
				return newbm;
			}
			set
			{
				newbm = value;
			}
		}
		// xử lý âm bản 
		public void XLA1()
		{
			try
			{
				Color c; 
				for(int i =0; i < width; i++)
				
					for(int j =0; j < height; j++)
					{
						c = newbm.GetPixel(i, j);
						newbm.SetPixel(i,j,Color.FromArgb(255-c.R,255-c.G,255-c.B));
					}
				
			}
			catch {
				MessageBox.Show("loi"); 
			}
		}

		// bộ lọc min filer
		public void Min_Filter()
		{
			// kich thuoc ma tran
			int n = 5;
			// khoang cach tu bien vao tam ma tran 
			int s = n / 2;
			try
			{
				Color c , c1; 
				// khai bao bien chua phan tu mau
				int r, g, b;
				// khai bao bien chua 2 diem anh
				Color[,] result = new Color[width,height];
				// duyrt anh 
				for(int x = 0; x < width-n; x++)
				{
					for(int  y = 0; y < height-n; y++)
					{
						// lay diem anh ow vi tri i , j
						c = newbm.GetPixel(x, y);
						r = c.R; g = c.G; b = c.B; 
						// duyett ma tran 5x5
						for(int i = 0;i < n; i++)
						{
							for(int j = 0; j < n; j++)
							{
								// tim diem co gia tri min
								c1 = newbm.GetPixel(x +i, y+j);

								if(r > c1.R) r = c1.R;
								if(g > c1.G) g = c1.G;
								if(b > c1.B) b = c1.B;
							}
						}
						// lay min gan nhat
						result[x,y] = Color.FromArgb(r, g, b);
					}
				}
				for(int x = s; x < width; x++)
				{
					for(int y = s; y < height;  y++)
					{
						newbm.SetPixel(x, y, result[x,y]);
					}
				}
			}
			catch
			{
				MessageBox.Show("loi");
			}

		}
		// bộ lọc max filter

		public void Max_Filter()
		{
			// kich thuoc ma tran
			int n = 5;
			// khoang cach tu bien vao tam ma tran 
			int s = n / 2;
			try
			{
				Color c, c1;
				// khai bao bien chua phan tu mau
				int r, g, b;
				// khai bao bien chua 2 diem anh
				Color[,] result = new Color[width, height];
				// duyrt anh 
				for (int x = 0; x < width - n; x++)
				{
					for (int y = 0; y < height - n; y++)
					{
						// lay diem anh ow vi tri i , j
						c = newbm.GetPixel(x, y);
						r = c.R; g = c.G; b = c.B;
						// duyett ma tran 5x5
						for (int i = 0; i < n; i++)
						{
							for (int j = 0; j < n; j++)
							{
								// tim diem co gia tri max
								c1 = newbm.GetPixel(x + i, y + j);

								if (r < c1.R) r = c1.R;
								if (g < c1.G) g = c1.G;
								if (b < c1.B) b = c1.B;
							}
						}
						// lay max gan nhat
						result[x, y] = Color.FromArgb(r, g, b);
					}
				}
				for (int x = s; x < width; x++)
				{
					for (int y = s; y < height; y++)
					{
						newbm.SetPixel(x, y, result[x, y]);
					}
				}
			}
			catch
			{
				MessageBox.Show("loi");
			}

		}
		// bộ lọc trung vị 

		public static void Sort(int[] a, int n)
		{
			int tmp;
			for (int i = 0; i < n - 1; i++)
				for (int j = i + 1; j < n; j++)
					if (a[i] > a[j])
					{
						tmp = a[i];
						a[i] = a[j];
						a[j] = tmp;
					}
			
		}

		public static Bitmap LocTrungVi(Bitmap bm)
		{
			int w = bm.Width, h = bm.Height, i, j; 
			Bitmap bmResult = new Bitmap(w,h);
			int[] A = new int[9];
			int[] B = new int[9];
			int[] C = new int[9];

			for( i = 1; i < h-1; i++)
				for( j = 1;  j < w-1;j++)
				{
					// xu lys Red pixel
					A[0] = bm.GetPixel(j-1,i-1).R;
					A[1] = bm.GetPixel(j, i - 1).R;
					A[2] = bm.GetPixel(j + 1, i - 1).R;
					A[3] = bm.GetPixel(j - 1, i ).R;
					A[4] = bm.GetPixel(j , i).R;
					A[5] = bm.GetPixel(j +1, i).R;
					A[6] = bm.GetPixel(j -1 , i + 1).R;
					A[7] = bm.GetPixel(j , i + 1).R;
					A[8] = bm.GetPixel(j + 1, i + 1).R;
					// xu ly Green pixel
					B[0] = bm.GetPixel(j - 1, i - 1).G;
					B[1] = bm.GetPixel(j, i - 1).G;
					B[2] = bm.GetPixel(j + 1, i - 1).G;
					B[3] = bm.GetPixel(j - 1, i).G;
					B[4] = bm.GetPixel(j, i).G;
					B[5] = bm.GetPixel(j + 1, i).G;
					B[6] = bm.GetPixel(j - 1, i + 1).G;
					B[7] = bm.GetPixel(j, i + 1).G;
					B[8] = bm.GetPixel(j + 1, i + 1).G;
					// xu ly Blue pixel
					C[0] = bm.GetPixel(j - 1, i - 1).B;
					C[1] = bm.GetPixel(j, i - 1).B;
					C[2] = bm.GetPixel(j + 1, i - 1).B;
					C[3] = bm.GetPixel(j - 1, i).B;
					C[4] = bm.GetPixel(j, i).B;
					C[5] = bm.GetPixel(j + 1, i).B;
					C[6] = bm.GetPixel(j - 1, i + 1).B;
					C[7] = bm.GetPixel(j, i + 1).B;
					C[8] = bm.GetPixel(j + 1, i + 1).B;

					Sort(A, 9); 
					Sort(B, 9);
					Sort(C, 9);
					bmResult.SetPixel(j, i, Color.FromArgb(A[4], B[4], C[4])); 
				}
			return bmResult;
		}

		
	}
}