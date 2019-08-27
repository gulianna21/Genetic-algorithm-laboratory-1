using System;

namespace Lab1
{

	class MainClass
	{
		int[] S;
		int[] U;
		string[] txt;
		//приспособленность
		void SetU(){
			for(int i = 0;i<S.Length;i++){
				U [i] = i;
				if (i < 32) {
					Console.WriteLine (txt [i] + " U = " + U [i]);
				}
			}
			Console.WriteLine ("================================================================================");
		}
		//Алгоритм Монте-Карло.
		void MetodMK(int N){
			int i=0,max = 0, maxS =0, m = 0;
			Random rnd = new Random ();
			while (i < N) {
				int j = rnd.Next (0, S.Length);
				if (max < U [j]) {
					max = U [j];
					maxS = S [j];
					m = j;
					Console.WriteLine ("i= "+i+" SWAP "+"maxS = " + txt[m] + " max = " + max.ToString ()+"|curS = " + txt[j] + " curU =" + U[j]);
				}
				else
					Console.WriteLine ("i= "+i+"      maxS = " + txt[m] + " max = " + max.ToString ()+"|curS = " + txt[j] + " curU =" + U[j]);
				i = i + 1;
			}
			Console.WriteLine ("END " + "maxS =" + txt[m] + " max =" + max.ToString ());
		}

		//Инициализация ПП
		public void IniS(int n){
			
			S = new int[(int)Math.Pow(2,n)];
			U = new int[(int)Math.Pow(2,n)];
			txt = new string[(int)Math.Pow(2,n)];
			int x;

			for (int j = 0; j < (int)Math.Pow(2,n); j++) {
				x = j;
				S [j] = j;
				string BI = Convert.ToString (S [j], 2);
				if (BI.Length < n) {
					while (BI.Length != n) {
						BI = String.Concat ('0' + BI);
					}
				}
				txt [j] = BI;
			}

		}
		public static void Main (string[] args)
		{
			MainClass MC = new MainClass();
			int L=15;
			MC.IniS(L);
			MC.SetU ();
			MC.MetodMK (10);
		}
	}
}
